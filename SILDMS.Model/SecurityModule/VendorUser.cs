using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.SecurityModule
{
    public class VendorUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
