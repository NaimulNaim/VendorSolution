using SILDMS.Model;
using SILDMS.Model.VendorSelectionModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.DataAccessInterface.VendorDashboard
{
    public interface IVendorDashboardV2DataService
    {
        //List<DashBoardInvitationTecnicalList> GetInvDetailList(object userId, string action);
        RequisitionUnassaign GetPlantWiseUnAssignedResult(string _userId, string action);
        InvitationDetail GetUserWiseInvDetailList(string invitationNumber, string userId);
    }
}
