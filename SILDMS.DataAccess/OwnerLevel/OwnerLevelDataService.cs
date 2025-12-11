using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using SILDMS.DataAccessInterface.OwnerLevel;
using SILDMS.Model.CBPSModule;
using SILDMS.Model.DocScanningModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.DataAccess.OwnerLevel
{
    public class OwnerLevelDataService : IOwnerLevelDataService
    {
        private readonly string spStatusParam = "@p_Status";
        public List<DSM_OwnerLevel> GetOwnerLevel(string OwnerLevelId, string userID, out string errorNumber)
        {
            errorNumber = string.Empty;
            List<DSM_OwnerLevel> ownerLevelList = new List<DSM_OwnerLevel>();
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("GetOwnerLevel"))
            {
                // Set parameters 
                db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.VarChar, userID);       
                db.AddInParameter(dbCommandWrapper, "@OwnerLevelID", SqlDbType.VarChar, OwnerLevelId);              
                db.AddOutParameter(dbCommandWrapper, spStatusParam, DbType.String, 10);
                // Execute SP. 
                DataSet ds = db.ExecuteDataSet(dbCommandWrapper);

                if (!db.GetParameterValue(dbCommandWrapper, spStatusParam).IsNullOrZero())
                {
                    // Get the error number, if error occurred.
                    errorNumber = db.GetParameterValue(dbCommandWrapper, spStatusParam).PrefixErrorCode();
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt1 = ds.Tables[0];
                        ownerLevelList = dt1.AsEnumerable().Select(reader => new DSM_OwnerLevel
                        {
                            OwnerLevelID = reader.GetString("OwnerLevelID"),
                            LevelName = reader.GetString("LevelName"),
                            LevelAccess = reader.GetString("LevelAccess"),
                            LevelSL = reader.GetString("LevelSL"),
                            UserLevel = reader.GetInt32("UserLevel"),
                            SetOn = reader.GetString("SetOn"),
                            SetBy = reader.GetString("SetBy"),
                            ModifiedOn = reader.GetString("ModifiedOn"),
                            ModifiedBy = reader.GetString("ModifiedBy"),
                            Status = reader.GetInt32("Status")
                        }).ToList();
                    }
                }
            }
            return ownerLevelList;
        }

        public string AddOwnerLevel(DSM_OwnerLevel ownerLevel, string action, out string errorNumber)
        {
            errorNumber = String.Empty;
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                SqlDatabase db = factory.CreateDefault() as SqlDatabase;
                using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("SetOwnerLevel"))
                {
                    // Set parameters 
                    db.AddInParameter(dbCommandWrapper, "@OwnerLevelID", SqlDbType.NVarChar, ownerLevel.OwnerLevelID);
                    db.AddInParameter(dbCommandWrapper, "@LevelName", SqlDbType.NVarChar, ownerLevel.LevelName.Trim());
                    db.AddInParameter(dbCommandWrapper, "@LevelAccess ", SqlDbType.NVarChar, ownerLevel.LevelAccess==null?"":ownerLevel.LevelAccess.Trim());
                    db.AddInParameter(dbCommandWrapper, "@LevelSL", SqlDbType.NVarChar, ownerLevel.LevelSL);
                    db.AddInParameter(dbCommandWrapper, "@UserLevel", SqlDbType.Int, ownerLevel.UserLevel);
                    db.AddInParameter(dbCommandWrapper, "@SetBy ", SqlDbType.NVarChar, ownerLevel.SetBy);
                    db.AddInParameter(dbCommandWrapper, "@ModifiedBy", SqlDbType.NVarChar, ownerLevel.ModifiedBy);
                    db.AddInParameter(dbCommandWrapper, "@Status", SqlDbType.Int, ownerLevel.Status);
                    db.AddInParameter(dbCommandWrapper, "@Action", SqlDbType.VarChar, action);
                    db.AddOutParameter(dbCommandWrapper, spStatusParam, SqlDbType.VarChar, 10);              
                    // Execute SP.
                    db.ExecuteNonQuery(dbCommandWrapper);
                    // Getting output parameters and setting response details.
                    if (!db.GetParameterValue(dbCommandWrapper, spStatusParam).IsNullOrZero())
                    {
                        // Get the error number, if error occurred.
                        errorNumber = db.GetParameterValue(dbCommandWrapper, spStatusParam).PrefixErrorCode();
                    }                   
                }
            }
            catch (Exception ex)
            {
                errorNumber = "E404"; // Log ex.Message  Insert Log Table               
            }
            return errorNumber;
        }




        public List<Sys_MasterData> GetJobLocation(string UserID, out string errorNumber)
        {
            errorNumber = string.Empty;
            List<Sys_MasterData> masterDataList = new List<Sys_MasterData>();
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("CBPS_GetAllLocations"))
            {
                // Set parameters 
                
                db.AddOutParameter(dbCommandWrapper, spStatusParam, DbType.String, 10);
                // Execute SP.
                DataSet ds = db.ExecuteDataSet(dbCommandWrapper);

                if (!db.GetParameterValue(dbCommandWrapper, spStatusParam).IsNullOrZero())
                {
                    errorNumber = db.GetParameterValue(dbCommandWrapper, spStatusParam).PrefixErrorCode();
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt1 = ds.Tables[0];
                        masterDataList = dt1.AsEnumerable().Select(reader => new Sys_MasterData
                        {
                            MasterDataID = reader.GetString("MasterDataID"),
                            MasterDataValue = reader.GetString("MasterDataValue"),
                            MasterDataTypeID = reader.GetString("MasterDataTypeID"),
                            OwnerID = reader.GetString("OwnerID"),
                            UserLevel = reader.GetString("UserLevel"),
                            SetBy = reader.GetString("SetBy"),
                            ModifiedBy = reader.GetString("ModifiedBy"),
                            Status = reader.GetInt32("Status"),
                            IsDefault = reader.GetString("IsDefault"),
                            SerialNo = reader.GetString("SerialNo"),
                            UDCode = reader.GetString("UDCode"),
                            OwnerLevelID = reader.GetString("OwnerLevelID")
                            
                        }).ToList();
                    }
                }
            }
            return masterDataList;
        }
    }
}
