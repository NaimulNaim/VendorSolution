using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.CBPSModule
{
    public class VendorHardCopyBillReceiveReturnDataModel
    {
        public List<VendorHardCopyReceiveModel> DocInfo { get; set; }
        public BPS_POHeader DocHeaderInfo { get; set; }
        //public IList<BPS_POItem> PoItems { get; set; }
    }
}
