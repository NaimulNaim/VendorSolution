using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.CBPSModule
{
    public class ReportModel 
    {
        public string UserRptID { get; set; }
        public string UserFullName { get; set; }
        public string BillReceiveFromDate { get; set; }
        public string BillReceiveToDate { get; set; }
        public string VendorPaymentFromDate { get; set; }
        public string VendorPaymentToDate { get; set; }
        public string OwnerLevelID { get; set; }
        public string OwnerID { get; set; }
        public string ParentOwnerID { get; set; }
        public string OwnerName { get; set; }
        public string EmployeeID { get; set; }
        public string InState { get; set; }
        public string DocCategoryID { get; set; }
        public string TransType { get; set; }
        public string StageAction { get; set; }
        public string DocCategoryName { get; set; }
        public string VendorID { get; set; }
        public string VendorCode { get; set; }
        public string VendorCode2 { get; set; }
        public string VendorName { get; set; }
        public string VendorAddress { get; set; }
        public string EFTindicator { get; set; }
        public string WebUserIndicator { get; set; }
        public string FromPONo { get; set; }
        public string ToPONo { get; set; }
        public string FromTrackNo { get; set; }
        public string ToTrackNo { get; set; }
        public string FromParkNo { get; set; }
        public string ToParkNo { get; set; }
        public string FromPostNo { get; set; }
        public string ToPostNo { get; set; }
        public string FromClearNo { get; set; }
        public string ToClearNo { get; set; }
        public string PrintChallanCode { get; set; }
        public string ChallanCode { get; set; }
        public string FromChallanNo { get; set; }
        public string ToChallanNo { get; set; }
        public string FromCertificateNo { get; set; }
        public string ToCertificateNo { get; set; }
        public string CertificateFromDate { get; set; }
        public string CertificateToDate { get; set; }
        public string TDSCertificateFromDate { get; set; }
        public string TDSCertificateToDate { get; set; }
        public string OwnerAddressID { get; set; }
        public string BankID { get; set; }
        public string BranchID { get; set; }
        public string AccountType { get; set; }
        public string AccountNo { get; set; }
        public string Status { get; set; }
        public string StageID { get; set; }
        public string ProcessState { get; set; }
        public string RoleID { get; set; }
        public string DocTypeID { get; set; }
        public string DocPropertyID { get; set; }
        public string ButtonType { get; set; }
        public string ReportType { get; set; }
        public string ViewType { get; set; }
        public string TrackingType { get; set; }
        public string ProcessType { get; set; }
        public string NextState { get; set; }
        public string Company { get; set; }
        
        public string BillTrackingNo { get; set; }
        public string BillDays { get; set; }
        public string First { get; set; }
        public string Second { get; set; }
        public string Third { get; set; }
        public string Four { get; set; }
        public string Five { get; set; }
        public string FirstTackNo { get; set; }
        public string SecondTackNo { get; set; }
        public string ThirdTackNo { get; set; }
        public string FourTackNo { get; set; }
        public string FiveTackNo { get; set; }
        public string BillTrackingNo1 { get; set; }
        public string BillTrackingNo2 { get; set; }
        public string BillTrackingNo3 { get; set; }
        public string BillTrackingNo4 { get; set; }
        public string BillTrackingNo5 { get; set; }
        public string SelectedTrackingNoin { get; set; }
        public string SelectedTrackingNoOut { get; set; }
        public string SelectedPO { get; set; }
        public string SelectedVendorCode { get; set; }
        public string VendorType { get; set; }
        public string RcvState { get; set; }
        public string ParkState { get; set; }
        public string PostState { get; set; }
        public string ClearState { get; set; }
        public string PrintState { get; set; }
        public string DisRcvState { get; set; }
        public string DisDonState { get; set; }
        public string SelectedPONo { get; set; }
        public string SelectedTrackingNo { get; set; }
        public string SelectedParkingNo { get; set; }
        public string SelectedPostingNo { get; set; }
        public string SelectedClearingNo { get; set; }
        public string POType { get; set; }
        public string ParkType { get; set; }
        public string PostType { get; set; }
        public string ClearType { get; set; }
        public string TableType { get; set; }
        public string ChequePrintDate { get; set; }
        public string ChequePrintToDate { get; set; }
        public string BankManger { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public string BankRefNo { get; set; }
        public string BFRefNo { get; set; }
        public string FromLeafNo { get; set; }
        public string ToLeafNo { get; set; }

        public string SignatoryName { get; set; }

        public string SignatoryDesignaion { get; set; }

        public string TIN { get; set; }

        public string BIN { get; set; }

        public string totbillamt { get; set; }

        public string tottaxamt { get; set; }
        public string VDSReceiver { get; set; }
        public string RefVDSReceiver { get; set; }
        public string Copyto { get; set; }
        public string PaymentFromDate { get; set; }
        public string PaymentToDate { get; set; }
        public string VDSCertificateRefNo { get; set; }
        public string TDSCertificateRefNo { get; set; }
        public string TDSPaymentFromDate { get; set; }
        public string TDSPaymentToDate { get; set; }
        public string challanAddress1 { get; set; }
        public string challanAddress { get; set; }
        public string VDSComAddress { get; set; }
        public string TDSVDSType { get; set; }
        public string SelectedChallanNo { get; set; }
        public string SelectedCertificateNo { get; set; }
        public string ChallanType { get; set; }
        public string CertificateType { get; set; }
        public string BoxOpenFromDate { get; set; }
        public string BoxOpenToDate { get; set; }
        public string BoxCloseFromDate { get; set; }
        public string BoxCloseToDate { get; set; }
        public string Booth { get; set; }
        public string StoreLocation { get; set; }
        public string BoxNumber { get; set; }
        public string PostingFiscalYear { get; set; }
        public string IssueDate { get; set; }
        public string PONo { get; set; }
        public string SelectedIndentNo { get; set; }
        public string LCNo { get; set; }
        public string LCType { get; set; }
        public string IndentNo { get; set; }
        public string IndentType { get; set; }
        public string TransportNo { get; set; }
        public string TransportType { get; set; }
        public string SelectedLCNo { get; set; }
        public string SelectedTransportNo { get; set; }
        public string LCOpenDate { get; set; }
        public string LCOpenFromDate { get; set; }
        public string LCOpenToDate { get; set; }
        public string MaterialCode { get; set; }
        public string Plant { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Currency { get; set; }
        public string RecordNo { get; set; }
    }

    public class RptConditionDetailModel
    {
        public string ConditionType { get; set; }
        public string CompanyCode { get; set; }
        public string Plant { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }

    public class RptConditionDtlListModel
    {
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
        public string PONo { get; set; }
        public string LCNumber { get; set; }
        public string TrackingNumber { get; set; }
        public string BillNo { get; set; }
        public string BillDate { get; set; }
        public string BillAmount { get; set; }
        public string ConditionType { get; set; }
        public string PaymentText { get; set; }
    }

    public class RptBoothModel
    {
        public string BoothID { get; set; }
        public string BoothName { get; set; }

        public string BoxNumberID { get; set; }
        public string BoxNumberName { get; set; }

        public string StoreLocationID { get; set; }
        public string StoreLocationName { get; set; }
    }

    public class RptBillMoveStatusModel
    {
        public string Company { get; set; }
        public string Vendor { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public string PoNo { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public decimal InvoiceAmt { get; set; }
        public string BillTrakingNo { get; set; }
        public string BillTrackingNo { get; set; }
        public string BillReceiveDate { get; set; }
        public string BillReceivedBy { get; set; }
        public string ReceiveforParkingDate { get; set; }
        public string ReceiveforParkingBy { get; set; }
        public string ParkingDoneDate { get; set; }
        public string ParkingDoneBy { get; set; }
        public string ReceiveforPostingDate { get; set; }
        public string ReceiveforPostingBy { get; set; }

        public string PostingDoneDate { get; set; }
        public string PostingDoneBy { get; set; }

        public string ReceiveforClearingDate { get; set; }
        public string ReceiveforClearingBy { get; set; }

        public string ClearingDoneDate { get; set; }
        public string ClearingDoneBy { get; set; }

        public string ReceiveforChequePrintingDate { get; set; }
        public string ReceiveforChequePrintingBy { get; set; }
        public string ChequePrintingDate { get; set; }
        public string ChequePrintingDoneBy { get; set; }
        public string ReceiveforDisburseDate { get; set; }
        public string ReceiveforDisburseBy { get; set; }
        public string DisburseDoneDate { get; set; }
        public string DisburseDoneBy { get; set; }
        public string BillCurrentStatus { get; set; }
        public string StageState { get; set; }
        public string TotalDays { get; set; }
        public decimal TotalAmt { get; set; }
        public string ResponsiblePerson { get; set; }
        public string Status { get; set; }
    }

    public class RptChequeDisbursementTopSheetInfo
    {
        public string ChequeNo { get; set; }
        public string BillTrackingNo { get; set; }
        public string VenInvoiceNo { get; set; }
        public string PurchaseOrder { get; set; }
        public string TDSCode { get; set; }
        public string TDSAmt { get; set; }
        public string VDSCode { get; set; }
        public string VDSAmt { get; set; }
        public string NETAmt { get; set; }
        public string GrossAmt { get; set; }
    }

    public class RptChequeOrEFTInfoVendorWise
    {
        public string BillTrackingNo { get; set; }
        public string VendorTransName { get; set; } // VendorTransactionName
        public string BillNo { get; set; }
        public string BillDate { get; set; }
        public string BillAmount { get; set; }
        public string PayAmount { get; set; }
        public string TDSAmt { get; set; }
        public string VDSAmt { get; set; }
        public string ChequeNo { get; set; }
        public string ChequeDate { get; set; }
        public string BankName { get; set; }
        public string MoneyRectNo { get; set; }
        public string MoneyRectDate { get; set; }
    }

    public class RptVendorWithAddress
    {
        public string VendorID { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public string TransAccountName { get; set; }
        public string BIN { get; set; }
        public string TIN { get; set; }
        public string VatRegNo { get; set; }
        public string VendorAddress { get; set; }
        public string VendorEmail { get; set; }
        //public string NETAmt { get; set; }
        //public string GrossAmt { get; set; }
    }

    public class RptReferanceDocumentsDetailsModel
    {
        public string Company { get; set; }
        public string Vendor { get; set; }
        public string PONo { get; set; }
        public string BillTrackNo { get; set; }
        public string PRKFisYear { get; set; }
        public string PRKInvNo { get; set; }
        public string POSFisYear { get; set; }
        public string POSInvNo { get; set; }
        public string CLRFisYear { get; set; }
        public string CLRInvNo { get; set; }
        public string ChqEftNo { get; set; }
        public string ChqEftDate { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string BankGL { get; set; }
        public string MoneyReceiptNo { get; set; }
        public string Musak { get; set; }
        public string MusakAmount { get; set; }
        public string PostingGL { get; set; }
        public string PostGLName { get; set; }
        public string InvoiceDocType { get; set; }
    }
    public class RptBarchartModel
    {
        public string Company { get; set; }
        public string RcvDonBillNum { get; set; }
        public string RcvPndBillNum { get; set; }
        public string RcvDonBillVal { get; set; }
        public string RcvPndBillVal { get; set; }

        public string PrkDonBillNum { get; set; }
        public string PrkPndBillNum { get; set; }
        public string PrkDonBillVal { get; set; }
        public string PrkPndBillVal { get; set; }

        public string PosDonBillNum { get; set; }
        public string PosPndBillNum { get; set; }
        public string PosDonBillVal { get; set; }
        public string PosPndBillVal { get; set; }

        public string ClrDonBillNum { get; set; }
        public string ClrPndBillNum { get; set; }
        public string ClrDonBillVal { get; set; }
        public string ClrPndBillVal { get; set; }

        public string ChkDonBillNum { get; set; }
        public string ChkPndBillNum { get; set; }
        public string ChkDonBillVal { get; set; }
        public string ChkPndBillVal { get; set; }
    }

    public class RptBillAssignmentStatus
    {
        public string Activity { get; set; }
        public string Company { get; set; }
        public string BillReceiveFromDate { get; set; }
        public string BillReceiveToDate { get; set; }
        public string Supervisor { get; set; }
        public string ExecutedBy { get; set; }
        public string Vendor { get; set; }
        public string BillTrackingNo { get; set; }
        public string Status { get; set; }
        public string ReportType { get; set; }
        public string ButtonType { get; set; }

    }
    public class Bill
    {
        public string BillTrackingNo { get; set; }

        public string StageName { get; set; }

        public string ButtonType { get; set; }
    }

   
}
