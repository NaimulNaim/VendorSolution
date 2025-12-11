using SILDMS.Model.CBPSModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.DataAccessInterface.MasterDataSetup
{
    public interface IMasterDataSetupDataService
    {
        List<Sys_MasterDataType> LoadMasterDataTypeList(string _userId,string _OwnerID, out string _errorNumber);

        string AddMasterDataType(Sys_MasterDataType masterDataType, string action, out string outStatus);

        List<Sys_MasterData> LoadMasterDataList(string _userId, string MasterDataTypeID, out string _errorNumber);

        List<Sys_MasterDataType> GetAllTypes(string _userId, string _OwnerID, out string _errorNumber);

        List<Sys_MasterData> LoadParentDataList(string _userId, string id, out string _errorNumber);

        string AddMasterData(Sys_MasterData masterData, string action, out string outStatus);

        List<Sys_MasterDataType> LoadParentDataListForType(string _userId, string id, out string _errorNumber);
        List<SILDMS.Model.CBPSModule.Sys_MasterData.ddlMasterData> GetMasterData(string ItemType, out string _errorNumber);

        List<SILDMS.Model.CBPSModule.Sys_MasterData.ddlMasterData> GetShipmentPort(int ReceivingPortType, out string _errorNumber);
    }
}
