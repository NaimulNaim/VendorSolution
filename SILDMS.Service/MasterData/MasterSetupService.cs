using SILDMS.DataAccessInterface.MasterDataSetup;
using SILDMS.Model.CBPSModule;
using SILDMS.Utillity;
using SILDMS.Utillity.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SILDMS.Service.MasterData
{
    public class MasterSetupService : IMasterSetupService
    {
        private readonly IMasterDataSetupDataService _masterDataSetupDataService;
        private readonly ILocalizationService _localizationService;
        private string _errorNumber = string.Empty;


        public MasterSetupService(IMasterDataSetupDataService masterDataSetupDataService,
            ILocalizationService localizationService)
        {
            _masterDataSetupDataService = masterDataSetupDataService;
            _localizationService = localizationService;
        }

        public ValidationResult LoadMasterDataTypeList(string _userId, string _OwnerID, out List<Sys_MasterDataType> masterDataTypeList)
        {
            masterDataTypeList = _masterDataSetupDataService.LoadMasterDataTypeList
               (_userId, _OwnerID,  out _errorNumber);

            if (_errorNumber.Length > 0)
            {
                return new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber));
            }

            return ValidationResult.Success;
        }

        public ValidationResult AddMasterDataType(Sys_MasterDataType masterDataType, string action, out string outStatus)
        {
            _masterDataSetupDataService.AddMasterDataType(masterDataType, action, out outStatus);
            if (outStatus.Length > 0)
            {
                return new ValidationResult(outStatus, _localizationService.GetResource(outStatus));
            }
            return ValidationResult.Success;
        }


        public ValidationResult EditMasterDataType(Sys_MasterDataType masterDataType, string action, out string outStatus)
        {
            _masterDataSetupDataService.AddMasterDataType(masterDataType, action, out outStatus);
            if (outStatus.Length > 0)
            {
                return new ValidationResult(outStatus, _localizationService.GetResource(outStatus));
            }
            return ValidationResult.Success;
        }


        public ValidationResult LoadMasterDataList(string _userId, string MasterDataTypeID, out List<Sys_MasterData> masterDataList)
        {
            masterDataList = _masterDataSetupDataService.LoadMasterDataList
              (_userId, MasterDataTypeID, out _errorNumber);

            if (_errorNumber.Length > 0)
            {
                return new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber));
            }

            return ValidationResult.Success;
        }


        public ValidationResult GetAllTypes(string _OwnerID, string _userId, out List<Sys_MasterDataType> objMasterData)
        {
            objMasterData = _masterDataSetupDataService.GetAllTypes
              (_userId, _OwnerID, out _errorNumber);

            if (_errorNumber.Length > 0)
            {
                return new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber));
            }

            return ValidationResult.Success;
        }


        public ValidationResult LoadParentDataList(string _userId, string id, out List<Sys_MasterData> masterDataList)
        {
            masterDataList = _masterDataSetupDataService.LoadParentDataList
             (_userId, id, out _errorNumber);

            if (_errorNumber.Length > 0)
            {
                return new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber));
            }

            return ValidationResult.Success;
        }


        public ValidationResult AddMasterData(Sys_MasterData masterData, string action, out string outStatus)
        {
            _masterDataSetupDataService.AddMasterData(masterData, action, out outStatus);
            if (outStatus.Length > 0)
            {
                return new ValidationResult(outStatus, _localizationService.GetResource(outStatus));
            }
            return ValidationResult.Success;
        }


        public ValidationResult EditMasterData(Sys_MasterData masterData, string action, out string outStatus)
        {
            _masterDataSetupDataService.AddMasterData(masterData, action, out outStatus);
            if (outStatus.Length > 0)
            {
                return new ValidationResult(outStatus, _localizationService.GetResource(outStatus));
            }
            return ValidationResult.Success;
        }


        public ValidationResult LoadParentDataListForType(string _userId, string id, out List<Sys_MasterDataType> masterDataTypeList)
        {
            masterDataTypeList = _masterDataSetupDataService.LoadParentDataListForType
             (_userId, id, out _errorNumber);

            if (_errorNumber.Length > 0)
            {
                return new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber));
            }

            return ValidationResult.Success;
        }
        public ValidationResult GetMasterData(string ItemType, out List<SILDMS.Model.CBPSModule.Sys_MasterData.ddlMasterData> MasterData)
        {
            MasterData = _masterDataSetupDataService.GetMasterData(ItemType, out _errorNumber);
            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }

        public ValidationResult GetShipmentPort(int ReceivingPortType, out List<SILDMS.Model.CBPSModule.Sys_MasterData.ddlMasterData> MasterData)
        {
            MasterData = _masterDataSetupDataService.GetShipmentPort(ReceivingPortType, out _errorNumber);
            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }
    }
}
