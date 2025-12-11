using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SILDMS.Model;
using SILDMS.Model.SecurityModule;
using SILDMS.Utillity;

namespace SILDMS.Service.Dashboard
{
    public interface IDashboardService
    {
        Model.SecurityModule.Dashboard GetDashboardInfo(string userId, DateTime? dateFrom, DateTime? dateTo);
    }
}
