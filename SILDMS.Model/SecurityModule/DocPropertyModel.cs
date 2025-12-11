namespace SILDMS.Model.SecurityModule
{
    public class DocPropertyModel
    {
        public string PropertyID { get; set; }
        public string PropertyTime { get; set; }
        public string PropertyRemarks { get; set; }

        public int TimeValue { get; set; }
        public string TimeUnit { get; set; }
        public string ExceptionValue { get; set; }

        public string DestroyPolicyDtlID { get; set; }

    }
}