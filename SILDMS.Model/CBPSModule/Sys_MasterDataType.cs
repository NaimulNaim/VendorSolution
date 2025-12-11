using SILDMS.Model.DocScanningModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.CBPSModule
{
    public class Sys_MasterDataType
    {
        
        public string MasterDataTypeID { get; set; }
        public string TypeName { get; set; }
        public string TypePurpose { get; set; }
        public string TypeCode { get; set; }
        public string OwnerID { get; set; }

        public string LevelName { get; set; }
        public string UserLevel { get; set; }
        public string SetBy { get; set; }

        public string ParentID { get; set; }
        public string ModifiedBy { get; set; }
        public string Status { get; set; }
        public ddlDSMOwner Owner { get; set; }

        public ddlMasterDataType ParentTypeID { get; set; }
        public class ddlMasterDataType
        {
            public string MasterDataTypeID { get; set; }
            public string TypeName { get; set; }
        }
    }
}
