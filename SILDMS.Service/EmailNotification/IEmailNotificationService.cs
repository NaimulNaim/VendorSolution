using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Service.EmailNotification
{
    public interface IEmailNotificationService
    {
        int SendEmail();
    }
}
