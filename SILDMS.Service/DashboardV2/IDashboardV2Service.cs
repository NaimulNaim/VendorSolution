using SILDMS.Model.CBPSModule;
using SILDMS.Utillity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SILDMS.Model;

namespace SILDMS.Service.DashboardV2
{
    public interface IDashboardV2Service
    {
        ValidationResult GetParkingForDashbord(string _userId,string action, out List<ParkingForDashbord> pd);
        ValidationResult GetPostingForDashbord(string _userId,string action, out List<ParkingForDashbord> pd);
        ValidationResult GetClearingForDashbord(string _userId,string action, out List<ParkingForDashbord> pd);
        ValidationResult IsASuperVisor(string _userId, out bool isSupervisor);
        ValidationResult GetPendingBillCount(string _userId, out PendingBillsCount pbc);
    }
}
