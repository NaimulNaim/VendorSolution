using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.VendorSelectionModule
{
    public class ExictingVendorInfo
    {
        public long VendorID { get; set; }
        public string VendorName { get; set; }
        public string VendorPhoneNumberOne { get; set; }
        public string VendorPhoneNumberTwo { get; set; }
        public string VendorEmail { get; set; }
        public string VendorCountry { get; set; }
        public string MaterialCode { get; set; }
        public string EnlistedStatus { get; set; }
    }

    public class VendorDetails
    {
        public string BusinessName { get; set; }
        public string ContactPerson { get; set; }
        public string VendorPhoneNumber { get; set; }
        public string Email { get; set; }
        public string TIN { get; set; }
        public string BIN { get; set; }
        public string CompanyAddress { get; set; }
        public string GenaralDetailsServices { get; set; }
    }
}
