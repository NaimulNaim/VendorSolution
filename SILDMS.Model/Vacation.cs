using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model
{
    public class Vacation
    {
        public string id { get; set; }
        public string ownerLevel { get; set; }
        public string owner { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string holidayType { get; set; }
        public string holidayTitle { get; set; }
        public string shortdesc { get; set; }
        public string color { get; set; }
    }
}
