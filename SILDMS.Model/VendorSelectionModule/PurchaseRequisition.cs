using SILDMS.Model.VendorSelectionModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.VendorSelectionModule
{
    public class PurchaseRequisition
    {
        public int Row_count { get; set; }
        public string PRNo { get; set; }
        public string Plant_code { get; set; }
        public string Plant_name { get; set; }
        public string RequisitionDate { get; set; }
        public string PurReqID { get; set; }
        public string PurReqType { get; set; }
        public string Assignment_no { get; set; }
        public string Assignment_date { get; set; }
        public string Assigned_to_name { get; set; }
        public string Assigned_to_ID { get; set; }
        public string Assigned_By_name { get; set; }
        public string Assigned_By_ID { get; set; }
        public int Number_of_PR { get; set; }
        public string PurReqItemAssignID { get; set; }
    }

    public class PRmasterDataDetail
    {
        public string PRNo { get; set; }
        public Int64 PurReqItemID { get; set; }
        public Int64 PurReqID { get; set; }
        public string PurRequisitionNo { get; set; }
        public string ItemNo { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string Searching_Name { get; set; }
        public string Material_Category_Code { get; set; }
        public string Material_Category_Name { get; set; }
        public string Material_Group_Name { get; set; }
        public string Material_Group_Code { get; set; }
        public double MaterialQuantity { get; set; }
        public string MaterialType { get; set; }
        public string OderUnit { get; set; }
        public Decimal NetPrice { get; set; }
        public Decimal NetOrderValue { get; set; }
        public string PurGroup { get; set; }
        public string AssignCategory { get; set; }
        public string Requisitioner { get; set; }
        public string DeliveryDate { get; set; }
        public string PRItemCurStatus { get; set; }
        public int AssignFlag { get; set; }
        public int Status { get; set; }
        public string Currency { get; set; }
        public string MatInvType { get; set; }
        public Decimal Propose_Quantity { get; set; }

        public Decimal Price_Unit { get; set; }

        public string InvitationNumber { get; set; }
        public string InvitationID { get; set; }
        public string BiddingItemVendorID { get; set; }
    }
}
