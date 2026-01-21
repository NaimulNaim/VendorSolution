using System;

namespace SILDMS.Model.VendorSelectionModule
{
    //public class TechnicalQuotation
    //{
    //    public string TechQuotationItemID { get; set; }
    //    public string rowIndex { get; set; }
    //    public string MoleculeName { get; set; }
    //    public string SampleAvailable { get; set; }
    //    public string OtherSample { get; set; }
    //    public string CASNO { get; set; }
    //    public string RepresentativePackSize { get; set; }
    //    public string Manufacturer { get; set; }
    //    public string Regulatory { get; set; }
    //    public string Supplier { get; set; }
    //    public string CurrentStatus { get; set; }
    //    public string ManufactureAddress { get; set; }
    //    public int ProdCapacity { get; set; }
    //    public decimal RDPrice { get; set; }
    //    public Currency RNDPriceCur { get; set; }
    //    public int Shelf { get; set; }
    //    public decimal CommercialPrice { get; set; }
    //    public Currency ComPriceCur { get; set; }
    //    public string Condition { get; set; }
    //    public int OrderQty { get; set; }
    //    public string OrderUnit { get; set; }
    //    public string Specification { get; set; }
    //    public string OtherSpecification { get; set; }
    //    public int CommercialConsignment { get; set; }
    //    public int AvailPackSize { get; set; }
    //    public int MinPack { get; set; }
    //    public string Example { get; set; }
    //    public Currency Currency { get; set; }
    //    public string Reference { get; set; }
    //    public string Validation { get; set; }
    //    public string Training { get; set; }
    //    public string Prerequisite { get; set; }
    //    public string ManufacturerPart { get; set; }
    //    public string Installation { get; set; }
    //    public string Subcontractor { get; set; }
    //    public string ManufacturerOrigin { get; set; }
    //    public string Penalty { get; set; }
    //    public string Fat { get; set; }
    //    public string Calibration { get; set; }
    //    public string Alldocuments { get; set; }
    //    //public string RNDPriceCur { get; set; }
    //    //public string ComPriceCur { get; set; }
    //    public Item OrderQtyUnit { get; set; }
    //    public string LocalPartner { get; set; }
    //    public string ShelfUnit { get; set; }
    //    public string APIRegApproval { get; set; }
    //}



    //public class TechnicalQuotation
    //{

    //    public string TechQuotationItemID { get; set; }
    //    public string rowIndex { get; set; }

    //    // --- Item / Molecule ---
    //    public string ItemName { get; set; }
    //    public string MoleculeName { get; set; }

    //    // --- Manufacturer / Supplier ---
    //    public string Manufacturer { get; set; }
    //    public string ManufacturerPart { get; set; }
    //    public string ManufactureAddress { get; set; }
    //    public string ManufacturerOrigin { get; set; }
    //    public string Supplier { get; set; }
    //    public string LocalPartner { get; set; }

    //    // --- Pricing ---
    //    public decimal? RDPrice { get; set; }
    //    public decimal? CommercialPrice { get; set; }
    //    public decimal? PricePer { get; set; }
    //    public string PriceUnit { get; set; }
    //    public string Currency { get; set; }

    //    // --- Order / Pack ---
    //    public int? MinOrderQty { get; set; }
    //    public string OrderQtyUnit { get; set; }
    //    public string CommercialPackSize { get; set; }
    //    public string MinPack { get; set; }

    //    // --- Shelf / Storage ---
    //    public int? ShelfLifeValue { get; set; }
    //    public string ShelfLifeUnit { get; set; }
    //    public string StorageCondition { get; set; }

    //    // --- References / Notes ---
    //    public string Reference { get; set; }
    //    public string Notes { get; set; }
    //    public string CASNO { get; set; }
    //    public string CASNo { get; set; }
    //    public string CatalogueNo { get; set; }

    //    // --- Production ---
    //    public string CurrentStatus { get; set; }
    //    public string ProdCapacity { get; set; }
    //    public string ProductionFrequency { get; set; }
    //    public int? ProductionLeadTimeValue { get; set; }
    //    public string ProductionLeadTimeUnit { get; set; }

    //    // --- Representative Sample ---
    //    public string RepresentativeSample { get; set; }
    //    public string RepresentativeSamplePackSize { get; set; }

    //    // --- Compliance / Qualification ---
    //    public string ComplianceWith { get; set; }
    //    public string QualificationDocuments { get; set; }
    //    public string QualificationDocumentsOther { get; set; }

    //    // --- FAT / SAT / Assistance ---
    //    public string FATAtManufacturerSite { get; set; }
    //    public string FATAtManufacturerSiteOther { get; set; }
    //    public string SATScope { get; set; }
    //    public string AssistanceAtSite { get; set; }
    //    public string AssistanceAtSiteOther { get; set; }

    //    // --- Utilities / Safety ---
    //    public string UtilitiesRequirement { get; set; }
    //    public string SafetyFeatures { get; set; }
    //    public string EnergyEfficiencyFeatures { get; set; }

    //    // --- Servicing / Scope ---
    //    public string SparesServicing { get; set; }
    //    public string ScopeConfirmation { get; set; }
    //    public string ScopeDeviationRemarks { get; set; }

    //    // --- Responsibility Matrix ---
    //    public string Erection { get; set; }
    //    public string ErectionOther { get; set; }

    //    public string Installation { get; set; }
    //    public string InstallationOther { get; set; }

    //    public string Testing { get; set; }
    //    public string TestingOther { get; set; }

    //    public string Commissioning { get; set; }
    //    public string CommissioningOther { get; set; }

    //    // --- Regulatory ---
    //    public string RegulatoryApproval { get; set; }
    //    public string RegulatoryApprovalOther { get; set; }
    //    public string SampleDocumentID { get; set; }


    //    // --- Misc ---
    //    public string ColumnSpecification { get; set; }
    //    public string CapacityExtendable { get; set; }
    //    public string ProductLifeCycleUnit { get; set; }
    //    public string CapacityExtendableOther { get; set; }
    //    public object CountryOrigin { get; set; }
    //    public string YearOfManufacturing { get; set; }
    //    public decimal ProductLifeCycleValue { get; set; }
    //    public string Capacity { get; set; }
    //    public string ModelVersion { get; set; }
    //    public string proposal { get; set; }
    //    public string Proposal { get; set; }
    //    public string techtype { get; set; }
    //    public string Techtype { get; set; }
    //    public string QuotationRevisionNo { get; set; }
    //    public string QuotationID { get; set; }
    //    public string QuotationNo { get; set; }
    //    public string ManufactureOrigin { get; set; }
    //    public string InstallTestCom { get; set; }
    //    public string SubContractor { get; set; }
    //    public string Calibration { get; set; }
    //    public string Training { get; set; }
    //    public string ValidationScope { get; set; }
    //    public string PenealtyClause { get; set; }
    //}


    public class TechnicalQuotation
    {
        // --- Identity ---
        public string TechQuotationItemID { get; set; }
        public string rowIndex { get; set; }

        // --- Item / Molecule ---
        public string ItemName { get; set; }
        public string MoleculeName { get; set; }

        // --- Manufacturer / Supplier ---
        public string Manufacturer { get; set; }
        public string ManufacturerPart { get; set; }
        public string ManufactureAddress { get; set; }
        public string ManufacturerOrigin { get; set; }
        public string Supplier { get; set; }
        public string LocalPartner { get; set; }

        // --- Pricing ---
        public decimal? RDPrice { get; set; }
        public decimal? CommercialPrice { get; set; }
        public decimal? PricePer { get; set; }
        public Item PriceUnit { get; set; }
        public MasterData Currency { get; set; }

        // --- Order / Pack ---
        public int? MinOrderQty { get; set; }
        public string OrderQtyUnit { get; set; }
        public string CommercialPackSize { get; set; }
        public string MinPack { get; set; }

        // --- Shelf / Storage ---
        public int? ShelfLifeValue { get; set; }
        public string ShelfLifeUnit { get; set; }
        public string StorageCondition { get; set; }

        // --- References / Notes ---
        public string Reference { get; set; }
        public string Notes { get; set; }
        public string CASNO { get; set; }        // KEEP ONE
        public string CatalogueNo { get; set; }

        // --- Production ---
        public string CurrentStatus { get; set; }
        public string ProdCapacity { get; set; }
        public string ProductionFrequency { get; set; }
        public int? ProductionLeadTimeValue { get; set; }
        public string ProductionLeadTimeUnit { get; set; }

        // --- Sample ---
        public string RepresentativeSample { get; set; }
        public string RepresentativeSamplePackSize { get; set; }

        // --- Compliance ---
        public string ComplianceWith { get; set; }
        public string QualificationDocuments { get; set; }
        public string QualificationDocumentsOther { get; set; }

        // --- FAT / SAT ---
        public string FATAtManufacturerSite { get; set; }
        public string FATAtManufacturerSiteOther { get; set; }
        public string SATScope { get; set; }
        public string AssistanceAtSite { get; set; }
        public string AssistanceAtSiteOther { get; set; }

        // --- Utilities / Safety ---
        public string UtilitiesRequirement { get; set; }
        public string SafetyFeatures { get; set; }
        public string EnergyEfficiencyFeatures { get; set; }

        // --- Scope ---
        public string SparesServicing { get; set; }
        public string ScopeConfirmation { get; set; }
        public string ScopeDeviationRemarks { get; set; }

        // --- Responsibility ---
        public string Erection { get; set; }
        public string ErectionOther { get; set; }
        public string Installation { get; set; }
        public string InstallationOther { get; set; }
        public string Testing { get; set; }
        public string TestingOther { get; set; }
        public string Commissioning { get; set; }
        public string CommissioningOther { get; set; }

        // --- Regulatory ---
        public string RegulatoryApproval { get; set; }
        public string RegulatoryApprovalOther { get; set; }

        // --- Misc ---
        public string ColumnSpecification { get; set; }
        public string ModelVersion { get; set; }
        public string CountryOrigin { get; set; }
        public string YearOfManufacturing { get; set; }
        public decimal? ProductLifeCycleValue { get; set; }
        public string ProductLifeCycleUnit { get; set; }
        public string Capacity { get; set; }
        public string CapacityExtendable { get; set; }
        public string CapacityExtendableOther { get; set; }
        public string SampleDocumentID { get; set; }
        public string Techtype { get; set; }     // KEEP ONE
        public string Proposal { get; set; }
        public string QuotationRevisionNo { get; set; }
        public string QuotationID { get; set; }
        public string QuotationNo { get; set; }
        
        public string PenaltyClause { get; set; }// KEEP ONE

       /* public string[] PharmacopeialReference { get; set; } */ // It's an array in Angular
        public string InstallationResponsibility { get; set; }
        public string InstallationResponsibilityOther { get; set; }
        public string SampleAvailable { get; set; }
        public string SamplePackSize { get; set; }
        public string PharmacopeialReference { get; set; }
        public string AllPharmacopeialReference { get; set; }
    }


    public class Currency
    {
        public string MasterDataID { get; set; }

        public string MasterDataValue { get; set; }
    }


   


//public class FinancialQuotationDetail
//    {
//        public string rowIndex { get; set; }
//        public string FinanQuotationItemID { get; set; }
//        public double ProposeQty { get; set; }
      
//        public Item Unit { get; set; }
//        public double UnitPrice { get; set; }
//        public Currency Currency { get; set; }
//        public double TotalPrice { get; set; }
//        public double VatAmount { get; set; }
//        public double TaxAmount { get; set; }
//        public double GrossPrice { get; set; }
//        public double DiscountPrice { get; set; }
//        public double NetPrice { get; set; }
//        public DateTime QuotValidDate { get; set; }
//        public DateTime ExpecDeliDate { get; set; }
//        public string ProposalType { get; set; }
//        public string QuotValidDateString { get; set; }
//        public string ExpecDeliDateString { get; set; }

 
//    }
  public class FinancialQuotationDetail
    {
        public string rowIndex { get; set; }
        public string FinanQuotationItemID { get; set; }
        public decimal ProposeQty { get; set; }
        public MasterData Currency { get; set; }

        public Item PriceUnit { get; set; }
        public decimal QuotationQty { get; set; }
        public Item QuotationQtyUnit { get; set; }

        public decimal QtyTolerance { get; set; }
        public decimal MinimumOrderQty { get; set; }
        public string PackSize { get; set; }

        // Delivery Information
        public string DeliveryTimeline { get; set; }
        public DateTime ExpecDeliDate { get; set; }
        public string ExpecDeliDateString { get; set; }
        public string PartDelivery { get; set; }
        public MasterData Incoterms { get; set; }
        public MasterData IncotermsLocation { get; set; }
        public string ShipmentMode { get; set; }
        public string InlandTransportation { get; set; }

        // Payment Information
        public MasterData PaymentMode { get; set; }
        public string PaymentTerms { get; set; }

        // Validity and Terms
        public string QuotationValidity { get; set; }
        public DateTime QuotValidDate { get; set; }
        public string QuotValidDateString { get; set; }

        // Manufacturer Information
        public string ManufacturerPartNo { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufacturerSiteAddress { get; set; }

        // Service and Support
        public string Warranty { get; set; }
        public string Installation { get; set; }
        public string Servicing { get; set; }

        // Additional Details
        public string KeyCustomerList { get; set; }
        public string Subcontractor { get; set; } = "No";
        public string SubcontractorDetails { get; set; }
        public string ReturnableItem { get; set; }
        public string PenaltyClause { get; set; }
        public string Remarks { get; set; }

        // Calculated fields
       
        public string ProposalType { get; set; }
        public string SupplierName { get; set; }
        public string LocalAgentName { get; set; }
        public decimal? Price { get; set; }
        public decimal Per { get; set; }
        public string VAT { get; set; }
        public string Tax { get; set; }
        public decimal? Freight { get; set; }
        public decimal? Discount { get; set; }

        public decimal? OrderHandlingCharges { get; set; }

        public decimal? PackingCharges { get; set; }

        public decimal? SundryCharges { get; set; }

        public decimal? DeliveryCharge { get; set; }

        public string Fintype { get; set; } 
        public string SampleDocumentID { get; set; }

        public string QuotationID { get; set; }
        public string QuotationNo { get; set; }
        public string InvitationNumber { get; set; }
  
    }

    // Supporting class for MasterData objects
    public class MasterData
    {
        public string MasterDataID { get; set; }
        public string MasterDataValue { get; set; }
    }



  









    public class Invitation
    {
        public string Invitation_Number { get; set; }

        public string ProposalType { get; set; }
        public string Fintype { get; set; }
        public string TechType { get; set; }
    }


    public class Quotation
    {
        public string quotationID { get; set; }

        public string quotationNo { get; set; }
        public string InvitationNumber { get; set; }
        public string QuotationDate { get; set; }
    }
    public class SimplifiedMaterialInvitation
    {
        public string MaterialQuantity { get; set; }
        public string Unit { get; set; }
        public string MatInvType { get; set; }
        public string invitationNumber { get; set; }
        public int? departmentId { get; set; }
        public string matCategory { get; set; }
        public int? itemNo { get; set; }
        public string materialCode { get; set; }
        public string materialName { get; set; }
        public string remarks { get; set; }
        public string sampleDocId { get; set; }
        public string VendorID { get; set; }
        public string proposalType { get; set; }
        public bool sharedToFactory { get; set; }
        public bool askFinanQoutations { get; set; }
        public string modificationType { get; set; }
        public DateTime? setOn { get; set; }
        public DateTime? modifiedOn { get; set; }
        public string SampleDocumentID { get; set; }
        public string material_Category_Code { get; set; }

        public string QuotationID { get; set; }
        public string QuotationNo { get; set; }
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
        public int ? ShelfLifeValue { get; set; }
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
        public string Fintype { get; set; }
        public string Proposal { get; set; }
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
