using SILDMS.DataAccess.VendorRegistration;
using SILDMS.Model.CBPSModule;
using SILDMS.Model.DocScanningModule;
using SILDMS.Model.VendorSelectionModule;
using SILDMS.Utillity;
using SILDMS.Utillity.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Service.VendorRegistration
{
    public class VendorRegistrationService : IVendorRegistrationService
    {
        private readonly IVendorRegistrationDataService _vendorRegistrationDataService;
        private readonly ILocalizationService _localizationService;
        private string _errorNumber = string.Empty;

        public VendorRegistrationService(IVendorRegistrationDataService vendorRegistrationDataService, ILocalizationService localizationService)
        {
            _vendorRegistrationDataService = vendorRegistrationDataService;
            _localizationService = localizationService;

            _errorNumber = string.Empty;
        }

        public ValidationResult RegistrationCheckService(string vendorID,string Email, out string vendor)
        {
            vendor = _vendorRegistrationDataService.RegistrationCheckData(vendorID,Email, out _errorNumber);
            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        } 
        
        public ValidationResult GetVendorbyIDService(string vendorID,string Email, out List<VendorRegData> IndvVendorData)
        {
            IndvVendorData = _vendorRegistrationDataService.GetVendorbyIDData(vendorID, Email, out _errorNumber);
            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }

        public ValidationResult ItemVendorcheckService(string vendorID, out string vendor)
        {
            vendor = _vendorRegistrationDataService.ItemVendorcheckData(vendorID, out _errorNumber);
            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }


       

     

        public ValidationResult GetSupportDoc(string UserID, string FromName, out List<DSM_DocProperty> docProperties)
        {
            docProperties = _vendorRegistrationDataService.GetSupportDoc(UserID, FromName, out _errorNumber);
            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }

        public ValidationResult GetIdentificationAttributesForDocProperties(string _UserID, string _SelectedPropID,
         out List<DSM_DocPropIdentify> docPropIdentifyList)
        {
            docPropIdentifyList = _vendorRegistrationDataService.GetIdentificationAttributesForDocProperties
                (_UserID, _SelectedPropID, out _errorNumber);

            if (_errorNumber.Length > 0)
            {
                return new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber));
            }

            return ValidationResult.Success;
        }

        public ValidationResult AddDocument(string UserId, string vendorId, string uploaderIP, string selectedPropID, List<DocMetaValue> docMetaValues, out BPS_NewBillReturnData objDocPropIdentifies)
        {
            objDocPropIdentifies = _vendorRegistrationDataService.AddDocument
                (UserId,vendorId, uploaderIP, selectedPropID, docMetaValues, out _errorNumber);

            if (_errorNumber.Length > 0)
            {
                return new ValidationResult(_errorNumber,
                    _localizationService.GetResource(_errorNumber));
            }

            return ValidationResult.Success;
        }

        public ValidationResult VendorRegistrationDetailsService(string businessName, string contactPerson, string vendorPhoneNumber, string email, string companyAddress, string country, string businessType, string typeOfMaterial, string tin, string bin, string generalDetailsServices, string userName, string password, string status, string vendor, out SecVendor_User user)
        {
            user = _vendorRegistrationDataService.VendorRegistrationDetailsDataService(
        businessName, contactPerson, vendorPhoneNumber, email, companyAddress, country,
        businessType, typeOfMaterial, tin, bin, generalDetailsServices, userName,
        password, status, vendor, out _errorNumber);
            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }

        public ValidationResult VendorupdateRegistrationDetailsService(string businessName, string contactPerson, string vendorPhoneNumber, string companyAddress, string country, string businessType, string tIN, string bIN, string generalDetailsServices, string status, string vendor, string UserName, string Password, out SecVendor_User user)
        {
            user = _vendorRegistrationDataService.VendorupdateRegistrationDetailsData(businessName, contactPerson, vendorPhoneNumber,
              companyAddress, country, businessType, tIN, bIN, generalDetailsServices, status, vendor, UserName, Password, out _errorNumber);
            return _errorNumber.Length > 0
            ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
            : ValidationResult.Success;
        }


        public List<BusinessTypeDto> GetBusinessTypeList()
        {
            return _vendorRegistrationDataService.GetBusinessTypeList();
        }

        public List<BusinessNatureDto> GetBusinessNatureList()
        {
            return _vendorRegistrationDataService.GetBusinessNatureList();
        }


    }
}
