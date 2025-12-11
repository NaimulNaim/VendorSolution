//using SILDMS.DataAccessInterface.MassDocPrint;
using SILDMS.Model.CBPSModule;
using SILDMS.Model.DocScanningModule;
using SILDMS.Utillity;
using SILDMS.Utillity.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Service.MassDocPrint
{
    public class MassDocPrintService//:IMassDocPrintService
    {
        //#region Fields

        ////private readonly IMassDocPrintDataService massDocPrintDataService;
        //private readonly ILocalizationService localizationService;
        //private string status = "";
        //#endregion

        ////#region Constractor
        ////public MassDocPrintService(IMassDocPrintDataService repository, ILocalizationService localizationService)
        ////{
        ////    this.massDocPrintDataService = repository;
        ////    this.localizationService = localizationService;
        ////}

        ////#endregion
        ////public ValidationResult GetDocByCompany(string OwnerID, out List<DSM_DocProperty> docs)
        ////{
        ////    docs = massDocPrintDataService.GetDocByCompany(OwnerID, out status);
        ////    if (status.Length > 0)
        ////    {
        ////        return new ValidationResult(status, localizationService.GetResource(status));
        ////    }
        ////    return ValidationResult.Success;
        ////}

        //public ValidationResult GetDocCategory(string OwnerID, out List<DSM_DocCategory> docCat)
        //{
        //    docCat = massDocPrintDataService.GetDocCategory(OwnerID, out status);
        //    if (status.Length > 0)
        //    {
        //        return new ValidationResult(status, localizationService.GetResource(status));
        //    }
        //    return ValidationResult.Success;
        //}

        //public ValidationResult FindReceivedBillsDoc(string DateType, string RecDateOne, string RecDateTwo, string BillTrackingNoFrom, string Company, string DocCategory, string DocType, string DocProp, string UserID, out List<DocSearch> docs)
        //{
        //    docs = massDocPrintDataService.FindReceivedBillsDoc(DateType, RecDateOne, RecDateTwo, BillTrackingNoFrom, Company, DocCategory, DocType, DocProp, UserID, out status);
        //    if (status.Length > 0)
        //    {
        //        return new ValidationResult(status, localizationService.GetResource(status));
        //    }
        //    return ValidationResult.Success;
        //}


        //public ValidationResult GetDocType(string OwnerID, string DocCatID, out List<DSM_DocType> docTyp)
        //{
        //    docTyp = massDocPrintDataService.GetDocType(OwnerID, DocCatID, out status);
        //    if (status.Length > 0)
        //    {
        //        return new ValidationResult(status, localizationService.GetResource(status));
        //    }
        //    return ValidationResult.Success;
        //}


        //public ValidationResult GetDocProp(string OwnerID, string DocCatID, string DocTyp, out List<DSM_DocProperty> docProp)
        //{
        //    docProp = massDocPrintDataService.GetDocProp(OwnerID, DocCatID, DocTyp, out status);
        //    if (status.Length > 0)
        //    {
        //        return new ValidationResult(status, localizationService.GetResource(status));
        //    }
        //    return ValidationResult.Success;
        //}


        //public ValidationResult GetDocByVendors(string DateType, string RecDateOne, string RecDateTwo, string VendorCode, string Company, string DocCategory, string DocType, string DocProp, string UserID, out List<DocSearch> docList)
        //{
        //    docList = massDocPrintDataService.GetDocByVendors( DateType, RecDateOne, RecDateTwo, VendorCode, Company, DocCategory, DocType, DocProp, UserID, out status);
        //    if (status.Length > 0)
        //    {
        //        return new ValidationResult(status, localizationService.GetResource(status));
        //    }
        //    return ValidationResult.Success;
        //}


        //public ValidationResult FindDocbyDate(string RecDateOne, string RecDateTwo, string DateType, string Company, string DocCategory, string DocType, string DocProp, string UserID, out List<DocSearch> docList)
        //{
        //    docList = massDocPrintDataService.FindDocbyDate(RecDateOne, RecDateTwo, DateType, Company, DocCategory, DocType, DocProp, UserID, out status);
        //    if (status.Length > 0)
        //    {
        //        return new ValidationResult(status, localizationService.GetResource(status));
        //    }
        //    return ValidationResult.Success;
        //}

        //public ValidationResult GetDoc(string PONo, string DocProp, string UserID, out List<DocSearch> docList)
        //{
        //    docList = massDocPrintDataService.GetDoc(PONo, DocProp, UserID, out status);
        //    if (status.Length > 0)
        //    {
        //        return new ValidationResult(status, localizationService.GetResource(status));
        //    }
        //    return ValidationResult.Success;
        //}


        //public ValidationResult GetBilltrackingNo(string billTrackingNo, string ownerId, int page, int itemsPerPage, string sortBy, bool reverse, string search, out List<BPS_BillReceive> billReceive)
        //{
        //    billReceive = massDocPrintDataService.GetBilltrackingNo(billTrackingNo, ownerId, page, itemsPerPage, sortBy, reverse, search, out status);
        //    if (status.Length > 0)
        //    {
        //        return new ValidationResult(status, localizationService.GetResource(status));
        //    }
        //    return ValidationResult.Success;
        //}


        //public ValidationResult GetDocByGLCode(string DateType, string RecDateOne, string RecDateTwo, string GLAccount, string Company, string DocCategory, string DocType, string DocProp, string UserID, out List<DocSearch> docList)
        //{
        //    docList = massDocPrintDataService.GetDocByGLCode(DateType, RecDateOne, RecDateTwo, GLAccount, Company, DocCategory, DocType, DocProp, UserID, out status);
        //    if (status.Length > 0)
        //    {
        //        return new ValidationResult(status, localizationService.GetResource(status));
        //    }
        //    return ValidationResult.Success;
        //}


        //public ValidationResult GetDocByPostDocNo(string DateType, string RecDateOne, string RecDateTwo, string PostDocNo, string Company, string DocCategory, string DocType, string DocProp, string UserID, out List<DocSearch> docList)
        //{
        //    docList = massDocPrintDataService.GetDocByPostDocNo(DateType, RecDateOne, RecDateTwo, PostDocNo, Company, DocCategory, DocType, DocProp, UserID, out status);
        //    if (status.Length > 0)
        //    {
        //        return new ValidationResult(status, localizationService.GetResource(status));
        //    }
        //    return ValidationResult.Success;
        //}


        //public ValidationResult GetDocProperty(out List<DSM_DocProperty> docProp)
        //{
        //    docProp = massDocPrintDataService.GetDocProperty(out status);
        //    if (status.Length > 0)
        //    {
        //        return new ValidationResult(status, localizationService.GetResource(status));
        //    }
        //    return ValidationResult.Success;
        //}
        //public ValidationResult GetDocPropertyForLC(out List<DSM_DocProperty> docProp)
        //{
        //    docProp = massDocPrintDataService.GetDocPropertyForLC(out status);
        //    if (status.Length > 0)
        //    {
        //        return new ValidationResult(status, localizationService.GetResource(status));
        //    }
        //    return ValidationResult.Success;
        //}
    }
}
