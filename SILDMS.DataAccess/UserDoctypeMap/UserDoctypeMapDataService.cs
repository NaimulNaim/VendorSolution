using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
//using SILDMS.DataAccessInterface.BillProcessingStop;
using SILDMS.Model;
using SILDMS.Model.DocScanningModule;
using SILDMS.Utillity;
using SILDMS.Model.SecurityModule;
using SILDMS.DataAccessInterface.UserDoctypeMap;

namespace SILDMS.DataAccess.UserDoctypeMap
{
    public class UserDoctypeMapDataService : IUserDoctypeMapDataService
    {
        #region Fields

        private readonly string _spStatusParam;

        #endregion

        #region Constructor

        public UserDoctypeMapDataService()
        {
            this._spStatusParam = "@p_Status";
        }

        #endregion

        public List<SEC_User> GetUsers(string userId, int page, int itemsPerPage, string sortBy, bool reverse, string search, out string errorNumber)
        {
            errorNumber = string.Empty;
            var users = new List<SEC_User>();

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("CBPS_GetUsersForDocTypeAsign"))
            {
                // Set parameters 
                db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.NVarChar, userId);
                db.AddInParameter(dbCommandWrapper, "@page", SqlDbType.Int, page);
                db.AddInParameter(dbCommandWrapper, "@itemsPerPage", SqlDbType.Int, itemsPerPage);
                db.AddInParameter(dbCommandWrapper, "@sortBy", SqlDbType.NVarChar, sortBy);
                db.AddInParameter(dbCommandWrapper, "@reverse", SqlDbType.Int, reverse == true ? 1:0);
                db.AddInParameter(dbCommandWrapper, "@search", SqlDbType.NVarChar, search);
                db.AddOutParameter(dbCommandWrapper, _spStatusParam, DbType.String, 10);
                // Execute SP.
                var ds = db.ExecuteDataSet(dbCommandWrapper);

                if (!db.GetParameterValue(dbCommandWrapper, _spStatusParam).IsNullOrZero())
                {
                    //Get the error number, if error occurred.
                    errorNumber = db.GetParameterValue(dbCommandWrapper, _spStatusParam).PrefixErrorCode();
                }
                else
                {
                    if (ds.Tables[0].Rows.Count <= 0) return users;
                    var dt1 = ds.Tables[0];
                    users = dt1.AsEnumerable().Select(reader => new SEC_User
                    {
                        UserID = reader.GetString("UserID"),
                        ParentUserID = reader.GetString("ParentUserID"),
                        OwnerID = reader.GetString("OwnerID"),
                        OwnerName = reader.GetString("OwnerName"),
                        EmployeeID = reader.GetString("EmployeeID"),
                        DispUserName = reader.GetString("DispUserName"),
                        UserFullName = reader.GetString("UserFullName"),
                        UserName = reader.GetString("UserName"),
                        UserDesignation = reader.GetString("UserDesignation"),
                        JobLocation = reader.GetString("JobLocation"),
                        SupervisorName = reader.GetString("SupervisorName"),
                        TotalPages = reader.GetInt32("TotalPages")
                    }).ToList();
                }
            }
            return users;
        }

        public List<SEC_UserDoctypeMap> GetDocTypeMap(string userId, out string errorNumber)
        {
            errorNumber = string.Empty;
            var users = new List<SEC_UserDoctypeMap>();

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("GetDocTypeForUserAssign"))
            {
                // Set parameters 
                db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.NVarChar, userId);
                db.AddOutParameter(dbCommandWrapper, _spStatusParam, DbType.String, 10);
                // Execute SP.
                var ds = db.ExecuteDataSet(dbCommandWrapper);

                if (!db.GetParameterValue(dbCommandWrapper, _spStatusParam).IsNullOrZero())
                {
                    //Get the error number, if error occurred.
                    errorNumber = db.GetParameterValue(dbCommandWrapper, _spStatusParam).PrefixErrorCode();
                }
                else
                {
                    if (ds.Tables[0].Rows.Count <= 0) return users;
                    var dt1 = ds.Tables[0];
                    users = dt1.AsEnumerable().Select(reader => new SEC_UserDoctypeMap
                    {
                        DocumentType = reader.GetString("DocumentType")
                    }).ToList();
                }
            }
            return users;
        }


        public List<SEC_UserDoctypeMap> GetDocTypeAssignedToUser(string userId, out string errorNumber)
        {
            errorNumber = string.Empty;
            var users = new List<SEC_UserDoctypeMap>();

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("CBPS_GetDocTypeAssignedToUser"))
            {
                // Set parameters 
                db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.NVarChar, userId);
                db.AddOutParameter(dbCommandWrapper, _spStatusParam, DbType.String, 10);
                // Execute SP.
                var ds = db.ExecuteDataSet(dbCommandWrapper);

                if (!db.GetParameterValue(dbCommandWrapper, _spStatusParam).IsNullOrZero())
                {
                    //Get the error number, if error occurred.
                    errorNumber = db.GetParameterValue(dbCommandWrapper, _spStatusParam).PrefixErrorCode();
                }
                else
                {
                    if (ds.Tables[0].Rows.Count <= 0) return users;
                    var dt1 = ds.Tables[0];
                    users = dt1.AsEnumerable().Select(reader => new SEC_UserDoctypeMap
                    {
                        DocumentType = reader.GetString("Doctype"),
                        Assigned = reader.GetInt16("Assigned") == 1 ? true : false
                    }).ToList();
                }
            }
            return users;
        }

        public string SetDocTypeToUser(string userId, string setBy, List<SEC_UserDoctypeMap> docTypes, out string errorNumber)
        {
            errorNumber = string.Empty;
            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;

            #region Convert docTypes object to data table
            int i = 1;
            var docDataTable = new DataTable();
            docDataTable.Columns.Add("ID");
            docDataTable.Columns.Add("DocumentType");

            foreach (var doc in docTypes)
            {
                var docDataTableRow = docDataTable.NewRow();
                docDataTableRow[0] = i;
                docDataTableRow[1] = doc.DocumentType;
                docDataTable.Rows.Add(docDataTableRow);
                i++;
            }

            #endregion

            using (var dbCommandWrapper = db.GetStoredProcCommand("CBPS_SetDocTypeToUser"))
            {
                // Set parameters 
                db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.NVarChar, userId);
                db.AddInParameter(dbCommandWrapper, "@SetBy", SqlDbType.NVarChar, setBy);
                db.AddInParameter(dbCommandWrapper, "@SEC_UserDoctypeMap", SqlDbType.Structured, docDataTable);
                db.AddOutParameter(dbCommandWrapper, _spStatusParam, SqlDbType.VarChar, 10);
                // Execute SP.
                db.ExecuteNonQuery(dbCommandWrapper);
                // Getting output parameters and setting response details.
                if (!db.GetParameterValue(dbCommandWrapper, _spStatusParam).IsNullOrZero())
                {
                    // Get the error number, if error occurred.
                    errorNumber = db.GetParameterValue(dbCommandWrapper, _spStatusParam).PrefixErrorCode();
                }
            }

            return errorNumber;
        }

        #region DocType Map

        public List<SEC_DocTypeMap> GetDocTypeMap(out string errorNumber)
        {
            errorNumber = string.Empty;
            var docType = new List<SEC_DocTypeMap>();

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("GetDocTypeMap"))
            {
                // Set parameters 
                //db.AddOutParameter(dbCommandWrapper, _spStatusParam, DbType.String, 10);
                // Execute SP.
                var ds = db.ExecuteDataSet(dbCommandWrapper);

                //if (!db.GetParameterValue(dbCommandWrapper, _spStatusParam).IsNullOrZero())
                //{
                //    //Get the error number, if error occurred.
                //    errorNumber = db.GetParameterValue(dbCommandWrapper, _spStatusParam).PrefixErrorCode();
                //}
                //else
                //{
                    if (ds.Tables[0].Rows.Count <= 0) return docType;
                    var dt1 = ds.Tables[0];
                    docType = dt1.AsEnumerable().Select(reader => new SEC_DocTypeMap
                    {
                        Doctype = reader.GetString("Doctype"),
                        VendorPayType = reader.GetString("VendorPayType"),
                    }).ToList();
                //}
            }
            return docType;
        }


        public string SetDocTypeMap(string userId, List<SEC_DocTypeMap> docTypes, out string errorNumber)
        {
            errorNumber = string.Empty;
            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;

            #region Convert docTypes object to data table
            int i = 1;
            var docDataTable = new DataTable();
            docDataTable.Columns.Add("ID");
            docDataTable.Columns.Add("DoctypeID");
            docDataTable.Columns.Add("Doctype");
            docDataTable.Columns.Add("VendorPayType");
            docDataTable.Columns.Add("SetBy");
            docDataTable.Columns.Add("ModifiedBy");
            docDataTable.Columns.Add("Status");
            foreach (var doc in docTypes)
            {
                var docDataTableRow = docDataTable.NewRow();
                docDataTableRow[0] = i;
                docDataTableRow[1] = "";
                docDataTableRow[2] = doc.Doctype;
                docDataTableRow[3] = doc.VendorPayType;
                docDataTableRow[4] = userId;
                docDataTableRow[5] = userId;
                docDataTableRow[6] = 1;
                docDataTable.Rows.Add(docDataTableRow);
                i++;
            }

            #endregion

            using (var dbCommandWrapper = db.GetStoredProcCommand("SetDocTypeMap"))
            {
                // Set parameters 
                db.AddInParameter(dbCommandWrapper, "@SEC_DocTypeMap", SqlDbType.Structured, docDataTable);
                db.AddOutParameter(dbCommandWrapper, _spStatusParam, SqlDbType.VarChar, 10);
                // Execute SP.
                db.ExecuteNonQuery(dbCommandWrapper);
                // Getting output parameters and setting response details.
                if (!db.GetParameterValue(dbCommandWrapper, _spStatusParam).IsNullOrZero())
                {
                    // Get the error number, if error occurred.
                    errorNumber = db.GetParameterValue(dbCommandWrapper, _spStatusParam).PrefixErrorCode();
                }
            }

            return errorNumber;
        }

        #endregion

    }
}
