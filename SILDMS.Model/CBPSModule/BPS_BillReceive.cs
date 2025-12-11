using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.CBPSModule
{
    public class BPS_BillReceive : BaseModel
    {
        
        public string BillReceiveID { get; set; }
        public string BoothID { get; set; }
        public string PONo { get; set; }
        public string BillTrackingNo { get; set; }
        public string InvoicingParty { get; set; }
        public int IsVendorPartySame { get; set; }
        public string InvoiceDocNo { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public decimal InvoiceAmt { get; set; }
        public string InvoiceCurrency { get; set; }
        public string PreferedPayMode { get; set; }
        public string BillSubmittedBy { get; set; }
        public string BillSubmitDate { get; set; }
        public string BearerContactNo { get; set; }
        public string ReleaseIndicator { get; set; }
        public string DeletionIndecator { get; set; }
        public string CompletionStatus { get; set; }
        public string ProcessState { get; set; }
        public string ProcessGroupID { get; set; }
        public string StageID { get; set; }
        public string CurrentStage { get; set; }
        public string Mushak { get; set; }
        public string Remarks { get; set; }
        public string BackReason { get; set; }
        public string BackRemarks { get; set; }
        public decimal MushakAmount { get; set; }
        public int AssignedDays { get; set; }
        public int RemainingDays { get; set; }
        public string totalPages { get; set; }
        public decimal InvoiceAmtTotal { get; set; }
        public string SetOn { get; set; }

        public string OwnerID { get; set; }   
        public int SL { get; set; }
        public int IsStop { get; set; }
        public bool IsBacked { get; set; }
        public string TotalPages { get; set; }
        public bool IsReference { get; set; }

        public string IsRef { get; set; }
        public string MenuUrl { get; set; }
        public string LCStageFrom { get; set; }

        #region View Properties

        public string VendorID { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public string VendorEmail { get; set; }
        public string VendorMobileNo { get; set; }
        public string ProcessGroupName { get; set; }
        public string PurchasingGroup { get; set; }
        public string StageName { get; set; }
        public string InvoicingPartyName { get; set; }
        public string OwnerName { get; set; }
        public string DocType { get; set; }
        public string PODate { get; set; }
        public string UserName { get; set; }
        public string EmployeeID { get; set; }
        public string BenchMark { get; set; }
        public string NewBenchMark { get; set; }
        public decimal TotalAmount { get; set; }
        public string BackedBy { get; set; }
        public bool Priority { get; set; }


        #endregion
    }
}
