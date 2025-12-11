using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.CBPSModule
{
    public class BPS_Box
    {
        public string BoxID { get; set; }
        public string BoxNumber { get; set; }
        public string OwnerID { get; set; }
        public string BillTrackingNo { get; set; }
        public string BoxName { get; set; }
        public string BoothBox { get; set; }
        public string BoothName { get; set; }
        public DateTime BoxCreateDate { get; set; }
        public DateTime BoxOpenDate { get; set; }
        public string FirstTrackingNo { get; set; }
        public string LastTrackingNo { get; set; }
        public DateTime BoxCloseDate { get; set; }
        public string TargetDocumentNo { get; set; }
        public string BoothBoxSL { get; set; }
        public string TotalNoDoc { get; set; }
        public string PrintTagId { get; set; }
        public string PrintTagNo { get; set; }
        public string PrintTagSL { get; set; }
        public string Location { get; set; }
        public string LocationName { get; set; }
        public int Received { get; set; }
        public string Remarks { get; set; }
        public string BoxStatus { get; set; }
        public DateTime SetOn { get; set; }
        public string SetBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int Status { get; set; }
        public string BoxSentBy { get; set; }
        public string BoxSentOn { get; set; }
        public string Address { get; set; }
        public string RackNo { get; set; }
        public int TotalPages { get; set; }
        public string BoxLocationID { get; set; }
        public string BoxPreservationID { get; set; }
        public string NewBoxNo { get; set; }
        public List<BPS_BoxUserDtl> BPS_BoxUserDtl { get; set; }
        public string ReceivedDocumentNo { get; set; }
        public string OwnerName { get; set; }
        public string PrevBoxNumber { get; set; }
        public string NextBoxNumber { get; set; }

        public string BoxOpDate { get; set; }
        public string BoxClDate { get; set; }
        public DateTime BoxSentDate { get; set; }
        public string BoxStoreDate { get; set; }
    }
}
