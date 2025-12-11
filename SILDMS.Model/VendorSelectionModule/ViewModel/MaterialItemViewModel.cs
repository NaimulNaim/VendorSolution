using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.VendorSelectionModule.ViewModel
{
    public class MaterialItemViewModel
    {
        public string ItemNo { get; set; }
        public string AssigneeNo { get; set; }
        public string MaterialName  { get; set; }
        public double MaterialQuantity { get; set; }
        public string MaterialCategory { get; set; }
        public string MaterialGroup { get; set; }
        public DateTime ExpDeliveryDate { get; set; }
    }
    public class ProcessNumberViewModel
    {
        public string ProcessNo { get; set; }
    }

    public class VendorListForInvitationViewModel
    {
        public int ID { get; set; }
        public int BiddingItemVendorID { get; set; }
        public string BiddingProcessNumber { get; set; }
        public string VendorTitle { get; set; }
        public string ItemNo { get; set; }
        public string MaterialName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialCategory { get; set; }
        public string MaterialType { get; set; }
        public string MaterialGroup { get; set; }
        public Decimal RequestQty { get; set;}
        public Decimal Unit { get; set;}
        public int EnlistedStatus { get; set;}
        public string EnlistedStatusDetails { get; set;}


    }
}
