using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SILDMS.Model.DocScanningModule;
using SILDMS.Model.CBPSModule;
using SILDMS.Model.SecurityModule;
using SILDMS.Service.MasterData;
using SILDMS.Service.DocProperty;
using SILDMS.Service.DocumentCategory;
using SILDMS.Service.DocumentType;
using SILDMS.Service.Owner;
using SILDMS.Service.OwnerLevel;
using SILDMS.Service.OwnerProperIdentity;
using SILDMS.Utillity;
using SILDMS.Utillity.Localization;
using SILDMS.Web.UI.Areas.SecurityModule.Models;

namespace SILDMS.Web.UI.Areas.SecurityModule.Controllers
{
    public class MasterDataTypeController : Controller
    {
        private readonly IMasterSetupService _imasterSetupService;
        private ValidationResult result;
        private readonly ILocalizationService _localizationService;
        private string outStatus = string.Empty;
        private readonly string _userId;
        private string action = string.Empty;


        public MasterDataTypeController(IMasterSetupService ImasterSetupService, ILocalizationService localizationService)
        {
            _imasterSetupService = ImasterSetupService;
            _localizationService = localizationService;
            result = new ValidationResult();
            _userId = SILAuthorization.GetUserID();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<dynamic> LoadMasterDataTypeList(string _OwnerID)
        {
            List<SILDMS.Model.CBPSModule.Sys_MasterDataType> masterDataTypeList = null;

            await Task.Run(() => _imasterSetupService.LoadMasterDataTypeList(_userId, _OwnerID, out masterDataTypeList));

            var result = (from r in masterDataTypeList

                          select new SILDMS.Model.CBPSModule.Sys_MasterDataType
                          {
                              MasterDataTypeID = r.MasterDataTypeID,
                              OwnerID = r.OwnerID,
                              LevelName = r.LevelName,
                              TypeName = r.TypeName,
                              ParentID = r.ParentID,
                              TypePurpose = r.TypePurpose,
                              TypeCode = r.TypeCode,
                              Status = r.Status
                          }).ToList();

            return Json(new { Msg = "", result }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public async Task<dynamic> LoadParentDataListForType(string id)
        {
            List<SILDMS.Model.CBPSModule.Sys_MasterDataType> masterDataTypeList = null;

            await Task.Run(() => _imasterSetupService.LoadParentDataListForType(_userId, id, out masterDataTypeList));

            //var result = (from b in masterDataTypeList

            //              select new SILDMS.Model.CBPSModule.Sys_MasterDataType
            //              {
            //                  MasterDataTypeID =b.MasterDataTypeID,                             
            //                  TypeName = b.TypeName
                              
            //              }).ToList();

            var result = masterDataTypeList.Select(x => new
            {
                MasterDataTypeID = x.MasterDataTypeID,
                TypeName = x.TypeName
            }).ToList();

            return Json(new { Msg = "", result }, JsonRequestBehavior.AllowGet);
        }

        
        [HttpPost]
        [Authorize]
        [SILLogAttribute]
        public async Task<dynamic> AddMasterDataType(SILDMS.Model.CBPSModule.Sys_MasterDataType masterDataType)
        {
            if (ModelState.IsValid)
            {
                action = "add";
                result = await Task.Run(() => _imasterSetupService.AddMasterDataType(masterDataType, action, out outStatus));
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
        public async Task<dynamic> EditMasterDataType(SILDMS.Model.CBPSModule.Sys_MasterDataType masterDataType)
        {
            if (ModelState.IsValid)
            {
                action = "edit";
                result = await Task.Run(() => _imasterSetupService.EditMasterDataType(masterDataType, action, out outStatus));
                return Json(new { Message = result.Message, result }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                result = new ValidationResult("E404", _localizationService.GetResource("E404"));
            }
            return Json(new { Message = result.Message, result }, JsonRequestBehavior.AllowGet);
        }
	}
}