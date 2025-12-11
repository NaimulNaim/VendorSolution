using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;

namespace SILDMS.Utillity
{
    public static class EmailService
    {
        //public static string FixBase64ForImage(string Image)
        //{
        //    System.Text.StringBuilder sbText = new System.Text.StringBuilder(Image, Image.Length);
        //    sbText.Replace("\r\n", string.Empty); sbText.Replace(" ", string.Empty);
        //    return sbText.ToString();
        //}

        public static int SendMail(string mailto, string mailSubject = null, string mailBody = null, Stream streamData = null, string ccEmail = null, string bccEmail = null)
        {
            int a = 1;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("cbps@squaregroup.com"); //From Email Id
            mailMessage.Subject = mailSubject == null ? "NA" : mailSubject; //Subject of Email            
            mailMessage.Body = mailBody;  

            //Byte[] bitmapData = Convert.FromBase64String(FixBase64ForImage(mailBody));
            //System.IO.MemoryStream streamBitmap = new System.IO.MemoryStream(bitmapData);

            //var imageToInline = new LinkedResource(streamBitmap, MediaTypeNames.Image.Jpeg);
            //imageToInline.ContentId = Guid.NewGuid().ToString();
            
            //AlternateView alternateView = AlternateView.CreateAlternateViewFromString(imageToInline.ContentId, null, MediaTypeNames.Image.Jpeg);
            //alternateView.LinkedResources.Add(imageToInline);
            //mailMessage.AlternateViews.Add(alternateView); 

            mailMessage.IsBodyHtml = true;
            
            string[] m = mailto.Split(',');
            foreach (var item in m)
            {
                mailMessage.To.Add(new MailAddress(item.Trim()));
            }

            if (!string.IsNullOrEmpty(ccEmail))
            {
                string[] c = ccEmail.Split(',');
                foreach (var item in c)
                {
                    mailMessage.CC.Add(new MailAddress(item.Trim()));
                }
            }

            if (!string.IsNullOrEmpty(bccEmail))
            {
                string[] bc = bccEmail.Split(',');
                foreach (var item in bc)
                {
                    mailMessage.Bcc.Add(new MailAddress(item.Trim()));
                }
            }

            if (streamData != null)
            {
                mailMessage.Attachments.Add(new Attachment(streamData, "Attachment_(" + DateTime.Now.ToShortDateString() + ").pdf"));
            }

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "172.16.128.39";
            smtp.EnableSsl = true;

            NetworkCredential networkCred = new NetworkCredential();
            networkCred.UserName = mailMessage.From.Address;
            networkCred.Password = "Cbps@987#";
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = networkCred;
            smtp.Port = 587;
            //smtp.Host = ConfigurationManager.AppSettings["EmailHost"].ToString();
            //smtp.EnableSsl = true;
            //NetworkCredential networkCred = new NetworkCredential();
            //networkCred.UserName = mailMessage.From.Address;
            //networkCred.Password = ConfigurationManager.AppSettings["EmailPass"].ToString();
            //smtp.UseDefaultCredentials = true;
            //smtp.Credentials = networkCred;
            //smtp.Port = 587;

            ServicePointManager.ServerCertificateValidationCallback = (s, certificate, chain, sslPolicyErrors) => true;

            try
            {
                smtp.Send(mailMessage);
                a = 2;
            }
            catch (Exception ex)
            {

                string filePath = @"D:\EmailError.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }

                a = 0;
            }

            return a;

        }

    }
}
