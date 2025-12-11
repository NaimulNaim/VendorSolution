using SILDMS.Model.SecurityModule;
using SILDMS.Utillity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Service.UserDoctypeMap
{
    public interface IUserDoctypeMapService
    {
        ValidationResult GetUsers(string userId, int page, int itemsPerPage, string sortBy, bool reverse, string search, out List<SEC_User> users);
        ValidationResult GetDocTypeAssignedToUser(string userId, out List<SEC_UserDoctypeMap> docTypes);
        ValidationResult SetDocTypeToUser(string userId, string setBy, List<SEC_UserDoctypeMap> docTypes, out string status);

        #region DocType Map
        ValidationResult GetDocTypeMap(out List<SEC_DocTypeMap> docTypes);
        ValidationResult SetDocTypeMap(string setBy, List<SEC_DocTypeMap> docTypes, out string status);
        #endregion
    }
}
