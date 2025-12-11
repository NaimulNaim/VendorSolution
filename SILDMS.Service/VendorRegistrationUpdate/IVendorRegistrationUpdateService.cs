using SILDMS.Model.CBPSModule;
using SILDMS.Model.DocScanningModule;
using SILDMS.Model.VendorSelectionModule;
using SILDMS.Utillity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Service.VendorRegistrationUpdate
{
    public interface IVendorRegistrationUpdateService
    {
        ValidationResult GetDocsForFurtherDoc(string tinBinDocId, string userID, out BillInfoForFurtherDoc docs);

        ValidationResult GetVendorInformation(string userID, out List<VendorRegData> indvVendorData);
    }
}
