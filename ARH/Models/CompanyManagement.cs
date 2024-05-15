using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARH.Models
{
	[Index(nameof(CompanyName), IsUnique = true)]
	[Index(nameof(Email), IsUnique = true)]
	public class CompanyManagement
	{
		[Key]
		public int CompanyId { get;set; }
		[Column(TypeName = "nvarchar(100)")]
		[Required(ErrorMessage = "Company name is required")]
		public string CompanyName { get;set;}
		public string CompanyType { get;set;}
		
		[Column(TypeName = "nvarchar(11)")]
		[Required(ErrorMessage = "Mobile Number is required")]
		[RegularExpression(@"^\d{11}$", ErrorMessage = "Invalid Mobile number")]
		public string Mobile { get;set;}

		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid email address")]
		public string Email { get;set;}
		[Column(TypeName = "nvarchar(50)")]
		public string WebsiteURL { get;set;}
		[Column(TypeName = "nvarchar(10)")]
		public string BRN { get;set;}
		[Column(TypeName = "nvarchar(15)")]
		public string CPH { get;set;}
		public string GridReferenceNo { get;set;}
		public string OrganicCertificationCode { get;set;}
		public int AddressID { get; set; }
		
		public string TelNo { get; set; }
		public string FaxNo { get; set; }
		public bool IsActive { get; set; }

		public string ApplicationStatus { get; set; }

	}
}
