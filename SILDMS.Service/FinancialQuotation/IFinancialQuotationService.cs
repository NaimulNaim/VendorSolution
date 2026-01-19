using SILDMS.Model.CBPSModule;
using SILDMS.Model.DocScanningModule;
using SILDMS.Model.VendorSelectionModule;
using SILDMS.Utillity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Service.FinancialQuotation
{
    public interface IFinancialQuotationService
    {
        ValidationResult GetAllInvitationService(string userID, out List<Invitation> invitationList);

        ValidationResult InvWiseMaterialService(string UserID, string invNumber,string ProposalType,string Fintype, out List<MaterialInvitation> materialList);

        ValidationResult AddDocumentInfo(DocumentsInfo _modelDocumentsInfo,
            string _selectedPropID, List<DocMetaValue> _docMetaValues, string action,
            out BPS_NewBillReturnData docPropIdentifyList);
        ValidationResult submitquotationService(string invId, string biddingItemVendorID, string invitationNumber, out List<Quotation> QuotationList);
        ValidationResult submitfinancialquotationservice(string UserID,FinancialQuotationDetail financialQuotationlist, SimplifiedMaterialInvitation materialInvitationlist,string ProposalType, Quotation quotation, out int iD);
        ValidationResult GetAllQuotationService(string userid, out List<Quotation> quotationList);
        ValidationResult QuotWiseMaterialService(string UserId,string quotationNo, out List<MaterialInvitation> allmaterial);
        ValidationResult FinQuotwiseDetailsService(string financialquotdetailID, out List<FinancialQuotationDetail> technicalQuotationList);
        ValidationResult FetchServerDetailsService(string billReceiveID, out Model.VendorSelectionModule.Server serverList);
        ValidationResult SaveFinQuotwiseDetailsService(FinancialQuotationDetail financialQuotation, out long iD);
        ValidationResult GetMaterialDocStatus(out DSM_Documents document, out bool docStatus, string materialCode);
        ValidationResult UpdateExtensionByDocIdService(string documentID, string extension, out string iD);
        ValidationResult ItemlistService(out List<Item> itemList);
    }
}
