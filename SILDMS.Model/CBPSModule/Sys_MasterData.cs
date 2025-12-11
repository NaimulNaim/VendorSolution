using SILDMS.Model.DocScanningModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.CBPSModule
{
    public class Sys_MasterData
    {
        public string MasterDataID { get; set; }
        public string MasterDataValue { get; set; }
        public string MasterDataTypeID { get; set; }
        public string OwnerID { get; set; }
        public string UserLevel { get; set; }
        public string UDCode { get; set; }
        public string ParrentID { get; set; }
        public string OwnerLevelID { get; set; }
        public string SerialNo { get; set; }
        public string IsDefault { get; set; }
        public string SetBy { get; set; }
        public string ModifiedBy { get; set; }
        public int Status { get; set; }

        public bool? Permission { get; set; }

        public ddlDSMOwner Owner { get; set; }
        public SILDMS.Model.CBPSModule.Sys_MasterDataType.ddlMasterDataType MasterDataType { get; set; }

        public ddlMasterData ParentID { get; set; }
        public class ddlMasterData
        {
            public string MasterDataID { get; set; }
            public string MasterDataValue { get; set; }
        }
    }
}
