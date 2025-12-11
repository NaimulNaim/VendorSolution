using SILDMS.Model.SecurityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.DataAccessInterface.UserDoctypeMap
{
    public interface IUserDoctypeMapDataService
    {
        List<SEC_User> GetUsers(string userId, int page, int itemsPerPage, string sortBy, bool reverse, string search, out string errorNumber);
        List<SEC_UserDoctypeMap> GetDocTypeAssignedToUser(string userId, out string errorNumber);
        string SetDocTypeToUser(string userId, string setBy, List<SEC_UserDoctypeMap> docTypes, out string errorNumber);

        #region DocType Map

        List<SEC_DocTypeMap> GetDocTypeMap(out string errorNumber);
        string SetDocTypeMap(string userId, List<SEC_DocTypeMap> docTypes, out string errorNumber);

        #endregion
    }
}
