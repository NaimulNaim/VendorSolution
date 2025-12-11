using SILDMS.Model.CBPSModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.VendorSelectionModule
{
    public class RequisitionUnassaign
    {
        public string TotalSCM { get; set; }
        public string TotalSCMCHQ { get; set; }
        public string TotalSCMDU { get; set; }
        public string TotalSCMPU { get; set; }
        public string TotalTSD { get; set; }
        public string TotalTSDCHQ { get; set; }
        public string TotalTSDDU { get; set; }
        public string TotalTSDPU { get; set; }

        public string TotASSNSCMCHQ { get; set; }
        public string TotASSNSCMDU { get; set; }
        public string TotASSNSCMPU { get; set; }
        public string TotASSNTSDCHQ { get; set; }
        public string TotASSNTSDDU { get; set; }
        public string TotASSNTSDPU { get; set; }

        public string TotSCM { get; set; }
        public string TotTSD { get; set; }

        public string TechInvToRespTotal { get; set; }
        public string FinanInvToRespTotal { get; set; }
        public string RunInvTotal { get; set; }
        public List<DashBoardInvitationTecnicalList> InvitationTecnicalList { get; set; }
        public List<DashBoardInvitationFinanList> InvitationFinanList { get; set; }
        public List<DashBoardInvitationRunninglList> InvitationRunninglList { get; set; }
    }
}
