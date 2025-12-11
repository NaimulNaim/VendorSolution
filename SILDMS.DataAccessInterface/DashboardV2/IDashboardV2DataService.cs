using SILDMS.Model.CBPSModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SILDMS.Model;

namespace SILDMS.DataAccessInterface.DashboardV2
{
    public interface IDashboardV2DataService
    {
        List<ParkingForDashbord> GetParkingForDashbord(string _userId,string action);
        List<ParkingForDashbord> GetClearingForDashbord(string userid,string action);
        List<ParkingForDashbord> GetPostingForDashbord(string _userId,string action);
        bool IsASuperVisor(string _userId);
        PendingBillsCount GetPendingBillCount(string _userId);
    }
}
