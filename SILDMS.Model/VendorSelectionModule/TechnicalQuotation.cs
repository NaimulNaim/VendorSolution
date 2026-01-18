using System;

namespace SILDMS.Model.VendorSelectionModule
{
    public class TechnicalQuotation
    {
        public string TechQuotationItemID { get; set; }
        public string rowIndex { get; set; }
        public string MoleculeName { get; set; }
        public string SampleAvailable { get; set; }
        public string OtherSample { get; set; }
        public string CASNO { get; set; }
        public string RepresentativePackSize { get; set; }
        public string Manufacturer { get; set; }
        public string Regulatory { get; set; }
        public string Supplier { get; set; }
        public string CurrentStatus { get; set; }
        public string ManufactureAddress { get; set; }
        public int ProdCapacity { get; set; }
        public decimal RDPrice { get; set; }
        public Currency RNDPriceCur { get; set; }
        public int Shelf { get; set; }
        public decimal CommercialPrice { get; set; }
        public Currency ComPriceCur { get; set; }
        public string Condition { get; set; }
        public int OrderQty { get; set; }
        public string OrderUnit { get; set; }
        public string Specification { get; set; }
        public string OtherSpecification { get; set; }
        public int CommercialConsignment { get; set; }
        public int AvailPackSize { get; set; }
        public int MinPack { get; set; }
        public string Example { get; set; }
        public Currency Currency { get; set; }
        public string Reference { get; set; }
        public string Validation { get; set; }
        public string Training { get; set; }
        public string Prerequisite { get; set; }
        public string ManufacturerPart { get; set; }
        public string Installation { get; set; }
        public string Subcontractor { get; set; }
        public string ManufacturerOrigin { get; set; }
        public string Penalty { get; set; }
        public string Fat { get; set; }
        public string Calibration { get; set; }
        public string Alldocuments { get; set; }
        //public string RNDPriceCur { get; set; }
        //public string ComPriceCur { get; set; }
        public Item OrderQtyUnit { get; set; }
        public string LocalPartner { get; set; }
        public string ShelfUnit { get; set; }
        public string APIRegApproval { get; set; }
    }
    public class Currency
    {
        public string MasterDataID { get; set; }

        public string MasterDataValue { get; set; }
    }


   


public class FinancialQuotationDetail
    {
        public string rowIndex { get; set; }
        public string FinanQuotationItemID { get; set; }
        public double ProposeQty { get; set; }
      
        public Item Unit { get; set; }
        public double UnitPrice { get; set; }
        public Currency Currency { get; set; }
        public double TotalPrice { get; set; }
        public double VatAmount { get; set; }
        public double TaxAmount { get; set; }
        public double GrossPrice { get; set; }
        public double DiscountPrice { get; set; }
        public double NetPrice { get; set; }
        public DateTime QuotValidDate { get; set; }
        public DateTime ExpecDeliDate { get; set; }
        public string ProposalType { get; set; }
        public string QuotValidDateString { get; set; }
        public string ExpecDeliDateString { get; set; }

 
    }
  









    public class Invitation
    {
        public string Invitation_Number { get; set; }

        public string ProposalType { get; set; }
        public string Fintype { get; set; }
    }


    public class Quotation
    {
        public string quotationID { get; set; }

        public string quotationNo { get; set; }
        public string InvitationNumber { get; set; }
        public string QuotationDate { get; set; }
    }

    public class MaterialInvitation
    { public string TechQuotationItemID { get; set; }
     public string FinanQuotationItemID { get; set; }
        public string MaterialQuantity { get; set; }
        public string Unit { get; set; }
     
        public string rowIndex { get; set; }
        public string invitationNumber { get; set; }
        public int? departmentId { get; set; }
        public string matCategory { get; set; }
        public int? itemNo { get; set; }
        public string materialCode { get; set; }
        public string materialName { get; set; }
        public string remarks { get; set; }
        public string Remarks { get; set; }
        public string sampleDocId { get; set; }
        public string proposalType { get; set; }
        public bool sharedToFactory { get; set; }
        public bool askFinanQoutations { get; set; }
        public string modificationType { get; set; }
        public DateTime? setOn { get; set; }
        public string setBy { get; set; }
        public DateTime? modifiedOn { get; set; }
        public string modifiedBy { get; set; }
        public string status { get; set; }
        public int Status { get; set; }
        public string SampleDocumentID { get; set; }
        public string material_Category_Code { get; set; }
        public string MatInvType { get; set; }
        public string InvitationID { get; set; }
        public string BiddingItemVendorID { get; set; }
        public string VendorID { get; set; }
        public string Action { get; set; }

        public long QuotationID { get; set; }

        public string QuotationNo { get; set; }
        public string BiddingID { get; set; }
        public string DeliveryTimeline { get; set; }
        public string Incoterms { get; set; }
        public string IncotermsLocation { get; set; }
        public string ShipmentMode { get; set; }
        public string PaymentMode { get; set; }
        public string PartDelivery { get; set; }
        public string PaymentTerms { get; set; }
        public string ManufacturerPartNo { get; set; }
        public string ManufacturerName { get; set; }
        public string Warranty { get; set; }
        public string Installation { get; set; }
        public string Servicing { get; set; }
        public string PenaltyClause { get; set; }


        // TechnicalQuotation new

        public string MoleculeName { get; set; }
        public string Manufacturer { get; set; }
        public string ShelfLifeValue { get; set; }
        public string ShelfLifeUnit { get; set; }
        public string Notes { get; set; }
        public string CASNO { get; set; }
        public string CatalogueNo { get; set; }
        public string SampleAvailable { get; set; }
        public string SamplePackSize { get; set; }
        public string Capacity { get; set; }
        public string CapacityExtendable { get; set; }
        public string CapacityExtendableOther { get; set; }
        public string FATAtManufacturerSite { get; set; }
        public string FATAtManufacturerSiteOther { get; set; }
        public string SATScope { get; set; }
        public string AssistanceAtSite { get; set; }
        public string AssistanceAtSiteOther { get; set; }
        public string ComplianceWith { get; set; }
        public string QualificationDocuments { get; set; }
        public string QualificationDocumentsOther { get; set; }
        public string UtilitiesRequirement { get; set; }
        public string SafetyFeatures { get; set; }
        public string EnergyEfficiencyFeatures { get; set; }
        public string SparesServicing { get; set; }
        public string ScopeConfirmation { get; set; }
        public string ScopeDeviationRemarks { get; set; }
        public string Erection { get; set; }
        public string ErectionOther { get; set; }
        public string InstallationResponsibility { get; set; }
        public string InstallationResponsibilityOther { get; set; }
        public string Testing { get; set; }
        public string TestingOther { get; set; }
        public string Commissioning { get; set; }
        public string CommissioningOther { get; set; }
        public string ItemName { get; set; }
        public string ManufacturerPartNoTech { get; set; }
        public string ModelVersion { get; set; }
        public string ProductLifeCycleValue { get; set; }
        public string ProductLifeCycleUnit { get; set; }
    }


    public class Server
    {
        public string ServerIP { get; set; }
        public string ServerPort { get; set; }
        public string FileServerURL { get; set; }
        public string FtpUserName { get; set; }
        public string FtpPassword { get; set; }
        public string Extensions { get; set; }
    }
    

}
