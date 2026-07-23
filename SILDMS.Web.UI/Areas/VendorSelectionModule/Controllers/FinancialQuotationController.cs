using SILDMS.Model.CBPSModule;
using SILDMS.Model.DocScanningModule;
using SILDMS.Model.VendorSelectionModule;
using SILDMS.Service.AutoValueSetup;
using SILDMS.Service.TechnicalQuotation;
using SILDMS.Utillity;
using SILDMS.Web.UI.Areas.SecurityModule.Models;
using SILDMS.Web.UI.Areas.SecurityModule;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SILDMS.Service.FinancialQuotation;

namespace SILDMS.Web.UI.Areas.VendorSelectionModule.Controllers
{
    public class FinancialQuotationController : Controller
    {
        private readonly IFinancialQuotationService _financialQuotationService;
        private readonly string UserID = string.Empty;
        private ValidationResult respStatus = new ValidationResult();
        private readonly IAutoValueSetupService _autoValueSetupService;
        private string action = "";

        public FinancialQuotationController(IFinancialQuotationService financialQuotationService, IAutoValueSetupService autoValueSetupService)
        {
            _financialQuotationService = financialQuotationService;
            _autoValueSetupService = autoValueSetupService;
            UserID = SILAuthorization.GetUserID();

        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }


        [Authorize]
        public async Task<dynamic> GetAllInvitation()
        {
            var InvitationList = new List<Invitation>();
            await Task.Run(() => _financialQuotationService.GetAllInvitationService(UserID, out InvitationList));
            return Json(new { InvitationList, Msg = "" }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public async Task<dynamic> InvWiseMaterial(string InvNumber)
        {
            var InvMaterialList = new List<MaterialInvitation>();
            await Task.Run(() => _financialQuotationService.InvWiseMaterialService(UserID, InvNumber, out InvMaterialList));
            return Json(new { InvMaterialList, Msg = "" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [Authorize]
        [SILLogAttribute]
        public async Task<dynamic> AddDocumentInfo(DocumentsInfo _modelDocumentsInfo,
                  string _selectedPropID = null, List<DocMetaValue> _docMetaValues = null)
        {

            BPS_NewBillReturnData objDocPropIdentifies = null;

            if (ModelState.IsValid)
            {
                action = "add";
                _modelDocumentsInfo.SetBy = UserID;
                _modelDocumentsInfo.ModifiedBy = _modelDocumentsInfo.SetBy;
                _modelDocumentsInfo.UploaderIP = GetIPAddress.LocalIPAddress();

                

                respStatus = await Task.Run(() => _financialQuotationService.AddDocumentInfo(
                    _modelDocumentsInfo, _selectedPropID, _docMetaValues, action,
                    out objDocPropIdentifies));


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
               

                foreach (var item in DistinctDocIDs1)
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
                    DistinctID = DistinctDocIDs1,
                    HeaderInfo = objDocPropIdentifies.DocHeaderInfo
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //respStatus = new ValidationResult("E404", _localizationService.GetResource("E404"));
                return Json(new { Message = respStatus.Message, respStatus }, JsonRequestBehavior.AllowGet);
            }


        }




        [HttpPost]
        [Authorize]

        public async Task<dynamic> submitquotation(string InvId, string VendorID, string InvitationNumber)
        {
            var QuotationList = new List<Quotation>();
            await Task.Run(() => _financialQuotationService.submitquotationService(InvId, VendorID, InvitationNumber, out QuotationList));
            return Json(new { QuotationList, Msg = "" }, JsonRequestBehavior.AllowGet);
        }

        public async Task<dynamic> submitfinancialquotation(FinancialQuotationDetail FinancialQuotationlist, SimplifiedMaterialInvitation MaterialInvitationlist, string ProposalType, Quotation Quotation)
        {
            int ID = 0;
            var QuotationList = new List<Quotation>();
            await Task.Run(() => _financialQuotationService.submitfinancialquotationservice(UserID, FinancialQuotationlist, MaterialInvitationlist, ProposalType, Quotation, out ID));
            if (ID > 0)
            {
                respStatus.Message = "Data Saved Successfully";
                return Json(new
                {
                    respStatus,
                    Msg = ""
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                respStatus.Message = "Error Found";
                return Json(new
                {
                    respStatus,
                    Msg = ""
                }, JsonRequestBehavior.AllowGet);
            }

        }


        [Authorize]
        public async Task<dynamic> GetAllQuotation()
        {
            var AllQuotation = new List<Quotation>();
            await Task.Run(() => _financialQuotationService.GetAllQuotationService(UserID, out AllQuotation));
            return Json(new { AllQuotation, Msg = "" }, JsonRequestBehavior.AllowGet);
        }



        [Authorize]
        public async Task<dynamic> QuotWiseMaterial(string QuotationNo)
        {
            var AllQuotation = new List<MaterialInvitation>();
            await Task.Run(() => _financialQuotationService.QuotWiseMaterialService(UserID, QuotationNo, out AllQuotation));
            return Json(new { AllQuotation, Msg = "" }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public async Task<dynamic> FinQuotwiseDetails(string FinanQuotationItemID)
        {
            var FinancialQuotationDetailList = new List<FinancialQuotationDetail>();
            await Task.Run(() => _financialQuotationService.FinQuotwiseDetailsService(FinanQuotationItemID, out FinancialQuotationDetailList));
            return Json(new { FinancialQuotationDetailList, Msg = "" }, JsonRequestBehavior.AllowGet);
        }


        [Authorize]
        public async Task<dynamic> FetchServerDetails(string BillReceiveID)
        {
            var ServerList = new Server();
            await Task.Run(() => _financialQuotationService.FetchServerDetailsService(BillReceiveID, out ServerList));
            return Json(new { ServerList, Msg = "" }, JsonRequestBehavior.AllowGet);
        }


        [Authorize]
        public async Task<dynamic> SaveFinQuotwiseDetails(FinancialQuotationDetail financialQuotation)
        {
            long ID = 0;
            await Task.Run(() => _financialQuotationService.SaveFinQuotwiseDetailsService(financialQuotation, out ID));
            if (ID > 0)
            {
                respStatus.Message = "Data Updated Successfully";
                return Json(new
                {
                    respStatus,
                    Msg = ""
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                respStatus.Message = "Error Found";
                return Json(new
                {
                    respStatus,
                    Msg = ""
                }, JsonRequestBehavior.AllowGet);
            }
        }


        [Authorize]
        public async Task<dynamic> GetMaterialDocStatus(string MaterialCode)
        {
            var document = new DSM_Documents();
            bool docStatus = true;
            await Task.Run(() => _financialQuotationService.GetMaterialDocStatus(out document, out docStatus, MaterialCode));
            return Json(new { document, docStatus, Msg = "" }, JsonRequestBehavior.AllowGet);
        }


        public async Task<dynamic> UploadOtherFiles(string serverIP, string ftpPort, string ftpUserName, string ftpPassword, string serverURL, string documentID, string Ext)
        {
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase file = files[0];

            var safeFileName = documentID.Replace("/", "_");

            try
            {
                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create("ftp://" + serverIP + "/" + serverURL + "/" + safeFileName + "." + Ext);
                ftp.Credentials = new NetworkCredential(ftpUserName, ftpPassword);
                ftp.Proxy = null;
                ftp.KeepAlive = true;
                ftp.UseBinary = true;
                ftp.Method = WebRequestMethods.Ftp.UploadFile;
                Stream ftpstream = ftp.GetRequestStream();

                byte[] data;
                using (Stream inputStream = file.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }

                    data = memoryStream.ToArray();
                }

                await ftpstream.WriteAsync(data, 0, data.Length);
                ftpstream.Close();

                return new HttpStatusCodeResult(200, "OK!");
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(500, "OK!");
            }
        }

       


        private string GetMimeType(string ext)
        {
            switch (ext)
            {
                case "pdf": return "application/pdf";
                case "mp4": return "video/mp4";
                case "mp3": return "audio/mpeg";
                case "jpg":
                case "jpeg": return "image/jpeg";
                case "png": return "image/png";
                case "gif": return "image/gif";
                case "docx": return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                case "xlsx": return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                case "zip": return "application/zip";
                default: return "application/octet-stream";
            }
        }








        public FileResult DownloadDocumentfromMat(
        string documentID,
        string serverIP,
        string serverURL,
        string ftpPort,
        string ftpUserName,
        string ftpPassword)
        {
            string safeDocumentID = documentID.Replace("/", "_");

            string fullUrl =
                "ftp://" + serverIP +
                "/" + serverURL +
                "/" + safeDocumentID + ".pdf";

            byte[] fileData;

            using (WebClient request = new WebClient())
            {
                request.Credentials =
                    new NetworkCredential(
                        ftpUserName,
                        ftpPassword);

                fileData = request.DownloadData(fullUrl);
            }

            Response.Clear();

            Response.Buffer = true;

            Response.ContentType = "application/pdf";

            Response.AddHeader(
                "Content-Disposition",
                "inline; filename=" + safeDocumentID + ".pdf");

            return File(fileData, "application/pdf");
        }


        [Authorize]
        public async Task<dynamic> UpdateExtensionByDocId(string DocumentID, string Extension)
        {

            string ID = "";
            await Task.Run(() => _financialQuotationService.UpdateExtensionByDocIdService(DocumentID, Extension, out ID));

            if (ID != "")
            {
                respStatus.Message = "Data Updated Successfully";
                return Json(new
                {
                    respStatus,
                    Msg = ""
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                respStatus.Message = "Error Found";
                return Json(new
                {
                    respStatus,
                    Msg = ""
                }, JsonRequestBehavior.AllowGet);
            }
        }


        public async Task<FileResult> DownloadDocument2(string documentID, string Ext)
        {

            var document = new DSM_Documents();
            bool docStatus = true;
            await Task.Run(() => _financialQuotationService.GetMaterialDocStatus(out document, out docStatus, documentID));

            string userName = document.FtpUserName;
            string password = document.FtpPassword;
            string serverIP = document.ServerIP;
            string serverURL = document.FileServerURL;
            using (WebClient request = new WebClient())
            {
                if (Ext == "")
                {
                    Ext = "pdf";
                }

                request.Credentials = new NetworkCredential(userName, password);

                string fullUrl = "ftp://" + serverIP + "/" + serverURL + "/" + documentID + "." + Ext;
                byte[] fileData = request.DownloadData(fullUrl);

                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = documentID + "." + Ext,
                    Inline = false,
                };

                Response.AppendHeader("Content-Disposition", cd.ToString());
                return File(fileData, "application / " + Ext);
            }
        }

        [Authorize]
        public async Task<dynamic> Itemlist()
        {
            var ItemList = new List<Item>();
            await Task.Run(() => _financialQuotationService.ItemlistService(out ItemList));
            return Json(new { ItemList, Msg = "" }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpPost]
        public async Task<dynamic> DeleteFinquot(string FinanQuotationItemID)
        {
            bool isDeleted = false;

            await Task.Run(() =>
                _financialQuotationService.DeleteFinquot(
                    FinanQuotationItemID, out isDeleted)
            );

            if (isDeleted)
            {
                respStatus.Message = "Data Deleted Successfully";
                return Json(new
                {
                    Success = true,
                    respStatus,
                    Msg = ""
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                respStatus.Message = "Error Found";
                return Json(new
                {
                    Success = false,
                    respStatus,
                    Msg = ""
                }, JsonRequestBehavior.AllowGet);
            }
        }






        [HttpPost]
        public JsonResult GetDocumentsByDocumentID(string documentID)
        {
            if (string.IsNullOrWhiteSpace(documentID))
                return Json(new { success = false, message = "Missing document id." });

            List<MaterialDocumentInfo> documents;
            var result = _financialQuotationService.GetDocumentsByDocumentIdService(documentID, out documents);

   

            return Json(new { success = true, documents });
        }




        private static readonly Dictionary<string, string> ViewableMimeTypes =
    new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        { ".pdf", "application/pdf" },
        { ".jpg", "image/jpeg" },
        { ".jpeg", "image/jpeg" },
        { ".png", "image/png" },
        { ".doc", "application/msword" },
        { ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
        { ".xls", "application/vnd.ms-excel" },
        { ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" }
    };

        [HttpGet]
        public async Task<ActionResult> ViewDocument(string documentID)
        {
            MaterialDocumentInfo existing;
            var lookup = _financialQuotationService.GetDocumentByIdService(documentID, out existing);
            if (lookup != ValidationResult.Success || existing == null)
                return HttpNotFound();

            // mp4 (and anything else you don't want inline-previewed) is
            // download-only — no inline view, by design.
            if (string.Equals(existing.FileExtension, ".mp4", StringComparison.OrdinalIgnoreCase))
                return new HttpStatusCodeResult(400, "This file type is download-only.");

            // TODO: ownership check goes here.

            string ftpUri = $"ftp://{existing.ServerIP}/{existing.FileServerUrl}/{existing.DocumentID}{existing.FileExtension}";
            byte[] bytes = await DownloadFromFtp(ftpUri, existing.FtpUserName, existing.FtpPassword);
            if (bytes == null) return new HttpStatusCodeResult(500, "Failed to load document.");

            string mimeType;
            if (!ViewableMimeTypes.TryGetValue(existing.FileExtension ?? "", out mimeType))
                mimeType = "application/octet-stream";

            return File(bytes, mimeType); // no filename -> inline, not attachment
        }


        [HttpGet]
        public async Task<ActionResult> DownloadDocument(string documentID, string materialName)
        {
            MaterialDocumentInfo existing;
            var lookup = _financialQuotationService.GetDocumentByIdService(documentID, out existing);
            if (lookup != ValidationResult.Success || existing == null)
                return HttpNotFound();

            // TODO: ownership check goes here — return new HttpStatusCodeResult(403) if it fails.

            string ftpUri = $"ftp://{existing.ServerIP}/{existing.FileServerUrl}/{existing.DocumentID}{existing.FileExtension}";
            byte[] bytes = await DownloadFromFtp(ftpUri, existing.FtpUserName, existing.FtpPassword);
            if (bytes == null) return new HttpStatusCodeResult(500, "Download failed");

            var invalid = Path.GetInvalidFileNameChars();
            string safeName = string.Join("_", (existing.FileOriginalName ?? "Document").Split(invalid));

            return File(bytes, "application/octet-stream", safeName + existing.FileExtension);
        }




        private async Task<byte[]> DownloadFromFtp(string uri, string user, string pass)
        {
            try
            {
                var req = (FtpWebRequest)FtpWebRequest.Create(uri);
                req.Credentials = new NetworkCredential(user, pass);
                req.Method = WebRequestMethods.Ftp.DownloadFile;
                using (var resp = (FtpWebResponse)await req.GetResponseAsync())
                using (var respStream = resp.GetResponseStream())
                using (var ms = new MemoryStream())
                {
                    await respStream.CopyToAsync(ms);
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError("FTP download failed: " + ex);
                return null;
            }
        }

    }
}