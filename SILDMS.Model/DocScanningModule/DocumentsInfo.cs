using System.Collections.Generic;

namespace SILDMS.Model.DocScanningModule
{
    public class DocumentsInfo
    {
        public ddlDSMOwnerLevel OwnerLevel { get; set; }
        public ddlDSMOwner Owner { get; set; }
        public ddlDSMDocCategory DocCategory { get; set; }
        public ddlDSMDocType DocType { get; set; }
        public ddlDSMDocProperty DocProperty { get; set; }
        public string DidtributionOf { get; set; }
        public string Remarks { get; set; }
        public string DocVersionID { get; set; }
        public string SetBy { get; set; }
        public string ModifiedBy { get; set; }
        public string PageName { get; set; }

        public string OwnerLevelID { get; set; }
        public string OwnerID { get; set; }
        public string DocPropertyID { get; set; }
        public string DocTypeID { get; set; }
        public string DocCategoryID { get; set; }
        public string DocumentID { get; set; }
        public string DocCategoryName { get; set; }

        public string UploaderIP { get; set; }

        public string ConfigureColumnIds { get; set; }
        public string Status { get; set; }




        public string BillReceiveID { get; set; }
        public string BoothID { get; set; }
        public string ProcessGroupID { get; set; }

        public string PONo { get; set; }
        public string BillTrackingNo { get; set; }
        public string InvoicingParty { get; set; }
        public string InvoicingPartyCode { get; set; }
        public string InvoicingPartyName { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        
        public string InvoiceCurrency { get; set; }
        public string PreferedPayMode { get; set; }
        public string BillSubmittedBy { get; set; }
        public string BillSubmitDate { get; set; }
        public string BearerContactNo { get; set; }


        public string InvoiceAmt { get; set; }
        public string POType { get; set; }
        public string PODate { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }

        public IList<DocMetaValue> DocMetaValues { get; set; }
        public IList<DocSearch> docList { get; set; }
    }
}