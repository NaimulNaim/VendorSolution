using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.VendorSelectionModule
{
    public class GoogleSearch
    {
        public string title { get; set; }
        public long googlesearch_Id { get; set; }
       
        public string phone { get; set; }

        public string phone2 { get; set; }

        public string website { get; set; }
        public string address { get; set; }
        public string email { get; set; }

        public string email2 { get; set; }
        public string searchname { get; set; }
        public string business_name { get; set; }
        public string mat_code { get; set; }

        public string ExistVendorId { get; set; }
        public double Quantity { get; set; }
        public int status { get; set; }
    }
}
