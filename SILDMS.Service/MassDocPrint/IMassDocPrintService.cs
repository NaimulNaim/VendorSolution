using SILDMS.Model.CBPSModule;
using SILDMS.Model.DocScanningModule;
using SILDMS.Utillity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Service.MassDocPrint
{
    public interface IMassDocPrintService
    {

        ValidationResult GetDocByCompany(string OwnerID, out List<DSM_DocProperty> docs);
        ValidationResult FindReceivedBillsDoc(string DateType, string RecDateOne, string RecDateTwo, string BillTrackingNoFrom, string Company, string DocCategory, string DocType, string DocProp, string UserID, out  List<DocSearch> docList);
        ValidationResult GetDocCategory(string OwnerID, out List<DSM_DocCategory> docCat);

        ValidationResult GetDocType(string OwnerID, string DocCatID, out List<DSM_DocType> docTyp);

        ValidationResult GetDocProp(string OwnerID, string DocCatID, string DocTyp, out List<DSM_DocProperty> docProp);

        ValidationResult GetDocByVendors(string DateType, string RecDateOne, string RecDateTwo, string VendorCode, string Company, string DocCategory, string DocType, string DocProp, string UserID, out List<DocSearch> docList);

        ValidationResult FindDocbyDate(string RecDateOne, string RecDateTwo, string DateType, string Company, string DocCategory, string DocType, string DocProp, string UserID, out List<DocSearch> docList);
        ValidationResult GetDoc(string PONo, string DocProp, string UserID, out List<DocSearch> docList);
        //ValidationResult GetBilltrackingNo(string billTrackingNo, string ownerId, int page, int itemsPerPage, string sortBy, bool reverse, string search, out List<BPS_BillReceive> billReceive);

        ValidationResult GetDocByGLCode(string DateType, string RecDateOne, string RecDateTwo, string GLAccount, string Company, string DocCategory, string DocType, string DocProp, string UserID, out List<DocSearch> docList);

        ValidationResult GetDocByPostDocNo(string DateType, string RecDateOne, string RecDateTwo, string PostDocNo, string Company, string DocCategory, string DocType, string DocProp, string UserID, out List<DocSearch> docList);

        ValidationResult GetDocProperty(out List<DSM_DocProperty> docProp);
        ValidationResult GetDocPropertyForLC(out List<DSM_DocProperty> docProp);
    }
}
