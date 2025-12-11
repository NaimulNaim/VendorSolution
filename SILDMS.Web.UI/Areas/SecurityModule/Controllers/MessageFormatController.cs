//using SILDMS.Model.CheckPrintModule;
using SILDMS.Service;
using SILDMS.Service.MessageFormatSetup;
using SILDMS.Utillity;
using SILDMS.Utillity.Localization;
using SILDMS.Web.UI.Areas.SecurityModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SILDMS.Web.UI.Areas.SecurityModule.Controllers
{
    public class MessageFormatController : Controller
    {
        #region Fields

        private IMessageFormatService _messageFormatService;
        private ValidationResult _respStatus;
        private readonly ILocalizationService _localizationService;
        private string _outStatus;
        private string _action;
        private readonly string _userId;

        #endregion

        #region Constructor

        public MessageFormatController()
        {
            //_messageFormatService = new MessageFormatService();
            _respStatus = new ValidationResult();
            _localizationService = new LocalizationService();
            _outStatus = string.Empty;
            _action = string.Empty;
            _userId = SILAuthorization.GetUserID();
        }

        #endregion

        public ActionResult Index()
        {
            return View();
        }

        //[Authorize]
        //public async Task<dynamic> GetMessages(string search = null, string searchGroup = null)
        //{
        //    var messages = new List<MessageFormat>();
        //    await Task.Run(() => _messageFormatService.GetMessages(search, searchGroup, out messages));
        //    var result = Json(new { messages, msg = "Messages are loaded in the table." }, JsonRequestBehavior.AllowGet);
        //    result.MaxJsonLength = Int32.MaxValue;
        //    return result;
        //}

        //[Authorize]
        //[HttpPost]
        //public async Task<dynamic> AddNewMessage(MessageFormat messageFormat)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _action = "add";
        //        _respStatus = await Task.Run(() => _messageFormatService.AddNewMessage(messageFormat, _action, out _outStatus));
        //    }
        //    else
        //    {
        //        _respStatus = new ValidationResult("404", _localizationService.GetResource("404"));
        //    }
        //    return Json(new { _respStatus }, JsonRequestBehavior.AllowGet);
        //}

        //[Authorize]
        //[HttpPost]
        //public async Task<dynamic> EditMessage(MessageFormat messageFormat)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _action = "edit";
        //        _respStatus = await Task.Run(() => _messageFormatService.AddNewMessage(messageFormat, _action, out _outStatus));
        //    }
        //    else
        //    {
        //        _respStatus = new ValidationResult("404", _localizationService.GetResource("404"));
        //    }
        //    return Json(new { _respStatus }, JsonRequestBehavior.AllowGet);
        //}

        //[Authorize]
        //[HttpPost]
        //public async Task<dynamic> DeleteMessage(MessageFormat messageFormat)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _action = "delete";
        //        _respStatus = await Task.Run(() => _messageFormatService.AddNewMessage(messageFormat, _action, out _outStatus));
        //    }
        //    else
        //    {
        //        _respStatus = new ValidationResult("404", _localizationService.GetResource("404"));
        //    }
        //    return Json(new { _respStatus }, JsonRequestBehavior.AllowGet);
        //}
	}
}