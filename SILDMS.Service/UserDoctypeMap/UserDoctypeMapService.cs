using SILDMS.DataAccess.UserDoctypeMap;
using SILDMS.DataAccessInterface.UserDoctypeMap;
using SILDMS.Model.SecurityModule;
using SILDMS.Utillity;
using SILDMS.Utillity.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Service.UserDoctypeMap
{
    public class UserDoctypeMapService : IUserDoctypeMapService
    {
        #region Fields

        private readonly IUserDoctypeMapDataService _userDoctypeMapDataService;
        private readonly ILocalizationService _localizationService;
        private string _errorNumber;

        #endregion

        #region Constructor

        public UserDoctypeMapService()
        {
            _userDoctypeMapDataService = new UserDoctypeMapDataService();
            _localizationService = new LocalizationService();
            _errorNumber = string.Empty;
        }

        #endregion
        public ValidationResult GetUsers(string userId, int page, int itemsPerPage, string sortBy, bool reverse, string search, out List<SEC_User> users)
        {
            users = _userDoctypeMapDataService.GetUsers(userId, page, itemsPerPage, sortBy, reverse, search, out _errorNumber);
            return _errorNumber.Length > 0 ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber)) :
                ValidationResult.Success;
        }

        public ValidationResult GetDocTypeAssignedToUser(string userId, out List<SEC_UserDoctypeMap> docTypes)
        {
            docTypes = _userDoctypeMapDataService.GetDocTypeAssignedToUser(userId, out _errorNumber);
            return _errorNumber.Length > 0 ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber)) :
                ValidationResult.Success;
        }

        public ValidationResult SetDocTypeToUser(string userId, string setBy, List<SEC_UserDoctypeMap> docTypes, out string status)
        {
            _userDoctypeMapDataService.SetDocTypeToUser(userId, setBy, docTypes, out status);
            return status.Length > 0
                ? new ValidationResult(status, _localizationService.GetResource(status))
                : ValidationResult.Success;
        }

        #region DocType Map

        public ValidationResult GetDocTypeMap(out List<SEC_DocTypeMap> docTypes)
        {
            docTypes = _userDoctypeMapDataService.GetDocTypeMap( out _errorNumber);
            return _errorNumber.Length > 0 ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber)) :
                ValidationResult.Success;
        }

        public ValidationResult SetDocTypeMap(string setBy, List<SEC_DocTypeMap> docTypes, out string status)
        {
            _userDoctypeMapDataService.SetDocTypeMap(setBy,  docTypes, out status);
            return status.Length > 0
                ? new ValidationResult(status, _localizationService.GetResource(status))
                : ValidationResult.Success;
        }

        #endregion
    }
}
