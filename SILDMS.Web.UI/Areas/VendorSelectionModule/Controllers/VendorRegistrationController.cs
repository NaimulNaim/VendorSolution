using iTextSharp.text.pdf;
using SILDMS.Model.CBPSModule;
using SILDMS.Model.DocScanningModule;
using SILDMS.Model.VendorSelectionModule;
using SILDMS.Service.VendorRegistration;
using SILDMS.Utillity;
using SILDMS.Web.UI.Areas.SecurityModule.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SILDMS.Web.UI.Areas.VendorSelectionModule.Controllers
{
    public class VendorRegistrationController : Controller
    {

        private readonly IVendorRegistrationService _vendorRegistrationService;
        private readonly string UserID = string.Empty;
        private ValidationResult respStatus = new ValidationResult();

        public VendorRegistrationController(IVendorRegistrationService vendorRegistrationService)
        {
            _vendorRegistrationService = vendorRegistrationService;
            UserID = SILAuthorization.GetUserID();
        }
        // GET: VendorSelectionModule/VendorRegistration
        public ActionResult Index()
        {
            return View();
        }

        // GET: VendorSelectionModule/VendorRegistration
        //public ActionResult Temporary()
        //{
        //    return View();
        //}

        [HttpPost]

        public async Task<dynamic> VendorRegistrationDetails(
    string businessName, string contactPersonFirstName, string contactPersonLastName, string vendorPhoneNumber,
    string email, string companyAddress, string country, string businessType, string typeOfMaterial,
    string tin, string bin, string generalDetailsServices, string userName, string password,
    string status, string vendor)
        {
            string respStatus = string.Empty, message = string.Empty;
            var user = new SecVendor_User();
            string contactPerson = $"{contactPersonFirstName} {contactPersonLastName}";
            password = StringEncription.Encrypt(password, true);

            // Call the service method with correct casing and parameter passing
            var result = _vendorRegistrationService.VendorRegistrationDetailsService(
                businessName, contactPerson, vendorPhoneNumber, email, companyAddress, country,
                businessType, typeOfMaterial, tin, bin, generalDetailsServices, userName,
                password, status, vendor, out user);



            return Json(new { user, message }, JsonRequestBehavior.AllowGet);
        }



        public async Task<dynamic> GetSupportDoc()
        {
            var docProperties = new List<DSM_DocProperty>();
            string FromName = "VENDOCS";
            await Task.Run(() => _vendorRegistrationService.GetSupportDoc(UserID, FromName, out docProperties));
            return Json(new { docProperties, Msg = "" }, JsonRequestBehavior.AllowGet);
        }


        public async Task<dynamic> RegistrationCheck(string VendorID, string Email)
        {
            var Vendor = "";
            await Task.Run(() => _vendorRegistrationService.RegistrationCheckService(VendorID, Email, out Vendor));
            return Json(new { Vendor, Msg = "" }, JsonRequestBehavior.AllowGet);
        }

        public async Task<dynamic> GetVendorbyID(string VendorID, string Email)
        {
            var IndvVendorData = new List<VendorRegData>();

            await Task.Run(() => _vendorRegistrationService.GetVendorbyIDService(VendorID, Email, out IndvVendorData));
            return Json(new { IndvVendorData, Msg = "" }, JsonRequestBehavior.AllowGet);
        }

        public async Task<dynamic> ItemVendorcheck(string VendorID)
        {
            var Vendor2 = "";
            await Task.Run(() => _vendorRegistrationService.ItemVendorcheckService(VendorID, out Vendor2));
            return Json(new { Vendor2, Msg = "" }, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]

        public async Task<dynamic> VendorupdateRegistrationDetails(string BusinessName, string ContactPersonFirstName, string ContactPersonLastName, string VendorPhoneNumber,
           string CompanyAddress, string Country, string BusinessType, string TIN, string BIN, string GeneralDetailsServices, string Status, string Vendor, string UserName = null, string Password = null)
        {
            string resp_status = string.Empty, message = string.Empty;
            string ContactPerson = $"{ContactPersonFirstName} {ContactPersonLastName}";

            var user = new SecVendor_User();
            if (Password != null)
            {
                Password = StringEncription.Encrypt(Password, true);
            }
            else
            {
                UserName = "";
                Password = "";
            }
            var result = _vendorRegistrationService.VendorupdateRegistrationDetailsService(BusinessName, ContactPerson, VendorPhoneNumber,
                 CompanyAddress, Country, BusinessType, TIN, BIN, GeneralDetailsServices, Status, Vendor, UserName, Password, out user);

            return Json(new { user, message }, JsonRequestBehavior.AllowGet);
        }
        public async Task<dynamic> GetIdentificationAttributesForDocProperties(string _SelectedPropID)
        {
            List<DSM_DocPropIdentify> docPropIdentifies = new List<DSM_DocPropIdentify>();
            await Task.Run(() => _vendorRegistrationService.GetIdentificationAttributesForDocProperties(
                UserID, _SelectedPropID, out docPropIdentifies));

            return Json(docPropIdentifies, JsonRequestBehavior.AllowGet);
        }


        public async Task<dynamic> AddDocument(string UserId, string VendorId,
         string _selectedPropID, List<DocMetaValue> _docMetaValues)
        {
            BPS_NewBillReturnData objDocPropIdentifies = null;
            var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();

            if (ModelState.IsValid)
            {
                string UploaderIP = "172.16.189.34";

                respStatus.Message = "Success";

                respStatus = await Task.Run(() => _vendorRegistrationService.AddDocument(UserId, VendorId, UploaderIP,
                 _selectedPropID, _docMetaValues, out objDocPropIdentifies));


                var DistinctDocIDs1 = (from s in objDocPropIdentifies.DocInfo
                                       group s by new
                                       {
                                           s.DocumentID
                                       }
                                           into g
                                       select new
                                       {
                                           DocPropID = g.Select(p => p.DocPropertyID).FirstOrDefault(),
                                           DocPropertyName = g.Select(p => p.DocPropertyName).FirstOrDefault(),
                                           DocumentID = g.Select(p => p.DocumentID).FirstOrDefault(),
                                           BillTrackingNo = g.Select(p => p.BillTrackingNo).FirstOrDefault(),
                                           BillReceiveID = g.Select(p => p.BillReceiveID).FirstOrDefault(),
                                           BoothName = g.Select(p => p.BoothName).FirstOrDefault(),
                                           ReceivedBy = g.Select(p => p.ReceivedBy).FirstOrDefault(),
                                           FileCodeName = g.Select(p => p.FileCodeName).FirstOrDefault(),
                                           ServerIP = g.Select(p => p.ServerIP).FirstOrDefault(),
                                           ServerPort = g.Select(p => p.ServerPort).FirstOrDefault(),
                                           FtpUserName = g.Select(p => p.FtpUserName).FirstOrDefault(),
                                           FtpPassword = g.Select(p => p.FtpPassword).FirstOrDefault(),
                                           FileServerUrl = g.Select(x => x.FileServerUrl).FirstOrDefault(),
                                           NumberOfMissingDocuments = g.Select(x => x.NumberOfMissingDocuments).FirstOrDefault()
                                       }).ToList();

                List<DSM_DocProperty> proplList = new List<DSM_DocProperty>();
                string[] docPropIDs = _selectedPropID.Split(',');

                foreach (var item in docPropIDs)
                {
                    DSM_DocProperty objDocProperty = new DSM_DocProperty();
                    objDocProperty.DocPropertyID = item;

                    proplList.Add(objDocProperty);
                }


                var DistinctDocIDs = (from p in proplList
                                      join d in DistinctDocIDs1 on p.DocPropertyID equals d.DocPropID
                                      select new
                                      {
                                          DocPropID = d.DocPropID,
                                          DocPropertyName = d.DocPropertyName,
                                          DocumentID = d.DocumentID,
                                          BillTrackingNo = d.BillTrackingNo,
                                          BillReceiveID = d.BillReceiveID,
                                          BoothName = d.BoothName,
                                          ReceivedBy = d.ReceivedBy,
                                          FileCodeName = d.FileCodeName,
                                          ServerIP = d.ServerIP,
                                          ServerPort = d.ServerPort,
                                          FtpUserName = d.FtpUserName,
                                          FtpPassword = d.FtpPassword,
                                          FileServerUrl = d.FileServerUrl

                                      }).ToList();

                foreach (var item in DistinctDocIDs)
                {
                    try
                    {
                        FolderGenerator.MakeFTPDir(objDocPropIdentifies.DocInfo.FirstOrDefault().ServerIP,
                            objDocPropIdentifies.DocInfo.FirstOrDefault().ServerPort,
                            item.FileServerUrl,
                            objDocPropIdentifies.DocInfo.FirstOrDefault().FtpUserName,
                            objDocPropIdentifies.DocInfo.FirstOrDefault().FtpPassword);
                    }
                    catch (Exception e)
                    {


                    }

                }

                return Json(new
                {
                    Message = respStatus.Message,
                    ResponseCode = respStatus.ErrorCode,
                    DistinctID = DistinctDocIDs,
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                respStatus = new Utillity.ValidationResult("E404", "Not found");
                return Json(new { Message = respStatus.Message, respStatus }, JsonRequestBehavior.AllowGet);
            }


        }


        [HttpPost]
        public async Task<ActionResult> UploadOtherFiles(
    string serverIP,
    int ftpPort,
    string ftpUserName,
    string ftpPassword,
    string vendorId,
    string docType)
        {
            HttpPostedFileBase file = Request.Files["file"];

            string folder = docType == "TIN"
                ? "chqDivision/PharmaceuticalsDivision/VendorDocuments/SuportingDocuments/TIN"
                : "chqDivision/PharmaceuticalsDivision/VendorDocuments/SuportingDocuments/BIN";

            string ftpPath = $"ftp://{serverIP}:{ftpPort}/{folder}/{vendorId}.pdf";

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpPath);
            request.Credentials = new NetworkCredential(ftpUserName, ftpPassword);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.UseBinary = true;

            using (var stream = request.GetRequestStream())
            {
                await file.InputStream.CopyToAsync(stream);
            }

            return new HttpStatusCodeResult(200);
        }


        [HttpGet]
        public JsonResult GetBusinessTypeList()
        {
            var data = _vendorRegistrationService.GetBusinessTypeList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetBusinessNatureList()
        {
            var data = _vendorRegistrationService.GetBusinessNatureList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}