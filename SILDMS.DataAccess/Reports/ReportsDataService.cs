using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using SILDMS.DataAccessInterface.Reports;
using SILDMS.Model.CBPSModule;
//using SILDMS.Model.CheckPrintModule;
using SILDMS.Model.DocScanningModule;
//using SILDMS.Model.LCModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.DataAccess.Reports
{
    public class ReportsDataService : IReportsDataService
    {
        private readonly string spErrorParam = "@p_Error";
        private readonly string spStatusParam = "@p_Status";

        public DataTable GetRptUserActivityStatus(string FromDate, string ToDate, string userID, string id, string action, out string errorNumber)
        {
            errorNumber = string.Empty;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("CBPS_GetRptUserActivityStatus"))
            {
                //db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.VarChar, action);
                //db.AddInParameter(dbCommandWrapper, "@OwnerID", SqlDbType.VarChar, id);
                //db.AddOutParameter(dbCommandWrapper, spErrorParam, DbType.Int32, 10);

                if (!string.IsNullOrEmpty(FromDate))
                {
                    string[] fromdate = FromDate.Split('/');
                    FromDate = fromdate[2] + "-" + fromdate[1] + "-" + fromdate[0];
                }
                if (!string.IsNullOrEmpty(ToDate))
                {
                    string[] todate = ToDate.Split('/');
                    ToDate = todate[2] + "-" + todate[1] + "-" + todate[0];
                }

                db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.VarChar, userID);
                db.AddInParameter(dbCommandWrapper, "@FromDate", SqlDbType.VarChar, FromDate);
                db.AddInParameter(dbCommandWrapper, "@ToDate", SqlDbType.VarChar, ToDate);
                //db.AddOutParameter(dbCommandWrapper, spErrorParam, DbType.Int32, 10);

                dbCommandWrapper.CommandTimeout = 300;

                var ds = db.ExecuteDataSet(dbCommandWrapper);
                DataTable dt1 = ds.Tables[0];
                return dt1;
            }
        }

        public DataTable GetRptUserDetails(string userID, string FromDate, string Status, string id, string action, out string errorNumber)
        {
            errorNumber = string.Empty;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("CBPS_GetRptUserDetails"))
            {
                //db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.VarChar, action);
                //db.AddInParameter(dbCommandWrapper, "@OwnerID", SqlDbType.VarChar, id);
                //db.AddOutParameter(dbCommandWrapper, spErrorParam, DbType.Int32, 10);

                if (!string.IsNullOrEmpty(FromDate))
                {
                    string[] fromdate = FromDate.Split('/');
                    FromDate = fromdate[2] + "-" + fromdate[1] + "-" + fromdate[0];
                }
                //if (!string.IsNullOrEmpty(ToDate))
                //{
                //    string[] todate = ToDate.Split('/');
                //    ToDate = todate[2] + "-" + todate[1] + "-" + todate[0];
                //}

                db.AddInParameter(dbCommandWrapper, "@RptUserID", SqlDbType.VarChar, userID);
                db.AddInParameter(dbCommandWrapper, "@FromDate", SqlDbType.VarChar, FromDate);
                //db.AddInParameter(dbCommandWrapper, "@ToDate", SqlDbType.VarChar, ToDate);
                db.AddInParameter(dbCommandWrapper, "@Status", SqlDbType.VarChar, Status);
                //db.AddOutParameter(dbCommandWrapper, spErrorParam, DbType.Int32, 10);


                var ds = db.ExecuteDataSet(dbCommandWrapper);
                DataTable dt1 = ds.Tables[0];
                return dt1;
            }
        }

        public DataTable GetRptOwnerList(string OwnerLevelID, string OwnerID, string ParentOwnerID, string Status, string id, string action, out string errorNumber)
        {
            errorNumber = string.Empty;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("CBPS_GetRptOwnerList"))
            {
                db.AddInParameter(dbCommandWrapper, "@OwnerLevelID", SqlDbType.VarChar, OwnerLevelID);
                db.AddInParameter(dbCommandWrapper, "@OwnerID", SqlDbType.VarChar, OwnerID);
                db.AddInParameter(dbCommandWrapper, "@ParentID", SqlDbType.VarChar, ParentOwnerID);
                db.AddInParameter(dbCommandWrapper, "@Status", SqlDbType.VarChar, Status);


                var ds = db.ExecuteDataSet(dbCommandWrapper);
                DataTable dt1 = ds.Tables[0];
                return dt1;
            }
        }

        public DataTable GetRptDocumentsList(string OwnerLevelID, string OwnerID, string DocCategoryID, string DocTypeID, string DocPropertyID, string Status, string id, string action, out string errorNumber)
        {
            errorNumber = string.Empty;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("CBPS_GetRptDocumentsList"))
            {

                db.AddInParameter(dbCommandWrapper, "@OwnerLevelID", SqlDbType.VarChar, OwnerLevelID);
                db.AddInParameter(dbCommandWrapper, "@OwnerID", SqlDbType.VarChar, OwnerID);
                db.AddInParameter(dbCommandWrapper, "@DocCategoryID", SqlDbType.VarChar, DocCategoryID);
                db.AddInParameter(dbCommandWrapper, "@DocTypeID", SqlDbType.VarChar, DocTypeID);
                db.AddInParameter(dbCommandWrapper, "@DocPropertyID", SqlDbType.VarChar, DocPropertyID);
                db.AddInParameter(dbCommandWrapper, "@Status", SqlDbType.VarChar, Status);


                var ds = db.ExecuteDataSet(dbCommandWrapper);
                DataTable dt1 = ds.Tables[0];
                return dt1;
            }
        }

        public DataTable GetRptRoleList(string OwnerLevelID, string OwnerID, string RoleID, string Status, string id, string action, out string errorNumber)
        {
            errorNumber = string.Empty;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("CBPS_GetRptRoleList"))
            {
                //db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.VarChar, action);
                //db.AddInParameter(dbCommandWrapper, "@OwnerID", SqlDbType.VarChar, id);
                //db.AddOutParameter(dbCommandWrapper, spErrorParam, DbType.Int32, 10);

                db.AddInParameter(dbCommandWrapper, "@OwnerLevelID", SqlDbType.VarChar, OwnerLevelID);
                db.AddInParameter(dbCommandWrapper, "@OwnerID", SqlDbType.VarChar, OwnerID);
                db.AddInParameter(dbCommandWrapper, "@RoleID", SqlDbType.VarChar, RoleID);
                db.AddInParameter(dbCommandWrapper, "@Status", SqlDbType.VarChar, Status);


                var ds = db.ExecuteDataSet(dbCommandWrapper);
                DataTable dt1 = ds.Tables[0];
                return dt1;
            }
        }

        public string GetCompanyOrOwnerNameByUserID(string UserID)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("GetRptComOwnerDivisionByUserID"))
            {
                db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.VarChar, UserID);
                var ds = db.ExecuteDataSet(dbCommandWrapper);

                DataTable dt1 = ds.Tables[0];
                if (dt1.Rows.Count > 0)
                    return dt1.Rows[0]["CompanyName"].ToString();
                else
                    return string.Empty;
            }
        }

        public List<RptVendorWithAddress> GetVendorNameAndAddress(string VendorID, out string errorNumber)
        {
            List<RptVendorWithAddress> RptAllEFTVendorList = new List<RptVendorWithAddress>();
            errorNumber = string.Empty;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("CBPS_RptGetVendorsWithAddress"))
            {
                db.AddInParameter(dbCommandWrapper, "@VendorID", SqlDbType.VarChar, VendorID);

                var ds = db.ExecuteDataSet(dbCommandWrapper);

                DataTable dt1 = ds.Tables[0];
                RptAllEFTVendorList = dt1.AsEnumerable().Select(reader => new RptVendorWithAddress
                {
                    VendorID = reader.GetString("VendorID"),
                    VendorCode = reader.GetString("VendorCode"),
                    VendorName = reader.GetString("VendorName"),
                    TransAccountName = reader.GetString("TransAccountName"),
                    TIN = reader.GetString("TIN"),
                    BIN = reader.GetString("BIN"),
                    VatRegNo = reader.GetString("VatRegNo"),
                    VendorAddress = reader.GetString("VendorAddress"),
                    VendorEmail = reader.GetString("VendorEmail")
                }).ToList();

                return RptAllEFTVendorList;
            }
        }
    }
}
