using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using iTextSharp.text;
using SILDMS.Model.DocScanningModule;
//using SILDMS.Model.LCModule;
using SILDMS.Service.AutoValueSetup;
using SILDMS.Service.DocProperty;
using SILDMS.Service.MultiDocScan;
using SILDMS.Service.OwnerProperIdentity;
using SILDMS.Utillity;
using SILDMS.Utillity.Localization;
using SILDMS.Web.UI.Areas.SecurityModule;
using SILDMS.Web.UI.Areas.SecurityModule.Models;
using static System.Net.WebRequestMethods;

namespace SILDMS.Web.UI.Areas.DocScanningModule.Controllers
{
   
    public class MultiDocScanController : Controller
    {
        private readonly IMultiDocScanService _multiDocScanService;
        private readonly IOwnerProperIdentityService _ownerProperIdentityService;
        private readonly IAutoValueSetupService _autoValueSetupService;
        
        private readonly IDocPropertyService _docPropertyService;
        private readonly ILocalizationService _localizationService;
        private ValidationResult respStatus = new ValidationResult();
        private readonly string UserID = string.Empty;
        
        private string action = "";


        public MultiDocScanController(IMultiDocScanService multiDocScanService, IOwnerProperIdentityService ownerProperIdentityRepository,
            IDocPropertyService docPropertyService,IAutoValueSetupService autoValueSetupService, ILocalizationService localizationService)
        {
            _multiDocScanService = multiDocScanService;
            _ownerProperIdentityService = ownerProperIdentityRepository;
            _docPropertyService = docPropertyService;
            _localizationService = localizationService;
            _autoValueSetupService = autoValueSetupService;
            UserID = SILAuthorization.GetUserID();
        }

        [SILAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<dynamic> GetDocPropIdentityForSelectedDocTypes(string _OwnerID, string _DocCategoryID,
             string _DocTypeID, string _SelectedPropID)
        {
            var SelectedPropID = _SelectedPropID.Split(',').Select(x => x).ToList();

            List<DSM_DocPropIdentify> objDocPropIdentifies = null;
            List<DSM_DocProperty> objDocPropertyList = null;
            

            await Task.Run(() => _ownerProperIdentityService.GetDocPropIdentify
                (UserID, "", out objDocPropIdentifies));

            await Task.Run(() => _docPropertyService.GetDocProperty
                ("", UserID, out objDocPropertyList));

            var result = (from dpi in objDocPropIdentifies.AsEnumerable()
                where dpi.OwnerID == _OwnerID & dpi.DocCategoryID == _DocCategoryID &
                      dpi.DocTypeID == _DocTypeID & dpi.Status == 1 &
                      SelectedPropID.Contains(dpi.DocPropertyID)

                join dp in objDocPropertyList on dpi.DocPropertyID equals dp.DocPropertyID

                orderby dp.SerialNo 
                select new DSM_DocPropIdentify
                {
                    DocPropIdentifyID = dpi.DocPropIdentifyID,
                    DocPropertyID = dpi.DocPropertyID,
                    DocPropertyName = dp.DocPropertyName,
                    //DocTypeID = dpi.DocTypeID,
                    //DocCategoryID = dpi.DocCategoryID,
                    //OwnerID = dpi.OwnerID,
                    //IdentificationCode = dpi.IdentificationCode,
                    //IdentificationSL = dpi.IdentificationSL,
                    IdentificationAttribute = dpi.IdentificationAttribute,
                    //AttributeGroup = dpi.AttributeGroup,
                    IsRequired = dpi.IsRequired,
                    IsAuto = dpi.IsAuto,
                    //Remarks = dpi.Remarks,
                    Status = dpi.Status,
                    IsRestricted = dpi.IsRequired
                }).ToList();

            return Json(new { Msg = "", result }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public async Task<dynamic> GetDocumentProperty(string _DocCategoryID,
            string _OwnerID, string _DocTypeID)
        {
            List<DSM_DocProperty> objDsmDocProperties = null;
            List<DSM_DocPropIdentify> objDocPropIdentifies = null;

            await Task.Run(() => _docPropertyService.GetDocProperty("", UserID, out objDsmDocProperties));
            await Task.Run(() => _ownerProperIdentityService.GetDocPropIdentify(UserID, "", out objDocPropIdentifies));

            var joinResult = (from dp in objDsmDocProperties
                where dp.OwnerID == _OwnerID & dp.DocCategoryID == _DocCategoryID &
                      dp.DocTypeID == _DocTypeID & dp.Status == 1

                join dpi in objDocPropIdentifies on dp.DocPropertyID equals dpi.DocPropertyID into docPropIdentities
                from dpi in docPropIdentities.DefaultIfEmpty()

                select new
                {
                    DocPropertyID = dp.DocPropertyID,
                    DocPropertyName = dp.DocPropertyName,
                    IsSelected = false
                }).ToList();

            var result = (from s in joinResult
                          group s by new
                          {
                              s.DocPropertyID
                          }
                              into g
                              select new
                              {
                                  DocPropertyID = g.Select(p => p.DocPropertyID).FirstOrDefault(),
                                  DocPropertyName = g.Select(x => x.DocPropertyName).FirstOrDefault(),
                                  IsSelected = false
                              }).ToList();

            
            return Json(new { Msg = "", result }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize]
        [SILLogAttribute]
        public async Task<dynamic> AddDocumentInfo(DocumentsInfo _modelDocumentsInfo, string _selectedPropID, List<DocMetaValue> _docMetaValues)
        {
            List<DSM_DocPropIdentify> objDocPropIdentifies = null;

            if (ModelState.IsValid)
            {
                action = "add";
                _modelDocumentsInfo.SetBy = UserID;
                _modelDocumentsInfo.ModifiedBy = _modelDocumentsInfo.SetBy;
                _modelDocumentsInfo.UploaderIP = GetIPAddress.LocalIPAddress();

                var _docPropIdentifyIDs = string.Join(",", _docMetaValues.Select(x => x.DocPropIdentifyID));

                _modelDocumentsInfo.ConfigureColumnIds = _autoValueSetupService.GetConfigureColumnList
                    ("/Home/DocumentScanning", _modelDocumentsInfo.Owner.OwnerID,
                        _modelDocumentsInfo.DocCategory.DocCategoryID,
                        _modelDocumentsInfo.DocType.DocTypeID,
                        _selectedPropID, _docPropIdentifyIDs);

                respStatus.Message = "Success";
                respStatus = await Task.Run(() => _multiDocScanService.AddDocumentInfo(
                    _modelDocumentsInfo, _selectedPropID, _docMetaValues, action,
                    out objDocPropIdentifies));

                var DistinctDocIDs1 = (from s in objDocPropIdentifies
                    group s by new
                    {
                        s.DocumentID
                    }
                    into g
                    select new
                    {
                        DocPropID = g.Select(p => p.DocPropertyID).FirstOrDefault(),
                        DocumentID = g.Select(p => p.DocumentID).FirstOrDefault(),
                        FileCodeName = g.Select(p => p.FileCodeName).FirstOrDefault(),
                        FileServerUrl = g.Select(x => x.FileServerUrl).FirstOrDefault()
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
                        DocumentID = d.DocumentID,
                        FileCodeName = d.FileCodeName,
                        FileServerUrl = d.FileServerUrl
                    }).ToList();

                foreach (var item in DistinctDocIDs)
                {
                    try
                    {
                        FolderGenerator.MakeFTPDir(objDocPropIdentifies.FirstOrDefault().ServerIP,
                            objDocPropIdentifies.FirstOrDefault().ServerPort,
                            item.FileServerUrl,
                            objDocPropIdentifies.FirstOrDefault().FtpUserName,
                            objDocPropIdentifies.FirstOrDefault().FtpPassword);
                    }
                    catch (Exception e)
                    {

                    }
                }

                return Json(new
                {
                    Message = respStatus.Message,
                    result = objDocPropIdentifies,
                    DistinctID = DistinctDocIDs
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //var errors = ModelState.Values.SelectMany(v => v.Errors);
                respStatus = new ValidationResult("E404", _localizationService.GetResource("E404"));
                return Json(new { Message = respStatus.Message, respStatus }, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<dynamic> DeleteDocumentInfo(string _DocumentIDs)
        {
            respStatus = await Task.Run(() => _multiDocScanService.DeleteDocumentInfo(_DocumentIDs));
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public async Task<dynamic> DownloadMergedDocument(List<LC_Document> documentList)
        //{
        //    HttpResponseMessage response = null;

        //    //string serverIP, serverPort, ftpUserName, ftpPassword, serverURL, documentID;
        //    bool allFileExist = false;
        //    string fileName, fileExtension;
        //    byte[] documentContent = null;
        //    List<byte[]> documentContentCollection = null;

        //    try
        //    {
        //        string[] fileInfoCollection = null;
        //        List<string> fileNameCollection = new List<string>();

        //        foreach (var item in documentList)
        //        {
        //            if
        //            (
        //                !string.IsNullOrEmpty(item.ServerIP) && //!string.IsNullOrEmpty(item.ServerPort) &&
        //                !string.IsNullOrEmpty(item.FtpUserName) && !string.IsNullOrEmpty(item.FtpPassword) &&
        //                !string.IsNullOrEmpty(item.FileServerURL) && !string.IsNullOrEmpty(item.DocumentID)
        //            )
        //            {
        //                using (WebClient webClient = new WebClient())
        //                {
        //                    //need to optimize server call

        //                    webClient.Credentials = new NetworkCredential(item.FtpUserName, item.FtpPassword);

        //                    FtpWebRequest ftpWebRequest = (FtpWebRequest)FtpWebRequest.Create("ftp://" + item.ServerIP + "/" + item.FileServerURL + "/");
        //                    ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
        //                    ftpWebRequest.Credentials = new NetworkCredential(item.FtpUserName, item.FtpPassword);
        //                    ftpWebRequest.UsePassive = true;
        //                    ftpWebRequest.UseBinary = true;
        //                    ftpWebRequest.KeepAlive = false;

        //                    using (FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse())
        //                    {
        //                        using (StreamReader streamReader = new StreamReader(ftpWebResponse.GetResponseStream()))
        //                        {
        //                            fileInfoCollection = streamReader.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        //                            for (int i = 0; i < fileInfoCollection.Length; i++)
        //                            {
        //                                string[] fileInfoCollectionTemp = fileInfoCollection[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        //                                for (int j = 0; j < fileInfoCollectionTemp.Length; j++)
        //                                {
        //                                    if (fileInfoCollectionTemp[j].Contains("."))
        //                                    {
        //                                        fileNameCollection.Add(fileInfoCollectionTemp[j]);
        //                                    }
        //                                }
        //                            }

        //                            if (fileNameCollection.Count > 0)
        //                            {
        //                                for (int i = 0; i < fileNameCollection.Count; i++)
        //                                {
        //                                    if (fileNameCollection[i].Contains(item.DocumentID))
        //                                    {
        //                                        documentContent = webClient.DownloadData("ftp://" + item.ServerIP + "/" + item.FileServerURL + "/" + fileNameCollection[i]);
        //                                        documentContentCollection.Add(documentContent);
        //                                    }
        //                                }

        //                                if (documentList.Count == documentContentCollection.Count)
        //                                {
        //                                    allFileExist = true;
        //                                }
        //                            }
        //                        }

        //                        if (allFileExist == true)
        //                        {
        //                            //need to assign name
        //                            string fileIdentifier = "ABC" + ".pdf";

        //                            response = new HttpResponseMessage(HttpStatusCode.OK);
        //                            response.Content = new ByteArrayContent(documentContent);

        //                            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
        //                            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        //                            response.Content.Headers.ContentLength = documentContent.Length;
        //                            response.Content.Headers.ContentDisposition.FileName = fileIdentifier;
        //                            response.Content.Headers.Add("ResponseCode", "S200");
        //                            response.Content.Headers.Add("Message", "Download successful.");

        //                            return response;
        //                        }
        //                        else
        //                        {
        //                            response = new HttpResponseMessage(HttpStatusCode.NotFound);
        //                            response.Content = new StringContent("", Encoding.UTF8, "application/json");
        //                            response.Content.Headers.Add("ResponseCode", "E200");
        //                            response.Content.Headers.Add("Message", "Document not found.");

        //                            return response;
        //                        }

        //                        documentContent = null;
        //                    }
        //                }

                        
        //            }
        //            else
        //            {
                        
        //            }


        //        }

        //        //response = new HttpResponseMessage(HttpStatusCode.NotFound);
        //        //response.Content = new StringContent("", Encoding.UTF8, "application/json");
        //        //response.Content.Headers.Add("ResponseCode", "E400");
        //        //response.Content.Headers.Add("Message", "Token is invalid.");

        //        //return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new
        //        {
        //            ResponseCode = "E500",
        //            Message = "Document download failed."
        //        }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        [HttpGet]
        public async Task<dynamic> DownloadDocument(string token)
        {
            HttpResponseMessage response = null;

            try
            {
                string serverIP, serverPort, ftpUserName, ftpPassword, serverURL, documentID;
                int fileIndex = 0;
                string fileName, fileExtension;
                byte[] documentContent = null;

                var base64EncodedBytes = Convert.FromBase64String(token);
                var tokenConverted = Encoding.UTF8.GetString(base64EncodedBytes);

                string[] fileInfo = tokenConverted.Split(new[] { "..|.." }, StringSplitOptions.None);

                serverIP = fileInfo[0];
                serverPort = fileInfo[1];
                ftpUserName = fileInfo[2];
                ftpPassword = fileInfo[3];
                serverURL = fileInfo[4];
                documentID = fileInfo[5];

                if (!string.IsNullOrEmpty(serverIP) && //!string.IsNullOrEmpty(serverPort) &&
                    !string.IsNullOrEmpty(ftpUserName) && !string.IsNullOrEmpty(ftpPassword) &&
                    !string.IsNullOrEmpty(serverURL) && !string.IsNullOrEmpty(documentID)
                )
                {
                    string[] fileInfoCollection = null;
                    List<string> fileNameCollection = new List<string>();

                    using (WebClient webClient = new WebClient())
                    {
                        webClient.Credentials = new NetworkCredential(ftpUserName, ftpPassword);

                        FtpWebRequest ftpWebRequest = (FtpWebRequest)FtpWebRequest.Create("ftp://" + serverIP + "/" + serverURL + "/");
                        ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                        ftpWebRequest.Credentials = new NetworkCredential(ftpUserName, ftpPassword);
                        ftpWebRequest.UsePassive = true;
                        ftpWebRequest.UseBinary = true;
                        ftpWebRequest.KeepAlive = false;

                        using (FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse())
                        {
                            using (StreamReader streamReader = new StreamReader(ftpWebResponse.GetResponseStream()))
                            {
                                fileInfoCollection = streamReader.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                                for (int i = 0; i < fileInfoCollection.Length; i++)
                                {
                                    string[] fileInfoCollectionTemp = fileInfoCollection[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                                    for (int j = 0; j < fileInfoCollectionTemp.Length; j++)
                                    {
                                        if (fileInfoCollectionTemp[j].Contains("."))
                                        {
                                            fileNameCollection.Add(fileInfoCollectionTemp[j]);
                                        }
                                    }
                                }
                            }
                        }

                        for (int i = 0; i < fileNameCollection.Count; i++)
                        {
                            if (fileNameCollection[i].Contains(documentID))
                            {
                                documentContent = webClient.DownloadData("ftp://" + serverIP + "/" + serverURL + "/" + fileNameCollection[i]);
                                fileIndex = i;
                            }
                        }

                        if (documentContent != null && documentContent.Length > 0)
                        {
                            string[] documentProperties = fileNameCollection[fileIndex].Split('.');
                            fileName = documentProperties[0];
                            fileExtension = documentProperties[1];

                            response = new HttpResponseMessage(HttpStatusCode.OK);
                            response.Content = new ByteArrayContent(documentContent);
                            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                            response.Content.Headers.ContentLength = documentContent.Length;
                            response.Content.Headers.ContentDisposition.FileName = fileName + "." + fileExtension;
                            response.Content.Headers.Add("ResponseCode", "S200");
                            response.Content.Headers.Add("Message", "Download successful.");
                        }
                        else
                        {
                            response = new HttpResponseMessage(HttpStatusCode.NotFound);
                            response.Content = new StringContent("", Encoding.UTF8, "application/json");
                            response.Content.Headers.Add("ResponseCode", "E200");
                            response.Content.Headers.Add("Message", "Document not found.");
                        }
                    }
                }
                else
                {
                    response = new HttpResponseMessage(HttpStatusCode.NotFound);
                    response.Content = new StringContent("", Encoding.UTF8, "application/json");
                    response.Content.Headers.Add("ResponseCode", "E400");
                    response.Content.Headers.Add("Message", "Token is invalid.");
                }
            }
            catch (Exception ex)
            {
                #region Alternative
                //return Json(new
                //{
                //    ResponseCode = "E500",
                //    Message = "Document download failed."
                //}, JsonRequestBehavior.AllowGet);
                #endregion

                response = new HttpResponseMessage(HttpStatusCode.NotFound);
                response.Content = new StringContent("", Encoding.UTF8, "application/json");
                response.Content.Headers.Add("ResponseCode", "E500");
                response.Content.Headers.Add("Message", "Document download failed.");
            }

            return response;
        }

    }
}