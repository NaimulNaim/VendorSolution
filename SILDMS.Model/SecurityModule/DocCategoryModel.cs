namespace SILDMS.Model.SecurityModule
{
    public class DocCategoryModel
    {
        public string CategoryID { get; set; }

        public string CategoryTime { get; set; }
        public string CategoryRemarks { get; set; }

        
        public int TimeValue { get; set; }
        public string TimeUnit { get; set; }
        public string ExceptionValue { get; set; }

        public string DestroyPolicyDtlID { get; set; }

    }
}