using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.CBPSModule
{
    public class BPS_BoxPreservation
    {
        public string BoxPreservationID { get; set; }
        public string BoxID { get; set; }
        public string BoxLocationID { get; set; }
        public string RackNo { get; set; }
        public string Remarks { get; set; }
        public string ReceivedCondition { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
    }
}
