using SILDMS.Model.DocScanningModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.CBPSModule
{
    public class DocDistributeViewModel
    {
        public List<DSM_DocPropIdentify> DSM_DocPropsIdentify { get; set; }
        public List<DocDuplicate> DocDuplicates { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    
    }
    public class DocDuplicate
    {
        public string BillTrackingNo { get; set; }
        public string DocPropertyName { get; set; }
    }
}
