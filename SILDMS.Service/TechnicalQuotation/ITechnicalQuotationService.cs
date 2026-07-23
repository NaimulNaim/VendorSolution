using SILDMS.Model.CBPSModule;
using SILDMS.Model.DocScanningModule;
using SILDMS.Model.VendorSelectionModule;
using SILDMS.Utillity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Service.TechnicalQuotation
{
    public interface ITechnicalQuotationService
    {
        ValidationResult GetAllInvitationService(string userID, out List<Invitation> invitationList);
        ValidationResult GetAllItemTypes(string masterDataType, out List<Sys_MasterData> itemTypes);

        ValidationResult InvWiseMaterialService(string UserID, string invNumber, out List<MaterialInvitation> materialList);

        ValidationResult AddDocumentInfo(DocumentsInfo _modelDocumentsInfo,
            string _selectedPropID, List<DocMetaValue> _docMetaValues, string action,
            out BPS_NewBillReturnData docPropIdentifyList);
        ValidationResult submitquotationService(string UserId,string invId, string biddingItemVendorID, string invitationNumber,string MaterialCode,string MaterialName,string RFQUnit, out List<Quotation> QuotationList);
        ValidationResult submittechnicalquotationservice(string UserId, Model.VendorSelectionModule.TechnicalQuotation technicalQuotationlist,SimplifiedMaterialInvitation materialInvitationlist, Quotation quotation, out int iD);
        ValidationResult GetAllQuotationService(string UserID, out List<Quotation> quotationList);
        ValidationResult QuotWiseMaterialService(string quotationNo, out List<MaterialInvitation> allmaterial);
        ValidationResult TechQuotwiseDetailsService(string techQuotationItemID, out List<Model.VendorSelectionModule.TechnicalQuotation> technicalQuotationList);
        ValidationResult FetchServerDetailsService(string billReceiveID, out Model.VendorSelectionModule.Server serverList);
        ValidationResult SaveTechQuotwiseDetailsService(Model.VendorSelectionModule.TechnicalQuotation technicalQuotation, out long iD);
        ValidationResult GetMaterialDocStatus(out DSM_Documents document, out bool docStatus, string materialCode,string BiddingID,string VendorCode);
        ValidationResult UpdateExtensionByDocIdService(string documentID, string extension, out string iD);
        ValidationResult ItemlistService(out List<Item> itemList);
        ValidationResult DeleteTechQuotwiseDetailsService(string techQuotationItemID, out bool isDeleted);
    }
}
