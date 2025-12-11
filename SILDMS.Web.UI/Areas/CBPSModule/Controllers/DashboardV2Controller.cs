using MvcSiteMapProvider.Globalization;
using SILDMS.Model;
using SILDMS.Model.CBPSModule;
using SILDMS.Service.DashboardV2;
using SILDMS.Utillity;
using SILDMS.Web.UI.Areas.SecurityModule;
using SILDMS.Web.UI.Areas.SecurityModule.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SILDMS.Web.UI.Areas.CBPSModule.Controllers
{
    public class DashboardV2Controller : Controller
    {
        #region Fields
        private readonly IDashboardV2Service _dashboardV2Service;
        private ValidationResult _respStatus;
        private readonly ILocalizationService _localizationService;
        private readonly string _userId;
        #endregion

        public DashboardV2Controller(IDashboardV2Service IDashboardV2Service)
        {
            _dashboardV2Service = IDashboardV2Service;
            _respStatus = new ValidationResult();
            _userId = SILAuthorization.GetUserID();
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<dynamic> GetParkingResult()
        {
            List<ParkingForDashbord> pd = new List<ParkingForDashbord>();
            await Task.Run(() => _dashboardV2Service.GetParkingForDashbord(_userId, "me", out pd));
            var TotalPendingParking = pd.Count();
            var OverBenchmark = pd.Where(o => Convert.ToInt32(o.BenchMark) < 0).Count();
            var WithinBenchMark = pd.Where(o => Convert.ToInt32(o.BenchMark) >= 0).Count();

            return Json(new { TotalPendingParking = pd.Count(), OverBenchmark = pd.Where(o => Convert.ToInt32(o.BenchMark) < 0).Count(), WithinBenchMark = pd.Where(o => Convert.ToInt32(o.BenchMark) >= 0).Count() }, JsonRequestBehavior.AllowGet);
        }

        public async Task<dynamic> GetPostingResult()
        {
            List<ParkingForDashbord> pd = new List<ParkingForDashbord>();
            await Task.Run(() => _dashboardV2Service.GetPostingForDashbord(_userId, "me", out pd));
            var TotalPendingParking = pd.Count();
            var OverBenchmark = pd.Where(o => Convert.ToInt32(o.BenchMark) < 0).Count();
            var WithinBenchMark = pd.Where(o => Convert.ToInt32(o.BenchMark) >= 0).Count();

            return Json(new { TotalPendingParking = pd.Count(), OverBenchmark = pd.Where(o => Convert.ToInt32(o.BenchMark) < 0).Count(), WithinBenchMark = pd.Where(o => Convert.ToInt32(o.BenchMark) >= 0).Count() }, JsonRequestBehavior.AllowGet);
        }

        public async Task<dynamic> GetClearingResult()
        {
            List<ParkingForDashbord> pd = new List<ParkingForDashbord>();
            await Task.Run(() => _dashboardV2Service.GetClearingForDashbord(_userId, "me", out pd));
            var TotalPendingParking = pd.Count();
            var OverBenchmark = pd.Where(o => Convert.ToInt32(o.BenchMark) < 0).Count();
            var WithinBenchMark = pd.Where(o => Convert.ToInt32(o.BenchMark) >= 0).Count();

            return Json(new { TotalPendingParking = pd.Count(), OverBenchmark = pd.Where(o => Convert.ToInt32(o.BenchMark) < 0).Count(), WithinBenchMark = pd.Where(o => Convert.ToInt32(o.BenchMark) >= 0).Count() }, JsonRequestBehavior.AllowGet);
        }

        public async Task<dynamic> IsASuperVisor()
        {
            bool isSupervisor = false;
            await Task.Run(() => _dashboardV2Service.IsASuperVisor(_userId, out isSupervisor));

            return Json(isSupervisor, JsonRequestBehavior.AllowGet);
        }

        public async Task<dynamic> GetPendingBillCount()
        {
            PendingBillsCount pbc = new PendingBillsCount();
            await Task.Run(() => _dashboardV2Service.GetPendingBillCount(_userId, out pbc));
            return Json(pbc, JsonRequestBehavior.AllowGet);
        }

        //Methods to retrive Assigned(Supervisor) Data for Dashbord
        public async Task<dynamic> GetParkingResultAsgn()
        {
            List<ParkingForDashbord> pd1 = new List<ParkingForDashbord>();
            List<ParkingForDashbord> pd2 = new List<ParkingForDashbord>();
            List<ParkingForDashbord> pd3 = new List<ParkingForDashbord>();

            await Task.Run(() => _dashboardV2Service.GetParkingForDashbord(_userId, "asgn", out pd1));
            await Task.Run(() => _dashboardV2Service.GetPostingForDashbord(_userId, "asgn", out pd2));
            await Task.Run(() => _dashboardV2Service.GetClearingForDashbord(_userId, "asgn", out pd3));

            var result1 = from prd in pd1
                          group prd by new { prd.UserID} into gcs
                          select new
                          {
                              UserID = gcs.Key.UserID,
                              CompanyCode = gcs.Select(a=>a.CompanyCode).FirstOrDefault(),
                              EmployeeID = gcs.Select(a=>a.EmployeeID).FirstOrDefault(),
                              UserName = gcs.Select(a => a.UserName).FirstOrDefault(),
                              CompanyName = gcs.Select(a => a.CompanyName).FirstOrDefault(),
                              TotalPendingParking = gcs.Count(),
                              OverBenchmarkParking = gcs.Count(o => Convert.ToInt32(o.BenchMark) < 0),
                              WithinBenchMarkParking = gcs.Count(o => Convert.ToInt32(o.BenchMark) >= 0),
                              TotalPendingPosting = "",
                              OverBenchmarkPosting = "",
                              WithinBenchMarkPosting = "",
                              TotalPendingClearing = "",
                              OverBenchmarkClearing = "",
                              WithinBenchMarkClearing = ""
                          };

            var result2 = from prd in pd2
                          group prd by new { prd.UserID} into gcs
                          select new
                          {
                              UserID = gcs.Key.UserID,
                              CompanyCode = gcs.Select(a => a.CompanyCode).FirstOrDefault(),
                              EmployeeID = gcs.Select(a => a.EmployeeID).FirstOrDefault(),
                              UserName = gcs.Select(a => a.UserName).FirstOrDefault(),
                              CompanyName = gcs.Select(a => a.CompanyName).FirstOrDefault(),
                              TotalPendingParking = "",
                              OverBenchmarkParking = "",
                              WithinBenchMarkParking = "",
                              TotalPendingPosting = gcs.Count(),
                              OverBenchmarkPosting = gcs.Count(o => Convert.ToInt32(o.BenchMark) < 0),
                              WithinBenchMarkPosting = gcs.Count(o => Convert.ToInt32(o.BenchMark) >= 0),
                              TotalPendingClearing = "",
                              OverBenchmarkClearing = "",
                              WithinBenchMarkClearing = ""
                          };

            var result3 = from prd in pd3
                          group prd by new { prd.UserID } into gcs
                          select new
                          {
                              UserID = gcs.Key.UserID,
                              CompanyCode = gcs.Select(a => a.CompanyCode).FirstOrDefault(),
                              EmployeeID = gcs.Select(a => a.EmployeeID).FirstOrDefault(),
                              UserName = gcs.Select(a => a.UserName).FirstOrDefault(),
                              CompanyName = gcs.Select(a => a.CompanyName).FirstOrDefault(),
                              TotalPendingParking = "",
                              OverBenchmarkParking = "",
                              WithinBenchMarkParking = "",
                              TotalPendingPosting = "",
                              OverBenchmarkPosting = "",
                              WithinBenchMarkPosting = "",
                              TotalPendingClearing = gcs.Count(),
                              OverBenchmarkClearing = gcs.Count(o => Convert.ToInt32(o.BenchMark) < 0),
                              WithinBenchMarkClearing = gcs.Count(o => Convert.ToInt32(o.BenchMark) >= 0)
                          };

            var result4 = result1.FullOuterJoin(result2, a => a.UserID, b => b.UserID, (a, b) => new
            {
                UserID = (a != null) ? a.UserID : b.UserID,
                EmployeeID = (a != null) ? a.EmployeeID : b.EmployeeID,
                CompanyCode = (a != null) ? a.CompanyCode : b.CompanyCode,
                UserName = (a != null) ? a.UserName : b.UserName,
                CompanyName = (a != null) ? a.CompanyName : b.CompanyName,
                TotalPendingParking = (a != null) ? a.TotalPendingParking.ToString() : "",
                OverBenchmarkParking = (a != null) ? a.OverBenchmarkParking.ToString() : "",
                WithinBenchMarkParking = (a != null) ? a.WithinBenchMarkParking.ToString() : "",
                TotalPendingPosting = (b != null) ? b.TotalPendingPosting.ToString() : "",
                OverBenchmarkPosting = (b != null) ? b.OverBenchmarkPosting.ToString() : "",
                WithinBenchMarkPosting = (b != null) ? b.WithinBenchMarkPosting.ToString() : "",
            }, StringComparer.OrdinalIgnoreCase);

            var finalResult = result4.FullOuterJoin(result3, a => a.UserID, b => b.UserID, (a, b) => new
            {
                UserID = (a != null) ? a.UserID : b.UserID,
                EmployeeID = (a != null) ? a.EmployeeID : b.EmployeeID,
                CompanyCode = (a != null) ? a.CompanyCode : b.CompanyCode,
                UserName = (a != null) ? a.UserName : b.UserName,
                CompanyName = (a != null) ? a.CompanyName : b.CompanyName,
                TotalPendingParking = (a != null) ? a.TotalPendingParking.ToString() : "",
                OverBenchmarkParking = (a != null) ? a.OverBenchmarkParking.ToString() : "",
                WithinBenchMarkParking = (a != null) ? a.WithinBenchMarkParking.ToString() : "",
                TotalPendingPosting = (a != null) ? a.TotalPendingPosting.ToString() : "",
                OverBenchmarkPosting = (a != null) ? a.OverBenchmarkPosting.ToString() : "",
                WithinBenchMarkPosting = (a != null) ? a.WithinBenchMarkPosting.ToString() : "",
                TotalPendingClearing = (b != null) ? b.TotalPendingClearing.ToString() : "",
                OverBenchmarkClearing = (b != null) ? b.OverBenchmarkClearing.ToString() : "",
                WithinBenchMarkClearing = (b != null) ? b.WithinBenchMarkClearing.ToString() : ""
            }, StringComparer.OrdinalIgnoreCase);

            return Json(finalResult, JsonRequestBehavior.AllowGet);
        }
    }
}