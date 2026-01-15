using SILDMS.Model.CBPSModule;
using SILDMS.Model.DocScanningModule;
using SILDMS.Model.VendorSelectionModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.DataAccess.VendorRegistration
{
    public interface IVendorRegistrationDataService
    {
        string RegistrationCheckData(string vendorID,string Email, out string errorNumber);
        List <VendorRegData> GetVendorbyIDData(string vendorID,string Email, out string errorNumber);
        string ItemVendorcheckData(string vendorID, out string errorNumber);
        SecVendor_User VendorRegistrationDetailsDataService(string BusinessName, string ContactPerson, string VendorPhoneNumber, string Email,
               string CompanyAddress, string Country, string BusinessType, string TypeOfMaterial, string TIN, string BIN, string GeneralDetailsServices, string UserName, string Password, string Status, string Vendor, out string _errorNumber);
        SecVendor_User VendorupdateRegistrationDetailsData(string businessName, string contactPerson, string vendorPhoneNumber, string companyAddress, string country, string businessType, string tIN, string bIN, string generalDetailsServices, string status, string vendor,string UserName,string Password, out string errorNumber);
        List<DSM_DocProperty> GetSupportDoc(string userID, string fromName, out string errorNumber);
        List<DSM_DocPropIdentify> GetIdentificationAttributesForDocProperties(string userID, string selectedPropID, out string errorNumber);
        BPS_NewBillReturnData AddDocument(string UserId,string vendorId, string uploaderIP, string selectedPropID, List<DocMetaValue> docMetaValues, out string errorNumber);

        List<BusinessTypeDto> GetBusinessTypeList();
        List<BusinessNatureDto> GetBusinessNatureList();
    }
}
