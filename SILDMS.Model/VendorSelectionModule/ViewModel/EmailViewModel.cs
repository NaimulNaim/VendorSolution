using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.VendorSelectionModule.ViewModel
{
    public class EmailViewModel
    {
        public int  EmailID { get; set; }   
        public string EmailSubject { get; set; } = string.Empty;
        public string EmailBody { get; set; }
    }
}
