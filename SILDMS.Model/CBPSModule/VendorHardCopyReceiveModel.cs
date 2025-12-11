using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.CBPSModule
{
    public class VendorHardCopyReceiveModel
    {
        public int Id { get; set; }
        public string BillReferenceNo { get; set; }  
        public string PONo { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceAmt { get; set; }
        public string InvoiceDate { get; set; }
        public string InvoiceCurrency { get; set; }
        public string ProcessGroupID { get; set; }
        public string MushakAmount { get; set; }
        public string Mushak { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCode { get; set; }
        public string VendorName { get; set; }
        public string VendorCode { get; set; }
        public string InvoiceParty { get; set; }
        public string Remarks { get; set; }
        public string BillSubmittedBy { get; set; }
        public string BillSubmitDate { get; set; }
        public string UploaderIP { get; set; }
        public string SetBy { get; set; }
        public string ModifiedBy { get; set; }

        ///////Show//////

        public string BillTrackingNo { get; set; }
        public string BillReceiveID { get; set; }
        public string DocumentID { get; set; }
        public string FileServerUrl { get; set; }
        public string ServerIP { get; set; }
        public string ServerPort { get; set; }
        public string FtpUserName { get; set; }
        public string FtpPassword { get; set; }
       
        ////////////////
    }
    public class VendorHardCopyReceiveServerInfoModel
    {
        public string DocPropID { get; set; }
        public string DocPropertyName { get; set; }
        public string DocumentID { get; set; }
        public string BillTrackingNo { get; set; }
        public string BillReceiveID { get; set; }
        public string BoothName { get; set; }
        public string ReceivedBy { get; set; }
        public string FileCodeName { get; set; }
        public string ServerIP { get; set; }
        public string ServerPort { get; set; }
        public string FtpUserName { get; set; }
        public string FtpPassword { get; set; }
        public string FileServerUrl { get; set; }
        public string NumberOfMissingDocuments { get; set; }
    }
}
