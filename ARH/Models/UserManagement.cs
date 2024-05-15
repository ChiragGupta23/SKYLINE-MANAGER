using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARH.Models
{
    [Index(nameof(UserName), IsUnique = true)]
    public class UserManagement
    {
        [Key]
        public int UserID { get; set; }
        public int NameTitleID { get; set; }
        [Column(TypeName = "Varchar(50)")]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Column(TypeName = "Varchar(50)")]
        public string LastName { get; set; }
        [Column(TypeName = "Varchar(50)")]
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }

        public List<int> RoleTypeID { get;set; }
       
        [Column(TypeName = "Varchar(11)")]
        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        public int AreaOfficeID { get; set; }
        public int AddressID { get; set; }
        
        public string TelNo{ get; set; }
        public string FaxNo { get;set; }
        public bool IsActive { get; set; }

       
    }


}
