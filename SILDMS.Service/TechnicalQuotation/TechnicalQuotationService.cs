using SILDMS.DataAccess.TechnicalQuotation;
using SILDMS.Model.CBPSModule;
using SILDMS.Model.DocScanningModule;
using SILDMS.Model.VendorSelectionModule;
using SILDMS.Utillity;
using SILDMS.Utillity.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Service.TechnicalQuotation
{
    public class TechnicalQuotationService : ITechnicalQuotationService
    {
        private readonly ITechnicalQuotationData _technicalQuotationData;
        private readonly ILocalizationService _localizationService;
        private string _errorNumber = string.Empty;






        public TechnicalQuotationService(ITechnicalQuotationData technicalQuotationData,ILocalizationService localizationService)
        {
            _technicalQuotationData = technicalQuotationData;
            _localizationService = localizationService;

            _errorNumber = string.Empty;
        }
        public ValidationResult GetAllInvitationService(string userID, out List<Invitation> invitationList)
        {
   
            invitationList = _technicalQuotationData.GetAllInvitationData(userID,out _errorNumber);
            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }

        public ValidationResult InvWiseMaterialService(string UserID,string invNumber, out List<MaterialInvitation> materialList)
        {
            materialList = _technicalQuotationData.InvWiseMaterialData(UserID,invNumber, out _errorNumber);
            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }

        public ValidationResult AddDocumentInfo(DocumentsInfo _modelDocumentsInfo,
                    string _selectedPropID, List<DocMetaValue> _docMetaValues, string action,
                    out BPS_NewBillReturnData docPropIdentifyList)
        {
            docPropIdentifyList = _technicalQuotationData.AddDocumentInfo
                (_modelDocumentsInfo, _selectedPropID, _docMetaValues, action, out _errorNumber);

            if (_errorNumber.Length > 0)
            {
                return new ValidationResult(_errorNumber,
                    _localizationService.GetResource(_errorNumber));
            }

            return ValidationResult.Success;
        }


        public ValidationResult submitquotationService(string UserId,string invId, string biddingItemVendorID, string invitationNumber,out List<Quotation> quotationList)
        {

            quotationList = _technicalQuotationData.submitquotationData(UserId,invId, biddingItemVendorID, invitationNumber,out _errorNumber);
            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }

        public ValidationResult submittechnicalquotationservice(string UserId,List<Model.VendorSelectionModule.TechnicalQuotation> technicalQuotationlist, List<MaterialInvitation> materialInvitationlist, Quotation quotation, out int iD)
        {

            iD = _technicalQuotationData.submittechnicalquotationData(UserId,technicalQuotationlist, materialInvitationlist, quotation, out _errorNumber);
            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }

        public ValidationResult GetAllQuotationService(string UserId,out List<Quotation> quotationList)
        {
            quotationList = _technicalQuotationData.GetAllQuotationData(UserId,out _errorNumber);
            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }

        public ValidationResult QuotWiseMaterialService(string quotationNo, out List<MaterialInvitation> allmaterial)
        {
            allmaterial = _technicalQuotationData.QuotWiseMaterialData(quotationNo,out _errorNumber);
            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }

        public ValidationResult TechQuotwiseDetailsService(string techQuotationItemID, out List<Model.VendorSelectionModule.TechnicalQuotation> technicalQuotationList)
        {
            technicalQuotationList = _technicalQuotationData.TechQuotwiseDetailsData(techQuotationItemID, out _errorNumber);

            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }

        public ValidationResult FetchServerDetailsService(string billReceiveID, out Model.VendorSelectionModule.Server serverList)
        {
            serverList = _technicalQuotationData.FetchServerDetailsData(billReceiveID, out _errorNumber);

            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }

        public ValidationResult SaveTechQuotwiseDetailsService(Model.VendorSelectionModule.TechnicalQuotation technicalQuotation, out long iD)
        {
            iD = _technicalQuotationData.SaveTechQuotwiseDetailsData(technicalQuotation, out _errorNumber);

            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }

        public ValidationResult GetMaterialDocStatus(out DSM_Documents document, out bool docStatus, string materialCode, string BiddingID, string VendorCode)
        {
            document = _technicalQuotationData.GetMaterialDocStatus(out docStatus, materialCode, BiddingID, VendorCode, out _errorNumber);
            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }

        public ValidationResult UpdateExtensionByDocIdService(string documentID, string extension, out string iD)
        {
            iD = _technicalQuotationData.UpdateExtensionByDocIdData(documentID, extension, out _errorNumber);
            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }


        public ValidationResult ItemlistService(out List<Item> items)
        {
            items = _technicalQuotationData.ItemlistData(out _errorNumber);
            return _errorNumber.Length > 0
                ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
                : ValidationResult.Success;
        }

        public ValidationResult GetAllItemTypes(string masterDataType, out List<Sys_MasterData> itemTypes)
        {
            itemTypes = _technicalQuotationData.GetAllItemTypes(masterDataType, out _errorNumber);
            return _errorNumber.Length > 0 ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber)) :
                ValidationResult.Success;
        }

    }
}

