using System.ComponentModel.DataAnnotations;

namespace ARH.Models
{
	public class LoginRequest
	{
		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		public string Email { get; set; }


		[Required(ErrorMessage = "Password is required")]
		[StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 20 characters")]
		public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
