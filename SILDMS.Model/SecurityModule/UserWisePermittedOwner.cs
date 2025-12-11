namespace SILDMS.Model.SecurityModule
{
    public class UserWisePermittedOwner
    {
        public string UserOwnerAccessID { get; set; }
        public string OwnerID { get; set; }
        public string OwnerName { get; set; }
        public bool IsSelected { get; set; }
        public string UserLevel { get; set; }
        public string SupervisorLevel { get; set; }
    }
}