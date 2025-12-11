using SILDMS.DataAccess.VendorRegistration;
using SILDMS.DataAccess.VendorRegistrationUpdate;
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

namespace SILDMS.Service.VendorRegistrationUpdate
{
    public class VendorRegistrationUpdateService : IVendorRegistrationUpdateService
    {
        private readonly IVendorRegistrationUpdateData _vendorRegistrationUpdateData;
        private readonly ILocalizationService _localizationService;
        private string _errorNumber = string.Empty;

        public VendorRegistrationUpdateService(IVendorRegistrationUpdateData vendorRegistrationUpdateData, ILocalizationService localizationService)
        {
            _vendorRegistrationUpdateData = vendorRegistrationUpdateData;
            _localizationService = localizationService;

            _errorNumber = string.Empty;
        }
        public ValidationResult GetVendorInformation(string userID, out List<VendorRegData> indvVendorData)
        {
            indvVendorData = _vendorRegistrationUpdateData.GetVendorInformation(userID,out _errorNumber);
            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }

        public ValidationResult GetDocsForFurtherDoc(string TinBinDocId, string UserID, out BillInfoForFurtherDoc docs)
        {
            docs = _vendorRegistrationUpdateData.GetDocsForFurtherDoc(TinBinDocId, UserID, out _errorNumber);
            if (_errorNumber.Length > 0)
            {
                return new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber));
            }
            return ValidationResult.Success;
        }

        
    }
}
