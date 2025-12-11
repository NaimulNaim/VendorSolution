using SILDMS.Model.DocScanningModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.VendorSelectionModule
{
    public class Plant
    {

        public string Plant_Id { get; set; }

        public string Plant_Name { get; set; }
    }


    public class Company
    {

        public string OwnerID { get; set; }
        public string UDOwnerCode { get; set; }

        public string OwnerName { get; set; }
    }
    public class Department
    {

        public string Dept_Id { get; set; }

        public string Dept_Name { get; set; }
    }
    public class MaterialCategory
    {
        public string Material_Category_Code { get; set; }

        public string Material_Category_Name { get; set; }

    }

    public class MaterialType
    {
        public string Material_Type_Code { get; set; }

        public string Material_Type_Name { get; set; }
    }
    public class MaterialGroup
    {
        public string Material_Group_Code { get; set; }

        public string Material_Group_Name { get; set; }
    }
    public class Material
    {
        public Int64 Material_Id { get; set; }
        public string Material_Code { get; set; }
        public string ItemNo { get; set; }
     
        public string BasePrice { get; set; }
        public string Material_Name { get; set; }
        public string MaterialCategoryName { get; set; }
        public string MaterialTypeName { get; set; }
        public string MaterialGroupName { get; set; }

    }


    public class purchaseGrp

    {
        public string purchase_Group_Code { get; set; }

        public string purchase_Group_Name { get; set; }

        public string purchase_Dept { get; set; }
    }

    public class Item
    {
        public string Item_Code { get; set; }

        public string Item_Name { get; set; }
    }

    public class AssgnCategory

    {
        public string AssgnCategory_Group_Code { get; set; }

        public string AssgnCategory_Group_Name { get; set; }

    }

    public class PurreqMaster
    {
        public long PurreqID { get; set; }
        public string PurreqNumber { get; set; }
        public Company Company { get; set; }
        public DateTime PurreqDate { get; set; }
        public string PurreqDateString { get; set; }

        public purchaseGrp purchaseGrp { get; set; }
        public Plant PlantType { get; set; }
        public Department Department { get; set; }
        public string PurreqType { get; set; }
        public string ReqRaised { get; set; }
        public string ReqRaisedPerson { get; set; }

        public string Remarks { get; set; }
    }

    public class PurreqDtlModel
    {
        public string Id { get; set; }
        public MaterialCategory MaterialCategory { get; set; }
        public MaterialType MaterialType { get; set; }
        public MaterialGroup MaterialGroup { get; set; }
        public Material Material { get; set; }
        public DateTime Delivery_Date { get; set; }
        public string  Delivery_DateString { get; set; }
        public double Quantity { get; set; }
        public int Shorttext { get; set; }
        public AssgnCategory AssgnCategory { get; set; }
        public Item Item { get; set; }

        public string ItemCategory { get; set; }
        public string ReqRaised { get; set; }
        public string ReqRaisedPerson { get; set; }
    }



}
