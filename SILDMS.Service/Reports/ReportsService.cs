using SILDMS.Utillity;
using SILDMS.Utillity.Localization;
using SILDMS.DataAccessInterface.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SILDMS.Model.CBPSModule;
//using SILDMS.Model.CheckPrintModule;
using SILDMS.Model.DocScanningModule;
//using SILDMS.Model.LCModule;

namespace SILDMS.Service.Reports
{
    public class ReportsService : IReportsService
    {
        #region Fields

        private readonly IReportsDataService _reportDataService;
        private readonly ILocalizationService _localizationService;
        private string _errorNumber = string.Empty;

        #endregion

        #region Constructor

        public ReportsService(IReportsDataService reportDataService, ILocalizationService localizationService)
        {
            _reportDataService = reportDataService;
            _localizationService = localizationService;
        }

        #endregion

        public ValidationResult GetRptUserActivityStatus(string FromDate, string ToDate, string userID, string id, string action, out DataTable dt)
        {
            dt = _reportDataService.GetRptUserActivityStatus(FromDate, ToDate, userID, id, action, out _errorNumber);
            if (_errorNumber.Length > 0)
            {
                return new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber));
            }
            return ValidationResult.Success;
        }

        public ValidationResult GetRptUserDetails(string UserRptID, string BillReceiveFromDate, string Status, string id, string action, out DataTable dt)
        {
            dt = _reportDataService.GetRptUserDetails(UserRptID, BillReceiveFromDate, Status, id, action, out _errorNumber);
            if (_errorNumber.Length > 0)
            {
                return new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber));
            }
            return ValidationResult.Success;
        }

        public ValidationResult GetRptOwnerList(string OwnerLevelID, string OwnerID, string ParentOwnerID, string Status, string id, string action, out DataTable dt)
        {
            dt = _reportDataService.GetRptOwnerList(OwnerLevelID, OwnerID, ParentOwnerID, Status, id, action, out _errorNumber);
            if (_errorNumber.Length > 0)
            {
                return new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber));
            }
            return ValidationResult.Success;
        }

        public ValidationResult GetRptDocumentsList(string OwnerLevelID, string OwnerID, string DocCategoryID, string DocTypeID, string DocPropertyID, string Status, string id, string action, out DataTable dt)
        {
            dt = _reportDataService.GetRptDocumentsList(OwnerLevelID, OwnerID, DocCategoryID, DocTypeID, DocPropertyID, Status, id, action, out _errorNumber);
            if (_errorNumber.Length > 0)
            {
                return new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber));
            }
            return ValidationResult.Success;
        }

        public ValidationResult GetRptRoleList(string OwnerLevelID, string OwnerID, string RoleID, string Status, string id, string action, out DataTable dt)
        {
            dt = _reportDataService.GetRptRoleList(OwnerLevelID, OwnerID, RoleID, Status, id, action, out _errorNumber);
            if (_errorNumber.Length > 0)
            {
                return new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber));
            }
            return ValidationResult.Success;
        }

        public string GetCompanyOrOwnerNameByUserID(string UserID)
        {
            return _reportDataService.GetCompanyOrOwnerNameByUserID(UserID);
        }
       
        public ValidationResult GetVendorNameAndAddress(string vendorID, out List<RptVendorWithAddress> RptAllEFTVendorList)
        {
            RptAllEFTVendorList = _reportDataService.GetVendorNameAndAddress(vendorID, out _errorNumber);
            if (_errorNumber.Length > 0)
            {
                return new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber));
            }
            return ValidationResult.Success;
        }
    }
}
