using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using SILDMS.Model.SecurityModule;
using SILDMS.Utillity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SILDMS.Web.UI.Areas.SecurityModule.Controllers
{
    public class ForgotPasswordController : Controller
    {
        // GET: SecurityModule/Forgot
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]


        //public ActionResult SendCredentials(string email)
        //{
        //    int result = 1;

        //    try
        //    {
        //        List<VendorUser> user = GetUserByEmailAsync(email);

        //        if (user == null || user.Count == 0)
        //        {
        //            result = 3; // User not found
        //            return Json(new { Msg = result }, JsonRequestBehavior.AllowGet);
        //        }

        //        string userId = user[0].UserId;
        //        string decryptedPassword = StringEncription.Decrypt(user[0].Password, true);

        //        // Read SMTP settings from web.config
        //        string fromMail = ConfigurationManager.AppSettings["FromMail"];
        //        string smtpPassword = ConfigurationManager.AppSettings["Password"];
        //        string host = ConfigurationManager.AppSettings["Host"];
        //        int port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);

        //        ServicePointManager.SecurityProtocol =
        //            SecurityProtocolType.Tls |
        //            SecurityProtocolType.Tls11 |
        //            SecurityProtocolType.Tls12;

        //        using (MailMessage mailMessage = new MailMessage())
        //        {
        //            mailMessage.From = new MailAddress(fromMail);
        //            mailMessage.To.Add(email);
        //            mailMessage.Subject = "Forgot Password";
        //            mailMessage.IsBodyHtml = true;

        //            mailMessage.Body = $@"
        //        <html>
        //        <body>
        //            <p>Dear User,</p>

        //            <p>Your login credentials are:</p>

        //            <p>
        //                <strong>User ID:</strong> {userId}<br/>
        //                <strong>Password:</strong> {decryptedPassword}
        //            </p>

        //            <p>Regards,<br/>CBPS System</p>
        //        </body>
        //        </html>";

        //            using (SmtpClient smtp = new SmtpClient())
        //            {
        //                smtp.Host = host;
        //                smtp.Port = port;

        //                // For internal SMTP server on port 25 usually SSL is disabled.
        //                smtp.EnableSsl = true;

        //                smtp.UseDefaultCredentials = false;
        //                smtp.Credentials = new NetworkCredential(
        //                    fromMail,
        //                    smtpPassword);

        //                // Ignore SSL certificate validation if needed
        //                ServicePointManager.ServerCertificateValidationCallback =
        //                    (sender, certificate, chain, sslPolicyErrors) => true;

        //                smtp.Send(mailMessage);
        //            }
        //        }

        //        result = 2; // Success
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log exception here
        //        string errorMessage = ex.ToString();

        //        result = 0; // Failed
        //    }

        //    return Json(new { Msg = result }, JsonRequestBehavior.AllowGet);
        //}



        public async Task<ActionResult> SendCredentials(string email)
        {
            int result = 1;

            try
            {
                List<VendorUser> user = GetUserByEmailAsync(email);

                if (user == null || user.Count == 0)
                {
                    return Json(new { Msg = 3 }, JsonRequestBehavior.AllowGet);
                }

                string userId = user[0].UserId;
                string decryptedPassword = StringEncription.Decrypt(user[0].Password, true);

                string fromMail = ConfigurationManager.AppSettings["FromMail"];
                string smtpPassword = ConfigurationManager.AppSettings["Password"];
                string host = ConfigurationManager.AppSettings["Host"];
                int port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);

                ServicePointManager.SecurityProtocol =
                    SecurityProtocolType.Tls |
                    SecurityProtocolType.Tls11 |
                    SecurityProtocolType.Tls12;

                ServicePointManager.ServerCertificateValidationCallback =
                    (sender, certificate, chain, sslPolicyErrors) => true;

                using (var mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(fromMail);
                    mailMessage.To.Add(email);
                    mailMessage.Subject = "Forgot Password";
                    mailMessage.IsBodyHtml = true;

                    mailMessage.Body = $@"
<html>
<body>
    <p>Dear User,</p>

    <p>Your login credentials are:</p>

    <p>
        <strong>User ID:</strong> {userId}<br/>
        <strong>Password:</strong> {decryptedPassword}
    </p>

    <p>Regards,<br/>CBPS System</p>
</body>
</html>";

                    using (var smtpClient = new SmtpClient(host, port))
                    {
                        smtpClient.EnableSsl = true; // same as your working code
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new NetworkCredential(
                            fromMail,
                            smtpPassword);

                        smtpClient.Timeout = 30000;

                        await smtpClient.SendMailAsync(mailMessage);
                    }
                }

                result = 2;
            }
            catch (SmtpException smtpEx)
            {
                System.IO.File.WriteAllText(
                    Server.MapPath("~/SmtpError.txt"),
                    smtpEx.ToString());

                result = 0;
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText(
                    Server.MapPath("~/GeneralError.txt"),
                    ex.ToString());

                result = 0;
            }

            return Json(new { Msg = result }, JsonRequestBehavior.AllowGet);
        }




        public List<VendorUser> GetUserByEmailAsync(string email)
        {
            var usersList = new List<VendorUser>();

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_GetUserByEmail"))
            {
                db.AddInParameter(dbCommandWrapper, "@Email", SqlDbType.VarChar, email);
                db.AddOutParameter(dbCommandWrapper, "@p_Error", DbType.Int32, 10);

                // Execute SP asynchronously.
                var ds = db.ExecuteDataSet(dbCommandWrapper);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[0];

                    usersList = dt.AsEnumerable().Select(row => new VendorUser
                    {
                        // Assuming column names for UserId and Password in the database
                        UserId = row.Field<string>("UserName"),
                        Password = row.Field<string>("Password")
                    }).ToList();
                }
            }

            return usersList;
        }

        public string HostAdd { get; set; }


        public string FromEmailid { get; set; }

        public string ToEmail { get; set; }

        public string Password { get; set; }
    }
}