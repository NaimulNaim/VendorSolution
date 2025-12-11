using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.VendorSelectionModule.ViewModel
{
    public class EmpWiseAssignmentViewModel
    {
        public string UserID { get; set; }
        public string EmployeeName { get; set; }
        public string Category { get; set; }
        public string CategoryCode { get; set; }
        public int TotalItem { get; set; }
        public int RM { get; set; }
        public int PM { get; set; }
        public int IT { get; set; }
        public int Other {  get; set; }
        public int SP { get; set; }
        public int CM { get; set; }
        public int Asset { get; set; }
        public int NM { get; set; }
        public int Service { get; set; }
        public int PoM { get; set; }
    }
}
