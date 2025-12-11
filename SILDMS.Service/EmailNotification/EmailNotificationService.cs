//using SILDMS.DataAccessInterface.EmailNotification;
using SILDMS.Utillity;
using SILDMS.Utillity.Localization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Service.EmailNotification
{
    public class EmailNotificationService// : IEmailNotificationService
    {
        #region Fields

        //private readonly IEmailNotificationDataService _emailDataService;
        private readonly ILocalizationService _localizationService;
        private string _errorNumber = string.Empty;

        #endregion

        #region Constructor

        //public EmailNotificationService(IEmailNotificationDataService emailDataService, ILocalizationService localizationService)
        //{
        //    _emailDataService = emailDataService;
        //    _localizationService = localizationService;
        //}

        #endregion
        //public int SendEmail()
        //{
        //    DataTable dt1 = new DataTable();
        //    dt1 = _emailDataService.EachCoverNoteAssignmentRPT(out _errorNumber);
        //    if (_errorNumber.Length > 0)
        //    {
        //        return 0;
        //    }
        //    return 1;
        //}
    }
}
