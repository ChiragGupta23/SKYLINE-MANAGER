using ARH.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using reg_login.Models;
using Skyline_Manager.EmailServices;
using Skyline_Manager.Util;
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
        public async Task<IActionResult> Login(Models.LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Verify reCAPTCHA
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

            var tokenString = GenerateJSONWebToken(user, loginRequest.RememberMe);

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = loginRequest.RememberMe ? DateTime.Now.AddDays(30) : (DateTime?)null
            };

            Response.Cookies.Append("JwtToken", tokenString, cookieOptions);

            return RedirectToAction("Home", "Home");
        }

        [HttpPost("Logout")]
        [Authorize]
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

        private string GenerateJSONWebToken(User user, bool rememberMe)
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
                expires: rememberMe ? DateTime.Now.AddDays(30) : DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["ExpiryMinutes"])),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost("ForgotPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(Models.ForgotPassword forgotPasswordModel)
        {
            bool flag = false;
            //if (!ModelState.IsValid)
            //    return View(forgotPasswordModel);
            if (forgotPasswordModel.Email == null)
            {
                TempData["ErrorMsg"] = "Please enter your registered email address";
                return View(forgotPasswordModel);
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == forgotPasswordModel.Email);
            AppSettings appSettings = new AppSettings();

            if (user != null)
            {
                string tokenValue = Utilities.RandomString(10, true);
                user.VerificationCode = tokenValue;
                _context.Users.Update(user);
                _context.SaveChanges();
                var lnkHref = "<a href='" + Url.Action("ResetPassword", "Account", new { email = forgotPasswordModel.Email, token = tokenValue }, "https") + "'>click here to reset your password</a>";
                string body = appSettings.Body + "<br />" + lnkHref +
                    "<br /><br /><br />" + appSettings.Signature;
                flag = EmailManager.SendEmail(forgotPasswordModel.Email, "Password Reset Link", body);
                if (flag)
                {
                    return RedirectToAction(nameof(ForgotPasswordConfirmation));
                }
                else
                {
                    TempData["ErrorMsg"] = "Something went wrong, while sending an email ID.";
                    return View(forgotPasswordModel);
                }
            }
            else
            {
                TempData["ErrorMsg"] = "Something went wrong, while verifying your account";
                return View(forgotPasswordModel);
            }

            return RedirectToAction(nameof(ForgotPasswordConfirmation));
        }

        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

       // Reset password
       //[HttpGet]
       // public IActionResult ResetPassword(string email, string token)
       // {
       //     var model = new ResetPassword { Token = email, Email = token };
       //     return View(model);
       // }
    }
}
// Branch created by archana//
