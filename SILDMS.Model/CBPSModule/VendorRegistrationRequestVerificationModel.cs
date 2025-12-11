using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.CBPSModule
{
    public class VendorRegistrationRequestVerificationModel
    {
        public int Id { get; set; }
        public int VendorBusinessCompanyId { get; set; }
        public string VendorBusinessCompanyName { get; set; }
        public string VendorIP { get; set; }
        public string RejectionReason { get; set; }
        public bool IsApproved { get; set; }
        public string VendorAddress { get; set; }
        public string EmailAddress { get; set; }
        public string VendorRemarks { get; set; }
        public string ContactNo { get; set; }
        public string VendorName { get; set; }
        public string VendorCode { get; set; }
        public string SystemUserName { get; set; }
        public string VendorTIN { get; set; }
        public DateTime SetOn { get; set; }
        public string SetBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int DataStatus { get; set; }
        public string CompanyCode { get; set; } 
    }
}
