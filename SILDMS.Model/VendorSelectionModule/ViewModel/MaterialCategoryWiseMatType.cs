using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.VendorSelectionModule.ViewModel
{
    public class MaterialCategoryWiseMatType
    {

        public string UserID { get; set; }
        public string OwnerID { get; set; }
        public string PlantCode { get; set; }
        public string DepartmentID { get; set; }
        public string MaterialCategory { get; set; }
        public string MaterialCategoryCode { get; set; }
        public string MaterialType { get; set; }
        public string PurGroup { get; set; }
        public string MaterialNameCount { get; set; }


    }

    public class MaterialTypeWiseMat
    {
        public string UserID { get; set; }
        public string MaterialType { get; set; }
        public string MaterialNameCount { get; set; }
    }
}
