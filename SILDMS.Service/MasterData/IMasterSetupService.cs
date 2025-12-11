using SILDMS.Model;
using SILDMS.Model.CBPSModule;
using SILDMS.Model.SecurityModule;
using SILDMS.Utillity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Service.MasterData
{
    public interface IMasterSetupService
    {

        ValidationResult LoadMasterDataTypeList(string _userId, string _OwnerID, out List<Sys_MasterDataType> masterDataTypeList);

        ValidationResult AddMasterDataType(Sys_MasterDataType masterDataType, string action, out string outStatus);

        ValidationResult EditMasterDataType(Sys_MasterDataType masterDataType, string action, out string outStatus);

        ValidationResult LoadMasterDataList(string _userId, string MasterDataTypeID, out List<Sys_MasterData> masterDataList);

        ValidationResult GetAllTypes(string _OwnerID, string _userId, out List<Sys_MasterDataType> objMasterData);

        ValidationResult LoadParentDataList(string _userId, string id, out List<Sys_MasterData> masterDataList);

        ValidationResult AddMasterData(Sys_MasterData masterData, string action, out string outStatus);

        ValidationResult EditMasterData(Sys_MasterData masterData, string action, out string outStatus);

        ValidationResult LoadParentDataListForType(string _userId, string id, out List<Sys_MasterDataType> masterDataTypeList);

        ValidationResult GetMasterData(string ItemType, out List<SILDMS.Model.CBPSModule.Sys_MasterData.ddlMasterData> MasterData);
        ValidationResult GetShipmentPort(int ReceivingPortType, out List<SILDMS.Model.CBPSModule.Sys_MasterData.ddlMasterData> MasterData);
    }
}
