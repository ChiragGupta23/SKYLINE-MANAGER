using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using reg_login.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient(); // Add this line

var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

// Configure JWT and cookie authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };

    // Enable token retrieval from cookies and handle challenge
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            context.Token = context.Request.Cookies["JwtToken"];
            return Task.CompletedTask;
        },
        OnChallenge = context =>
        {
            // This is called when the user is not authenticated
            context.HandleResponse(); // Prevents the default behavior
            context.Response.StatusCode = 401;
            context.Response.Redirect("/Auth/Login"); // Redirect to login page
            return Task.CompletedTask;
        }
    };
});

// Add database context
builder.Services.AddDbContext<UserauthdbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbcs")));

// Configure role-based authorization policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("User", policy => policy.RequireRole("User"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.Use(async (context, next) =>
{
    context.Response.OnStarting(() =>
    {
        if (context.Response.Headers.ContainsKey("Cache-Control"))
        {
            context.Response.Headers["Cache-Control"] = "no-cache,no-store";
        }
        else
        {
            context.Response.Headers.Add("Cache-Control", "no-cache,no-store");
        }
        if (context.Response.Headers.ContainsKey("Pragma"))
        {
            context.Response.Headers["Pragma"] = "no-cache";
        }
        else
        {
            context.Response.Headers.Add("Pragma", "no-cache");
        }
        return Task.FromResult(0);
    });
    await next.Invoke();
});

app.Use(async (context, next) =>
{
    if (context.Response.StatusCode == 401)
    {
        context.Response.Redirect("/Auth/Login");
        return;
    }
    await next();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
