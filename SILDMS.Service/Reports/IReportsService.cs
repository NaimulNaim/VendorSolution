using SILDMS.Model.CBPSModule;
//using SILDMS.Model.CheckPrintModule;
using SILDMS.Model.DocScanningModule;
//using SILDMS.Model.LCModule;
using SILDMS.Utillity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Service.Reports
{
    public interface IReportsService
    {
        ValidationResult GetRptUserActivityStatus(string FromDate, string ToDate, string userID, string id, string action, out DataTable UserActivityStatus);
        
        ValidationResult GetRptUserDetails(string UserRptID, string BillReceiveFromDate, string Status, string id, string action, out DataTable UserDetails);
      
        ValidationResult GetRptOwnerList(string OwnerLevelID, string OwnerID, string ParentOwnerID, string Status, string id, string action, out DataTable OwnerList);

        ValidationResult GetRptDocumentsList(string OwnerLevelID, string OwnerID, string DocCategoryID, string DocTypeID, string DocPropertyID, string Status, string id, string action, out DataTable DocumentsList);
        ValidationResult GetRptRoleList(string OwnerLevelID, string OwnerID, string RoleID, string Status, string id, string action, out DataTable RoleList);
        
        string GetCompanyOrOwnerNameByUserID(string UserID);

        ValidationResult GetVendorNameAndAddress(string vendorID, out List<RptVendorWithAddress> RptAllEFTVendorList);
    }
}
