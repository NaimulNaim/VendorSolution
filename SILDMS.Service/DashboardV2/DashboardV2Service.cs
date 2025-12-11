using SILDMS.DataAccessInterface.DashboardV2;
using SILDMS.Model.CBPSModule;
using SILDMS.Utillity;
using SILDMS.Utillity.Localization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SILDMS.Model;

namespace SILDMS.Service.DashboardV2
{
    public class DashboardV2Service : IDashboardV2Service
    {
        #region Fields

        private readonly IDashboardV2DataService dashboardV2DataService;
        private readonly ILocalizationService _localizationService;
        private string _errorNumber = string.Empty;

        #endregion

        #region Constructor

        public DashboardV2Service(IDashboardV2DataService _dashboardV2DataService, ILocalizationService localizationService)
        {
            dashboardV2DataService = _dashboardV2DataService;
            _localizationService = localizationService;
        }

        #endregion

        public ValidationResult GetParkingForDashbord(string _userId,string action, out List<ParkingForDashbord> pd)
        {
            pd = dashboardV2DataService.GetParkingForDashbord(_userId,action);
            return ValidationResult.Success;
        }

        public ValidationResult GetPostingForDashbord(string _userId, string action, out List<ParkingForDashbord> pd)
        {
            pd = dashboardV2DataService.GetPostingForDashbord(_userId,action);
            return ValidationResult.Success;
        }

        public ValidationResult GetClearingForDashbord(string _userId, string action, out List<ParkingForDashbord> pd)
        {
            pd = dashboardV2DataService.GetClearingForDashbord(_userId,action);
            return ValidationResult.Success;
        }

        public ValidationResult IsASuperVisor(string _userId, out bool isSupervisor)
        {
            isSupervisor= dashboardV2DataService.IsASuperVisor(_userId);
            return ValidationResult.Success;
        }

        public ValidationResult GetPendingBillCount(string _userId, out PendingBillsCount pbc)
        {
            pbc= dashboardV2DataService.GetPendingBillCount(_userId);
            return ValidationResult.Success;
        }
    }
}
