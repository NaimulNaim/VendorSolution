using SILDMS.Model.CBPSModule;
using SILDMS.Model.DocScanningModule;
using SILDMS.Model.VendorSelectionModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.DataAccess.TechnicalQuotation
{
    public interface ITechnicalQuotationData
    {
        List<Invitation> GetAllInvitationData(string userid,out string errorNumber);
        List<MaterialInvitation> InvWiseMaterialData(string UserID, string invNumber, out string errorNumber);

        BPS_NewBillReturnData AddDocumentInfo(DocumentsInfo _modelDocumentsInfo,
            string _selectedPropID, List<DocMetaValue> _docMetaValues,
            string _action, out string _errorNumber);
        List<Quotation> submitquotationData(string Userid,string invId, string biddingItemVendorID, string invitationNumber, string MaterialCode,string MaterialName,string RFQUnit,  out string errorNumber);
        int submittechnicalquotationData(string UserId,Model.VendorSelectionModule.TechnicalQuotation technicalQuotationlist, SimplifiedMaterialInvitation materialInvitationlist, Quotation quotation, out string errorNumber);
        List<Quotation> GetAllQuotationData(string UserId,out string errorNumber);
        List<MaterialInvitation> QuotWiseMaterialData(string quotationNo, out string errorNumber);
        List<Model.VendorSelectionModule.TechnicalQuotation> TechQuotwiseDetailsData(string techQuotationItemID, out string errorNumber);
        Model.VendorSelectionModule.Server FetchServerDetailsData(string billReceiveID, out string errorNumber);
        long SaveTechQuotwiseDetailsData(Model.VendorSelectionModule.TechnicalQuotation technicalQuotation, out string errorNumber);
        DSM_Documents GetMaterialDocStatus(out bool docStatus, string materialCode,string BiddingID,string VendorCode,  out string errorNumber);
        string UpdateExtensionByDocIdData(string documentID, string extension, out string errorNumber);
        List<Item> ItemlistData(out string errorNumber);

        List<Sys_MasterData> GetAllItemTypes(string masterDataType, out string _errorNumber);
        bool DeleteTechQuotwiseDetailsData(string techQuotationItemID, out string errorNumber);
        bool DeleteDocumenDataService(string documentID, out string errorNumber);
    }
}
