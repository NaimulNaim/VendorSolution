using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.CBPSModule
{
    public class BPS_BoxTackingNoDtl
    {
        public BPS_BoxTackingNoDtl() {
            DisableDrop = true;
        }

        public string BoxTrackNoDtlID { get; set; }
        public string BoxID { get; set; }
        public string BoxUserDtlID { get; set; }
        public string BillTrackingNo { get; set; }
        public int Status { get; set; }
        public string RequestedBy { get; set; }
        public string RequestedOn { get; set; }
        public string IssuedBy { get; set; }
        public string IssuedOn { get; set; }
        public string OtherResponsiblePerson { get; set; }
        public string ReceivedBy { get; set; }
        public string ReceivedOn { get; set; }
        public string TrackStatus { get; set; }
        public string DocAddress { get; set; } 
        public string BoxNumber { get; set; }
        public string BoxName { get; set; }
        public string Location { get; set; }
        public bool DisableDrop { get; set; }
        public string LocationChangeCause { get; set; }
        public string RequestFromLocation { get; set; }
        public string IssueToLocation { get; set; }
    }

}
