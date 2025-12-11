using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.CBPSModule
{
	public class TdsVdsModel
	{
		public string BillTrackingNo { get; set; }
		public string PONo { get; set; }
		public decimal InvoiceAmt { get; set; }
		public string UserName { get; set; }
		public string BenchMark { get; set; }
		public string NewBenchMark { get; set; }
		public string EmployeeID { get; set; }
		public string CompanyCode { get; set; }
		public string FiscalYear { get; set; }
		public string ClearingNo { get; set; }
		public string VendorCode { get; set; }
	}
}
