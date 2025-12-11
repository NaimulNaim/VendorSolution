using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using SILDMS.DataAccessInterface.MessageFormatDataSetup;
//using SILDMS.Model.CheckPrintModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.DataAccess.MessageFormatDataSetup
{
    public class MessageFormatDataService : IMessageFormatDataService
    {
        #region Fields

        private readonly string _spStatusParam;

        #endregion

        #region Constructor
        public MessageFormatDataService()
        {
            _spStatusParam = "@p_Status";
        }
        #endregion
        //public List<MessageFormat> GetMessages(string search, string searchGroup, out string errorNumber)
        //{
        //    errorNumber = string.Empty;
        //    var messages = new List<MessageFormat>();

        //    var factory = new DatabaseProviderFactory();
        //    var db = factory.CreateDefault() as SqlDatabase;
        //    using (var dbCommandWrapper = db.GetStoredProcCommand("GetMessageFormat"))
        //    {
        //        // Set parameters 
                
        //        db.AddInParameter(dbCommandWrapper, "@search", SqlDbType.NVarChar, search);
        //        db.AddInParameter(dbCommandWrapper, "@searchGroup", SqlDbType.NVarChar, searchGroup);
        //        db.AddOutParameter(dbCommandWrapper, _spStatusParam, DbType.String, 10);
        //        // Execute SP.
        //        var ds = db.ExecuteDataSet(dbCommandWrapper);

        //        if (!db.GetParameterValue(dbCommandWrapper, _spStatusParam).IsNullOrZero())
        //        {
        //            //Get the error number, if error occurred.
        //            errorNumber = db.GetParameterValue(dbCommandWrapper, _spStatusParam).PrefixErrorCode();
        //        }
        //        else
        //        {
        //            if (ds.Tables[0].Rows.Count <= 0) return messages;
        //            var dt1 = ds.Tables[0];
        //            messages = dt1.AsEnumerable().Select(reader => new MessageFormat
        //            {
        //                MessageFormatID = reader.GetInt32("MessageFormatID"),
        //                EmailBody = reader.GetString("EmailBody"),
        //                EmailSubject = reader.GetString("EmailSubject"),
        //                SMSText = reader.GetString("SMSText"),
        //                MessageFor = reader.GetString("MessageFor"),
        //                OwnerName = reader.GetString("OwnerName"),
        //                OwnerId = reader.GetString("OwnerID"),
        //                IsAuto = reader.GetInt32("IsAutomatic")
        //            }).ToList();

        //        }
        //    }
        //    return messages;
        //}


        //public string AddNewMessage(MessageFormat messageFormat, string _action, out string errorNumber)
        //{
        //    errorNumber = string.Empty;
        //    try
        //    {
        //        var factory = new DatabaseProviderFactory();
        //        var db = factory.CreateDefault() as SqlDatabase;
        //        using (var dbCommandWrapper = db.GetStoredProcCommand("SEC_SetNewMessages"))
        //        {
        //            // Set parameters 
        //            db.AddInParameter(dbCommandWrapper, "@MessageFormatID", SqlDbType.NVarChar, messageFormat.MessageFormatID);
        //            db.AddInParameter(dbCommandWrapper, "@SMSText", SqlDbType.NVarChar, messageFormat.SMSText);
        //            db.AddInParameter(dbCommandWrapper, "@EmailBody", SqlDbType.NVarChar, messageFormat.EmailBody);
        //            db.AddInParameter(dbCommandWrapper, "@EmailSubject", SqlDbType.NVarChar, messageFormat.EmailSubject);
        //            db.AddInParameter(dbCommandWrapper, "@IsAutometic", SqlDbType.NVarChar, messageFormat.IsAuto);
        //            db.AddInParameter(dbCommandWrapper, "@MessageFor", SqlDbType.NVarChar, messageFormat.MessageFor);
        //            db.AddInParameter(dbCommandWrapper, "@OwnerId", SqlDbType.NVarChar, messageFormat.OwnerId);
        //            db.AddInParameter(dbCommandWrapper, "@Action", SqlDbType.VarChar, _action);
        //            db.AddOutParameter(dbCommandWrapper, _spStatusParam, SqlDbType.VarChar, 10);

        //            // Execute SP.
        //            db.ExecuteNonQuery(dbCommandWrapper);
        //            // Getting output parameters and setting response details.
        //            if (!db.GetParameterValue(dbCommandWrapper, _spStatusParam).IsNullOrZero())
        //            {
        //                // Get the error number, if error occurred.
        //                errorNumber = db.GetParameterValue(dbCommandWrapper, _spStatusParam).PrefixErrorCode();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        errorNumber = "E404"; // Log ex.Message  Insert Log Table               
        //    }
        //    return errorNumber;
        //}
    }
}
