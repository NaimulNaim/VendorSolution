
using SILDMS.DataAccess.MessageFormatDataSetup;
using SILDMS.DataAccessInterface.MessageFormatDataSetup;
//using SILDMS.Model.CheckPrintModule;
using SILDMS.Utillity;
using SILDMS.Utillity.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Service.MessageFormatSetup
{
    public class MessageFormatService//: IMessageFormatService
    {
        // #region Fields

        //private readonly IMessageFormatDataService _messageFormatDataService;
        //private readonly ILocalizationService _localizationService;
        //private string _errorNumber = string.Empty;

        //#endregion

        //#region Constructor

        //public MessageFormatService()
        //{
        //    _messageFormatDataService = new MessageFormatDataService();
        //    _localizationService = new LocalizationService();
        //    _errorNumber = string.Empty;
        //}

        //#endregion

        //public ValidationResult GetMessages(string search,string searchGroup, out List<MessageFormat> messages)
        //{
        //    messages = _messageFormatDataService.GetMessages(search, searchGroup, out _errorNumber);
        //    return _errorNumber.Length > 0
        //        ? new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber))
        //        : ValidationResult.Success;
        //}


        //public ValidationResult AddNewMessage(MessageFormat messageFormat, string _action, out string _outStatus)
        //{
        //    _messageFormatDataService.AddNewMessage(messageFormat, _action, out _outStatus);
        //    return _outStatus.Length > 0
        //        ? new ValidationResult(_outStatus, _localizationService.GetResource(_outStatus))
        //        : ValidationResult.Success;
        //}
    }
}
