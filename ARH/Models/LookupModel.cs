using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ARH.Models
{   

    //Model for Active Packaging Center
    public class ActivePackagingModel
    {
        public int active_centerID { get; set; }
        [Required(ErrorMessage = "Please Provide SiteID")]
        [MinLength(5, ErrorMessage = "Site Id must be at least 5 characters long.")]
        public string SiteId { get; set; }
        [Required(ErrorMessage = "Please Provide Active Packing Centre name")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Active Packaging Center should only contain letters, numbers, and spaces.")]
        public string activecenter { get; set; }
    }

    //Model for Area Offices

    public class AreaOfficeModel
    {
        public int area_officeID { get; set; }
        [Required(ErrorMessage = "Please Provide Area Office Name")]
        [RegularExpression("^[a-zA-Z0-9 -]*$", ErrorMessage = "Area Office should only contain letters, numbers, and spaces.")]
        public string area_office { get; set; }
    }

    //Model for AreaOffice-Inspection Officer
    public class AO_InspectionOfficerModel
    {
        public int aO_officeID { get; set; }
        [Required(ErrorMessage = "Please Provide Area Office Name")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Area Office should only contain letters, numbers, and spaces.")]
        public string area_office { get; set; }
        [Required(ErrorMessage = "Please Provide Inspection Officer Name")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Inspection Officer Name should only contain letters, numbers, and spaces.")]
        public string inspection_officer { get; set; }
    }

    //Model for Bird Houses- Calculations-Constants 
    public class birdhouse_calcModel
    {
        public int birdhouse_calcID { get; set; }
        [Required(ErrorMessage = "Please Provide Constant Name")]
        [RegularExpression("^[a-zA-Z0-9 %]*$", ErrorMessage = "Constant Name should only contain letters, numbers, spaces, and '%' symbol.")]
        public string constantname { get; set; }
        [Required(ErrorMessage = "Please Provide Rearing Type")]
        public string rearingtype { get; set; }
        [Required(ErrorMessage = "Please Provide Species Name")]
        public string species { get; set; }
        public string gender { get; set; }
        [Required(ErrorMessage = "Please Provide Value")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Invalid value. Only numeric values allowed.")]
        public string value { get; set; }
        [Required(ErrorMessage = "Please Provide Unit")]
        [RegularExpression("^[a-zA-Z0-9 %/]*$", ErrorMessage = "Unit should only contain letters, numbers, spaces, '%' symbol, and '/' symbol.")]
        public string unit { get; set; }
    }

    //Model for Breed
    public class BreedModel
    {
        public int breedID { get; set; }
        [Required(ErrorMessage = "Please Provide Breed")]
        [RegularExpression("^[a-zA-Z0-9()/& -]*$", ErrorMessage = "Breed should only contain letters, numbers, and spaces.")]
        public string breed { get; set; }
        public bool activeuntil { get; set; }
    }

    //Model for Type Of Business
    public class BusinessTypeModel
    {
        public int businessID { get; set; }
        [Required(ErrorMessage = "Please Provide Business Type")]
        [RegularExpression("^[a-zA-Z0-9 /]*$", ErrorMessage = "Business Type should only contain letters, numbers, and spaces.")]
        public string BusinessType { get; set; }
       
        public bool activeuntil { get; set; }
    }

    //Model for Cage Type
    public class CageTypeModel
    {
        public int cageID { get; set; }
        [Required(ErrorMessage = "Please Provide Cage Type")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Cage Type should only contain letters, numbers, and spaces.")]
        public string CageType { get; set; }
        
        public bool activeuntil { get; set; }
    }

    //Model for Collection Type
    public class collection_TypeModel
    {
        public int collectiontypeID { get; set; }
        [Required(ErrorMessage = "Please Provide Collection Type")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Collection Type should only contain letters, numbers, and spaces.")]
        public string collectionType { get; set; }
   
        public bool activeuntil { get; set; }

    }

    //Model for Collection Methods

    public class collection_methodModel
    {
        public int cmethodID { get; set; }
        [Required(ErrorMessage = "Please Provide Collection Method")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Collection Method should only contain letters, numbers, and spaces.")]
        public string collectionMethod { get; set; }
      
        public bool activeuntil { get; set; }

    }

    //Model for Company Type
    public class CompanytypeModel
    {
        public int companyID { get; set; }
        [Required(ErrorMessage = "Please Provide Company Type")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Company Type should only contain letters, numbers, and spaces.")]
        public string companytype { get; set; }

        public bool activeuntil { get; set; }
    }

    //Model for Current Application Status
    public class CurrAppStatusModel
    {
        public int curr_appID { get; set; }
        [Required(ErrorMessage = "Please Provide Current Application Status")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Current Application Status should only contain letters, numbers, and spaces.")]
        public string curr_applicationstatus { get; set; }

    }
    public class CurrAppStatus_PremiseModel : CurrAppStatusModel
    {
        public int curr_appPremiseID { get; set; }
        [Required(ErrorMessage = "Please Provide Current Application Status")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Current Application Status should only contain letters, numbers, and spaces.")]
        public string curr_applicationstatusPre { get; set; }
        [Required(ErrorMessage = "Please Provide Premises Type")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Premises Type should only contain letters, numbers, and spaces.")]
        public string PremiseType { get; set; }
        [RegularExpression("^[a-zA-Z0-9- ]*$", ErrorMessage = "Letter Name should only contain letters, numbers, and spaces.")]
        [Required(ErrorMessage ="Please Provide Letter Name")]
        public string letername { get; set; }
    }

    //Model for Default Criteria

    public class DefaultCiriteriaModel
    {
        public int def_criteriaID { get; set; }
        [Required(ErrorMessage = "Please Provide Area")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Area should only contain letters, numbers, and spaces.")]
        public string Area { get; set; }
        [Required(ErrorMessage = "Please Provide Default Criteria")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Default Critera should only contain letters, numbers, and spaces.")]
        public string DefaultCriteria { get; set; }
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Premises Type should only contain letters, numbers, and spaces.")]
        public string Premisetype { get; set; }
    }

    //Model for Egg Sizes & Expected Weight of Cases

    public class EggsandCasesModel
    {
        public int eggcasesID { get; set; }
        [Required(ErrorMessage = "Please Provide Weight Grade")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Weight Grade should only contain letters, numbers, and spaces.")]
        public string weightgrade { get; set; }
        [Required(ErrorMessage = "Please Provide Weight Low")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Invalid value. Only numeric values allowed.")]
        public string weightlow { get; set; }
        [Required(ErrorMessage = "Please Provide Weight High")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Invalid value. Only numeric values allowed.")]
        public string weighthigh { get; set; }
        public bool activeuntil { get; set; }
    }

    //Model for Type of Feed
    public class feedtypeModel
    {
        public int feedID { get; set; }
        [Required(ErrorMessage = "Please Provide Feed Type")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Feed Type should only contain letters, numbers, and spaces.")]
        public string feed { get; set; }

        public bool activeuntil { get; set; }

    }

    //Model for Floor Type
    public class floortypeModel
    {
        public int floorID { get; set; }
        [Required(ErrorMessage = "Please Provide Floor Type")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Floor Type should only contain letters, numbers, and spaces.")]
        public string floor { get; set; }
        public bool activeuntil { get; set; }

    }
    //Model for Local Authorities - Food Safety Mail Boxes
    public class LocalAuth_FoodmailboxModel
    {
        public int localauth_mailID { get; set; }
        [Required(ErrorMessage = "Please Provide Local Authority")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Local Authority should only contain letters, numbers, and spaces.")]
        public string local_auth { get; set; }
        [Required(ErrorMessage = "Please Provide Email")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string email { get; set; }
    }

    //Model for Gender

    public class GenderModel
    {
        public int genderID { get; set; }
        [Required(ErrorMessage = "Please Provide Gender")]
        [RegularExpression("^[a-zA-Z0-9 -]*$", ErrorMessage = "Gender should only contain letters, numbers, and spaces.")]
        public string gender { get; set; }
        public bool activeuntil { get; set; }
    }

    //Model for Hen House Calculations
    public class HenHouseCalModel
    {
        public int henhousecalID { get; set; }
        [Required(ErrorMessage = "Please Provide Constant Name")]
        [RegularExpression("^[a-zA-Z0-9 %]*$", ErrorMessage = "Constant Name should only contain letters, numbers, spaces, and '%' symbol.")]
        public string constantname { get; set; }
        [Required(ErrorMessage = "Please Provide Value")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Invalid value. Only numeric values allowed.")]
        public string value { get; set; }
        [Required(ErrorMessage = "Please Provide Unit")]
        [RegularExpression("^[a-zA-Z0-9 %/]*$", ErrorMessage = "Unit should only contain letters, numbers, spaces, '%' symbol, and '/' symbol.")]
        public string unit { get; set; }
    }

    //Model for Inspection Officer.
    public class InspectionOfficerModel
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "Please Provide Officer Name")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Officer Name should only contain letters, numbers, and spaces.")]
        public string officerName { get; set; }
        [Required(ErrorMessage = "Please Provide Email")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string officer_email { get; set; }
        [DataType(DataType.Date)]
        public DateTime activefrom { get; set; }
        [DataType(DataType.Date)]
        public DateTime activeto { get; set; }

    }

    //Model for Inspection Minimum Risk Analysis Score
    public class InspectionMinScoreModel
    {
        public int scoreID { get; set; }
        [Required(ErrorMessage = "Please Provide Minimum Score")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Invalid value. Only numeric values allowed.")]
        public string minScore { get; set; }
    }

    //Model for Inspection and Premises Note
    public class IpremiseNoteModel
    {
        public int IpremiseID { get; set; }
        [Required(ErrorMessage = "Please Provide Combo Box Name")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Combo Box Name should only contain letters, numbers, and spaces.")]
        public string ComboBoxName { get; set; }
        [Required(ErrorMessage = "Please Provide Entry")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Entry should only contain letters, numbers, and spaces.")]
        public string Entry { get; set; }
    }

    //Model for Land Type
    public class LandTypeModel
    {
        public int landtypeID { get; set; }
        [Required(ErrorMessage = "Please Provide Land Type")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Land Type should only contain letters, numbers, and spaces.")]
        public string landtype { get; set; }
        public bool activeuntil { get; set; }

    }

    //Model for Local Authorities
    public class LocalAuthorityModel
    {
        public int local_authID { get; set; }
        [Required(ErrorMessage = "Please Provide Local Authority")]
        [RegularExpression("^[a-zA-Z0-9() ]*$", ErrorMessage = "Local Authority should only contain letters, numbers, and spaces.")]
        public string local_auth { get; set; }
    }

    //Model for Local Authorities-Area Offices

    public class LocalAuth_AreaOfficeModel
    {
        public int local_authAOID { get; set; }
        [Required(ErrorMessage = "Please Provide Local Authority")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Local Authority should only contain letters, numbers, and spaces.")]
        public int localauthno { get; set; }
        public string local_authAO { get; set; }
        [Required(ErrorMessage = "Please Provide Area Office")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Area Office should only contain letters, numbers, and spaces.")]
        public string area_officeAO { get; set; }
        public int areaofficeno { get; set; }

    }

    //Model for Marketing Terms
    public class MarketingModel
    {
        public int marketingID { get; set; }
        [Required(ErrorMessage = "Please Provide Marketing Term")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Marketing Term should only contain letters, numbers, and spaces.")]
        public string marketingterm { get; set; }
        public bool activeuntil { get; set; }

    }

    //Model for NestType
    public class NestTypeModel
    {
        public int nestID { get; set; }
        [Required(ErrorMessage = "Please Provide Nest Type")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Nest Type should only contain letters, numbers, and spaces.")]
        public string nest { get; set; }
        public bool activeuntil { get; set; }

    }

    //Model for Organic Certification Model
    public class org_certificationModel
    {
        public int orgID { get; set; }
        [Required(ErrorMessage = "Please Provide Organic Certification Body")]
        [RegularExpression("^[a-zA-Z0-9 -]*$", ErrorMessage = "Organic Certification Body should only contain letters, numbers, and spaces.")]
        public string orgcertification { get; set; }
        public bool activeuntil { get; set; }

    }

    //Model for Pack Sizes
    public class PackSizeModel
    {
        public int packsizeID { get; set; }
        [Required(ErrorMessage = "Please Provide Pack Size")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Pack Size should only contain letters, numbers, and spaces.")]
        public string packsize { get; set; }
        public bool activeuntil { get; set; }

    }

    //Model for Pack Type
    public class PackTypeModel
    {
        public int packID { get; set; }
        [Required(ErrorMessage = "Please Provide Pack Type")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Pack Type should only contain letters, numbers, and spaces.")]
        public string packtype { get; set; }
        public bool activeuntil { get; set; }

    }
    //Model for Premise Type
    public class PremiseTypeModel
    {
        public int premiseID { get; set; }
        [Required(ErrorMessage = "Please Provide Premises Type")]
        [RegularExpression("^[a-zA-Z0-9 /]*$", ErrorMessage = "Premises Type should only contain letters, numbers, and spaces.")]
        public string premisetype { get; set; }
        public bool activeuntil { get; set; }

    }

    //MModel for Production Model
    public class ProductionModel
    {
        public int productionID { get; set; }
        [Required(ErrorMessage = "Please Provide Production Type")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Production Type should only contain letters, numbers, and spaces.")]
        public string production { get; set; }
        public bool activeuntil { get; set; }

    }

    //Model for Quality Class
    public class QualityClassModel
    {
        public int qualityID { get; set; }
        [Required(ErrorMessage = "Please Provide Quality Class")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Quality Class should only contain letters, numbers, and spaces.")]
        public string quality { get; set; }
        public bool activeuntil { get; set; }

    }

    //Model for Type of Rearing
    public class RearingModel
    {
        public int rearingID { get; set; }
        [Required(ErrorMessage = "Please Provide Type of Rearing")]
        [RegularExpression("^[a-zA-Z0-9 ()]*$", ErrorMessage = "Type of Rearing should only contain letters, numbers, and spaces.")]
        public string rearingtype { get; set; }
        public bool activeuntil { get; set; }

    }

    //Model for Region Outwith Scotland - Inspection Officer
    public class regionSCO_IOfficerModel
    {
        public int regionSCO_IOID { get; set; }
        [Required(ErrorMessage = "Please Provide Type of Region outwith Scotland")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Region outwith Scotland should only contain letters, numbers, and spaces.")]
        public string region_SCO { get; set; }
        [Required(ErrorMessage = "Please Provide Email")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string officer_email { get; set; }
        public bool activeuntil { get; set; }

    }

    //Model for Sloping Type
    public class slopingTypeModel
    {
        public int slopingID { get; set; }
        [Required(ErrorMessage = "Please Provide Sloping Type")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Sloping Type should only contain letters, numbers, and spaces.")]
        public string sloping { get; set; }
        public bool activeuntil { get; set; }

    }

    //Model for Species
    public class SpeciesModel
    {
        public int speciesID { get; set; }
        [Required(ErrorMessage = "Please Provide Species")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Species should only contain letters, numbers, and spaces.")]
        public string species { get; set; }
        public bool activeuntil { get; set; }

    }

    //Model for System Type
    public class systemTypeModel
    {
        public int systemID { get; set; }
        [Required(ErrorMessage = "Please Provide System Type")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "System Type should only contain letters, numbers, and spaces.")]
        public string system { get; set; }
        public bool activeuntil { get; set; }

    }

    //Model for Tolerances
    public class tolerancesModel
    {
        public int toleranceID { get; set;}
        [Required(ErrorMessage = "Please Provide Tolerance")]
        [RegularExpression("^[a-zA-Z0-9 %]*$", ErrorMessage = "Tolerance should only contain letters, numbers, spaces, and '%' symbol.")]
        public string tolerances { get; set; }
        [Required(ErrorMessage = "Please Provide Premises Type")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Premises Type should only contain letters, numbers, and spaces.")]
        public string premise_type { get; set; }
        [RegularExpression("^[-+]?[0-9]+$", ErrorMessage = "Operand2 should only contain positive or negative integers.")]
        public int operand2 { get; set; }

    }

    //Model for Weight Grades
    public class weight_gradesModel
    {
        public int gradeID { get; set; }
        [Required(ErrorMessage = "Please Provide Weight Grade")]
        [RegularExpression(@"^[A-Z]*$", ErrorMessage = "Weight Grade should be one or more uppercase characters")]
        
        public string grade { get; set; }
        public bool activeuntil { get; set; }

    }

    //Model for Minimum Number of Eggs and Packs 
    public class MinEggsPacksModel
    {
        public int minEggsPackID { get; set; }
        [Required(ErrorMessage = "Please Provide PackType")]
        [RegularExpression(@"^[A-Z]$", ErrorMessage = "PackType should be a single character")]
        public string packtype { get; set; }
        [Required(ErrorMessage = "Please Provide No. of Eggs in Batch Start")]
        [Range(1, int.MaxValue, ErrorMessage = "No. of Eggs in Batch Start should be a positive integer")]
        public int eggs_inBstart { get; set; }
        [Required(ErrorMessage = "Please Provide No. of Eggs in Batch Stop")]
        [Range(1, int.MaxValue, ErrorMessage = "No. of Eggs in Batch Stop should be a positive integer")]
        public int eggs_inBstop { get; set; }
        [Required(ErrorMessage = "Please Provide Minimum Eggs to be Checked in %")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Invalid value. Only numeric values allowed.")]
        public string mineggsinper { get; set; }
        [Required(ErrorMessage = "Please Provide Minimum Eggs to be Checked")]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Minimum Cases should be a valid number")]
        public int minegg { get; set; }
        [Required(ErrorMessage = "Please Provide Minimum Cases to be Checked in %")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Invalid value. Only numeric values allowed.")]
        public string mincasesinper { get; set; }
        [Required(ErrorMessage = "Please Provide Minimum Cases to be Checked")]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Minimum Cases should be a valid number")]
        public int mincases { get; set; }

    }
    //   Model class for Man Day Required Per Visit
    //   1)Model for Wholesaler-Category Wholesaler, Importer
    public class Wholesaler_CIModel
    {
        public int wholesaler_CIID { get; set; }
        [Required(ErrorMessage = "Please Provide Category")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Please Provide ThroughPut Cases From")]
        [Range(1, int.MaxValue, ErrorMessage = "ThroughPut Cases From should be a positive integer")]
        public int throughputfrom { get; set; }
        [Required(ErrorMessage = "Please Provide ThroughPut Cases To")]
        [Range(1, int.MaxValue, ErrorMessage = "ThroughPut Cases To should be a positive integer")]
        public int throughputto { get; set;}
        [Required(ErrorMessage = "Please Provide Man Days Required Per Visit")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Invalid value. Only numeric values allowed.")]
        public string WCImanpervisit { get; set; }
    }

    public class OtherWholesalerModel:Wholesaler_CIModel
    {
        public int Other_WHOID { get; set; }
        [Required(ErrorMessage = "Please Provide Category")]
        public string WOCategory { get; set; }
        [Required(ErrorMessage = "Please Provide Man Days Required Per Visit")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Invalid value. Only numeric values allowed.")]
        public string WOmanpervisit { get; set; }

    }
    public class PackingCenterModel:OtherWholesalerModel
    {
        public int packingcenterID { get; set; }
       
        [Required(ErrorMessage = "Please Provide ThroughPut Cases From")]
        [Range(1, int.MaxValue, ErrorMessage = "ThroughPut Cases From should be a positive integer")]
        public int PCthroughputfrom { get; set; }
        [Required(ErrorMessage = "Please Provide ThroughPut Cases To")]
        [Range(1, int.MaxValue, ErrorMessage = "ThroughPut Cases To should be a positive integer")]
        public int PCthroughputto { get; set; }
        [Required(ErrorMessage = "Please Provide Man Days Required Per Visit")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Invalid value. Only numeric values allowed.")]
        public string PCmanpervisit { get; set; }

    }

    public class HatcheryModel:PackingCenterModel
    {
        public int HatcheryID { get; set; }
        [Required(ErrorMessage = "Please Provide Category")]
        public string HCategory { get; set; }
        [Required(ErrorMessage = "Please Provide Man Days Required Per Visit")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Invalid value. Only numeric values allowed.")]
        public string Hmanpervisit { get; set; }
    }

    public class ProcessorModel:HatcheryModel
    {
        public int processorID { get; set; }
        [Required(ErrorMessage = "Please Provide Man Days Required Per Visit")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Invalid value. Only numeric values allowed.")]
        public string Pmanpervisit { get; set; }

    }

    public class eggProductionModel:ProcessorModel
    {
        public int eggProductionID { get; set; }
        [Required(ErrorMessage = "Please Provide Production Type")]
        public string production_Type { get; set; }
        [Required(ErrorMessage = "No. of Birds From Required Per Visit")]
        [Range(1, int.MaxValue, ErrorMessage = "No. of Birds From should be a positive integer")]
        public int Birds_From { get; set; }
        [Required(ErrorMessage = "No. of Birds To Required Per Visit")]
        [Range(1, int.MaxValue, ErrorMessage = "No. of Birds To should be a positive integer")]
        public int Birds_To { get; set; }
        [Required(ErrorMessage = "Please Provide Man Days Required Per Visit")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Invalid value. Only numeric values allowed.")]
        public string EPmanpervisit { get; set; }

    }
    public class poultrymeatModel:eggProductionModel
    {
        public int poultrymeatID { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "No. of Crops From Houses should be a positive integer")]
        [Required(ErrorMessage = "No. of Crops from all Bird Houses From Required Per Visit")]
        public int cropsfrom { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "No. of Crops To Houses should be a positive integer")]
        [Required(ErrorMessage = "No. of Crops to all Bird Houses From Required Per Visit")]
        public int cropsto { get; set; }
        [Required(ErrorMessage = "Please Provide Man Days Required Per Visit")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Invalid value. Only numeric values allowed.")]
        public string PMmanpervisit { get; set; }
    }
    public class ManDayRequiredModel:poultrymeatModel
    {

    }

        public class LookupModel
    {

    }
}
