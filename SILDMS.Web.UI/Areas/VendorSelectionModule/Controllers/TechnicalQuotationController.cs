using Antlr.Runtime.Misc;
using SILDMS.Model.CBPSModule;
using SILDMS.Model.DocScanningModule;
using SILDMS.Model.VendorSelectionModule;
using SILDMS.Service.AutoValueSetup;
using SILDMS.Service.TechnicalQuotation;
using SILDMS.Utillity;
using SILDMS.Web.UI.Areas.SecurityModule;
using SILDMS.Web.UI.Areas.SecurityModule.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SILDMS.Web.UI.Areas.VendorSelectionModule.Controllers
{
    public class TechnicalQuotationController : Controller
    {
        private readonly ITechnicalQuotationService _technicalQuotationService;
        private readonly string UserID = string.Empty;
        private ValidationResult respStatus = new ValidationResult();
        private readonly IAutoValueSetupService _autoValueSetupService;
        private string action = "";

        public TechnicalQuotationController(ITechnicalQuotationService technicalQuotationService, IAutoValueSetupService autoValueSetupService)
        {
            _technicalQuotationService = technicalQuotationService;
            _autoValueSetupService = autoValueSetupService;
            UserID = SILAuthorization.GetUserID();

        }


        [Authorize]
        public ActionResult Index()
        {
            return View();
        }


        [Authorize]
        public async Task<dynamic> loadItemType(string masterDataType)
        {
            
            var itemTypes = new List<SILDMS.Model.CBPSModule.Sys_MasterData>();
            await Task.Run(() => _technicalQuotationService.GetAllItemTypes(masterDataType, out itemTypes));
            var result = itemTypes.Select(x => new
            {
                x.MasterDataID,
                x.MasterDataValue
            }).ToList();
            return Json(new { result, msg = "" }, JsonRequestBehavior.AllowGet);
        }









        [Authorize]
        public async Task<dynamic> GetAllInvitation()
        {
            var InvitationList = new List<Invitation>();
            await Task.Run(() => _technicalQuotationService.GetAllInvitationService(UserID, out InvitationList));
            return Json(new { InvitationList, Msg = "" }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public async Task<dynamic> InvWiseMaterial(string InvNumber)
        {
            var InvMaterialList = new List<MaterialInvitation>();
            await Task.Run(() => _technicalQuotationService.InvWiseMaterialService(UserID, InvNumber, out InvMaterialList));
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

                //var _docPropIdentifyIDs = string.Join(",", _docMetaValues.Select(x => x.DocPropIdentifyID));

                //_modelDocumentsInfo.ConfigureColumnIds = _autoValueSetupService.GetConfigureColumnList
                //    ("/cbpsModule/BillReceive", _modelDocumentsInfo.OwnerID,
                //        null, null, null, null);
                //respStatus.Message = "Success";

                respStatus = await Task.Run(() => _technicalQuotationService.AddDocumentInfo(
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
                //string[] docPropIDs = _selectedPropID.Split(',');

                //foreach (var item in docPropIDs)
                //{
                //    DSM_DocProperty objDocProperty = new DSM_DocProperty();
                //    objDocProperty.DocPropertyID = item;

                //    proplList.Add(objDocProperty);
                //}


                //var DistinctDocIDs = (from p in proplList
                //                      join d in DistinctDocIDs1 on p.DocPropertyID equals d.DocPropID
                //                      select new
                //                      {
                //                          DocPropID = d.DocPropID,
                //                          DocPropertyName = d.DocPropertyName,
                //                          DocumentID = d.DocumentID,
                //                          BillTrackingNo = d.BillTrackingNo,
                //                          BillReceiveID = d.BillReceiveID,
                //                          BoothName = d.BoothName,
                //                          ReceivedBy = d.ReceivedBy,
                //                          FileCodeName = d.FileCodeName,
                //                          ServerIP = d.ServerIP,
                //                          ServerPort = d.ServerPort,
                //                          FtpUserName = d.FtpUserName,
                //                          FtpPassword = d.FtpPassword,
                //                          FileServerUrl = d.FileServerUrl,
                //                          NumberOfMissingDocuments = d.NumberOfMissingDocuments

                //                      }).ToList();

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

        public async Task<dynamic> submitquotation(string InvId, string VendorID, string InvitationNumber,string MaterialCode,string MaterialName)
        {
            var QuotationList = new List<Quotation>();
            await Task.Run(() => _technicalQuotationService.submitquotationService(UserID, InvId, VendorID, InvitationNumber, MaterialCode, MaterialName, out QuotationList));
            return Json(new { QuotationList, Msg = "" }, JsonRequestBehavior.AllowGet);
        }

        public async Task<dynamic> submittechnicalquotation(
              TechnicalQuotation TechnicalQuotationlist,
   SimplifiedMaterialInvitation MaterialInvitationlist,
    Quotation Quotation)

        {
            //TechnicalQuotation TechnicalQuotation = new TechnicalQuotation();
            //MaterialInvitation MaterialInvitation = new MaterialInvitation();
            int ID = 0;
            var QuotationList = new List<Quotation>();
            await Task.Run(() => _technicalQuotationService.submittechnicalquotationservice(UserID, TechnicalQuotationlist, MaterialInvitationlist, Quotation, out ID));
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
            await Task.Run(() => _technicalQuotationService.GetAllQuotationService(UserID, out AllQuotation));
            return Json(new { AllQuotation, Msg = "" }, JsonRequestBehavior.AllowGet);
        }



        [Authorize]
        public async Task<dynamic> QuotWiseMaterial(string QuotationNo)
        {
            var AllQuotation = new List<MaterialInvitation>();
            await Task.Run(() => _technicalQuotationService.QuotWiseMaterialService(QuotationNo, out AllQuotation));
            return Json(new { AllQuotation, Msg = "" }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public async Task<dynamic> TechQuotwiseDetails(string TechQuotationItemID)
        {
            var TechnicalQuotationList = new List<TechnicalQuotation>();
            await Task.Run(() => _technicalQuotationService.TechQuotwiseDetailsService(TechQuotationItemID, out TechnicalQuotationList));
            return Json(new { TechnicalQuotationList, Msg = "" }, JsonRequestBehavior.AllowGet);
        }


        [Authorize]
        public async Task<dynamic> FetchServerDetails(string BillReceiveID)
        {
            var ServerList = new Server();
            await Task.Run(() => _technicalQuotationService.FetchServerDetailsService(BillReceiveID, out ServerList));
            return Json(new { ServerList, Msg = "" }, JsonRequestBehavior.AllowGet);
        }


        [Authorize]
        public async Task<dynamic> SaveTechQuotwiseDetails(TechnicalQuotation technicalQuotation)
        {
            long ID = 0;
            await Task.Run(() => _technicalQuotationService.SaveTechQuotwiseDetailsService(technicalQuotation, out ID));
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
        public async Task<dynamic> GetMaterialDocStatus(string MaterialCode, string BiddingID, string VendorCode)
        {
            var document = new DSM_Documents();
            bool docStatus = true;
            await Task.Run(() => _technicalQuotationService.GetMaterialDocStatus(out document, out docStatus, MaterialCode, BiddingID, VendorCode));
            return Json(new { document, docStatus, Msg = "" }, JsonRequestBehavior.AllowGet);
        }


        public async Task<dynamic> UploadOtherFiles(string serverIP, string ftpPort, string ftpUserName, string ftpPassword, string serverURL, string documentID, string Ext)
        {
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase file = files[0];

            try
            {
                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create("ftp://" + serverIP + "/" + serverURL + "/" + documentID + "." + Ext);
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

        public async Task<FileResult> DownloadDocument(string documentID, string Ext)
        {

            var ServerList = new Server();

            await Task.Run(() => _technicalQuotationService.FetchServerDetailsService(documentID, out ServerList));

            string userName = ServerList.FtpUserName;
            string password = ServerList.FtpPassword;
            string serverIP = ServerList.ServerIP;
            string serverURL = ServerList.FileServerURL;
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
        public async Task<dynamic> UpdateExtensionByDocId(string DocumentID, string Extension)
        {

            string ID = "";
            await Task.Run(() => _technicalQuotationService.UpdateExtensionByDocIdService(DocumentID, Extension, out ID));

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



        //public async Task<FileResult> DownloadDocument(string documentID, string Ext)
        //{

        //    var ServerList = new Server();

        //    await Task.Run(() => _technicalQuotationService.FetchServerDetailsService(documentID, out ServerList));

        //    string userName = ServerList.FtpUserName;
        //    string password = ServerList.FtpPassword;
        //    string serverIP = ServerList.ServerIP;
        //    string serverURL = ServerList.FileServerURL;
        //    using (WebClient request = new WebClient())
        //    {
        //        if (Ext == "")
        //        {
        //            Ext = "pdf";
        //        }

        //        request.Credentials = new NetworkCredential(userName, password);

        //        string fullUrl = "ftp://" + serverIP + "/" + serverURL + "/" + documentID + "." + Ext;
        //        byte[] fileData = request.DownloadData(fullUrl);

        //        var cd = new System.Net.Mime.ContentDisposition
        //        {
        //            FileName = documentID + "." + Ext,
        //            Inline = false,
        //        };

        //        Response.AppendHeader("Content-Disposition", cd.ToString());
        //        return File(fileData, "application / " + Ext);
        //    }
        //}

        //public async Task<FileResult> DownloadDocument2(string documentID, string Ext)
        //{

        //    var document = new DSM_Documents();
        //    bool docStatus = true;
        //    await Task.Run(() => _technicalQuotationService.GetMaterialDocStatus(out document, out docStatus, documentID));

        //    string userName = document.FtpUserName;
        //    string password = document.FtpPassword;
        //    string serverIP = document.ServerIP;
        //    string serverURL = document.FileServerURL;
        //    using (WebClient request = new WebClient())
        //    {
        //        if (Ext == "")
        //        {
        //            Ext = "pdf";
        //        }

        //        request.Credentials = new NetworkCredential(userName, password);

        //        string fullUrl = "ftp://" + serverIP + "/" + serverURL + "/" + documentID + "." + Ext;
        //        byte[] fileData = request.DownloadData(fullUrl);

        //        var cd = new System.Net.Mime.ContentDisposition
        //        {
        //            FileName = documentID + "." + Ext,
        //            Inline = false,
        //        };

        //        Response.AppendHeader("Content-Disposition", cd.ToString());
        //        return File(fileData, "application / " + Ext);
        //    }
        //}

        [Authorize]
        public async Task<dynamic> Itemlist()
        {
            var ItemList = new List<Item>();
            await Task.Run(() => _technicalQuotationService.ItemlistService(out ItemList));
            return Json(new { ItemList, Msg = "" }, JsonRequestBehavior.AllowGet);
        }





    }
}