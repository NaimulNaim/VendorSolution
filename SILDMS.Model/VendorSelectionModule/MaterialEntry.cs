using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.VendorSelectionModule
{
    public class MaterialEntry
    {
         public string Id { get; set; }
        public string MaterialType { get; set; }
        public string MaterialGroup { get; set; }
        public string MaterialName { get; set; }
        public string MaterialCode { get; set; }
        public string BaseUnit { get; set; }
        public string ShortText { get; set; }
    }
}
