using SILDMS.Model.CBPSModule;
using SILDMS.Model.DocScanningModule;
using SILDMS.Model.VendorSelectionModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.DataAccess.FinancialQuotation
{
    public interface IFinancialQuotationData
    {
        List<Invitation> GetAllInvitationData(string userid, out string errorNumber);
        List<MaterialInvitation> InvWiseMaterialData(string UserID, string invNumber, out string errorNumber);

        BPS_NewBillReturnData AddDocumentInfo(DocumentsInfo _modelDocumentsInfo,
            string _selectedPropID, List<DocMetaValue> _docMetaValues,
            string _action, out string _errorNumber);
        List<Quotation> submitquotationData(string invId, string biddingItemVendorID, string invitationNumber, out string errorNumber);
        int submitfinancialquotationData(string UserId,FinancialQuotationDetail financialQuotationlist, SimplifiedMaterialInvitation materialInvitationlist,string ProposalType, Quotation quotation, out string errorNumber);
        List<Quotation> GetAllQuotationData(string userid,out string errorNumber);
        List<MaterialInvitation> QuotWiseMaterialData(string UserId,string quotationNo, out string errorNumber);
        List<FinancialQuotationDetail> FinQuotwiseDetailsData(string finQuotationItemID, out string errorNumber);
        Model.VendorSelectionModule.Server FetchServerDetailsData(string billReceiveID, out string errorNumber);
        long SaveFinQuotwiseDetailsData(FinancialQuotationDetail financialQuotation, out string errorNumber);
        DSM_Documents GetMaterialDocStatus(out bool docStatus, string materialCode, out string errorNumber);
        string UpdateExtensionByDocIdData(string documentID, string extension, out string errorNumber);
        List<Item> ItemlistData(out string errorNumber);
    }
}
