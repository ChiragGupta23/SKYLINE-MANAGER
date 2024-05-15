namespace ARH.Models
{
    public class AddUser
    {
        public UserManagement userManagement { get; set; }
        public Address address { get; set; }

        public AddressLines addressLines { get; set; }


    }
    public class AddCompanyReg
    {
        public CompanyManagement companyManagement{ get; set;}
		public Address address { get; set; }

        public AddressLines addressLines { get; set; }
    }

    public class UserEditCombined
    {
        public UserManagement userManagement_EU { get; set; }
        public AddressLines AddressLines_EU { get; set; }
        public Address address_EU { get; set; }
    }
}
