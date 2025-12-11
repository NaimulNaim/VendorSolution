using SILDMS.DataAccess.TechnicalQuotation;
using SILDMS.Model.CBPSModule;
using SILDMS.Model.DocScanningModule;
using SILDMS.Model.VendorSelectionModule;
using SILDMS.Utillity.Localization;
using SILDMS.Utillity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SILDMS.DataAccess.FinancialQuotation;

namespace SILDMS.Service.FinancialQuotation
{
    public class FinancialQuotationService : IFinancialQuotationService
    {
        private readonly IFinancialQuotationData _financialQuotationData;
        private readonly ILocalizationService _localizationService;
        private string _errorNumber = string.Empty;






        public FinancialQuotationService(IFinancialQuotationData financialQuotationData, ILocalizationService localizationService)
        {
            _financialQuotationData = financialQuotationData;
            _localizationService = localizationService;

            _errorNumber = string.Empty;
        }
        public ValidationResult GetAllInvitationService(string userID, out List<Invitation> invitationList)
        {

            invitationList = _financialQuotationData.GetAllInvitationData(userID, out _errorNumber);
            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }

        public ValidationResult InvWiseMaterialService(string UserID, string invNumber,string ProposalTYpe, out List<MaterialInvitation> materialList)
        {
            materialList = _financialQuotationData.InvWiseMaterialData(UserID, invNumber, ProposalTYpe, out _errorNumber);
            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }

        public ValidationResult AddDocumentInfo(DocumentsInfo _modelDocumentsInfo,
                    string _selectedPropID, List<DocMetaValue> _docMetaValues, string action,
                    out BPS_NewBillReturnData docPropIdentifyList)
        {
            docPropIdentifyList = _financialQuotationData.AddDocumentInfo
                (_modelDocumentsInfo, _selectedPropID, _docMetaValues, action, out _errorNumber);

            if (_errorNumber.Length > 0)
            {
                return new ValidationResult(_errorNumber,
                    _localizationService.GetResource(_errorNumber));
            }

            return ValidationResult.Success;
        }


        public ValidationResult submitquotationService(string invId, string biddingItemVendorID, string invitationNumber, out List<Quotation> quotationList)
        {

            quotationList = _financialQuotationData.submitquotationData(invId, biddingItemVendorID, invitationNumber, out _errorNumber);
            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }

        public ValidationResult submitfinancialquotationservice(string UserId,List<FinancialQuotationDetail> financialQuotationlist, List<MaterialInvitation> materialInvitationlist,string ProposalType, Quotation quotation, out int iD)
        {

            iD = _financialQuotationData.submitfinancialquotationData(UserId,financialQuotationlist, materialInvitationlist, ProposalType, quotation, out _errorNumber);
            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }

        public ValidationResult GetAllQuotationService(string userid,out List<Quotation> quotationList)
        {
            quotationList = _financialQuotationData.GetAllQuotationData(userid,out _errorNumber);
            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }

        public ValidationResult QuotWiseMaterialService(string UserId, string quotationNo, out List<MaterialInvitation> allmaterial)
        {
            allmaterial = _financialQuotationData.QuotWiseMaterialData(UserId, quotationNo, out _errorNumber);
            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }

        public ValidationResult FinQuotwiseDetailsService(string finQuotationItemID, out List<FinancialQuotationDetail> financialquotdetailList)
        {
            financialquotdetailList = _financialQuotationData.FinQuotwiseDetailsData(finQuotationItemID, out _errorNumber);

            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }

        public ValidationResult FetchServerDetailsService(string billReceiveID, out Model.VendorSelectionModule.Server serverList)
        {
            serverList = _financialQuotationData.FetchServerDetailsData(billReceiveID, out _errorNumber);

            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }

        public ValidationResult SaveFinQuotwiseDetailsService(FinancialQuotationDetail financialQuotation, out long iD)
        {
            iD = _financialQuotationData.SaveFinQuotwiseDetailsData(financialQuotation, out _errorNumber);

            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }

        public ValidationResult GetMaterialDocStatus(out DSM_Documents document, out bool docStatus, string materialCode)
        {
            document = _financialQuotationData.GetMaterialDocStatus(out docStatus, materialCode, out _errorNumber);
            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }

        public ValidationResult UpdateExtensionByDocIdService(string documentID, string extension, out string iD)
        {
            iD = _financialQuotationData.UpdateExtensionByDocIdData(documentID, extension, out _errorNumber);
            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }


        public ValidationResult ItemlistService(out List<Item> items)
        {
            items = _financialQuotationData.ItemlistData(out _errorNumber);
            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }
    }
}
