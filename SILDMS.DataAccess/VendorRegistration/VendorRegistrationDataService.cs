using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SILDMS.Model.VendorSelectionModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SILDMS.Model.DocScanningModule;
using System.Data.Common;
using SILDMS.Model.CBPSModule;
using System.Runtime.Remoting.Messaging;

namespace SILDMS.DataAccess.VendorRegistration
{
    public class VendorRegistrationDataService : IVendorRegistrationDataService
    {
        private readonly string spStatusParam;





        public VendorRegistrationDataService()
        {
            spStatusParam = "@p_Status";
        }

        public string RegistrationCheckData(string vendorID,string Email, out string errorNumber)
        {
            errorNumber = string.Empty;
            var Vendor = "";

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_GetRegisterStatus"))
            {
                db.AddInParameter(dbCommandWrapper, "@Vendor", SqlDbType.VarChar, vendorID);
                db.AddInParameter(dbCommandWrapper, "@Email", SqlDbType.VarChar, Email);
                db.AddOutParameter(dbCommandWrapper, "@p_Error", DbType.Int32, 10);
                // Execute SP.

                var ds = db.ExecuteDataSet(dbCommandWrapper);

                if (!db.GetParameterValue(dbCommandWrapper, "@p_Error").IsNullOrZero())
                {
                    errorNumber = db.GetParameterValue(dbCommandWrapper, "@p_Error").PrefixErrorCode();
                }
                else
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {

                        
                            var dt = ds.Tables[0];

                            var dr = dt.Rows[0];

                        Vendor = dr.GetString("vendorid");
                        
                    }
                    else
                    {
                        Vendor = "";
                    }
                }
            }
            return Vendor;
        }

        public List<VendorRegData> GetVendorbyIDData(string vendorID, string email, out string errorNumber)
        {
            errorNumber = string.Empty;
            List<VendorRegData> vendorData = new List<VendorRegData>();

            try
            {
                var factory = new DatabaseProviderFactory();
                var db = factory.CreateDefault() as SqlDatabase;

                using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_GetVendorByID"))
                {
                    db.AddInParameter(dbCommandWrapper, "@VendorID", DbType.String, vendorID);
                    db.AddInParameter(dbCommandWrapper, "@Email", DbType.String, email);
                    db.AddOutParameter(dbCommandWrapper, "@p_Error", DbType.String, 10);

                    var ds = db.ExecuteDataSet(dbCommandWrapper);

                    // Check for stored procedure error
                    var spError = db.GetParameterValue(dbCommandWrapper, "@p_Error");
                    if (spError != null && !string.IsNullOrEmpty(spError.ToString()))
                    {
                        errorNumber = spError.ToString();
                        return vendorData; // Return empty list on error
                    }

                    // Populate the list from DataSet
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            var vendor = new VendorRegData
                            {
                                BusinessName = row["VendorBussinessName"] != DBNull.Value ? row["VendorBussinessName"].ToString() : null,
                                VendorPhoneNumber = row["VendorPhoneNumber"] != DBNull.Value ? row["VendorPhoneNumber"].ToString() : null,
                                VendorEmail = row["VendorEmail"] != DBNull.Value ? row["VendorEmail"].ToString() : null,
                                ContactPerson = row["ContactPerson"] != DBNull.Value ? row["ContactPerson"].ToString() : null,
                                CompanyAddress = row["CompanyAddress"] != DBNull.Value ? row["CompanyAddress"].ToString() : null,
                                TIN = row["TIN"] != DBNull.Value ? row["TIN"].ToString() : null,
                                BIN = row["BIN"] != DBNull.Value ? row["BIN"].ToString() : null,
                                Country = row["Country"] != DBNull.Value ? row["Country"].ToString() : null,
                                GenaralDetailsServices = row["DetailsOfService"] != DBNull.Value ? row["DetailsOfService"].ToString() : null
                            };
                            vendorData.Add(vendor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorNumber = "Error occurred: " + ex.Message;
            }

            return vendorData;
        }



        public string ItemVendorcheckData(string vendorID, out string errorNumber)
        {
            errorNumber = string.Empty;
            var Vendor = "";

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_GetItemVendorStatus"))
            {
                db.AddInParameter(dbCommandWrapper, "@Vendor", SqlDbType.VarChar, vendorID);
                db.AddOutParameter(dbCommandWrapper, "@p_Error", DbType.Int32, 10);
                // Execute SP.

                var ds = db.ExecuteDataSet(dbCommandWrapper);

                if (!db.GetParameterValue(dbCommandWrapper, "@p_Error").IsNullOrZero())
                {
                    errorNumber = db.GetParameterValue(dbCommandWrapper, "@p_Error").PrefixErrorCode();
                }
                else
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {


                        var dt = ds.Tables[0];

                        var dr = dt.Rows[0];

                        Vendor = dr.GetString("EmployeeID");

                    }
                    else
                    {
                        Vendor = "";
                    }
                }
            }
            return Vendor;
        }




        public SecVendor_User VendorRegistrationDetailsDataService( string BusinessName, string ContactPerson, string VendorPhoneNumber, string Email,
               string CompanyAddress, string Country, string BusinessType, string TypeOfMaterial, string TIN, string BIN, string GeneralDetailsServices, string UserName, string Password, string Status,string Vendor, out string errorNumber)
        {
            errorNumber = string.Empty;
            var User=new SecVendor_User();

            
            
                var factory = new DatabaseProviderFactory();
                var db = factory.CreateDefault() as SqlDatabase;

                using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_VendorRegData"))
                {
                    db.AddInParameter(dbCommandWrapper, "@BusinessName", SqlDbType.VarChar, BusinessName);
                    db.AddInParameter(dbCommandWrapper, "@ContactPerson", SqlDbType.VarChar, ContactPerson);
                    db.AddInParameter(dbCommandWrapper, "@VendorPhoneNumber", SqlDbType.VarChar, VendorPhoneNumber);
                    db.AddInParameter(dbCommandWrapper, "@Email", SqlDbType.VarChar, Email);
                    db.AddInParameter(dbCommandWrapper, "@CompanyAddress", SqlDbType.VarChar, CompanyAddress);
                    db.AddInParameter(dbCommandWrapper, "@Country", SqlDbType.VarChar, Country);
                    db.AddInParameter(dbCommandWrapper, "@BusinessType", SqlDbType.VarChar, BusinessType);
                    db.AddInParameter(dbCommandWrapper, "@TypeOfMaterial", SqlDbType.VarChar, TypeOfMaterial);
                    db.AddInParameter(dbCommandWrapper, "@TIN", SqlDbType.VarChar, TIN);
                    db.AddInParameter(dbCommandWrapper, "@BIN", SqlDbType.VarChar, BIN);
                    db.AddInParameter(dbCommandWrapper, "@GeneralDetailsServices", SqlDbType.VarChar, GeneralDetailsServices);
                    db.AddInParameter(dbCommandWrapper, "@UserName", SqlDbType.VarChar, UserName);
                    db.AddInParameter(dbCommandWrapper, "@Password", SqlDbType.VarChar, Password);
                    db.AddInParameter(dbCommandWrapper, "@SetBy", SqlDbType.VarChar,"");
                    db.AddInParameter(dbCommandWrapper, "@ProcStatus", SqlDbType.VarChar, Status);
                    db.AddInParameter(dbCommandWrapper, "@Vendor", SqlDbType.VarChar, Vendor);
                db.AddOutParameter(dbCommandWrapper, "@p_Error", DbType.Int32, 10);

                var ds = db.ExecuteDataSet(dbCommandWrapper);

                    if (!db.GetParameterValue(dbCommandWrapper, "@p_Error").IsNullOrZero())
                    {
                        errorNumber = db.GetParameterValue(dbCommandWrapper, "@p_Error").PrefixErrorCode();
                    }
                    else
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            var dt = ds.Tables[0].Rows[0]; // Get the first row

                            User.UserID = dt["UserID"].ToString(); // Set the UserID from the dataset
                            User.VendorId = dt["EmployeeID"].ToString(); // Set the VendorId (EmployeeID) from the dataset
                        }
                        else
                        {
                            // Handle the case when no rows are returned, if necessary
                            User.UserID = string.Empty;
                            User.VendorId = string.Empty;
                        }
                    }
                }

                return User;
            
            
        }

        public SecVendor_User VendorupdateRegistrationDetailsData(string businessName, string contactPerson, string vendorPhoneNumber, string companyAddress, string country, string businessType, string tIN, string bIN, string generalDetailsServices, string status, string vendor,string UserName,string Password, out string errorNumber)
        {
            errorNumber = string.Empty;
            var User = new SecVendor_User();

         
                var factory = new DatabaseProviderFactory();
                var db = factory.CreateDefault() as SqlDatabase;

                using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_VendorupdateRegData"))
                {
                    db.AddInParameter(dbCommandWrapper, "@BusinessName", SqlDbType.VarChar, businessName);
                    db.AddInParameter(dbCommandWrapper, "@ContactPerson", SqlDbType.VarChar, contactPerson);
                    db.AddInParameter(dbCommandWrapper, "@VendorPhoneNumber", SqlDbType.VarChar, vendorPhoneNumber);
                    //db.AddInParameter(dbCommandWrapper, "@Email", SqlDbType.VarChar, Email);
                    db.AddInParameter(dbCommandWrapper, "@CompanyAddress", SqlDbType.VarChar, companyAddress);
                    db.AddInParameter(dbCommandWrapper, "@Country", SqlDbType.VarChar, country);
                    db.AddInParameter(dbCommandWrapper, "@BusinessType", SqlDbType.VarChar, businessType);
                    //db.AddInParameter(dbCommandWrapper, "@TypeOfMaterial", SqlDbType.VarChar, TypeOfMaterial);
                    db.AddInParameter(dbCommandWrapper, "@TIN", SqlDbType.VarChar, tIN);
                    db.AddInParameter(dbCommandWrapper, "@BIN", SqlDbType.VarChar, bIN);
                    db.AddInParameter(dbCommandWrapper, "@GeneralDetailsServices", SqlDbType.VarChar, generalDetailsServices);
                    db.AddInParameter(dbCommandWrapper, "@UserName", SqlDbType.VarChar, UserName);
                    db.AddInParameter(dbCommandWrapper, "@Password", SqlDbType.VarChar, Password);
                    db.AddInParameter(dbCommandWrapper, "@SetBy", SqlDbType.VarChar, "");
                    db.AddInParameter(dbCommandWrapper, "@ProcStatus", SqlDbType.VarChar, status);
                    db.AddInParameter(dbCommandWrapper, "@Vendor", SqlDbType.VarChar, vendor);
                //db.AddOutParameter(dbCommandWrapper, "@p_Error", DbType.Int32, 10);

                var ds = db.ExecuteDataSet(dbCommandWrapper);

                    //if (!db.GetParameterValue(dbCommandWrapper, "@p_Error").IsNullOrZero())
                    //{
                    //    errorNumber = db.GetParameterValue(dbCommandWrapper, "@p_Error").PrefixErrorCode();
                    //}
                    //else
                    //{
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            var dt = ds.Tables[0].Rows[0]; // Get the first row

                            User.UserID = dt["UserID"].ToString(); // Set the UserID from the dataset
                            User.VendorId = dt["EmployeeID"].ToString(); // Set the VendorId (EmployeeID) from the dataset
                        }
                        else
                        {
                            // Handle the case when no rows are returned, if necessary
                            User.UserID = string.Empty;
                            User.VendorId = string.Empty;
                        }
                    
                }

                return User;


            }

        public List<DSM_DocProperty> GetSupportDoc(string UserID, string FromName, out string _errorNumber)
        {
            _errorNumber = string.Empty;
            List<DSM_DocProperty> docPropertyList = new List<DSM_DocProperty>();

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;

            using (var dbCommandWrapper = db.GetStoredProcCommand("CBPS_GetSupportDocForLC"))
            {
                db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.VarChar, UserID);
                db.AddInParameter(dbCommandWrapper, "@FromName", SqlDbType.VarChar, FromName);
                db.AddOutParameter(dbCommandWrapper, spStatusParam, DbType.String, 10);

                var ds = db.ExecuteDataSet(dbCommandWrapper);
                if (!db.GetParameterValue(dbCommandWrapper, spStatusParam).IsNullOrZero())
                {
                    _errorNumber = db.GetParameterValue(dbCommandWrapper, spStatusParam).PrefixErrorCode();
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt1 = ds.Tables[0];
                    docPropertyList = dt1.AsEnumerable().Select(reader => new DSM_DocProperty
                    {
                        DocPropertyID = reader.GetString("DocPropertyID"),
                        DocPropertyName = reader.GetString("DocPropertyName"),
                        DocClassification = reader.GetString("DocClassification"),
                    }).ToList();
                }
            }
            return docPropertyList;
        }

        public List<DSM_DocPropIdentify> GetIdentificationAttributesForDocProperties(string _UserID, string _SelectedPropID, out string errorNumber)
        {
            errorNumber = string.Empty;
            List<DSM_DocPropIdentify> docPropIdentifyList = new List<DSM_DocPropIdentify>();
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("GetIdentificationAttributesForDocProperties"))
            {
                // Set parameters 
                db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.VarChar, _UserID);
                db.AddInParameter(dbCommandWrapper, "@SelectedPropID", SqlDbType.VarChar, _SelectedPropID);
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
                        docPropIdentifyList = dt1.AsEnumerable().Select(reader => new DSM_DocPropIdentify
                        {
                            DocPropIdentifyID = reader.GetString("DocPropIdentifyID"),
                            DocPropertyID = reader.GetString("DocPropertyID"),
                            DocPropertyName = reader.GetString("DocPropertyName"),
                            DocCategoryID = reader.GetString("DocCategoryID"),
                            DocTypeID = reader.GetString("DocTypeID"),
                            OwnerID = reader.GetString("OwnerID"),
                            IdentificationCode = reader.GetString("IdentificationCode"),
                            IdentificationSL = reader.GetString("IdentificationSL"),
                            AttributeGroup = reader.GetString("AttributeGroup"),
                            IdentificationAttribute = reader.GetString("IdentificationAttribute"),
                            IsRequired = reader.GetInt16("IsRequired"),
                            IsAuto = reader.GetInt16("IsAuto"),
                            IsRestricted = reader.GetInt16("IsRestriction"),
                            SetOn = reader.GetString("SetOn"),
                            SetBy = reader.GetString("SetBy"),
                            ModifiedOn = reader.GetString("ModifiedOn"),
                            ModifiedBy = reader.GetString("ModifiedBy"),
                            Status = reader.GetInt32("Status"),
                            Remarks = reader.GetString("Remarks")
                        }).ToList();
                    }
                }
            }
            return docPropIdentifyList;
        }

        public BPS_NewBillReturnData AddDocument(string UserId, string vendorId, string uploaderIP, string _selectedPropID, List<DocMetaValue> _docMetaValues, out string _errorNumber)
        {
            BPS_NewBillReturnData returnData = new BPS_NewBillReturnData();


            List<DSM_DocPropIdentify> docInfo = new List<DSM_DocPropIdentify>();
            BPS_POHeader headerInfo = new BPS_POHeader();


            DataTable docMetaDataTable = new DataTable();
            docMetaDataTable.Columns.Add("DocPropertyID");
            docMetaDataTable.Columns.Add("MetaValue");
            docMetaDataTable.Columns.Add("Remarks");
            docMetaDataTable.Columns.Add("DocPropIdentifyID");
            if (_docMetaValues != null)
            {
                foreach (var item in _docMetaValues)
                {
                    DataRow objDataRow = docMetaDataTable.NewRow();

                    objDataRow[0] = item.DocPropertyID;
                    objDataRow[1] = item.MetaValue;
                    objDataRow[2] = item.Remarks;
                    objDataRow[3] = item.DocPropIdentifyID;
                    docMetaDataTable.Rows.Add(objDataRow);
                }
            }

            DataTable docPropertyIDDataTable = new DataTable();
            docPropertyIDDataTable.Columns.Add("DocPropertyID");

            if (!string.IsNullOrEmpty(_selectedPropID))
            {
                string[] docPropIDs = _selectedPropID.Split(',');
                foreach (var item in docPropIDs)
                {
                    DataRow objDataRow = docPropertyIDDataTable.NewRow();
                    objDataRow[0] = item;

                    docPropertyIDDataTable.Rows.Add(objDataRow);
                }
            }

            DataTable ConditionTypesDataTable = new DataTable();
            ConditionTypesDataTable.Columns.Add("LC_ConditionTypeMapID");
            ConditionTypesDataTable.Columns.Add("ConditionType");
            ConditionTypesDataTable.Columns.Add("ConditionValue");
            ConditionTypesDataTable.Columns.Add("Currency");
            //if (_docMetaValues != null)
            //{
            

            _errorNumber = String.Empty;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            //if (_lcInsCoverNotReceive.InsCovNotReceivID == 0)
            //{
            using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("VCMS_TinBinForVendor"))
            {
           
                db.AddInParameter(dbCommandWrapper, "@UserId", SqlDbType.NVarChar, UserId);
                db.AddInParameter(dbCommandWrapper, "@VendorId", SqlDbType.NVarChar, vendorId);
                db.AddInParameter(dbCommandWrapper, "@UploaderIP", SqlDbType.NVarChar, uploaderIP);
                db.AddInParameter(dbCommandWrapper, "@Doc_MetaType", SqlDbType.Structured, docMetaDataTable);
                db.AddInParameter(dbCommandWrapper, "@Doc_PropertyType", SqlDbType.Structured, docPropertyIDDataTable);
      
                db.AddOutParameter(dbCommandWrapper, spStatusParam, SqlDbType.VarChar, 10);

                DataSet ds = db.ExecuteDataSet(dbCommandWrapper);

                if (!db.GetParameterValue(dbCommandWrapper, spStatusParam).IsNullOrZero())
                {
                    _errorNumber = db.GetParameterValue(dbCommandWrapper, spStatusParam).PrefixErrorCode();
                }

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt1 = ds.Tables[0];
                        docInfo = dt1.AsEnumerable().Select(reader => new DSM_DocPropIdentify
                        {
                            BillTrackingNo = reader.GetString("BillTrackingNo"),
                            BillReceiveID = reader.GetString("BillReceiveID"),
                            DocMetaID = reader.GetString("DocMetaID"),
                            DocumentID = reader.GetString("DocumentID"),
                            DocPropIdentifyID = reader.GetString("DocPropIdentifyID"),
                            DocPropertyID = reader.GetString("DocPropertyID"),
                            DocCategoryID = reader.GetString("DocCategoryID"),
                            DocTypeID = reader.GetString("DocTypeID"),
                            FileCodeName = reader.GetString("FileCodeName"),
                            OwnerID = reader.GetString("OwnerID"),
                            IdentificationCode = reader.GetString("IdentificationCode"),
                            DocPropertyName = reader.GetString("DocPropertyName"),
                            AttributeGroup = reader.GetString("AttributeGroup"),
                            IdentificationAttribute = reader.GetString("IdentificationAttribute"),
                            MetaValue = reader.GetString("MetaValue"),
                            Remarks = reader.GetString("Remarks"),
                            FileServerUrl = reader.GetString("FileServerUrl"),
                            ServerIP = reader.GetString("ServerIP"),
                            ServerPort = reader.GetString("ServerPort"),
                            FtpUserName = reader.GetString("FtpUserName"),
                            FtpPassword = reader.GetString("FtpPassword"),
                            BoothName = reader.GetString("BoothName"),
                            ReceivedBy = reader.GetString("ReceivedBy")
                        }).ToList();
                    }
                }

                returnData.DocInfo = docInfo;
            }
            return returnData;
        }

    
    }
}
