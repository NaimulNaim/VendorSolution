using SILDMS.Model;
using SILDMS.Model.VendorSelectionModule;
using SILDMS.Utillity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Service.VendorDashboard
{
    public interface IVendorDashboardV2Service
    {
        //ValidationResult GetInvDetailList(string userId, string v, out List<DashBoardInvitationTecnicalList> pd1);
        ValidationResult GetPlantWiseUnAssignedResult(string _userId, string action, out RequisitionUnassaign pd);
        ValidationResult GetUserWiseInvDetailList(string invitationNumber, string userId, out InvitationDetail pd);
    }
}
