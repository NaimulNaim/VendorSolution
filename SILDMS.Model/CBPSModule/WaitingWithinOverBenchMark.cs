using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.CBPSModule
{
    public class WaitingWithinOverBenchMark
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Company { get; set; }
        public string WaitingforParking { get; set; }
        public string ParkingWithinBenchMark { get; set; }
        public string ParkingOverBenchMark { get; set; }
        public string WaitingforPosting { get; set; }
        public string PostingWithinBenchMark { get; set; }
        public string PostingOverBenchMark { get; set; }
        public string WaitingforClearing { get; set; }
        public string ClearingWithinBenchMark { get; set; }
        public string ClearingOverBenchMark { get; set; }
    }
}
