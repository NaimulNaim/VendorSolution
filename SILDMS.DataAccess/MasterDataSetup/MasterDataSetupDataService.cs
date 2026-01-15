using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using SILDMS.DataAccessInterface.MasterDataSetup;
using SILDMS.Model.CBPSModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.DataAccess.MasterDataSetup
{
    public class MasterDataSetupDataService : IMasterDataSetupDataService
    {
        private readonly string spStatusParam = "@p_Status";

        public List<Sys_MasterDataType> LoadMasterDataTypeList(string _userId,string _OwnerID, out string _errorNumber)
        {
            _errorNumber = string.Empty;
            List<Sys_MasterDataType> masterDataTypeList = new List<Sys_MasterDataType>();

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("GetMasterDataTypeList"))
            {

                db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.VarChar, _userId);
                db.AddInParameter(dbCommandWrapper, "@OwnerID", SqlDbType.VarChar, _OwnerID);
                db.AddOutParameter(dbCommandWrapper, spStatusParam, DbType.String, 10);

                DataSet ds = db.ExecuteDataSet(dbCommandWrapper);

                if (!db.GetParameterValue(dbCommandWrapper, spStatusParam).IsNullOrZero())
                {
                    _errorNumber = db.GetParameterValue(dbCommandWrapper, spStatusParam).PrefixErrorCode();
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt1 = ds.Tables[0];
                        masterDataTypeList = dt1.AsEnumerable().Select(reader => new Sys_MasterDataType
                        {
                            MasterDataTypeID = reader.GetString("MasterDataTypeID"),
                            OwnerID = reader.GetString("OwnerID"),
                            LevelName = reader.GetString("LevelName"),
                            TypeName = reader.GetString("TypeName"),
                            TypePurpose = reader.GetString("TypePurpose"),
                            ParentID = reader.GetString("ParentID"),
                            TypeCode = reader.GetString("TypeCode"),
                            Status = reader.GetString("Status"),
                        }).ToList();
                    }
                }
            }
            return masterDataTypeList;
        }


        public string AddMasterDataType(Sys_MasterDataType masterDataType, string action, out string errorNumber)
        {
            errorNumber = String.Empty;
            try
            {
                //string ParentID = masterDataType.ParentTypeID.MasterDataTypeID;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                SqlDatabase db = factory.CreateDefault() as SqlDatabase;
                using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("SetMasterDataType"))
                {
                    db.AddInParameter(dbCommandWrapper, "@MasterDataTypeID", SqlDbType.NVarChar, masterDataType.MasterDataTypeID);
                    db.AddInParameter(dbCommandWrapper, "@OwnerID", SqlDbType.NVarChar, masterDataType.Owner.OwnerID);
                    db.AddInParameter(dbCommandWrapper, "@TypeName", SqlDbType.NVarChar, masterDataType.TypeName);
                    db.AddInParameter(dbCommandWrapper, "@TypePurpose", SqlDbType.NVarChar, masterDataType.TypePurpose);
                    db.AddInParameter(dbCommandWrapper, "@TypeCode", SqlDbType.NVarChar, masterDataType.TypeCode);
                    db.AddInParameter(dbCommandWrapper, "@ParentID", SqlDbType.NVarChar, masterDataType.ParentTypeID.MasterDataTypeID);
                    db.AddInParameter(dbCommandWrapper, "@SetBy ", SqlDbType.NVarChar, masterDataType.SetBy);
                    db.AddInParameter(dbCommandWrapper, "@ModifiedBy", SqlDbType.NVarChar, masterDataType.ModifiedBy);
                    db.AddInParameter(dbCommandWrapper, "@Status", SqlDbType.Int, masterDataType.Status);
                    db.AddInParameter(dbCommandWrapper, "@Action", SqlDbType.VarChar, action);
                    db.AddOutParameter(dbCommandWrapper, spStatusParam, SqlDbType.VarChar, 10);

                    db.ExecuteNonQuery(dbCommandWrapper);
                    if (!db.GetParameterValue(dbCommandWrapper, spStatusParam).IsNullOrZero())
                    {
                        errorNumber = db.GetParameterValue(dbCommandWrapper, spStatusParam).PrefixErrorCode();
                    }
                }
            }
            catch (Exception ex)
            {
                errorNumber = "E404";
            }
            return errorNumber;
        }


        public List<Sys_MasterData> LoadMasterDataList(string _userId, string MasterDataTypeID, out string _errorNumber)
        {
            _errorNumber = string.Empty;
            List<Sys_MasterData> masterDataList = new List<Sys_MasterData>();

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("GetMasterDataList"))
            {

                db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.VarChar, _userId);
                db.AddInParameter(dbCommandWrapper, "@MasterDataTypeID", SqlDbType.VarChar, MasterDataTypeID);
                db.AddOutParameter(dbCommandWrapper, spStatusParam, DbType.String, 10);

                DataSet ds = db.ExecuteDataSet(dbCommandWrapper);

                if (!db.GetParameterValue(dbCommandWrapper, spStatusParam).IsNullOrZero())
                {
                    _errorNumber = db.GetParameterValue(dbCommandWrapper, spStatusParam).PrefixErrorCode();
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
                            Status = reader.GetInt32("Status"),
                            IsDefault = reader.GetString("IsDefault"),
                            SerialNo = reader.GetString("SerialNo"),
                            UDCode = reader.GetString("UDCode"),
                            ParrentID = reader.GetString("ParentID"),
                        }).ToList();
                    }
                }
            }
            return masterDataList;
        }


        public List<Sys_MasterDataType> GetAllTypes(string _userId, string _OwnerID, out string _errorNumber)
        {
            _errorNumber = string.Empty;
            List<Sys_MasterDataType> masterDataTypeList = new List<Sys_MasterDataType>();
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("GetOwner"))
            {
                db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.VarChar, _userId);
                db.AddInParameter(dbCommandWrapper, "@OwnerID", SqlDbType.VarChar, _OwnerID == null ? "" : _OwnerID);
                db.AddOutParameter(dbCommandWrapper, spStatusParam, DbType.Int32, 10);

                var ds = db.ExecuteDataSet(dbCommandWrapper);

                if (!db.GetParameterValue(dbCommandWrapper, "@p_Error").IsNullOrZero())
                {
                    _errorNumber = db.GetParameterValue(dbCommandWrapper, "@p_Error").PrefixErrorCode();
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt1 = ds.Tables[0];
                        masterDataTypeList = dt1.AsEnumerable().Select(reader => new Sys_MasterDataType
                        {
                            MasterDataTypeID = reader.GetString("MasterDataTypeID"),
                            TypeName = reader.GetString("TypeName")
                            
                        }).ToList();
                    }
                }
            }
            return masterDataTypeList;
        }


        public List<Sys_MasterData> LoadParentDataList(string _userId, string id, out string _errorNumber)
        {
            _errorNumber = string.Empty;
            List<Sys_MasterData> masterDataList = new List<Sys_MasterData>();

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("GetParentDataList"))
            {

                db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.VarChar, _userId);
                db.AddInParameter(dbCommandWrapper, "@id", SqlDbType.VarChar, id == null ? "" : id);
                db.AddOutParameter(dbCommandWrapper, spStatusParam, DbType.String, 10);

                DataSet ds = db.ExecuteDataSet(dbCommandWrapper);

                if (!db.GetParameterValue(dbCommandWrapper, spStatusParam).IsNullOrZero())
                {
                    _errorNumber = db.GetParameterValue(dbCommandWrapper, spStatusParam).PrefixErrorCode();
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
                            Status = reader.GetInt32("Status"),
                            IsDefault = reader.GetString("IsDefault"),
                            SerialNo = reader.GetString("SerialNo"),
                            UDCode = reader.GetString("UDCode"),
                            ParrentID = reader.GetString("ParentID"),
                            OwnerLevelID = reader.GetString("OwnerLevelID"),
                        }).ToList();
                    }
                }
            }
            return masterDataList;
        }


        public string AddMasterData(Sys_MasterData masterData, string action, out string errorNumber)
        {
            errorNumber = String.Empty;
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                SqlDatabase db = factory.CreateDefault() as SqlDatabase;
                using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("SetMasterData"))
                {
                    db.AddInParameter(dbCommandWrapper, "@MasterDataID", SqlDbType.NVarChar, masterData.MasterDataID);
                    db.AddInParameter(dbCommandWrapper, "@OwnerID", SqlDbType.NVarChar, masterData.Owner.OwnerID);
                    db.AddInParameter(dbCommandWrapper, "@MasterDataValue", SqlDbType.NVarChar, masterData.MasterDataValue);
                    db.AddInParameter(dbCommandWrapper, "@MasterDataTypeID", SqlDbType.NVarChar, masterData.MasterDataType.MasterDataTypeID);
                    db.AddInParameter(dbCommandWrapper, "@ParrentID", SqlDbType.NVarChar, masterData.ParentID.MasterDataID);
                    db.AddInParameter(dbCommandWrapper, "@IsDefault", SqlDbType.NVarChar, masterData.IsDefault);
                    db.AddInParameter(dbCommandWrapper, "@UDCode", SqlDbType.NVarChar, masterData.UDCode);
                    db.AddInParameter(dbCommandWrapper, "@SerialNo", SqlDbType.Int, masterData.SerialNo);
                    db.AddInParameter(dbCommandWrapper, "@SetBy", SqlDbType.Int, masterData.SetBy);
                    db.AddInParameter(dbCommandWrapper, "@ModifiedBy", SqlDbType.Int, masterData.ModifiedBy);
                    db.AddInParameter(dbCommandWrapper, "@Status", SqlDbType.Int, masterData.Status);
                    db.AddInParameter(dbCommandWrapper, "@Action", SqlDbType.VarChar, action);
                    db.AddOutParameter(dbCommandWrapper, spStatusParam, SqlDbType.VarChar, 10);

                    db.ExecuteNonQuery(dbCommandWrapper);
                    if (!db.GetParameterValue(dbCommandWrapper, spStatusParam).IsNullOrZero())
                    {
                        errorNumber = db.GetParameterValue(dbCommandWrapper, spStatusParam).PrefixErrorCode();
                    }
                }
            }
            catch (Exception ex)
            {
                errorNumber = "E404";
            }
            return errorNumber;
        }


        public List<Sys_MasterDataType> LoadParentDataListForType(string _userId, string id, out string _errorNumber)
        {
            _errorNumber = string.Empty;
            List<Sys_MasterDataType> masterDataTypeList = new List<Sys_MasterDataType>();

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("GetParentDataTypeList"))
            {

                db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.VarChar, _userId);
                db.AddInParameter(dbCommandWrapper, "@id", SqlDbType.VarChar, id == null ? "" : id);
                db.AddOutParameter(dbCommandWrapper, spStatusParam, DbType.String, 10);

                DataSet ds = db.ExecuteDataSet(dbCommandWrapper);

                if (!db.GetParameterValue(dbCommandWrapper, spStatusParam).IsNullOrZero())
                {
                    _errorNumber = db.GetParameterValue(dbCommandWrapper, spStatusParam).PrefixErrorCode();
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt1 = ds.Tables[0];
                        masterDataTypeList = dt1.AsEnumerable().Select(reader => new Sys_MasterDataType
                        {
                            MasterDataTypeID = reader.GetString("MasterDataTypeID"),
                            ParentID = reader.GetString("ParentID"),
                            TypeName = reader.GetString("TypeName"),
                            TypePurpose = reader.GetString("TypePurpose"),
                            TypeCode = reader.GetString("TypeCode"),
                            OwnerID = reader.GetString("OwnerID"),
                            UserLevel = reader.GetString("UserLevel"),
                            Status = reader.GetString("Status"),
                        }).ToList();
                    }
                }
            }
            return masterDataTypeList;
        }

        public List<SILDMS.Model.CBPSModule.Sys_MasterData.ddlMasterData> GetMasterData(string ItemType, out string errornumber)
        {
            errornumber = string.Empty;
            var MasterDataList = new List<SILDMS.Model.CBPSModule.Sys_MasterData.ddlMasterData>();

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("CBPS_GetMasterDataValueInfo"))
            {
                // Set parameters 
                db.AddInParameter(dbCommandWrapper, "@ItemType", SqlDbType.VarChar, ItemType);
                // Execute SP.

                var ds = db.ExecuteDataSet(dbCommandWrapper);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    DataTable dt1 = new DataTable();
                    dt1 = ds.Tables[0];
                    MasterDataList = dt1.AsEnumerable().Select(reader => new SILDMS.Model.CBPSModule.Sys_MasterData.ddlMasterData
                    {
                        MasterDataID = reader.GetString("MasterDataID"),
                        MasterDataValue = reader.GetString("MasterDataValue"),
                    }).ToList();
                }
            }
            return MasterDataList;
        }

        public List<SILDMS.Model.CBPSModule.Sys_MasterData.ddlMasterData> GetShipmentPort(int ReceivingPortType, out string errornumber)
        {
            errornumber = string.Empty;
            var MasterDataList = new List<SILDMS.Model.CBPSModule.Sys_MasterData.ddlMasterData>();

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("LC_GetShipmentPort"))
            {
                // Set parameters 
                db.AddInParameter(dbCommandWrapper, "@ItemType", SqlDbType.Int, ReceivingPortType);
                // Execute SP.

                var ds = db.ExecuteDataSet(dbCommandWrapper);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    DataTable dt1 = new DataTable();
                    dt1 = ds.Tables[0];
                    MasterDataList = dt1.AsEnumerable().Select(reader => new SILDMS.Model.CBPSModule.Sys_MasterData.ddlMasterData
                    {
                        MasterDataID = reader.GetString("MasterDataID"),
                        MasterDataValue = reader.GetString("MasterDataValue"),
                    }).ToList();
                }
            }
            return MasterDataList;
        }
    }
}
