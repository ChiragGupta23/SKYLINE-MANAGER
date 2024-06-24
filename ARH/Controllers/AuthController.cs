using ARH.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using reg_login.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ARH.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserauthdbContext _context;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public AuthController(UserauthdbContext context, IConfiguration configuration, HttpClient httpClient)
        {
            _context = context;
            _configuration = configuration;
            _httpClient = httpClient;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
              return RedirectToAction("Home", "Home");
            return View();
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Home", "Home");
            return View();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            //Verify reCAPTCHA
            var reCaptchaResponse = Request.Form["g-recaptcha-response"];
            var isCaptchaValid = await VerifyReCaptcha(reCaptchaResponse);
            if (!isCaptchaValid)
            {
                return Redirect("Auth/Login?errorMessage=Invalid reCAPTCHA. Please try again.");
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginRequest.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password))
            {
                return Redirect("Auth/Login?errorMessage=Invalid Email or Password");
            }

            var tokenString = GenerateJSONWebToken(user);
            Response.Cookies.Append("JwtToken", tokenString, new CookieOptions { HttpOnly = true });

            return RedirectToAction("Home", "Home");
        }

        [HttpPost("Logout")]
        [Authorize] //AllowAnnounymously
        public IActionResult Logout()
        {
            Response.Cookies.Delete("JwtToken");
            return Redirect("Auth/Login");
        }

        private async Task<bool> VerifyReCaptcha(string reCaptchaResponse)
        {
            var reCaptchaSecretKey = _configuration["GoogleReCaptcha:SecretKey"];

            if (reCaptchaSecretKey != null && reCaptchaResponse != null)
            {
                var content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "secret", reCaptchaSecretKey },
                    { "response", reCaptchaResponse }
                });

                var response = await _httpClient.PostAsync("https://www.google.com/recaptcha/api/siteverify", content);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ReCaptchaResponse>();
                    return result.Success;
                }
            }
            return false;
        }


        private string GenerateJSONWebToken(User user)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("MobileNumber", user.MobileNumber),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["ExpiryMinutes"])),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
// Branch created by archana//
