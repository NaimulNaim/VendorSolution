using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.CBPSModule
{
    public class BPS_DocumentTransferLog
    {
        public string DocumentTransferLogID { get; set; }
        public string BoxID { get; set; }
        public string BoxTrackingNoDtlID { get; set; }
        public string BillTrackingNo { get; set; }
        public string PreviousBoxID { get; set; }
        public string DocStatus { get; set; }
        public string SetBy { get; set; }
        public string SetOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
        public int Status { get; set; }
    }
}
