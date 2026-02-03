using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SILDMS.Model.VendorSelectionModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SILDMS.Model.CBPSModule;
using SILDMS.Model.DocScanningModule;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;

namespace SILDMS.DataAccess.TechnicalQuotation
{
    public class TechnicalQuotationData : ITechnicalQuotationData
    {
        private readonly string spStatusParam = "@p_Status";
        public List<Invitation> GetAllInvitationData(string userid, out string errorNumber)
        {
            errorNumber = string.Empty;
            var invitationList = new List<Invitation>();

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_GetAllInvitation"))
            {
                db.AddInParameter(dbCommandWrapper, "@UserId", SqlDbType.VarChar, userid);
                db.AddOutParameter(dbCommandWrapper, "@p_Error", DbType.Int32, 10);
                // Execute SP.

                var ds = db.ExecuteDataSet(dbCommandWrapper);

                if (!db.GetParameterValue(dbCommandWrapper, "@p_Error").IsNullOrZero())
                {
                    errorNumber = db.GetParameterValue(dbCommandWrapper, "@p_Error").PrefixErrorCode();
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        DataTable dt1 = new DataTable();
                        dt1 = ds.Tables[0];

                        invitationList = dt1.AsEnumerable().Select(reader => new Invitation
                        {
                            Invitation_Number = reader.GetString("InvitationNumber"),
                            RFQDate = reader.GetDateTime("InvitationSendingDate").ToString("dd/MM/yyyy"),
                            RFQDeadline = reader.GetDateTime("RFQDeadline").ToString("dd/MM/yyyy"),
                        


                        }).ToList();
                    }
                }
            }
            return invitationList;
        }

        public List<MaterialInvitation> InvWiseMaterialData(string UserID, string invNumber, out string errorNumber)
        {
            errorNumber = string.Empty;
            var InvMaterialList = new List<MaterialInvitation>();

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;

            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_InvMaterial"))
            {
                db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.VarChar, UserID);
                db.AddInParameter(dbCommandWrapper, "@InvNumber", SqlDbType.VarChar, invNumber);
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
                        DataTable dt1 = ds.Tables[0];

                        InvMaterialList = dt1.AsEnumerable().Select(reader => new MaterialInvitation
                        {
                            materialCode = reader.GetString("MaterialCode"),
                            materialName = reader.GetString("MaterialName"),
                            material_Category_Code = reader.GetString("MaterialCategory"),
                            MaterialQuantity = reader.GetString("RFQQty"),
                            Unit = reader.GetString("RFQQtyUnit"),
                            MatInvType = reader.GetString("TechType"),
                            Proposal = reader.GetString("Proposal"),

                            invitationNumber = reader.GetString("InvitationNumber"),
                            InvitationID = reader.GetString("InvitationID"),
                            BiddingItemVendorID = reader.GetString("BiddingVendorID"),
                            VendorID = reader.GetString("VendorID"),
                            BiddingID = reader.GetString("BiddingID"),
                            Status = reader.GetInt32("Status"),

                            MoleculeName = reader.GetString("MoleculeName"),
                            Manufacturer = reader.GetString("Manufacturer"),
                            ShelfLifeValue = reader.GetInt32("ShelfLifeValue"),
                            ShelfLifeUnit = reader.GetString("ShelfLifeUnit"),
                            Notes = reader.GetString("Notes"),
                            CASNO = reader.GetString("CASNO"),
                            CatalogueNo = reader.GetString("CatalogueNo"),
                            SampleAvailable = reader.GetString("SampleAvailable"),
                            SamplePackSize = reader.GetString("SamplePackSize"),
                            Capacity = reader.GetString("Capacity"),
                            CapacityExtendable = reader.GetString("CapacityExtendable"),
                            CapacityExtendableOther = reader.GetString("CapacityExtendableOther"),
                            FATAtManufacturerSite = reader.GetString("FATAtManufacturerSite"),
                            FATAtManufacturerSiteOther = reader.GetString("FATAtManufacturerSiteOther"),
                            SATScope = reader.GetString("SATScope"),
                            AssistanceAtSite = reader.GetString("AssistanceAtSite"),
                            AssistanceAtSiteOther = reader.GetString("AssistanceAtSiteOther"),
                            ComplianceWith = reader.GetString("ComplianceWith"),
                            QualificationDocuments = reader.GetString("QualificationDocuments"),
                            QualificationDocumentsOther = reader.GetString("QualificationDocumentsOther"),
                            UtilitiesRequirement = reader.GetString("UtilitiesRequirement"),
                            SafetyFeatures = reader.GetString("SafetyFeatures"),
                            EnergyEfficiencyFeatures = reader.GetString("EnergyEfficiencyFeatures"),
                            SparesServicing = reader.GetString("SparesServicing"),
                            ScopeConfirmation = reader.GetString("ScopeConfirmation"),
                            ScopeDeviationRemarks = reader.GetString("ScopeDeviationRemarks"),
                            Erection = reader.GetString("Erection"),
                            ErectionOther = reader.GetString("ErectionOther"),
                            InstallationResponsibility = reader.GetString("InstallationResponsibility"),
                            InstallationResponsibilityOther = reader.GetString("InstallationResponsibilityOther"),
                            Testing = reader.GetString("Testing"),
                            TestingOther = reader.GetString("TestingOther"),
                            Commissioning = reader.GetString("Commissioning"),
                            CommissioningOther = reader.GetString("CommissioningOther"),
                            ItemName = reader.GetString("ItemName"),
                            ManufacturerPartNoTech = reader.GetString("ManufacturerPartNoTech"),
                            ModelVersion = reader.GetString("ModelVersion"),
                            ProductLifeCycleValue = reader.GetString("ProductLifeCycleValue"),
                            ProductLifeCycleUnit = reader.GetString("ProductLifeCycleUnit"),
                            sampleDocId = reader.GetString("DocumentID"),
                            Action = "A"

                        }).ToList();
                    }
                }
            }

            return InvMaterialList;
        }



        public BPS_NewBillReturnData AddDocumentInfo(DocumentsInfo _modelDocumentsInfo,
         string _selectedPropID, List<DocMetaValue> _docMetaValues,
         string _action, out string _errorNumber)
        {
            BPS_NewBillReturnData returnData = new BPS_NewBillReturnData();

            List<DSM_DocPropIdentify> docInfo = new List<DSM_DocPropIdentify>();
            BPS_POHeader headerInfo = new BPS_POHeader();

            //try
            //{
            //DataTable docMetaDataTable = new DataTable();
            //docMetaDataTable.Columns.Add("DocPropertyID");
            //docMetaDataTable.Columns.Add("MetaValue");
            //docMetaDataTable.Columns.Add("Remarks");
            //docMetaDataTable.Columns.Add("DocPropIdentifyID");

            //foreach (var item in _docMetaValues)
            //{
            //    DataRow objDataRow = docMetaDataTable.NewRow();

            //    objDataRow[0] = item.DocPropertyID;
            //    objDataRow[1] = item.MetaValue;
            //    objDataRow[2] = item.Remarks;
            //    objDataRow[3] = item.DocPropIdentifyID;
            //    docMetaDataTable.Rows.Add(objDataRow);
            //}

            //DataTable docPropertyIDDataTable = new DataTable();
            //docPropertyIDDataTable.Columns.Add("DocPropertyID");

            //string[] docPropIDs = _selectedPropID.Split(',');
            //foreach (var item in docPropIDs)
            //{
            //    DataRow objDataRow = docPropertyIDDataTable.NewRow();
            //    objDataRow[0] = item;

            //    docPropertyIDDataTable.Rows.Add(objDataRow);
            //}


            _errorNumber = String.Empty;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            SqlDatabase db = factory.CreateDefault() as SqlDatabase;

            using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("VCMS_Test"))
            {
                //db.AddInParameter(dbCommandWrapper, "@OwnerLevelID", SqlDbType.NVarChar, _modelDocumentsInfo.OwnerLevelID);
                //db.AddInParameter(dbCommandWrapper, "@OwnerID", SqlDbType.NVarChar, _modelDocumentsInfo.OwnerID);
                //db.AddInParameter(dbCommandWrapper, "@DocCategoryID ", SqlDbType.NVarChar, _modelDocumentsInfo.DocCategoryID);
                //db.AddInParameter(dbCommandWrapper, "@DocTypeID", SqlDbType.NVarChar, _modelDocumentsInfo.DocTypeID);
                //db.AddInParameter(dbCommandWrapper, "@FileOriginalName", SqlDbType.NVarChar, "");
                //db.AddInParameter(dbCommandWrapper, "@FileCodeName", SqlDbType.NVarChar, "");
                db.AddInParameter(dbCommandWrapper, "@FileExtension", SqlDbType.NVarChar, _modelDocumentsInfo.Extensions);
                db.AddInParameter(dbCommandWrapper, "@UploaderIP", SqlDbType.NVarChar, _modelDocumentsInfo.UploaderIP);
                db.AddInParameter(dbCommandWrapper, "@SetBy", SqlDbType.NVarChar, _modelDocumentsInfo.SetBy);
                db.AddInParameter(dbCommandWrapper, "@materialName", SqlDbType.NVarChar, _modelDocumentsInfo.materialName);
                //db.AddInParameter(dbCommandWrapper, "@ConfColumnIds", SqlDbType.NVarChar, _modelDocumentsInfo.ConfigureColumnIds);
                db.AddInParameter(dbCommandWrapper, "@Status", SqlDbType.Int, 1);
                //db.AddInParameter(dbCommandWrapper, "@Doc_MetaType", SqlDbType.Structured, docMetaDataTable);
                //db.AddInParameter(dbCommandWrapper, "@Doc_PropertyType", SqlDbType.Structured, docPropertyIDDataTable);
                db.AddOutParameter(dbCommandWrapper, spStatusParam, SqlDbType.VarChar, 10);

                db.AddInParameter(dbCommandWrapper, "@InvitationID", SqlDbType.NVarChar, _modelDocumentsInfo.InvitationID);
                db.AddInParameter(dbCommandWrapper, "@VendorID", SqlDbType.NVarChar, _modelDocumentsInfo.VendorID);

                //db.AddInParameter(dbCommandWrapper, "@BoothID", SqlDbType.NVarChar, _modelDocumentsInfo.BoothID);

                //db.AddInParameter(dbCommandWrapper, "@PONo", SqlDbType.NVarChar, _modelDocumentsInfo.PONo);

                ////db.AddInParameter(dbCommandWrapper, "@BillTrackingNo", SqlDbType.NVarChar,
                ////    _modelDocumentsInfo.BillTrackingNo);

                //db.AddInParameter(dbCommandWrapper, "@InvoicingParty", SqlDbType.NVarChar,
                //    _modelDocumentsInfo.InvoicingPartyCode);

                //db.AddInParameter(dbCommandWrapper, "@InvoiceNo", SqlDbType.NVarChar, _modelDocumentsInfo.InvoiceNo);

                //db.AddInParameter(dbCommandWrapper, "@InvoiceDate", SqlDbType.DateTime, Convert.ToDateTime(_modelDocumentsInfo.InvoiceDate));//null ? (DateTime?)null : DateTime.ParseExact(_modelDocumentsInfo.InvoiceDate, "dd/MM/yyyy", null));
                //                                                                                                                             // DMSUtility.FormatDate(_modelDocumentsInfo.InvoiceDate.ToString()));

                //db.AddInParameter(dbCommandWrapper, "@InvoiceAmount", SqlDbType.NVarChar,
                //    _modelDocumentsInfo.InvoiceAmt);

                //db.AddInParameter(dbCommandWrapper, "@InvoiceCurrency", SqlDbType.NVarChar,
                //    _modelDocumentsInfo.InvoiceCurrency);

                //db.AddInParameter(dbCommandWrapper, "@PreferedPayMode", SqlDbType.NVarChar,
                //    _modelDocumentsInfo.PreferedPayMode);

                //db.AddInParameter(dbCommandWrapper, "@BillSubmittedBy", SqlDbType.NVarChar,
                //    _modelDocumentsInfo.BillSubmittedBy);

                //db.AddInParameter(dbCommandWrapper, "@BillSubmitDate", SqlDbType.DateTime,
                //      _modelDocumentsInfo.BillSubmitDate == null ? (DateTime?)null : DateTime.ParseExact(_modelDocumentsInfo.BillSubmitDate, "dd/MM/yyyy", null));
                ////  DMSUtility.FormatDate(_modelDocumentsInfo.BillSubmitDate.ToString()));

                //db.AddInParameter(dbCommandWrapper, "@BearerContactNo", SqlDbType.NVarChar,
                //    _modelDocumentsInfo.BearerContactNo);

                //db.AddInParameter(dbCommandWrapper, "@ProcessGroupID", SqlDbType.NVarChar,
                //    _modelDocumentsInfo.ProcessGroupID);
                //db.AddInParameter(dbCommandWrapper, "@Remarks", SqlDbType.NVarChar,
                //    _modelDocumentsInfo.Remarks);

                //db.AddInParameter(dbCommandWrapper, "@Mushak", SqlDbType.NVarChar,
                // _modelDocumentsInfo.Mushak);

                //db.AddInParameter(dbCommandWrapper, "@MushakAmount", SqlDbType.Decimal,
                //     _modelDocumentsInfo.MushakAmount);

                //if (string.IsNullOrEmpty(_modelDocumentsInfo.MushakDate))
                //    db.AddInParameter(dbCommandWrapper, "@MushakDate", SqlDbType.DateTime, null);
                //else
                //    db.AddInParameter(dbCommandWrapper, "@MushakDate", SqlDbType.DateTime, Convert.ToDateTime(_modelDocumentsInfo.MushakDate));

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
                            Extensions = reader.GetString("FileExtension"),
                            DocPropertyName = reader.GetString("DocPropertyName"),
                            //AttributeGroup = reader.GetString("AttributeGroup"),
                            //IdentificationAttribute = reader.GetString("IdentificationAttribute"),
                            MetaValue = reader.GetString("MetaValue"),
                            Remarks = reader.GetString("Remarks"),
                            FileServerUrl = reader.GetString("FileServerUrl"),
                            ServerIP = reader.GetString("ServerIP"),
                            ServerPort = reader.GetString("ServerPort"),
                            FtpUserName = reader.GetString("FtpUserName"),
                            FtpPassword = reader.GetString("FtpPassword"),
                            BoothName = reader.GetString("BoothName"),
                            ReceivedBy = reader.GetString("ReceivedBy"),
                            NumberOfMissingDocuments = reader.GetInt32("NumberOfMissingDocuments")
                        }).ToList();
                    }
                }


                //if (ds.Tables.Count > 1)
                //{
                //    if (ds.Tables[1].Rows.Count > 0)
                //    {
                //        DataTable dt1 = ds.Tables[1];
                //        headerInfo = dt1.AsEnumerable().Select(reader => new BPS_POHeader
                //        {
                //            BillReceiveID = reader.GetString("BillReceiveID"),
                //            BillTrackingNo = reader.GetString("BillTrackingNo"),
                //            PONo = reader.GetString("PONo"),
                //            VendorType = reader.GetString("VendorType"),
                //            InvoicingParty = reader.GetString("InvoicingParty"),
                //            InvoiceNo = reader.GetString("InvoiceNo"),
                //            InvoiceAmt = reader.GetString("InvoiceAmt"),
                //            InvoiceCurrency = reader.GetString("InvoiceCurrency"),
                //            PreferedPayMode = reader.GetString("PreferedPayMode"),
                //            BillSubmitDate = reader.GetDateTime("BillSubmitDate").ToString("dd/MM/yyyy"),
                //            InvoiceDate = reader.GetDateTime("InvoiceDate").ToString("dd/MM/yyyy"),
                //            CompanyName = reader.GetString("CompanyName"),
                //            OwnerName = reader.GetString("OwnerName"),
                //            BillReceivedBy = reader.GetString("BillReceivedBy"),
                //            BillReceivedAt = reader.GetString("BillReceivedAt"),
                //            PurchaseGroup = reader.GetString("PurchaseGroup"),
                //            BoxNumber = reader.GetString("BoxNumber")
                //        }).FirstOrDefault();

                //    }
                //}
                returnData.DocInfo = docInfo;
                //returnData.DocHeaderInfo = headerInfo;
            }
            //}
            //catch (Exception ex)
            //{
            //    _errorNumber = "E404";
            //}



            return returnData;
        }

        public List<Quotation> submitquotationData(string UserId, string invId, string VendorID, string invitationNumber, string MaterialCode, string MaterialName, out string errorNumber)
        {
            errorNumber = string.Empty;
            var QuotationList = new List<Quotation>();

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_SubmitQuotation"))
            {
                db.AddInParameter(dbCommandWrapper, "@invId", SqlDbType.VarChar, invId);
                db.AddInParameter(dbCommandWrapper, "@invitationNumber", SqlDbType.VarChar, invitationNumber);
                db.AddInParameter(dbCommandWrapper, "@VendorID", SqlDbType.VarChar, VendorID);
                db.AddInParameter(dbCommandWrapper, "@MaterialCode", SqlDbType.VarChar, MaterialCode);
                db.AddInParameter(dbCommandWrapper, "@MaterialName", SqlDbType.VarChar, MaterialName);
                db.AddInParameter(dbCommandWrapper, "@Setby", SqlDbType.VarChar, UserId);

                db.AddOutParameter(dbCommandWrapper, "@p_Error", DbType.Int32, 10);
                // Execute SP.

                var ds = db.ExecuteDataSet(dbCommandWrapper);

                if (!db.GetParameterValue(dbCommandWrapper, "@p_Error").IsNullOrZero())
                {
                    errorNumber = db.GetParameterValue(dbCommandWrapper, "@p_Error").PrefixErrorCode();
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        DataTable dt1 = new DataTable();
                        dt1 = ds.Tables[0];

                        QuotationList = dt1.AsEnumerable().Select(reader => new Quotation
                        {

                            quotationID = reader.GetString("QuotationID"),
                            quotationNo = reader.GetString("QuotationNo"),





                        }).ToList();
                    }
                }
            }
            return QuotationList;
        }
        //int length = technicalQuotationlist.Count;

        //errorNumber = string.Empty;

        //foreach (var techQuotation in technicalQuotationlist)
        //{
        //    foreach (var materialInvitation in materialInvitationlist)
        //    {
        //        if (techQuotation.rowIndex == materialInvitation.rowIndex)
        //        {
        //            continue;
        //        }
        //    }
        //}


        //return 1;
        public int submittechnicalquotationData(string UserId, Model.VendorSelectionModule.TechnicalQuotation technicalQuotation, SimplifiedMaterialInvitation materialInvitation, Quotation quotation, out string errorNumber)
        {




            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            var i = 0;
            int ID = 0;
            errorNumber = string.Empty;





            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_SubmitTechnicalQuotation"))
            {



                db.AddInParameter(dbCommandWrapper, "@RowIndex", SqlDbType.VarChar, technicalQuotation.rowIndex);
                db.AddInParameter(dbCommandWrapper, "@ItemName", SqlDbType.VarChar, technicalQuotation.ItemName);
                db.AddInParameter(dbCommandWrapper, "@MoleculeName", SqlDbType.VarChar, technicalQuotation.MoleculeName);
                db.AddInParameter(dbCommandWrapper, "@Manufacturer", SqlDbType.VarChar, technicalQuotation.Manufacturer);
                db.AddInParameter(dbCommandWrapper, "@ManufacturerPart", SqlDbType.VarChar, technicalQuotation.ManufacturerPart);
                db.AddInParameter(dbCommandWrapper, "@ManufactureAddress", SqlDbType.VarChar, technicalQuotation.ManufactureAddress);
                db.AddInParameter(dbCommandWrapper, "@ManufacturerOrigin", SqlDbType.VarChar, technicalQuotation.ManufacturerOrigin);
                db.AddInParameter(dbCommandWrapper, "@Supplier", SqlDbType.VarChar, technicalQuotation.Supplier);
                db.AddInParameter(dbCommandWrapper, "@LocalPartner", SqlDbType.VarChar, technicalQuotation.LocalPartner);

                // =======================
                // Pricing
                // =======================
                db.AddInParameter(dbCommandWrapper, "@RDPrice", SqlDbType.Decimal, technicalQuotation.RDPrice ?? (object)DBNull.Value);
                db.AddInParameter(dbCommandWrapper, "@CommercialPrice", SqlDbType.Decimal, technicalQuotation.CommercialPrice ?? (object)DBNull.Value);
                db.AddInParameter(dbCommandWrapper, "@PricePer", SqlDbType.Decimal, technicalQuotation.PricePer ?? (object)DBNull.Value);
                if (string.IsNullOrEmpty(technicalQuotation.PriceUnit.Item_Code))
                {
                    db.AddInParameter(dbCommandWrapper, "@PriceUnit", SqlDbType.VarChar, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommandWrapper, "@PriceUnit", SqlDbType.VarChar, technicalQuotation.PriceUnit.Item_Code);
                }
                if (string.IsNullOrEmpty(technicalQuotation.Currency.MasterDataID))
                {
                    db.AddInParameter(dbCommandWrapper, "@Currency", SqlDbType.VarChar, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommandWrapper, "@Currency", SqlDbType.VarChar, technicalQuotation.Currency.MasterDataID);
                }
           

                // =======================
                // Order / Shelf / Storage
                // =======================
                db.AddInParameter(dbCommandWrapper, "@MinOrderQty", SqlDbType.Int, technicalQuotation.MinOrderQty);
                db.AddInParameter(dbCommandWrapper, "@OrderQtyUnit", SqlDbType.VarChar, string.IsNullOrEmpty(technicalQuotation.OrderQtyUnit) ? (object)DBNull.Value : technicalQuotation.OrderQtyUnit);
                db.AddInParameter(dbCommandWrapper, "@CommercialPackSize", SqlDbType.VarChar, technicalQuotation.CommercialPackSize);
                db.AddInParameter(dbCommandWrapper, "@MinPack", SqlDbType.VarChar, technicalQuotation.MinPack);
                db.AddInParameter(dbCommandWrapper, "@ShelfLifeValue", SqlDbType.Int, technicalQuotation.ShelfLifeValue ?? (object)DBNull.Value);
                db.AddInParameter(dbCommandWrapper, "@ShelfLifeUnit", SqlDbType.VarChar, technicalQuotation.ShelfLifeUnit);
                db.AddInParameter(dbCommandWrapper, "@StorageCondition", SqlDbType.VarChar, technicalQuotation.StorageCondition);

                // =======================
                // References / Notes
                // =======================
                db.AddInParameter(dbCommandWrapper, "@Reference", SqlDbType.VarChar, technicalQuotation.Reference);
                db.AddInParameter(dbCommandWrapper, "@Notes", SqlDbType.VarChar, technicalQuotation.Notes);
                db.AddInParameter(dbCommandWrapper, "@CASNO", SqlDbType.VarChar, technicalQuotation.CASNO);
                db.AddInParameter(dbCommandWrapper, "@CatalogueNo", SqlDbType.VarChar, technicalQuotation.CatalogueNo);

                // =======================
                // Production
                // =======================
                db.AddInParameter(dbCommandWrapper, "@CurrentStatus", SqlDbType.VarChar, technicalQuotation.CurrentStatus);
                db.AddInParameter(dbCommandWrapper, "@ProdCapacity", SqlDbType.VarChar, technicalQuotation.ProdCapacity);
                db.AddInParameter(dbCommandWrapper, "@ProductionFrequency", SqlDbType.VarChar, technicalQuotation.ProductionFrequency);
                db.AddInParameter(dbCommandWrapper, "@ProductionLeadTimeValue", SqlDbType.Int, technicalQuotation.ProductionLeadTimeValue);
                db.AddInParameter(dbCommandWrapper, "@ProductionLeadTimeUnit", SqlDbType.VarChar, technicalQuotation.ProductionLeadTimeUnit);
                db.AddInParameter(dbCommandWrapper, "@RepresentativeSample", SqlDbType.VarChar, technicalQuotation.RepresentativeSample);
                db.AddInParameter(dbCommandWrapper, "@RepresentativeSamplePackSize", SqlDbType.VarChar, technicalQuotation.RepresentativeSamplePackSize);
                db.AddInParameter(dbCommandWrapper, "@RepresentativeSampleOther", SqlDbType.VarChar, technicalQuotation.RepresentativeSampleOther);

                // =======================
                // Compliance / Qualification
                // =======================
                db.AddInParameter(dbCommandWrapper, "@ComplianceWith", SqlDbType.VarChar, technicalQuotation.ComplianceWith);
                db.AddInParameter(dbCommandWrapper, "@QualificationDocuments", SqlDbType.VarChar, technicalQuotation.QualificationDocuments);
                db.AddInParameter(dbCommandWrapper, "@QualificationDocumentsOther", SqlDbType.VarChar, technicalQuotation.QualificationDocumentsOther);

                // =======================
                // FAT / SAT / Assistance
                // =======================
                db.AddInParameter(dbCommandWrapper, "@FATAtManufacturerSite", SqlDbType.VarChar, technicalQuotation.FATAtManufacturerSite);
                db.AddInParameter(dbCommandWrapper, "@FATAtManufacturerSiteOther", SqlDbType.VarChar, technicalQuotation.FATAtManufacturerSiteOther);
                db.AddInParameter(dbCommandWrapper, "@SATScope", SqlDbType.VarChar, technicalQuotation.SATScope);
                db.AddInParameter(dbCommandWrapper, "@AssistanceAtSite", SqlDbType.VarChar, technicalQuotation.AssistanceAtSite);
                db.AddInParameter(dbCommandWrapper, "@AssistanceAtSiteOther", SqlDbType.VarChar, technicalQuotation.AssistanceAtSiteOther);

                // =======================
                // Utilities / Safety
                // =======================
                db.AddInParameter(dbCommandWrapper, "@UtilitiesRequirement", SqlDbType.VarChar, technicalQuotation.UtilitiesRequirement);
                db.AddInParameter(dbCommandWrapper, "@SafetyFeatures", SqlDbType.VarChar, technicalQuotation.SafetyFeatures);
                db.AddInParameter(dbCommandWrapper, "@EnergyEfficiencyFeatures", SqlDbType.VarChar, technicalQuotation.EnergyEfficiencyFeatures);

                // =======================
                // Servicing / Scope
                // =======================
                db.AddInParameter(dbCommandWrapper, "@SparesServicing", SqlDbType.VarChar, technicalQuotation.SparesServicing);
                db.AddInParameter(dbCommandWrapper, "@ScopeConfirmation", SqlDbType.VarChar, technicalQuotation.ScopeConfirmation);
                db.AddInParameter(dbCommandWrapper, "@ScopeDeviationRemarks", SqlDbType.VarChar, technicalQuotation.ScopeDeviationRemarks);

                // =======================
                // Responsibility Matrix
                // =======================
                db.AddInParameter(dbCommandWrapper, "@Erection", SqlDbType.VarChar, technicalQuotation.Erection);
                db.AddInParameter(dbCommandWrapper, "@ErectionOther", SqlDbType.VarChar, technicalQuotation.ErectionOther);
                db.AddInParameter(dbCommandWrapper, "@Installation", SqlDbType.VarChar, technicalQuotation.Installation);
                db.AddInParameter(dbCommandWrapper, "@InstallationOther", SqlDbType.VarChar, technicalQuotation.InstallationOther);
                db.AddInParameter(dbCommandWrapper, "@Testing", SqlDbType.VarChar, technicalQuotation.Testing);
                db.AddInParameter(dbCommandWrapper, "@TestingOther", SqlDbType.VarChar, technicalQuotation.TestingOther);
                db.AddInParameter(dbCommandWrapper, "@Commissioning", SqlDbType.VarChar, technicalQuotation.Commissioning);
                db.AddInParameter(dbCommandWrapper, "@CommissioningOther", SqlDbType.VarChar, technicalQuotation.CommissioningOther);

                // =======================
                // Regulatory
                // =======================
                db.AddInParameter(dbCommandWrapper, "@RegulatoryApproval", SqlDbType.VarChar, technicalQuotation.RegulatoryApproval);
                db.AddInParameter(dbCommandWrapper, "@RegulatoryApprovalOther", SqlDbType.VarChar, technicalQuotation.RegulatoryApprovalOther);

                // =======================
                // Misc
                // =======================
                db.AddInParameter(dbCommandWrapper, "@ColumnSpecification", SqlDbType.VarChar, technicalQuotation.ColumnSpecification);

                // =======================
                // p === 2 Specific Fields
                // =======================
                db.AddInParameter(dbCommandWrapper, "@ModelVersion", SqlDbType.VarChar, technicalQuotation.ModelVersion);
                db.AddInParameter(dbCommandWrapper, "@CountryOrigin", SqlDbType.VarChar, technicalQuotation.CountryOrigin);
                db.AddInParameter(dbCommandWrapper, "@YearOfManufacturing", SqlDbType.VarChar, technicalQuotation.YearOfManufacturing);

                db.AddInParameter(
    dbCommandWrapper,
    "@ProductLifeCycleValue",
    SqlDbType.Int,
    technicalQuotation.ProductLifeCycleValue.HasValue
        ? (object)technicalQuotation.ProductLifeCycleValue.Value
        : DBNull.Value
);


                db.AddInParameter(dbCommandWrapper, "@ProductLifeCycleUnit", SqlDbType.VarChar, technicalQuotation.ProductLifeCycleUnit);
                db.AddInParameter(dbCommandWrapper, "@Capacity", SqlDbType.VarChar, technicalQuotation.Capacity);
                db.AddInParameter(dbCommandWrapper, "@CapacityExtendable", SqlDbType.VarChar, technicalQuotation.CapacityExtendable);
                db.AddInParameter(dbCommandWrapper, "@CapacityExtendableOther", SqlDbType.VarChar, technicalQuotation.CapacityExtendableOther);

                // =======================
                // Material Invitation fields
                // =======================
                db.AddInParameter(dbCommandWrapper, "@MaterialQuantity", SqlDbType.VarChar, materialInvitation.MaterialQuantity);
                db.AddInParameter(dbCommandWrapper, "@MatUnit", SqlDbType.VarChar, materialInvitation.Unit);
                db.AddInParameter(dbCommandWrapper, "@MatInvType", SqlDbType.VarChar, materialInvitation.MatInvType);
                db.AddInParameter(dbCommandWrapper, "@invitationNumber", SqlDbType.VarChar, materialInvitation.invitationNumber);
                db.AddInParameter(dbCommandWrapper, "@departmentId", SqlDbType.Int, materialInvitation.departmentId);
                db.AddInParameter(dbCommandWrapper, "@matCategory", SqlDbType.VarChar, materialInvitation.matCategory);
                db.AddInParameter(dbCommandWrapper, "@itemNo", SqlDbType.Int, materialInvitation.itemNo);
                db.AddInParameter(dbCommandWrapper, "@materialCode", SqlDbType.VarChar, materialInvitation.materialCode);
                db.AddInParameter(dbCommandWrapper, "@materialName", SqlDbType.VarChar, materialInvitation.materialName);
                db.AddInParameter(dbCommandWrapper, "@remarks", SqlDbType.VarChar, materialInvitation.remarks);
                db.AddInParameter(dbCommandWrapper, "@sampleDocId", SqlDbType.VarChar, materialInvitation.sampleDocId);
                db.AddInParameter(dbCommandWrapper, "@BiddingItemVendorID", SqlDbType.VarChar, materialInvitation.VendorID);
                db.AddInParameter(dbCommandWrapper, "@proposalType", SqlDbType.VarChar, materialInvitation.proposalType);
                db.AddInParameter(dbCommandWrapper, "@sharedToFactory", SqlDbType.Bit, materialInvitation.sharedToFactory);
                db.AddInParameter(dbCommandWrapper, "@askFinanQoutations", SqlDbType.Bit, materialInvitation.askFinanQoutations);
                db.AddInParameter(dbCommandWrapper, "@modificationType", SqlDbType.VarChar, materialInvitation.modificationType);
                db.AddInParameter(dbCommandWrapper, "@setOn", SqlDbType.DateTime, materialInvitation.setOn);
                db.AddInParameter(dbCommandWrapper, "@setBy", SqlDbType.VarChar, UserId);
                db.AddInParameter(dbCommandWrapper, "@modifiedOn", SqlDbType.DateTime, materialInvitation.modifiedOn);
                db.AddInParameter(dbCommandWrapper, "@modifiedBy", SqlDbType.VarChar, UserId);
                db.AddInParameter(dbCommandWrapper, "@status", SqlDbType.VarChar, "1");
                db.AddInParameter(dbCommandWrapper, "@SampleDocumentID", SqlDbType.VarChar, technicalQuotation.SampleDocumentID);
                db.AddInParameter(dbCommandWrapper, "@proposal", SqlDbType.VarChar, technicalQuotation.Proposal);
                db.AddInParameter(dbCommandWrapper, "@techtype", SqlDbType.VarChar, technicalQuotation.Techtype);
                db.AddInParameter(dbCommandWrapper, "@material_Category_Code", SqlDbType.VarChar, materialInvitation.material_Category_Code);
               
                db.AddInParameter(dbCommandWrapper, "@AllPharmacopeialReference", SqlDbType.VarChar, technicalQuotation.AllPharmacopeialReference);

                // =======================
                // Quotation fields
                // =======================
                db.AddInParameter(dbCommandWrapper, "@quotationID", SqlDbType.VarChar, quotation.quotationID);
                db.AddInParameter(dbCommandWrapper, "@quotationNo", SqlDbType.VarChar, quotation.quotationNo);








                // Example of retrieving results if  the stored procedure returns data



                DataSet ds = db.ExecuteDataSet(dbCommandWrapper);


                if (ds.Tables[0].Rows.Count > 0)
                {
                    var dt = ds.Tables[0];

                    var dr = dt.Rows[0];

                    ID = dr.GetInt32("ID");
                }

            }
            return ID;













        }

        public List<Quotation> GetAllQuotationData(string userid, out string errorNumber)
        {
            errorNumber = string.Empty;
            var QuotationList = new List<Quotation>();

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_GetAllQuotation"))
            {
                db.AddInParameter(dbCommandWrapper, "@UserId", SqlDbType.VarChar, userid);
                db.AddOutParameter(dbCommandWrapper, "@p_Error", DbType.Int32, 10);
                // Execute SP.

                var ds = db.ExecuteDataSet(dbCommandWrapper);

                if (!db.GetParameterValue(dbCommandWrapper, "@p_Error").IsNullOrZero())
                {
                    errorNumber = db.GetParameterValue(dbCommandWrapper, "@p_Error").PrefixErrorCode();
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        DataTable dt1 = new DataTable();
                        dt1 = ds.Tables[0];

                        QuotationList = dt1.AsEnumerable().Select(reader => new Quotation
                        {

                            quotationID = reader.GetString("QuotationID"),
                            quotationNo = reader.GetString("QuotationNo"),
                            InvitationNumber = reader.GetString("InvitationNumber"),
                            QuotationDate = reader.GetDateTime("SetOn").ToString("dd/MM/yyyy"),
                            RFQDate = reader.GetDateTime("InvitationSendingDate").ToString("dd/MM/yyyy"),
                            RFQDeadline = reader.GetDateTime("QuotationSendingLastDate").ToString("dd/MM/yyyy"),





                        }).ToList();
                    }
                }
            }
            return QuotationList;
        }

        public List<MaterialInvitation> QuotWiseMaterialData(string quotationNo, out string errorNumber)
        {
            errorNumber = string.Empty;
            var QuotMaterialList = new List<MaterialInvitation>();

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_QuotMaterial"))
            {
                db.AddInParameter(dbCommandWrapper, "@quotationNo", SqlDbType.VarChar, quotationNo);
                db.AddOutParameter(dbCommandWrapper, "@p_Error", DbType.Int32, 10);
                // Execute SP.

                var ds = db.ExecuteDataSet(dbCommandWrapper);

                if (!db.GetParameterValue(dbCommandWrapper, "@p_Error").IsNullOrZero())
                {
                    errorNumber = db.GetParameterValue(dbCommandWrapper, "@p_Error").PrefixErrorCode();
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        DataTable dt1 = new DataTable();
                        dt1 = ds.Tables[0];

                        QuotMaterialList = dt1.AsEnumerable().Select(reader => new MaterialInvitation
                        {

                            TechQuotationItemID = reader.GetString("TechQuotationItemID"),
                            materialName = reader.GetString("MaterialName"),
                            MaterialQuantity = reader.GetString("RequestQty"),
                            Unit = reader.GetString("Unit"),
                            MatInvType = reader.GetString("Techtype"),
                            materialCode = reader.GetString("MaterialCode"),
                            material_Category_Code = reader.GetString("MatCategory"),
                            invitationNumber = reader.GetString("InvitationNumber"),
                            InvitationID = reader.GetString("InvitationID"),
                            VendorID = reader.GetString("VendorID"),
                            sampleDocId = reader.GetString("DocumentID"),
                            SampleDocumentID = reader.GetString("SampleDocId"),
                            BiddingItemVendorID = reader.GetString("BiddingVendorID"),

                            BiddingID = reader.GetString("BiddingID"),
                            Action = "E",




                        }).ToList();
                    }
                }
            }
            return QuotMaterialList;
        }

        public List<Model.VendorSelectionModule.TechnicalQuotation> TechQuotwiseDetailsData(string techQuotationItemID, out string errorNumber)
        {
            errorNumber = string.Empty;
            var TechnicalQuotationList = new List<Model.VendorSelectionModule.TechnicalQuotation>();

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_QuotMaterialDetail"))
            {
                db.AddInParameter(dbCommandWrapper, "@techQuotationItemID", SqlDbType.VarChar, techQuotationItemID);
                db.AddOutParameter(dbCommandWrapper, "@p_Error", DbType.Int32, 10);
                // Execute SP.

                var ds = db.ExecuteDataSet(dbCommandWrapper);

                if (!db.GetParameterValue(dbCommandWrapper, "@p_Error").IsNullOrZero())
                {
                    errorNumber = db.GetParameterValue(dbCommandWrapper, "@p_Error").PrefixErrorCode();
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        DataTable dt1 = new DataTable();
                        dt1 = ds.Tables[0];

                        TechnicalQuotationList = dt1.AsEnumerable().Select(reader => new Model.VendorSelectionModule.TechnicalQuotation
                        {

                            TechQuotationItemID = reader["TechQuotationItemID"] != DBNull.Value ? reader["TechQuotationItemID"].ToString() : null,
                            QuotationRevisionNo = reader["QuotationRevisionNo"] != DBNull.Value ? reader["QuotationRevisionNo"].ToString() : null,
                            QuotationID = reader["QuotationID"] != DBNull.Value ? reader["QuotationID"].ToString() : null,
                            QuotationNo = reader["QuotationNo"] != DBNull.Value ? reader["QuotationNo"].ToString() : null,
                            MoleculeName = reader["MoleculeName"] != DBNull.Value ? reader["MoleculeName"].ToString() : null,
                            ManufacturerPart = reader["ManufacturerPart"] != DBNull.Value ? reader["ManufacturerPart"].ToString() : null,
                            CASNO= reader["CASNo"] != DBNull.Value ? reader["CASNo"].ToString() : null,
                            Manufacturer = reader["Manufacturer"] != DBNull.Value ? reader["Manufacturer"].ToString() : null,
                            ManufacturerOrigin = reader["ManufactureOrigin"] != DBNull.Value ? reader["ManufactureOrigin"].ToString() : null,
                            Supplier = reader["Supplier"] != DBNull.Value ? reader["Supplier"].ToString() : null,
                            LocalPartner = reader["LocalPartner"] != DBNull.Value ? reader["LocalPartner"].ToString() : null,
                            ManufactureAddress = reader["ManufactureAddress"] != DBNull.Value ? reader["ManufactureAddress"].ToString() : null,

                            RDPrice = reader["RDPrice"] != DBNull.Value ? Convert.ToDecimal(reader["RDPrice"]) : (decimal?)null,

                            ShelfLifeValue = reader["ShelfLifeValue"] != DBNull.Value ? Convert.ToInt32(reader["ShelfLifeValue"]) : (int?)null,
                            CommercialPrice = reader["CommercialPrice"] != DBNull.Value ? Convert.ToDecimal(reader["CommercialPrice"]) : (decimal?)null,
                            PriceUnit = reader["PriceUnit"] != DBNull.Value
        ? new Item { Item_Code = reader["PriceUnit"].ToString() }
        : null,
                            MinOrderQty = reader["MinOrderQty"] != DBNull.Value ? Convert.ToInt32(reader["MinOrderQty"]) : (int?)null,
                            OrderQtyUnit = reader["OrderQtyUnit"] != DBNull.Value ? reader["OrderQtyUnit"].ToString() : null,
                            ProductionLeadTimeValue = reader["ProductionLeadTimeValue"] != DBNull.Value ? Convert.ToInt32(reader["ProductionLeadTimeValue"]) : (int?)null,


                            AssistanceAtSite = reader["AssistanceAtSite"] != DBNull.Value ? reader["AssistanceAtSite"].ToString() : null,
                            FATAtManufacturerSite = reader["FATAtManufacturerSite"] != DBNull.Value ? reader["FATAtManufacturerSite"].ToString() : null,
                            QualificationDocuments = reader["QualificationDocuments"] != DBNull.Value ? reader["QualificationDocuments"].ToString() : null,
                            RepresentativeSample = reader["RepresentativeSample"] != DBNull.Value ? reader["RepresentativeSample"].ToString() : null,
                            RepresentativeSamplePackSize = reader["RepresentativeSamplePackSize"] != DBNull.Value ? reader["RepresentativeSamplePackSize"].ToString() : null,
                            RepresentativeSampleOther = reader["RepresentativeSampleOther"] != DBNull.Value ? reader["RepresentativeSampleOther"].ToString() : null,
                            ProductionFrequency = reader["ProductionFrequency"] != DBNull.Value ? reader["ProductionFrequency"].ToString() : null,

                            ProdCapacity = reader["ProdCapacity"] != DBNull.Value ? reader["ProdCapacity"].ToString() : null,
                            ShelfLifeUnit = reader["ShelfLifeUnit"] != DBNull.Value ? reader["ShelfLifeUnit"].ToString() : null,
                            StorageCondition = reader["StorageCondition"] != DBNull.Value ? reader["StorageCondition"].ToString() : null,

                            Currency = reader["Currency"] != DBNull.Value
        ? new MasterData { MasterDataID = reader["Currency"].ToString() }
        : null,
                            Reference = reader["Reference"] != DBNull.Value ? reader["Reference"].ToString() : null,
                            
                      
                            PenaltyClause = reader["PenealtyClause"] != DBNull.Value ? reader["PenealtyClause"].ToString() : null,
                          
                            RegulatoryApproval = reader["RegulatoryApproval"] != DBNull.Value ? reader["RegulatoryApproval"].ToString() : null,
                            CurrentStatus = reader["CurApiStatus"] != DBNull.Value ? reader["CurApiStatus"].ToString() : null,


                            rowIndex = reader["rowIndex"] != DBNull.Value ? reader["rowIndex"].ToString() : null,
                            ItemName = reader["ItemName"] != DBNull.Value ? reader["ItemName"].ToString() : null,
                            PricePer = reader["PricePer"] != DBNull.Value ? Convert.ToDecimal(reader["PricePer"]) : (decimal?)null,
                            CommercialPackSize = reader["CommercialPackSize"] != DBNull.Value ? reader["CommercialPackSize"].ToString() : null,
                            MinPack = reader["MinPack"] != DBNull.Value ? reader["MinPack"].ToString() : null,
                            ProductionLeadTimeUnit = reader["ProductionLeadTimeUnit"] != DBNull.Value ? reader["ProductionLeadTimeUnit"].ToString() : null,
                            Notes = reader["Notes"] != DBNull.Value ? reader["Notes"].ToString() : null,
                            CatalogueNo = reader["CatalogueNo"] != DBNull.Value ? reader["CatalogueNo"].ToString() : null,
                            ComplianceWith = reader["ComplianceWith"] != DBNull.Value ? reader["ComplianceWith"].ToString() : null,
                            QualificationDocumentsOther = reader["QualificationDocumentsOther"] != DBNull.Value ? reader["QualificationDocumentsOther"].ToString() : null,
                            FATAtManufacturerSiteOther = reader["FATAtManufacturerSiteOther"] != DBNull.Value ? reader["FATAtManufacturerSiteOther"].ToString() : null,
                            SATScope = reader["SATScope"] != DBNull.Value ? reader["SATScope"].ToString() : null,
                            AssistanceAtSiteOther = reader["AssistanceAtSiteOther"] != DBNull.Value ? reader["AssistanceAtSiteOther"].ToString() : null,
                            UtilitiesRequirement = reader["UtilitiesRequirement"] != DBNull.Value ? reader["UtilitiesRequirement"].ToString() : null,
                            SafetyFeatures = reader["SafetyFeatures"] != DBNull.Value ? reader["SafetyFeatures"].ToString() : null,
                            EnergyEfficiencyFeatures = reader["EnergyEfficiencyFeatures"] != DBNull.Value ? reader["EnergyEfficiencyFeatures"].ToString() : null,
                            SparesServicing = reader["SparesServicing"] != DBNull.Value ? reader["SparesServicing"].ToString() : null,
                            ScopeConfirmation = reader["ScopeConfirmation"] != DBNull.Value ? reader["ScopeConfirmation"].ToString() : null,
                            ScopeDeviationRemarks = reader["ScopeDeviationRemarks"] != DBNull.Value ? reader["ScopeDeviationRemarks"].ToString() : null,
                            Erection = reader["Erection"] != DBNull.Value ? reader["Erection"].ToString() : null,
                            ErectionOther = reader["ErectionOther"] != DBNull.Value ? reader["ErectionOther"].ToString() : null,
                            Installation = reader["Installation"] != DBNull.Value ? reader["Installation"].ToString() : null,
                            InstallationOther = reader["InstallationOther"] != DBNull.Value ? reader["InstallationOther"].ToString() : null,
                            Testing = reader["Testing"] != DBNull.Value ? reader["Testing"].ToString() : null,
                            TestingOther = reader["TestingOther"] != DBNull.Value ? reader["TestingOther"].ToString() : null,
                            Commissioning = reader["Commissioning"] != DBNull.Value ? reader["Commissioning"].ToString() : null,
                            CommissioningOther = reader["CommissioningOther"] != DBNull.Value ? reader["CommissioningOther"].ToString() : null,
                            RegulatoryApprovalOther = reader["RegulatoryApprovalOther"] != DBNull.Value ? reader["RegulatoryApprovalOther"].ToString() : null,
                            ColumnSpecification = reader["ColumnSpecification"] != DBNull.Value ? reader["ColumnSpecification"].ToString() : null,
                            ModelVersion = reader["ModelVersion"] != DBNull.Value ? reader["ModelVersion"].ToString() : null,
                            CountryOrigin = reader["CountryOrigin"] != DBNull.Value ? reader["CountryOrigin"].ToString() : null,
                            YearOfManufacturing = reader["YearOfManufacturing"] != DBNull.Value ? reader["YearOfManufacturing"].ToString() : null,

                            ProductLifeCycleValue = reader["ProductLifeCycleValue"] != DBNull.Value
    ? Convert.ToInt32(reader["ProductLifeCycleValue"])
    : (int?)null,
                            ProductLifeCycleUnit = reader["ProductLifeCycleUnit"] != DBNull.Value ? reader["ProductLifeCycleUnit"].ToString() : null,
                            Capacity = reader["Capacity"] != DBNull.Value ? reader["Capacity"].ToString() : null,
                            CapacityExtendable = reader["CapacityExtendable"] != DBNull.Value ? reader["CapacityExtendable"].ToString() : null,
                            CapacityExtendableOther = reader["CapacityExtendableOther"] != DBNull.Value ? reader["CapacityExtendableOther"].ToString() : null,
                            Proposal = reader["Proposal"] != DBNull.Value ? reader["Proposal"].ToString() : null,
                            Techtype = reader["Techtype"] != DBNull.Value ? reader["Techtype"].ToString() : null,
                            SampleDocumentID = reader["SampleDocId"] != DBNull.Value ? reader["SampleDocId"].ToString() : null,
                            AllPharmacopeialReference = reader["AllPharmacopeialReference"] != DBNull.Value ? reader["AllPharmacopeialReference"].ToString() : null

                        }).ToList();

                    }
                }
            }
            return TechnicalQuotationList;
        }

        public Model.VendorSelectionModule.Server FetchServerDetailsData(string billReceiveID, out string errorNumber)
        {
            errorNumber = string.Empty;
            var ServerList = new Model.VendorSelectionModule.Server();

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_GetVendorMaterialDocStatus"))
            {
                db.AddInParameter(dbCommandWrapper, "@billReceiveID", SqlDbType.VarChar, billReceiveID);
                db.AddOutParameter(dbCommandWrapper, "@p_Error", DbType.Int32, 10);
                // Execute SP.

                var ds = db.ExecuteDataSet(dbCommandWrapper);

                if (!db.GetParameterValue(dbCommandWrapper, "@p_Error").IsNullOrZero())
                {
                    errorNumber = db.GetParameterValue(dbCommandWrapper, "@p_Error").PrefixErrorCode();
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        DataTable dt1 = new DataTable();
                        dt1 = ds.Tables[0];

                        ServerList = dt1.AsEnumerable().Select(reader => new Model.VendorSelectionModule.Server
                        {


                            ServerIP = reader.GetString("ServerIP"),
                            ServerPort = reader.GetString("FtpPort"),
                            FileServerURL = reader.GetString("FileServerURL"),
                            FtpUserName = reader.GetString("FtpUserName"),
                            FtpPassword = reader.GetString("FtpPassword"),
                            Extensions = reader.GetString("FileExtension")




                        }).FirstOrDefault();
                    }
                }
            }
            return ServerList;
        }

        public long SaveTechQuotwiseDetailsData(Model.VendorSelectionModule.TechnicalQuotation technicalQuotation, out string errorNumber)
        {

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            var i = 0;
            long ID = 0;
            errorNumber = string.Empty;


            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_UpdateTechnicalQuotation"))
            {

                // --- Identity / Meta ---
                db.AddInParameter(dbCommandWrapper, "@TechQuotationItemID", SqlDbType.VarChar, technicalQuotation.TechQuotationItemID);
                db.AddInParameter(dbCommandWrapper, "@rowIndex", SqlDbType.VarChar, technicalQuotation.rowIndex);
                db.AddInParameter(dbCommandWrapper, "@ItemName", SqlDbType.VarChar, technicalQuotation.ItemName);
                db.AddInParameter(dbCommandWrapper, "@MoleculeName", SqlDbType.VarChar, technicalQuotation.MoleculeName);
                db.AddInParameter(dbCommandWrapper, "@Manufacturer", SqlDbType.VarChar, technicalQuotation.Manufacturer);
                db.AddInParameter(dbCommandWrapper, "@ManufacturerPart", SqlDbType.VarChar, technicalQuotation.ManufacturerPart);
                db.AddInParameter(dbCommandWrapper, "@ManufactureAddress", SqlDbType.VarChar, technicalQuotation.ManufactureAddress);
                db.AddInParameter(dbCommandWrapper, "@ManufactureOrigin", SqlDbType.VarChar, technicalQuotation.ManufacturerOrigin);
                db.AddInParameter(dbCommandWrapper, "@Supplier", SqlDbType.VarChar, technicalQuotation.Supplier);
                db.AddInParameter(dbCommandWrapper, "@LocalPartner", SqlDbType.VarChar, technicalQuotation.LocalPartner);

                // --- Pricing ---
                db.AddInParameter(dbCommandWrapper, "@RDPrice", SqlDbType.Decimal, technicalQuotation.RDPrice);
                db.AddInParameter(dbCommandWrapper, "@CommercialPrice", SqlDbType.Decimal, technicalQuotation.CommercialPrice);
                db.AddInParameter(dbCommandWrapper, "@PricePer", SqlDbType.Decimal, technicalQuotation.PricePer);
                if (string.IsNullOrEmpty(technicalQuotation.PriceUnit.Item_Code))
                {
                    db.AddInParameter(dbCommandWrapper, "@PriceUnit", SqlDbType.VarChar, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommandWrapper, "@PriceUnit", SqlDbType.VarChar, technicalQuotation.PriceUnit.Item_Code);
                }

                if (string.IsNullOrEmpty(technicalQuotation.Currency.MasterDataID))
                {
                    db.AddInParameter(dbCommandWrapper, "@Currency", SqlDbType.VarChar, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommandWrapper, "@Currency", SqlDbType.VarChar, technicalQuotation.Currency.MasterDataID);
                }



                // --- Order / Shelf / Storage ---
                db.AddInParameter(dbCommandWrapper, "@MinOrderQty", SqlDbType.Int, technicalQuotation.MinOrderQty);
                db.AddInParameter(dbCommandWrapper, "@OrderQtyUnit", SqlDbType.VarChar, technicalQuotation.OrderQtyUnit);
                db.AddInParameter(dbCommandWrapper, "@CommercialPackSize", SqlDbType.VarChar, technicalQuotation.CommercialPackSize);
                db.AddInParameter(dbCommandWrapper, "@MinPack", SqlDbType.VarChar, technicalQuotation.MinPack);
                db.AddInParameter(dbCommandWrapper, "@ShelfLifeValue", SqlDbType.Int, technicalQuotation.ShelfLifeValue);
                db.AddInParameter(dbCommandWrapper, "@ShelfLifeUnit", SqlDbType.VarChar, technicalQuotation.ShelfLifeUnit);
                db.AddInParameter(dbCommandWrapper, "@StorageCondition", SqlDbType.VarChar, technicalQuotation.StorageCondition);

                // --- References / Notes ---
                db.AddInParameter(dbCommandWrapper, "@Reference", SqlDbType.VarChar, technicalQuotation.Reference);
                db.AddInParameter(dbCommandWrapper, "@Notes", SqlDbType.VarChar, technicalQuotation.Notes);
                db.AddInParameter(dbCommandWrapper, "@CASNo", SqlDbType.VarChar, technicalQuotation.CASNO);
                db.AddInParameter(dbCommandWrapper, "@CatalogueNo", SqlDbType.VarChar, technicalQuotation.CatalogueNo);

                // --- Production ---
                db.AddInParameter(dbCommandWrapper, "@ProdCapacity", SqlDbType.VarChar, technicalQuotation.ProdCapacity);
                db.AddInParameter(dbCommandWrapper, "@ProductionFrequency", SqlDbType.VarChar, technicalQuotation.ProductionFrequency);
                db.AddInParameter(dbCommandWrapper, "@ProductionLeadTimeValue", SqlDbType.Int, technicalQuotation.ProductionLeadTimeValue);
                db.AddInParameter(dbCommandWrapper, "@ProductionLeadTimeUnit", SqlDbType.VarChar, technicalQuotation.ProductionLeadTimeUnit);
                db.AddInParameter(dbCommandWrapper, "@RepresentativeSample", SqlDbType.VarChar, technicalQuotation.RepresentativeSample);
                db.AddInParameter(dbCommandWrapper, "@RepresentativeSamplePackSize", SqlDbType.VarChar, technicalQuotation.RepresentativeSamplePackSize);
                db.AddInParameter(dbCommandWrapper, "@RepresentativeSampleOther", SqlDbType.VarChar, technicalQuotation.RepresentativeSampleOther);

                // --- Compliance / Qualification ---
                db.AddInParameter(dbCommandWrapper, "@ComplianceWith", SqlDbType.VarChar, technicalQuotation.ComplianceWith);
                db.AddInParameter(dbCommandWrapper, "@QualificationDocuments", SqlDbType.VarChar, technicalQuotation.QualificationDocuments);
                db.AddInParameter(dbCommandWrapper, "@QualificationDocumentsOther", SqlDbType.VarChar, technicalQuotation.QualificationDocumentsOther);

                // --- FAT / SAT / Assistance ---
                db.AddInParameter(dbCommandWrapper, "@FATAtManufacturerSite", SqlDbType.VarChar, technicalQuotation.FATAtManufacturerSite);
                db.AddInParameter(dbCommandWrapper, "@FATAtManufacturerSiteOther", SqlDbType.VarChar, technicalQuotation.FATAtManufacturerSiteOther);
                db.AddInParameter(dbCommandWrapper, "@SATScope", SqlDbType.VarChar, technicalQuotation.SATScope);
                db.AddInParameter(dbCommandWrapper, "@AssistanceAtSite", SqlDbType.VarChar, technicalQuotation.AssistanceAtSite);
                db.AddInParameter(dbCommandWrapper, "@AssistanceAtSiteOther", SqlDbType.VarChar, technicalQuotation.AssistanceAtSiteOther);

                // --- Utilities / Safety ---
                db.AddInParameter(dbCommandWrapper, "@UtilitiesRequirement", SqlDbType.VarChar, technicalQuotation.UtilitiesRequirement);
                db.AddInParameter(dbCommandWrapper, "@SafetyFeatures", SqlDbType.VarChar, technicalQuotation.SafetyFeatures);
                db.AddInParameter(dbCommandWrapper, "@EnergyEfficiencyFeatures", SqlDbType.VarChar, technicalQuotation.EnergyEfficiencyFeatures);

                // --- Servicing / Scope ---
                db.AddInParameter(dbCommandWrapper, "@SparesServicing", SqlDbType.VarChar, technicalQuotation.SparesServicing);
                db.AddInParameter(dbCommandWrapper, "@ScopeConfirmation", SqlDbType.VarChar, technicalQuotation.ScopeConfirmation);
                db.AddInParameter(dbCommandWrapper, "@ScopeDeviationRemarks", SqlDbType.VarChar, technicalQuotation.ScopeDeviationRemarks);

                // --- Responsibility Matrix ---
                db.AddInParameter(dbCommandWrapper, "@Erection", SqlDbType.VarChar, technicalQuotation.Erection);
                db.AddInParameter(dbCommandWrapper, "@ErectionOther", SqlDbType.VarChar, technicalQuotation.ErectionOther);
                db.AddInParameter(dbCommandWrapper, "@Installation", SqlDbType.VarChar, technicalQuotation.Installation);
                db.AddInParameter(dbCommandWrapper, "@InstallationOther", SqlDbType.VarChar, technicalQuotation.InstallationOther);
                db.AddInParameter(dbCommandWrapper, "@Testing", SqlDbType.VarChar, technicalQuotation.Testing);
                db.AddInParameter(dbCommandWrapper, "@TestingOther", SqlDbType.VarChar, technicalQuotation.TestingOther);
                db.AddInParameter(dbCommandWrapper, "@Commissioning", SqlDbType.VarChar, technicalQuotation.Commissioning);
                db.AddInParameter(dbCommandWrapper, "@CommissioningOther", SqlDbType.VarChar, technicalQuotation.CommissioningOther);

                // --- Regulatory ---
                db.AddInParameter(dbCommandWrapper, "@RegulatoryApproval", SqlDbType.VarChar, technicalQuotation.RegulatoryApproval);
                db.AddInParameter(dbCommandWrapper, "@RegulatoryApprovalOther", SqlDbType.VarChar, technicalQuotation.RegulatoryApprovalOther);

                // --- Misc ---
                db.AddInParameter(dbCommandWrapper, "@ColumnSpecification", SqlDbType.VarChar, technicalQuotation.ColumnSpecification);

                // --- p===2 specific ---
                db.AddInParameter(dbCommandWrapper, "@ModelVersion", SqlDbType.VarChar, technicalQuotation.ModelVersion);
                db.AddInParameter(dbCommandWrapper, "@CountryOrigin", SqlDbType.VarChar, technicalQuotation.CountryOrigin);
                db.AddInParameter(dbCommandWrapper, "@YearOfManufacturing", SqlDbType.VarChar, technicalQuotation.YearOfManufacturing);
                db.AddInParameter(dbCommandWrapper, "@ProductLifeCycleValue", SqlDbType.Int, technicalQuotation.ProductLifeCycleValue);
                db.AddInParameter(dbCommandWrapper, "@ProductLifeCycleUnit", SqlDbType.VarChar, technicalQuotation.ProductLifeCycleUnit);
                db.AddInParameter(dbCommandWrapper, "@Capacity", SqlDbType.VarChar, technicalQuotation.Capacity);
                db.AddInParameter(dbCommandWrapper, "@CapacityExtendable", SqlDbType.VarChar, technicalQuotation.CapacityExtendable);
                db.AddInParameter(dbCommandWrapper, "@CapacityExtendableOther", SqlDbType.VarChar, technicalQuotation.CapacityExtendableOther);
                db.AddInParameter(dbCommandWrapper, "@Techtype", SqlDbType.VarChar, technicalQuotation.Techtype);
                db.AddInParameter(dbCommandWrapper, "@Proposal", SqlDbType.VarChar, technicalQuotation.Proposal);
                db.AddInParameter(dbCommandWrapper, "@AllPharmacopeialReference", SqlDbType.VarChar, technicalQuotation.AllPharmacopeialReference);
                db.AddInParameter(dbCommandWrapper, "@CurrentStatus", SqlDbType.VarChar, technicalQuotation.CurrentStatus);




                // Example of retrieving results if the stored procedure returns data



                DataSet ds = db.ExecuteDataSet(dbCommandWrapper);


                if (ds.Tables[0].Rows.Count > 0)
                {
                    var dt = ds.Tables[0];

                    var dr = dt.Rows[0];

                    ID = dr.GetInt64("ID");
                }
            }







            return ID;

        }

        public DSM_Documents GetMaterialDocStatus(out bool docStatus, string materialCode, string BiddingID, string VendorCode, out string errorNumber)
        {

            errorNumber = string.Empty;
            docStatus = true;
            var document = new DSM_Documents();

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_GetMaterialDocStatus"))
            {

                db.AddInParameter(dbCommandWrapper, "@MaterialCode", SqlDbType.NVarChar, materialCode);
                db.AddInParameter(dbCommandWrapper, "@BiddingId", SqlDbType.NVarChar, BiddingID);
                db.AddInParameter(dbCommandWrapper, "@VendorId", SqlDbType.NVarChar, VendorCode);
                db.AddOutParameter(dbCommandWrapper, "@p_Error", DbType.Int32, 10);
                // Execute SP.

                var ds = db.ExecuteDataSet(dbCommandWrapper);

                if (!db.GetParameterValue(dbCommandWrapper, "@p_Error").IsNullOrZero())
                {
                    errorNumber = db.GetParameterValue(dbCommandWrapper, "@p_Error").PrefixErrorCode();
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        DataTable dt1 = new DataTable();
                        dt1 = ds.Tables[0];

                        document = dt1.AsEnumerable().Select(reader => new DSM_Documents
                        {
                            DocumentID = reader.GetString("DocumentID"),
                            DocPropertyName = reader.GetString("DocPropertyName"),
                            FileServerURL = reader.GetString("FileServerURL"),
                            ServerIP = reader.GetString("ServerIP"),
                            FtpPort = reader.GetString("FtpPort"),
                            FtpUserName = reader.GetString("FtpUserName"),
                            FtpPassword = reader.GetString("FtpPassword"),
                            FileExtension = reader.GetString("FileExtension"),

                        }).FirstOrDefault();
                    }
                    else
                    {
                        docStatus = false;
                    }
                }
            }
            return document;
        }

        public string UpdateExtensionByDocIdData(string documentID, string extension, out string errorNumber)
        {

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            var i = 0;
            string ID = "";
            errorNumber = string.Empty;


            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_UpdateExtension"))
            {

                db.AddInParameter(dbCommandWrapper, "@BillReceiveID", SqlDbType.VarChar, documentID);
                db.AddInParameter(dbCommandWrapper, "@FileExtension", SqlDbType.VarChar, extension);











                // Example of retrieving results if the stored procedure returns data



                DataSet ds = db.ExecuteDataSet(dbCommandWrapper);


                if (ds.Tables[0].Rows.Count > 0)
                {
                    var dt = ds.Tables[0];

                    var dr = dt.Rows[0];

                    ID = dr.GetString("ID");
                }
            }







            return ID;
        }


        public List<Item> ItemlistData(out string errorNumber)
        {
            errorNumber = string.Empty;
            var itemList = new List<Item>();

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("GetAllItem"))
            {

                db.AddOutParameter(dbCommandWrapper, "@p_Error", DbType.Int32, 10);
                // Execute SP.

                var ds = db.ExecuteDataSet(dbCommandWrapper);

                if (!db.GetParameterValue(dbCommandWrapper, "@p_Error").IsNullOrZero())
                {
                    errorNumber = db.GetParameterValue(dbCommandWrapper, "@p_Error").PrefixErrorCode();
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        DataTable dt1 = new DataTable();
                        dt1 = ds.Tables[0];

                        itemList = dt1.AsEnumerable().Select(reader => new Item
                        {
                            Item_Code = reader.GetString("UoM_Code"),
                            Item_Name = reader.GetString("UoM_Text"),
                        }).ToList();
                    }
                }
            }
            return itemList;
        }

        public List<Sys_MasterData> GetAllItemTypes(string masterDataType, out string _errorNumber)
        {
            _errorNumber = string.Empty;
            var itemTypes = new List<Sys_MasterData>();

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("CBPS_GetAllItemTypes"))
            {
                db.AddInParameter(dbCommandWrapper, "@TypeName", SqlDbType.VarChar, masterDataType);
                db.AddOutParameter(dbCommandWrapper, spStatusParam, DbType.String, 10);

                var ds = db.ExecuteDataSet(dbCommandWrapper);

                if (!db.GetParameterValue(dbCommandWrapper, spStatusParam).IsNullOrZero())
                {
                    _errorNumber = db.GetParameterValue(dbCommandWrapper, spStatusParam).PrefixErrorCode();
                }
                else
                {
                    if (ds.Tables[0].Rows.Count <= 0) return itemTypes;
                    var dt1 = ds.Tables[0];
                    itemTypes = dt1.AsEnumerable().Select(reader => new Sys_MasterData
                    {
                        MasterDataID = reader.GetString("MasterDataID"),
                        MasterDataValue = reader.GetString("MasterDataValue"),
                        IsDefault = reader.GetString("IsDefault"),
                    }).ToList();
                }
            }
            return itemTypes;
        }

        public bool DeleteTechQuotwiseDetailsData(string techQuotationItemID, out string errorNumber)
        {
            errorNumber = string.Empty;
            bool isDeleted = false;

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;

            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_DeleteTechQuotMaterialDetail"))
            {
                // INPUT parameter (same pattern as above)
                db.AddInParameter(dbCommandWrapper, "@techQuotationItemID", SqlDbType.VarChar, techQuotationItemID);
                db.AddOutParameter(dbCommandWrapper, "@p_Error", DbType.Int32, 10);
                // Execute SP
                db.ExecuteNonQuery(dbCommandWrapper);

                if (!db.GetParameterValue(dbCommandWrapper, "@p_Error").IsNullOrZero())
                {
                    errorNumber = db
                        .GetParameterValue(dbCommandWrapper, "@p_Error")
                        .PrefixErrorCode();
                }
                else
                {
                    isDeleted = true;
                }
            }

            return isDeleted;
        }

    }
}
