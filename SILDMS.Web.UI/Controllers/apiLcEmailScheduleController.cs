using SILDMS.Service.EmailNotification;
using SILDMS.Web.UI.Schedular;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SILDMS.Web.UI.Controllers
{
    public class apiLcEmailScheduleController : ApiController
    {
        private IEmailNotificationService _emailService;

        public apiLcEmailScheduleController()
        {

        }

        //public apiLcEmailScheduleController(IEmailNotificationService emailService)
        //{
        //    this._emailService = emailService;
        //}

        //[HttpGet]
        //public int SendNotificationEmail()
        //{
        //    EmailNotificationSchedule _emailNotificationSchedular = new EmailNotificationSchedule();
        //    //int status = _emailNotificationSchedular.SendEmail();            
        //    //return status;
        //}
    }
}