using SILDMS.Model.CBPSModule;
using SILDMS.Model.DocScanningModule;
using SILDMS.Model.VendorSelectionModule;
using SILDMS.Utillity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Service.VendorRegistration
{
    public interface IVendorRegistrationService
    {
        ValidationResult RegistrationCheckService(string vendorID,string Email, out string vendor);
        ValidationResult GetVendorbyIDService(string vendorID,string Email, out List<VendorRegData> IndvVendorData);
        ValidationResult ItemVendorcheckService(string vendorID, out string vendor);
        ValidationResult VendorupdateRegistrationDetailsService( string businessName, string contactPerson, string vendorPhoneNumber, string companyAddress, string country, string businessType, string tIN, string bIN, string generalDetailsServices, string status, string vendor,string UserName,string Password, out SecVendor_User user);
        
        ValidationResult GetSupportDoc(string userID, string fromName, out List<DSM_DocProperty> docProperties);
        ValidationResult GetIdentificationAttributesForDocProperties(string userID, string selectedPropID, out List<DSM_DocPropIdentify> docPropIdentifies);
        ValidationResult AddDocument(string UserId,string vendorId, string uploaderIP, string selectedPropID, List<DocMetaValue> docMetaValues, out BPS_NewBillReturnData objDocPropIdentifies);
        ValidationResult VendorRegistrationDetailsService(string businessName, string contactPerson, string vendorPhoneNumber, string email, string companyAddress, string country, string businessType, string typeOfMaterial, string tIN, string bIN, string generalDetailsServices, string userName, string password, string status, string vendor, out SecVendor_User user);

        List<BusinessTypeDto> GetBusinessTypeList();
        List<BusinessNatureDto> GetBusinessNatureList();

        List<CurrencyDto> GetCurrencyList();
        List<CountryDto> GetCountryList();
    }
}
