using SILDMS.DataAccess.DashboardV2;
using SILDMS.DataAccessInterface.VendorDashboard;
using SILDMS.Model;
using SILDMS.Model.VendorSelectionModule;
using SILDMS.Utillity;
using SILDMS.Utillity.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Service.VendorDashboard
{ 


    public class VendorDashboardV2Service : IVendorDashboardV2Service
    {
        #region Fields

        private readonly IVendorDashboardV2DataService vendorDashboardV2DataService;
        private readonly ILocalizationService _localizationService;
        private string _errorNumber = string.Empty;

        #endregion

        #region Constructor

        public VendorDashboardV2Service(IVendorDashboardV2DataService _vendorDashboardV2DataService,ILocalizationService localizationService)
        {
            vendorDashboardV2DataService = _vendorDashboardV2DataService;
            _localizationService = localizationService;
        }
        #endregion

        //public ValidationResult GetInvDetailList(string userId, string action, out List<DashBoardInvitationTecnicalList> pd1)
        //{
        //    pd1 = vendorDashboardV2DataService.GetInvDetailList(userId, action);
        //    return ValidationResult.Success;
        //}
       
        public ValidationResult GetPlantWiseUnAssignedResult(string _userId, string action, out RequisitionUnassaign pd)
        {
            pd = vendorDashboardV2DataService.GetPlantWiseUnAssignedResult(_userId, action);
            return ValidationResult.Success;
        }

        public ValidationResult GetUserWiseInvDetailList(string invitationNumber, string userId, out InvitationDetail pd)
        {
            pd = vendorDashboardV2DataService.GetUserWiseInvDetailList(invitationNumber, userId);
            return ValidationResult.Success;
        }
    }
}
