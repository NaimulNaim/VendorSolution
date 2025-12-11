using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.CBPSModule
{
    public class BillAssinment
    {
        public string BillTrackingNo { get; set; }
        public string PONo { get; set; }
        public string SetOn { get; set; }
        public string OwnerID { get; set; }
        public string OwnerName { get; set; }
        public string Mushak { get; set; }
        public decimal MushakAmount { get; set; }
        public string VendorName { get; set; }
        public string InvoicingPartyName { get; set; }
        public string PurchasingGroup { get; set; }

        public decimal InvoiceAmt { get; set; }
        public string UserName { get; set; }
        public string BenchMark { get; set; }
        public string NewBenchMark { get; set; }
        public string EmployeeID { get; set; }
        public int Priority { get; set; }
    }
}
