using SILDMS.Model.CBPSModule;
using SILDMS.Model.DocScanningModule;
using SILDMS.Model.VendorSelectionModule;
using SILDMS.Utillity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.DataAccess.VendorRegistrationUpdate
{
    public interface IVendorRegistrationUpdateData
    {
        BillInfoForFurtherDoc GetDocsForFurtherDoc(string tinBinDocId, string userID, out string errorNumber);
        List<VendorRegData> GetVendorInformation(string userID, out string errorNumber);

    }
}
