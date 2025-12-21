using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using SILDMS.Model.SecurityModule;
using SILDMS.Utillity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
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


        public ActionResult SendCredentials(string email)
        {
            // HttpPostedFile httpPostedFileBase2 = System.Web.HttpContext.Current.Request.Files[0];
            int a = 1;
            //var toEmailId = new List<ReturnResult>();
            var user = new List<VendorUser>();
            user = GetUserByEmailAsync(email);
            if (user != null && user.Count > 0)
            {
                string userId = user[0].UserId;
                string password = user[0].Password;
                string decryptedPassword = StringEncription.Decrypt(user[0].Password, true);


                var message = "";
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)48 | (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                //Reading sender Email credential from web.config file
                HostAdd = "172.16.128.39";
                //FromEmailid = ConfigurationManager.AppSettings["FromMail"].ToString();
                Password = "(Cbp$)@978!"; ;
                // ToEmail = "shalim@squaregroup.com";
                //creating the object of MailMessage
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("cbps@squaregroup.com"); //From Email Id
                mailMessage.Subject = "Forgot Password"; //Subject of Email
                mailMessage.Body = $"<p>Your User ID: <b>{userId}</b></p><p>Your Password: <b>{decryptedPassword}</b></p>";
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(email);





                SmtpClient smtp = new SmtpClient(); // creating object of smptpclient
                smtp.Host = HostAdd; //host of emailaddress for example smtp.gmail.com etc
                smtp.EnableSsl = true;
                NetworkCredential networkCred = new NetworkCredential();
                networkCred.UserName = mailMessage.From.Address;
                networkCred.Password = Password;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCred;
                smtp.Port = 587;



                ServicePointManager.ServerCertificateValidationCallback = (s, certificate, chain, sslPolicyErrors) => true;

                try
                {
                    smtp.Send(mailMessage);
                    a = 2;
                }
                catch (Exception ex)
                {
                    a = 0;
                }
                return Json(new { Msg = a }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                a = 3;
                return Json(new { Msg = a }, JsonRequestBehavior.AllowGet);
            }

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