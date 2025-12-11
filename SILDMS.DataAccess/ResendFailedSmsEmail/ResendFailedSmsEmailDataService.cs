using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using SILDMS.DataAccessInterface.ResendFailedSmsEmail;
//using SILDMS.Model.CheckPrintModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.DataAccess.ResendFailedSmsEmail
{
    public class ResendFailedSmsEmailDataService : IResendFailedSmsEmailDataService
    {
        #region Fields

        private readonly string _spStatusParam;

        #endregion

        #region Constructor
        public ResendFailedSmsEmailDataService()
        {
            _spStatusParam = "@p_Status";
        }
        #endregion
        //public List<SmsEmailSend> GetBills(string OwnerID, string OpType, string BillType, string VendorCode, int page, int itemsPerPage, string sortBy, bool reverse, string VendorName, string Company, string ClearingNo, out string _errorNumber)
        //{
        //    _errorNumber = string.Empty;
        //    List<SmsEmailSend> billList = new List<SmsEmailSend>();

        //    var factory = new DatabaseProviderFactory();
        //    var db = factory.CreateDefault() as SqlDatabase;

        //    using (var dbCommandWrapper = db.GetStoredProcCommand("CBPS_GetBillsForSmsEmailSend"))
        //    {
        //        db.AddInParameter(dbCommandWrapper, "@OwnerID", SqlDbType.VarChar, OwnerID);
        //        db.AddInParameter(dbCommandWrapper, "@OpType", SqlDbType.VarChar, OpType);
        //        db.AddInParameter(dbCommandWrapper, "@BillType", SqlDbType.VarChar, BillType);
        //        db.AddInParameter(dbCommandWrapper, "@VendorCode", SqlDbType.VarChar, VendorCode);

        //        db.AddInParameter(dbCommandWrapper, "@page", SqlDbType.Int, page);
        //        db.AddInParameter(dbCommandWrapper, "@itemsPerPage", SqlDbType.Int, itemsPerPage);
        //        db.AddInParameter(dbCommandWrapper, "@sortBy", SqlDbType.NVarChar, sortBy);
        //        db.AddInParameter(dbCommandWrapper, "@reverse", SqlDbType.NVarChar, reverse ? "DESC" : "ASC");
        //        db.AddInParameter(dbCommandWrapper, "@VendorNameSearch", SqlDbType.VarChar, VendorName);
        //        db.AddInParameter(dbCommandWrapper, "@CompanySearch", SqlDbType.VarChar, Company);
        //        db.AddInParameter(dbCommandWrapper, "@ClearingNoSearch", SqlDbType.VarChar, ClearingNo);
        //        dbCommandWrapper.CommandTimeout = 300;

        //        db.AddOutParameter(dbCommandWrapper, _spStatusParam, DbType.String, 10);

        //        var ds = db.ExecuteDataSet(dbCommandWrapper);

        //        if (!db.GetParameterValue(dbCommandWrapper, _spStatusParam).IsNullOrZero())
        //        {
        //            _errorNumber = db.GetParameterValue(dbCommandWrapper, _spStatusParam).PrefixErrorCode();
        //        }

        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            DataTable dt1 = ds.Tables[0];
        //            billList = dt1.AsEnumerable().Select(reader => new SmsEmailSend
        //            {
        //                VendorName = reader.GetString("VendorName"),
        //                VendorID = reader.GetString("VendorID"),
        //                BillClearingID = reader.GetString("BillClearingID"),
        //                VendorMobileNo = reader.GetString("VendorMobileNo"),
        //                VendorEmail = reader.GetString("VendorEmail"),
        //                VendorType = reader.GetString("VendorType"),
        //                OwnerName = reader.GetString("OwnerName"),
        //                OwnerID = reader.GetString("OwnerID"),
        //                CompanyCode = reader.GetString("CompanyCode"),
        //                InvoiceDocNo = reader.GetString("InvoiceDocNo"),
        //                AmtInLocalCurrency = reader.GetToDecimal("AmtInLocalCurrency"),
        //                EmailBody = reader.GetString("EmailBody"),
        //                EmailSubject = reader.GetString("EmailSubject"),
        //                MessageFor = reader.GetString("MessageFor"),
        //                SMSText = reader.GetString("SMSText"),
        //                totalPages = reader.GetString("totalPages")
        //            }).ToList();
        //        }

        //    }
        //    return billList;
        //}


        //public List<SmsEmailSend> GetBillsByDate(string OwnerID, string OpType, string BillType, string VendorCode, string FDate, string EDtae, int page, int itemsPerPage, string sortBy, bool reverse, string VendorName, string Company, string ClearingNo, out string _errorNumber)
        //{
        //    _errorNumber = string.Empty;
        //    List<SmsEmailSend> billList = new List<SmsEmailSend>();

        //    var factory = new DatabaseProviderFactory();
        //    var db = factory.CreateDefault() as SqlDatabase;

        //    using (var dbCommandWrapper = db.GetStoredProcCommand("CBPS_GetBillsForSmsEmailSendByDate"))
        //    {
        //        db.AddInParameter(dbCommandWrapper, "@OwnerID", SqlDbType.VarChar, OwnerID);
        //        db.AddInParameter(dbCommandWrapper, "@OpType", SqlDbType.VarChar, OpType);
        //        db.AddInParameter(dbCommandWrapper, "@BillType", SqlDbType.VarChar, BillType);
        //        db.AddInParameter(dbCommandWrapper, "@VendorCode", SqlDbType.VarChar, VendorCode);
        //        db.AddInParameter(dbCommandWrapper, "@FromDate", SqlDbType.VarChar, FDate);
        //        db.AddInParameter(dbCommandWrapper, "@ToDate", SqlDbType.VarChar, EDtae);

        //        db.AddInParameter(dbCommandWrapper, "@page", SqlDbType.Int, page);
        //        db.AddInParameter(dbCommandWrapper, "@itemsPerPage", SqlDbType.Int, itemsPerPage);
        //        db.AddInParameter(dbCommandWrapper, "@sortBy", SqlDbType.NVarChar, sortBy);
        //        db.AddInParameter(dbCommandWrapper, "@reverse", SqlDbType.NVarChar, reverse ? "DESC" : "ASC");
        //        db.AddInParameter(dbCommandWrapper, "@VendorNameSearch", SqlDbType.VarChar, VendorName);
        //        db.AddInParameter(dbCommandWrapper, "@CompanySearch", SqlDbType.VarChar, Company);
        //        db.AddInParameter(dbCommandWrapper, "@ClearingNoSearch", SqlDbType.VarChar, ClearingNo);
        //        dbCommandWrapper.CommandTimeout = 300;

        //        db.AddOutParameter(dbCommandWrapper, _spStatusParam, DbType.String, 10);

        //        var ds = db.ExecuteDataSet(dbCommandWrapper);

        //        if (!db.GetParameterValue(dbCommandWrapper, _spStatusParam).IsNullOrZero())
        //        {
        //            _errorNumber = db.GetParameterValue(dbCommandWrapper, _spStatusParam).PrefixErrorCode();
        //        }

        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            DataTable dt1 = ds.Tables[0];
        //            billList = dt1.AsEnumerable().Select(reader => new SmsEmailSend
        //            {
        //                VendorName = reader.GetString("VendorName"),
        //                VendorID = reader.GetString("VendorID"),
        //                BillClearingID = reader.GetString("BillClearingID"),
        //                VendorMobileNo = reader.GetString("VendorMobileNo"),
        //                VendorEmail = reader.GetString("VendorEmail"),
        //                VendorType = reader.GetString("VendorType"),
        //                OwnerName = reader.GetString("OwnerName"),
        //                OwnerID = reader.GetString("OwnerID"),
        //                CompanyCode = reader.GetString("CompanyCode"),
        //                InvoiceDocNo = reader.GetString("InvoiceDocNo"),
        //                AmtInLocalCurrency = reader.GetToDecimal("AmtInLocalCurrency"),
        //                EmailBody = reader.GetString("EmailBody"),
        //                EmailSubject = reader.GetString("EmailSubject"),
        //                MessageFor = reader.GetString("MessageFor"), 
        //                SMSText = reader.GetString("SMSText"),
        //                totalPages = reader.GetString("totalPages")
        //            }).ToList();
        //        }

        //    }
        //    return billList;
        //}
    }
}
