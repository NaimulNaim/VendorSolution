using System.Collections.Generic;

namespace SILDMS.Model.SecurityModule
{
    public class Child
    {
        public string key { get; set; }
        public string title { get; set; }
        public string check { get; set; }
        public bool? select { get; set; }
        //public bool? expand { get; set; }
        public virtual ICollection<Child> children { get; set; }
    }
}