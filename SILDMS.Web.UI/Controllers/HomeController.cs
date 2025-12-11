using SILDMS.Utillity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SILDMS.Web.UI.Areas.SecurityModule;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;

namespace SILDMS.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        [SILAuthorize]
        [OutputCache(Duration = 1000, VaryByParam = "none", Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult DocumentScanning()
        {
            return View();
        }

        [SILAuthorize]
        [OutputCache(Duration = 1000, VaryByParam = "none", Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult OriginalDocSearching()
        {
            return View();
        }

        [SILAuthorize]
        [OutputCache(Duration = 1000, VaryByParam = "none", Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult VersioningOriginalDoc()
        {
            return View();
        }

        [SILAuthorize]
        [OutputCache(Duration = 1000, VaryByParam = "none", Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult VersionDocSearching()
        {
            return View();
        }

        [SILAuthorize]
        [OutputCache(Duration = 1000, VaryByParam = "none", Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult VersioningVersionedDoc()
        {
            return View();
        }

        [OutputCache(Duration = 1000, VaryByParam = "none", Location = OutputCacheLocation.Server)]
        public ActionResult NotFound()
        {
            return View();
        }

        [OutputCache(Duration = 1000, VaryByParam = "none", Location = OutputCacheLocation.Server)]
        public ActionResult BadRequest()
        {
            return View();
        }
        [SILAuthorize]
        public ActionResult DocumentDistribution()
        {
            return View();
        }

        public ActionResult DocumentSharing()
        {
            return View();
        }

        //
        // GET: /Home/AttendanceGeoData
        //[SILAuthorize]
        public ActionResult AttendanceGeoData()
        {
            return View();
        }

        [HttpPost]
        //[Authorize]
        //[SILLogAttribute]
        public async Task<dynamic> SaveAttendanceGeoData(string latitude, string longitude)
        {
            string status = string.Empty, message = string.Empty;
            //respStatus = await Task.Run(() => _lcRequestService.SaveLCRequestInfo(_modelLCRequestInfo, UserID, out status));
            //TempData["LCRequestPrintAndEmailInfo"] = _modelLCRequestInfo;
            message = "Data Posted Successfully";
            return Json(new { ResponseCode = 1, message }, JsonRequestBehavior.AllowGet);
        }


        private SqlConnection con;
        //string Code = "0";
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["AuthContext"].ToString();
            con = new SqlConnection(constr);
        }
    }

}