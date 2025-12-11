using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.VendorSelectionModule
{
    public class PurReqItemUnAssign
    {
        public string AssignedBy;
        public string AssignedDate;

    //    public string ItemNo { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string PlantCode { get; set; }
        public string DepartmentID { get; set; }
        public string MaterialType { get; set; }
        public DateTime PurReqStartDate { get; set; }
        public DateTime PurReqEndDate { get; set; }

        public string MaterialQuantity { get; set; }
        public string OderUnit { get; set; }
        public string DeliveryDate { get; set; }

        public string tempMaterialName { get; set; }
        public string AssignedPerson { get; set; }
        public string AssignedNo { get; set; }
        public long PurReqItemAssignID { get; set; }
        public long AssignedPersonID { get; set; }
        public string ItemRemarks { get; set; }
        public string RequsitionRemarks { get; set; }
        public string RequisitionNo { get; set; }
        public string PurReqItemID { get; set; }
        public string Requisitioner { get; set; }
    }

    public class PurReqItemUnAssignDetails
    {
        public long PurReqItemID { get; set; }
        public string PurRequisitionNo { get; set; }
    //    public string ItemNo { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string PlantCode { get; set; }
        public string DepartmentID { get; set; }
        public string MaterialType { get; set; }

        public DateTime PurReqStartDate { get; set; }
        public DateTime PurReqEndDate { get; set; }

        public int MaterialQuantity { get; set; }
        public string OderUnit { get; set; }
        public string PurGroup { get; set; }
        public string Requisitioner { get; set; }
        public string Requisitioner_FullName { get; set; }
        public string DeliveryDate { get; set; }

        public string PRNo { get; set; }

        public Int64 PurReqID { get; set; }
        public string MaterialCategory { get; set; }
        public string MaterialGroup { get; set; }
        public Decimal NetPrice { get; set; }
        public Decimal NetOrderValue { get; set; }
        public string AssignCategory { get; set; }
        public string PRItemCurStatus { get; set; }
        public int AssignFlag { get; set; }
        public int Status { get; set; }
        public string AssignmentDate { get; set; }
        public string Remarks { get; set; }
        public long PurReqItemAssignID { get; set; }
        public long AssignedNumber { get; set; }
        public string ItemRemarks { get; set; }
    }

    public class DistinctMaterialCategory
    {
        public string Material_Category_Name { get; set; }
        public string Material_Category_Code { get; set; }

    }


}
