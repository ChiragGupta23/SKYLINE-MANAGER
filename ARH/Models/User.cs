using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ARH.Models
{
	public class User
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Name is required")]

		public string Name { get; set; } = null!;

		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid Email Address")]

		public string Email { get; set; } = null!;

		[Required(ErrorMessage = "Mobile number is required")]
		[RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid Mobile Number")]

		public string MobileNumber { get; set; } = null!;

		[Required(ErrorMessage = "Password is required")]
		[StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 20 characters")]
		public string Password { get; set; } = null!;
        
        //public string SessionToken { get; internal set; }
    }
}
