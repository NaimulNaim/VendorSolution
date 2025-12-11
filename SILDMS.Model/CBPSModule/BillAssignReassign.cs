using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.CBPSModule
{     
    public class BillAssignReassign
    {public string TrackingNo { get; set; }
        public string PoNo { get; set; }
        public string AssignedBy { get; set; }
        public string AssignedTo { get; set; }

        public string AssignedDate { get; set; }
        public string ReAssignmentDate { get; set; }

        public string Remarks { get; set; } 
        public string StageName { get; set; }   
        public string ReceiveBooth { get; set; }

        public string ReceiveBy { get; set; }
        public string VendorName { get; set;}
    }
}
