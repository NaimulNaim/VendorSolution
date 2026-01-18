using SILDMS.Model;
using SILDMS.Model.VendorSelectionModule;
using SILDMS.Service.DashboardV2;
using SILDMS.Service.VendorDashboard;
using SILDMS.Utillity;
using SILDMS.Utillity.Localization;
using SILDMS.Web.UI.Areas.SecurityModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SILDMS.Web.UI.Areas.VendorSelectionModule.Controllers
{
    public class VendorDashboardController : Controller
    {
        #region Fields
        private readonly IVendorDashboardV2Service _iVendordashboardV2Service;
        private ValidationResult _respStatus;
        private readonly ILocalizationService _localizationService;
        private readonly string _userId;
        #endregion

        public VendorDashboardController(IVendorDashboardV2Service IVendorDashboardV2Service)
        {
            _iVendordashboardV2Service = IVendorDashboardV2Service;
            _respStatus = new ValidationResult();
            _userId = SILAuthorization.GetUserID();
        }

        [Authorize]
        // GET: VendorSelectionModule/VendorDashboard
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<dynamic> GetUserWiseInvList()
        {
            RequisitionUnassaign pd = new RequisitionUnassaign();
            await Task.Run(() => _iVendordashboardV2Service.GetPlantWiseUnAssignedResult(_userId, "me", out pd));
            var totalList = pd;
            return Json(new { totalList = pd }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public async Task<dynamic> GetUserWiseInvDetailList(string invitationNumber)
        {
            InvitationDetail pd = new InvitationDetail();
            await Task.Run(() => _iVendordashboardV2Service.GetUserWiseInvDetailList(invitationNumber, _userId, out pd));
            var totalList = pd;
            return Json(new { totalList = pd }, JsonRequestBehavior.AllowGet);
        }
    }
}