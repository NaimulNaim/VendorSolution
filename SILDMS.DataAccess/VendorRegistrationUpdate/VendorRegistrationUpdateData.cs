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
using SILDMS.Model.CBPSModule;

namespace SILDMS.DataAccess.VendorRegistrationUpdate
{
    public class VendorRegistrationUpdateData : IVendorRegistrationUpdateData
    {
        public BillInfoForFurtherDoc GetDocsForFurtherDoc(string tinBinDocId, string userID, out string errorNumber)
        {
            errorNumber = string.Empty;
            var bills = new BillInfoForFurtherDoc
            {
            
                DocProperties = new List<DSM_DocProperty>(),
                Documents = new List<DSM_Documents>()
            };

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_GetDocsForFurtherDoc"))
            {
                // Set parameters 
                db.AddInParameter(dbCommandWrapper, "@tinBinDocId", SqlDbType.NVarChar, tinBinDocId);
             
                // Execute SP.
                var ds = db.ExecuteDataSet(dbCommandWrapper);

                if (ds.Tables[0].Rows.Count <= 0 && ds.Tables[1].Rows.Count <= 0 ) return bills;
               
                var dt2 = ds.Tables[0];
                bills.DocProperties = dt2.AsEnumerable().Select(reader => new DSM_DocProperty
                {
                    DocPropertyID = reader.GetString("DocPropertyID"),
                    DocPropertyName = reader.GetString("DocPropertyName"),
                    DocClassification = reader.GetString("DocClassification"),
                    Exist = reader.GetInt16("Exist")
                }).ToList();
                var dt3 = ds.Tables[1];
                bills.Documents = dt3.AsEnumerable().Select(reader => new DSM_Documents
                {
                    DocumentID = reader.GetString("DocumentID"),
                    DocPropertyID = reader.GetString("DocPropertyID"),
                    FileServerURL = reader.GetString("FileServerURL"),
                    ServerID = reader.GetString("ServerID"),
                    //ServerIP = reader.GetString("ServerIP"),
                    //FtpPort = reader.GetString("FtpPort"),
                    //FtpUserName = reader.GetString("FtpUserName"),
                    //FtpPassword = reader.GetString("FtpPassword"),
                    DocPropertyName = reader.GetString("DocPropertyName"),
                    DocClassification = reader.GetString("DocClassification"),
                    //IdentificationAttribute = reader.GetString("IdentificationAttribute"),
                    MetaValue = reader.GetString("MetaValue"),
                    ServerIP = "",
                    FtpPort = "",
                    FtpUserName = "",
                    FtpPassword = "",

                }).ToList();
            }
            return bills;
        }

        public List<VendorRegData> GetVendorInformation(string userID, out string errorNumber)
        {
            errorNumber = string.Empty;
            List<VendorRegData> vendorData = new List<VendorRegData>();

            try
            {
                var factory = new DatabaseProviderFactory();
                var db = factory.CreateDefault() as SqlDatabase;

                using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_GetVendorInformation"))
                {
                    db.AddInParameter(dbCommandWrapper, "@UserID", DbType.String, userID);
                  
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
                                VendorID = row["VendorID"] != DBNull.Value ? row["VendorID"].ToString() : null,
                                BusinessName = row["VendorBussinessName"] != DBNull.Value ? row["VendorBussinessName"].ToString() : null,

                                BusinessType = row["BusinessType"] != DBNull.Value ? row["BusinessType"].ToString() : null,
                                BusinessNature = row["BusinessNature"] != DBNull.Value ? row["BusinessNature"].ToString() : null,
                                EstablishedYear = row["EstablishedYear"] != DBNull.Value ? row["EstablishedYear"].ToString() : null,
                                TradeLicenseValidity = row["TLValidity"] != DBNull.Value ? row["TLValidity"].ToString() : null,

                                VendorPhoneNumber = row["VendorPhoneNumber"] != DBNull.Value ? row["VendorPhoneNumber"].ToString() : null,
                                VendorPhoneNumber2 = row["VendorPhoneNumber2"] != DBNull.Value ? row["VendorPhoneNumber2"].ToString() : null,
                                VendorEmail = row["VendorEmail"] != DBNull.Value ? row["VendorEmail"].ToString() : null,
                                ContactPerson = row["ContactPerson"] != DBNull.Value ? row["ContactPerson"].ToString() : null,
                                CompanyAddress = row["CompanyAddress"] != DBNull.Value ? row["CompanyAddress"].ToString() : null,
                                TIN = row["TIN"] != DBNull.Value ? row["TIN"].ToString() : null,
                                BIN = row["BIN"] != DBNull.Value ? row["BIN"].ToString() : null,
                                CompanyProfile = row["CompanyProfile"] != DBNull.Value ? row["CompanyProfile"].ToString() : null,
                                TradeLicense = row["TradeLicense"] != DBNull.Value ? row["TradeLicense"].ToString() : null,
                                PartnershipDeed = row["PartnershipDeed"] != DBNull.Value ? row["PartnershipDeed"].ToString() : null,
                                IRC = row["IRC"] != DBNull.Value ? row["IRC"].ToString() : null,
                                IndentingLicense = row["IndentingLicense"] != DBNull.Value ? row["IndentingLicense"].ToString() : null,
                                Others = row["Others"] != DBNull.Value ? row["Others"].ToString() : null,
                                Country = row["Country"] != DBNull.Value ? row["Country"].ToString() : null,
                                GenaralDetailsServices = row["DetailsOfService"] != DBNull.Value ? row["DetailsOfService"].ToString() : null,
                                TinBinDocId = row["TinBinDocId"] != DBNull.Value ? row["TinBinDocId"].ToString() : null
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
    }
}
