namespace SILDMS.Model.SecurityModule
{
    public class DocPropIdentityModel
    {
        public string PropIdentityID { get; set; }
        public string PropIdentityTime { get; set; }
        public string PropIdentityRemarks { get; set; }
        public string PropIdentityMetaValue { get; set; }

        public int TimeValue { get; set; }
        public string TimeUnit { get; set; }
        public string ExceptionValue { get; set; }

        public string DestroyPolicyDtlID { get; set; }

    }
}