using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.CBPSModule
{
    public class BPS_UserBoxLocationMap
    {
        public string UserBoxLocationMapID { get; set; }
        public string UserID { get; set; }
        public string LocationID { get; set; }
        public string Remarks { get; set; }
        public string SetBy { get; set; }
        public string ModifiedBy { get; set; }
        public int Status { get; set; }

    }
}
