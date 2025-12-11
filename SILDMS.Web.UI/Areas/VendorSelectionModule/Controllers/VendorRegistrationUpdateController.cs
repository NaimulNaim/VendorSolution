using SILDMS.Model.CBPSModule;
using SILDMS.Model.DocScanningModule;
using SILDMS.Model.VendorSelectionModule;
using SILDMS.Service.AutoValueSetup;
using SILDMS.Service.TechnicalQuotation;
using SILDMS.Service.VendorRegistrationUpdate;
using SILDMS.Utillity;
using SILDMS.Web.UI.Areas.SecurityModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SILDMS.Web.UI.Areas.VendorSelectionModule.Controllers
{
    public class VendorRegistrationUpdateController : Controller
    {
        // GET: VendorSelectionModule/VendorRegistrationUpdate

        private readonly IVendorRegistrationUpdateService _vendorRegistrationUpdateService;
        private readonly string UserID = string.Empty;
        private ValidationResult respStatus = new ValidationResult();
        private readonly IAutoValueSetupService _autoValueSetupService;
        private string action = "";

        public ActionResult Index()
        {
            return View();
        }

        public VendorRegistrationUpdateController(IVendorRegistrationUpdateService vendorRegistrationUpdateService, IAutoValueSetupService autoValueSetupService)
        {
            _vendorRegistrationUpdateService = vendorRegistrationUpdateService;
            _autoValueSetupService = autoValueSetupService;
            UserID = SILAuthorization.GetUserID();

        }
        public async Task<dynamic> GetVendorInformation()
        {
            var IndvVendorData = new List<VendorRegData>();

            await Task.Run(() => _vendorRegistrationUpdateService.GetVendorInformation(UserID, out IndvVendorData));
            return Json(new { IndvVendorData, Msg = "" }, JsonRequestBehavior.AllowGet);
        }
        public async Task<dynamic> GetDocsForFurtherDoc(string TinBinDocId)
        {
            var billInfo = new BillInfoForFurtherDoc();

            await Task.Run(() => _vendorRegistrationUpdateService.GetDocsForFurtherDoc(TinBinDocId, UserID, out billInfo));

            return Json(new { docProperties = billInfo.DocProperties, documents = billInfo.Documents },
               JsonRequestBehavior.AllowGet);
        }





    }
}