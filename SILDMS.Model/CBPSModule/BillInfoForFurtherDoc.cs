using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SILDMS.Model.DocScanningModule;

namespace SILDMS.Model.CBPSModule
{
    public class BillInfoForFurtherDoc
    {
        public List<BPS_BillReceive> BillsInfo { get; set; }
        public List<DSM_DocProperty> DocProperties { get; set; }
        public List<DSM_Documents> Documents { get; set; }
    }
}
