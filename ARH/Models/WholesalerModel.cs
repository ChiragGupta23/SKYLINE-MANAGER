using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARH.Models
{
	public class OwnerAddressLines
	{
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
    }
	public class CorrespondenceAddressLines
	{
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string AddressLine3 { get; set; }
		public string AddressLine4 { get; set; }
	}
	public class CombinedWholesale
	{
		public WholesalerModelPage1 WholesalerModelPage1 { get; set; }

		public WholesalerModelPage2 WholesalerModelPage2 { get; set; }
        public AddressLines addressLines { get; set; }

		public OwnerAddressLines ownerAddressLines { get; set; }

		public CorrespondenceAddressLines correspondenceAddressLines { get; set; }

    }
	public class WholesalerModelPage1
	{

		[Key]
		public int ID { get; set; }

		[Required]
		public string PremisesName { get; set; }
		public string PremisesSiteId1 { get; set; }
		public string PremisesSiteId2 { get; set; }
		public DateOnly DateFirstCaptured { get; set; }
		public DateOnly DateFirstApproved { get; set; }
		public DateOnly DateReceived { get; set; }
		public int AreaOfficeID { get; set; }

		public bool SameAddress { get; set; }

		[Required]
		public string PostCode { get; set; }

		public string TelNo { get; set; }
		public string FaxNo { get; set; }
		public string Mobile { get; set; }

		public string Email { get; set; }

		public string CorrespondenceName { get; set; }
		public int CorrespondenceSameAddress { get; set; }
		public string CorrespondencePostCode { get; set; }
        public string CorrespondenceTelNo { get; set; }
        public string CorrespondenceFaxNo { get; set; }
        public string CorrespondenceMobile { get; set; }

        public string CorrespondenceEmail { get; set; }

		public string ContactName { get; set; }

		public string ContactTelNo { get; set; }


	}

	public class WholesalerModelPage2
	{
		public string OwnerName { get; set; }
		public string Email { get; set; }
		public int OwnerAddressSame { get; set; }

		public string PostCode { get; set; }
		public string TelNo { get; set; }
		public string FaxNo { get; set; }
		public string Mobile { get; set; }
		public int LocalAuthorityID { get; set; }
		public int TypeOfBusinessID { get; set; }
		public int CategoryID { get; set; }
		public int SalesTypeID { get; set; }
		public int EggStorageTypeID { get; set; }
		public int Temperature { get; set; }
		public string StorageDescription { get; set; }
		public int AverageThroughput { get; set; }



	}

	
}
