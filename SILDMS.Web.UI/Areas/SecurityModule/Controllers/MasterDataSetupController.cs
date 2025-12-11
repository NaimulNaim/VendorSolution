using SILDMS.Service.MasterData;
using SILDMS.Utillity;
using SILDMS.Utillity.Localization;
using SILDMS.Web.UI.Areas.SecurityModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static SILDMS.Model.CBPSModule.Sys_MasterData;

namespace SILDMS.Web.UI.Areas.SecurityModule.Controllers
{
    public class MasterDataSetupController : Controller
    {
        private readonly IMasterSetupService _imasterSetupService;
        private ValidationResult result;
        private readonly ILocalizationService _localizationService;
        private string outStatus = string.Empty;
        private readonly string _userId;
        private string action = string.Empty;


        public MasterDataSetupController(IMasterSetupService ImasterSetupService, ILocalizationService localizationService)
        {
            _imasterSetupService = ImasterSetupService;
            _localizationService = localizationService;
            result = new ValidationResult();
            _userId = SILAuthorization.GetUserID();
        }
        //
        // GET: /SecurityModule/MasterDataSetup/
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<dynamic> LoadMasterDataList(string MasterDataTypeID)
        {
            List<SILDMS.Model.CBPSModule.Sys_MasterData> masterDataList = null;

            await Task.Run(() => _imasterSetupService.LoadMasterDataList(_userId, MasterDataTypeID, out masterDataList));

            var result = (from b in masterDataList

                          select new SILDMS.Model.CBPSModule.Sys_MasterData
                          {
                              MasterDataID = b.MasterDataID,
                              MasterDataValue = b.MasterDataValue,
                              MasterDataTypeID = b.MasterDataTypeID,
                              OwnerID = b.OwnerID,
                              UserLevel = b.UserLevel,
                              Status = b.Status,
                              IsDefault = b.IsDefault,
                              SerialNo = b.SerialNo,
                              UDCode = b.UDCode,
                              ParrentID = b.ParrentID
                          }).ToList();

            return Json(new { Msg = "", result }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public async Task<dynamic> LoadParentDataList(string id)
        {
            List<SILDMS.Model.CBPSModule.Sys_MasterData> masterDataList = null;

            await Task.Run(() => _imasterSetupService.LoadParentDataList(_userId, id, out masterDataList));

            var result = (from b in masterDataList

                          select new SILDMS.Model.CBPSModule.Sys_MasterData
                          {
                              MasterDataID = b.MasterDataID,
                              MasterDataValue = b.MasterDataValue,
                              MasterDataTypeID = b.MasterDataTypeID,
                              OwnerID = b.OwnerID,
                              UserLevel = b.UserLevel,
                              Status = b.Status,
                              IsDefault = b.IsDefault,
                              SerialNo = b.SerialNo,
                              UDCode = b.UDCode,
                              ParrentID = b.ParrentID,
                              OwnerLevelID = b.OwnerLevelID
                          }).ToList();

            return Json(new { Msg = "", result }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize]
        public async Task<dynamic> GetTypeForSpecificOwner(string _OwnerID)
        {
            List<SILDMS.Model.CBPSModule.Sys_MasterDataType> objMasterDataType = null;

            await Task.Run(() => _imasterSetupService.LoadMasterDataTypeList(_userId, _OwnerID, out objMasterDataType));

            var result = (from r in objMasterDataType
                          where r.OwnerID == _OwnerID 
                          //orderby r.TypeName
                          select new SILDMS.Model.CBPSModule.Sys_MasterDataType
                          {
                              MasterDataTypeID = r.MasterDataTypeID,
                              OwnerID = r.OwnerID,
                              LevelName = r.LevelName,
                              TypeName = r.TypeName,
                              TypePurpose = r.TypePurpose,
                              TypeCode = r.TypeCode,
                              Status = r.Status
                          }).ToList();

            return Json(new { Msg = "", result }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize]
        [SILLogAttribute]
        public async Task<dynamic> AddMasterData(SILDMS.Model.CBPSModule.Sys_MasterData masterData)
        {
            if (ModelState.IsValid)
            {
                action = "add";
                result = await Task.Run(() => _imasterSetupService.AddMasterData(masterData, action, out outStatus));
                return Json(new { Message = result.Message, result }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                result = new ValidationResult("E404", _localizationService.GetResource("E404"));
            }
            return Json(new { Message = result.Message, result }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [Authorize]
        [SILLogAttribute]
        public async Task<dynamic> EditMasterData(SILDMS.Model.CBPSModule.Sys_MasterData masterData)
        {
            if (ModelState.IsValid)
            {
                action = "edit";
                result = await Task.Run(() => _imasterSetupService.EditMasterData(masterData, action, out outStatus));
                return Json(new { Message = result.Message, result }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                result = new ValidationResult("E404", _localizationService.GetResource("E404"));
            }
            return Json(new { Message = result.Message, result }, JsonRequestBehavior.AllowGet);
        }

        //[Authorize]
        public async Task<dynamic> GetMasterData(string ItemType)
        {
            var MasterData = new List<ddlMasterData>();
            await Task.Run(() => _imasterSetupService.GetMasterData(ItemType, out MasterData));
            return Json(new { MasterData, Msg = "" }, JsonRequestBehavior.AllowGet);
        }


        public async Task<dynamic> GetShipmentPort(int ReceivingPortType)
        {
            var MasterData = new List<ddlMasterData>();
            await Task.Run(() => _imasterSetupService.GetShipmentPort(ReceivingPortType, out MasterData));
            return Json(new { MasterData, Msg = "" }, JsonRequestBehavior.AllowGet);
        }

    }
}