using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARH.Models
{
    [Index(nameof(NameTitleDesc), IsUnique = true)]
    public class NameTitle
    {
        [Key]
        public int NameTitleID { get; set; }
        [Column(TypeName = "Varchar(50)")]
        [Required(ErrorMessage = "Name Title is required")]
        public string NameTitleDesc { get; set; }
        public bool IsActive { get; set; }
    }
    [Index(nameof(RoleTypeDesc), IsUnique = true)]
    public class RoleType
    {
        [Key]
        public int RoleID { get; set; }

        [Column(TypeName = "Varchar(50)")]
        [Required(ErrorMessage = "Role Type is required")]
        public string RoleTypeDesc { get; set; }
        public bool IsActive { get; set; }
    }

    public class Address
    {
        [Key]
        public int AddressID { get; set; }
        public int AddressTypeID { get; set; }
        public string AddressDesc { get; set; }
        public string PostCode { get; set; }
    }

    public class AddressLines
    {
        [Key]
        public int AddressLineID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }

    }


    [Index(nameof(AddressTypeDesc), IsUnique = true)]
    public class AddressType
    {
        [Key]
        public int AddressTypeID { get; set; }
        [Column(TypeName = "Varchar(50)")]
        [Required(ErrorMessage = "Address Type is required")]
        public string AddressTypeDesc { get; set; }
        public bool IsActive { get; set; }
    }
    public class AreaOffice
    {
        [Key]
        public int AreaOfficeID { get; set; }
        [Column(TypeName = "Varchar(50)")]
        [Required(ErrorMessage = "Area Office is required")]
        public string AreaOfficeDesc { get; set; }
        public bool IsActive { get; set; }
    }

    public class CountryCodes
    {
        [Key]
        public int CountryCodeID { get; set; }
        [Column(TypeName = "Varchar(50)")]
        public string CountryCodeD { get; set; }
        [Column(TypeName = "Varchar(50)")]
        public string Country { get; set; }
        public bool IsActive { get; set; }
    }

    public class CompanyType
    {
		[Key]
		public int CompanyTypeID { get; set; }
	
		[Column(TypeName = "Varchar(100)")]
		public string CompanyTypeDesc { get; set; }
		public bool IsActive { get; set; }

	}
}
