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
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
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


        [Authorize]
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

        [HttpGet]
        public ActionResult ViewDocument(
            string serverIP,
            string ftpPort,
            string ftpUserName,
            string ftpPassword,
            string fileServerURL,
            string vendorId, string ext)
        {
            try
            {

                if (!ext.StartsWith(".")) ext = "." + ext;

                string ftpUrl = $"ftp://{serverIP}:{ftpPort}/{fileServerURL}/{vendorId}{ext}";

                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(ftpUrl);
                ftpRequest.Credentials = new NetworkCredential(ftpUserName, ftpPassword);
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                ftpRequest.UseBinary = true;
                ftpRequest.KeepAlive = false;

                using (FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse())
                using (Stream responseStream = ftpResponse.GetResponseStream())
                {
                    if (responseStream == null)
                        return HttpNotFound("File not found.");

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        responseStream.CopyTo(memoryStream);
                        byte[] fileData = memoryStream.ToArray();

                        string extension = Path.GetExtension(fileServerURL)?.ToLower();

                        string contentType = "application/octet-stream";

                        switch (extension)
                        {
                            case ".pdf":
                                contentType = "application/pdf";
                                break;
                            case ".jpg":
                            case ".jpeg":
                                contentType = "image/jpeg";
                                break;
                            case ".png":
                                contentType = "image/png";
                                break;
                            case ".gif":
                                contentType = "image/gif";
                                break;
                            case ".doc":
                                contentType = "application/msword";
                                break;
                            case ".docx":
                                contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                break;
                            case ".xls":
                                contentType = "application/vnd.ms-excel";
                                break;
                            case ".xlsx":
                                contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                break;
                        }

                        return File(fileData, contentType);
                    }
                }
            }
            catch (WebException ex)
            {
                return new HttpStatusCodeResult(500, ex.Message);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, ex.Message);
            }
        }

    }
}