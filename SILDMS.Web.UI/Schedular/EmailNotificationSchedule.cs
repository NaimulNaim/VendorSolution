using CrystalDecisions.CrystalReports.Engine;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Web.Http;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.IO;
using CrystalDecisions.Shared;
using SILDMS.Model.BackgroundTaskModule;
//using SILDMS.Service.BackgroundTaskService;

namespace SILDMS.Web.UI.Schedular
{
    public class EmailNotificationSchedule
    {
        //BackgroundTaskService _backgroundTaskService = new BackgroundTaskService();
        //private SqlConnection sqlConnection;
        //private void GetConnection()
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["AuthContext"].ToString();
        //    sqlConnection = new SqlConnection(connectionString);
        //}

        //public int SendEmail()
        //{
        //    int status = 0;
        //    string rptUser = "CBPS System Generated";

        //    try
        //    {
        //        DataTable dt = GetEmailNotificationData();

        //        ReportDocument reportDocument = new ReportDocument();
        //        string ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports");
        //        ReportPath = ReportPath + "/rptNotificationEmail.rpt";
        //        reportDocument.Load(ReportPath);
        //        reportDocument.SetDataSource(dt);
        //        reportDocument.Refresh();
        //        reportDocument.SetParameterValue("ComDiv", "Square Pharmaceuticals Ltd.");
        //        reportDocument.SetParameterValue("rptName", "Endorsement Receive Pending List");

        //        //ViewBag.propertydisable = "true";
        //        if (dt.Rows.Count == 0)
        //        {
        //            status = 0;
        //            return status;
        //        }
        //        else
        //        {
        //            //.................sonet code...................
        //            #region EmailViaBackgroundService
        //            Stream attachmentData = reportDocument.ExportToStream(ExportFormatType.PortableDocFormat);
        //            byte[] attachmentContentByte;
        //            attachmentContentByte = new byte[attachmentData.Length];
        //            attachmentData.Read(attachmentContentByte, 0, attachmentContentByte.Length);


        //            string messageTo = ConfigurationManager.AppSettings["LCEmailTo"].ToString();
        //            string messageCC = ConfigurationManager.AppSettings["LCEmailCC"].ToString();
        //            string messageSubject = "Endorsement Receive Pending List";
        //            string messageContent = "Endorsement Receive Pending";

        //            var backgroundTaskMessage = new BackgroundTaskMessage()
        //            {
        //                ProjectCode = "CBPS_LC",
        //                MessageSubject = messageSubject,
        //                MessageContent = messageContent,
        //                MessageTo = messageTo,
        //                MessageCc = messageCC,
        //                MessageType = 1,
        //                TaskType = 3,
        //                IsAttachmentAvailable = 1
        //            };

        //            var backgroundTaskMessageAttachmentCollection = new List<BackgroundTaskMessageAttachment>()
        //         {
        //                 new BackgroundTaskMessageAttachment()
        //              {
        //                AttachmentName = "DailyEmailNotification",
        //                AttachmentUrl = null,
        //                AttachmentExtension = ".pdf",
        //                AttachmentContent = attachmentContentByte
        //              }
        //         };

        //            var errorCode = string.Empty;
                    
        //            _backgroundTaskService.SaveBackgroundServiceMessage(backgroundTaskMessage, backgroundTaskMessageAttachmentCollection, out errorCode);

        //            #endregion
        //            if(errorCode == "S200")
        //            {
        //                status = 1;
        //            }
        //            else
        //            {
        //                status = 0;
        //            }

        //            reportDocument.Close();
        //            reportDocument.Dispose();
        //            return status;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        status = 500;
        //    }
        //    return status;
        //}

       

        ////private DataTable GetEmailNotificationData()
        ////{
        ////    DataTable dt = null;
        ////    GetConnection();

        ////    SqlCommand cmd = new SqlCommand("select * from SEC_User Where [Status] = 1", sqlConnection);

        ////    try
        ////    {
        ////        sqlConnection.Open();
        ////        SqlDataAdapter da = new SqlDataAdapter(cmd);
        ////        DataSet ds = new DataSet();

        ////        da.Fill(ds);
        ////        dt = ds.Tables[0];
        ////    }
        ////    catch (Exception ex)
        ////    {

        ////    }
        ////    finally
        ////    {
        ////        sqlConnection.Close();
        ////    }

        ////    return dt;
        ////}

        //private DataTable GetEmailNotificationData()
        //{
        //    //errorNumber = string.Empty;
        //    DatabaseProviderFactory factory = new DatabaseProviderFactory();
        //    SqlDatabase db = factory.CreateDefault() as SqlDatabase;
        //    using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("CBPS_GetEmailNotificationForLC"))
        //    {
        //        //db.AddInParameter(dbCommandWrapper, "@PONo", SqlDbType.VarChar, PONo);
        //        //db.AddInParameter(dbCommandWrapper, "@LCNo", SqlDbType.VarChar, LCNo);
        //        //db.AddInParameter(dbCommandWrapper, "@SelectedLCNo", SqlDbType.VarChar, SelectedLCNo);
        //        dbCommandWrapper.CommandTimeout = 300;

        //        var ds = db.ExecuteDataSet(dbCommandWrapper);
        //        DataTable dt1 = ds.Tables[0];
        //        return dt1;
        //    }
        //}
    }
}