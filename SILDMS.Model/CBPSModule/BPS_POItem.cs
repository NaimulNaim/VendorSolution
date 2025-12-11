using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.CBPSModule
{
    public class BPS_POItem
    {
        public string POItemID { get; set; }
        public string POHeaderID { get; set; }
        public string PONo { get; set; }
        public string ItemNo { get; set; }
        public string DeletionIndecator { get; set; }
        public DateTime ChangedOn { get; set; }
        public string MaterialShortText { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialWithOutZero { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
        public string MaterialGroup { get; set; }
        public decimal MaterialQuantity { get; set; }
        public decimal GenunieQuantity { get; set; }
        public string OrderUnit { get; set; }
        public string OrderPriceUnit { get; set; }
        public decimal NetPrice { get; set; }
        public string PriceUnit { get; set; }
        public decimal NetOrderValue { get; set; }
        public decimal GrossOrderValue { get; set; }
        public string DeliveryCompleted { get; set; }
        public string ItemCategory { get; set; }
        public string AccAssignCategory { get; set; }
        public string MaterialType { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string MaterialName { get; set; }
        public string OwnerID { get; set; }
        public string DocCategoryID { get; set; }
        public string DocTypeID { get; set; }
        public string DocPropertyID { get; set; }
        public int UserLevel { get; set; }
        public DateTime SetOn { get; set; }
        public string SetBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int Status { get; set; }
        public string PlantName { get; set; }
        public string BlockList { get; set; }
        public string BlockListDate { get; set; }
        public decimal BlockListRate { get; set; }
        public decimal BlockListValue { get; set; }
        public string HSCode { get; set; }
        public string UDHSCode { get; set; }

        public string OwnerName { get; set; }
        public string TotalPages { get; set; }
        public string SortMaterialCode { get; set; }
        public string POItemNo { get; set; }
        public string POQty { get; set; }
        public string POUnitPrice { get; set; }
        public string PostedQty { get; set; }
        public string PostedUnitPrice { get; set; }
    }
}
