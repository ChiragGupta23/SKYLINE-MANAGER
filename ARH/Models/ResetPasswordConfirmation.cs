using System.ComponentModel.DataAnnotations;
namespace ARH.Models
{
    public class ResetPasswordConfirmation
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
    }
}