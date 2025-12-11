namespace SILDMS.Model.SecurityModule
{
    public class DocTypeModel
    {
        public string TypeID { get; set; }
        public string TypeTime { get; set; }
        public string TypeRemarks { get; set; }

        public int TimeValue { get; set; }
        public string TimeUnit { get; set; }
        public string ExceptionValue { get; set; }

        public string DestroyPolicyDtlID { get; set; }

    }
}