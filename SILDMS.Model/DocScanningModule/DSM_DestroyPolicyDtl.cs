namespace SILDMS.Model.DocScanningModule
{
    public class DSM_DestroyPolicyDtl
    {
        public string DestroyPolicyDtlID { get; set; }
        public string DestroyPolicyID { get; set; }
       

        public string OwnerID { get; set; }
        public string DocCategoryID { get; set; }
        public string DocTypeID { get; set; }
        public string DocPropertyID { get; set; }
        public string DocPropertyName { get; set; }
        public string DocPropIdentifyID { get; set; }


        public string MetaValue { get; set; }
        public int TimeValue { get; set; }
        public string TimeUnit { get; set; }
        public string ExceptionValue { get; set; }
        public int UserLevel { get; set; }






        public string Remarks { get; set; }
        public string SetOn { get; set; }
        public string SetBy { get; set; }
        public string ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int Status { get; set; }

    }
}