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

                        InvMaterialList = dt1.AsEnumerable().Select(reader => new MaterialInvitation
                        {

                            materialName = reader.GetString("MaterialName"),
                            MaterialQuantity = reader.GetString("RFQQty"),
                            Unit = reader.GetString("RFQQtyUnit"),
                            //MatInvType = reader.GetString("MatInvType"),
                            materialCode = reader.GetString("MaterialCode"),
                            material_Category_Code = reader.GetString("MaterialCategory"),
                            invitationNumber = reader.GetString("InvitationNumber"),
                            InvitationID = reader.GetString("InvitationID"),
                            BiddingItemVendorID = reader.GetString("BiddingVendorID"),
                            VendorID = reader.GetString("VendorID"),
                            BiddingID = reader.GetString("BiddingID"),
                         
                            Action = "A",




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
                db.AddInParameter(dbCommandWrapper, "@materialCode", SqlDbType.NVarChar, _modelDocumentsInfo.materialCode);
                //db.AddInParameter(dbCommandWrapper, "@ConfColumnIds", SqlDbType.NVarChar, _modelDocumentsInfo.ConfigureColumnIds);
                db.AddInParameter(dbCommandWrapper, "@Status", SqlDbType.Int, 1);
                //db.AddInParameter(dbCommandWrapper, "@Doc_MetaType", SqlDbType.Structured, docMetaDataTable);
                //db.AddInParameter(dbCommandWrapper, "@Doc_PropertyType", SqlDbType.Structured, docPropertyIDDataTable);
                db.AddOutParameter(dbCommandWrapper, spStatusParam, SqlDbType.VarChar, 10);

                db.AddInParameter(dbCommandWrapper, "@InvitationID", SqlDbType.NVarChar, _modelDocumentsInfo.InvitationID);
                db.AddInParameter(dbCommandWrapper, "@BiddingItemVendorID", SqlDbType.NVarChar, _modelDocumentsInfo.BiddingItemVendorID);

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

        public List<Quotation> submitquotationData(string UserId,string invId, string biddingItemVendorID, string invitationNumber, out string errorNumber)
        {
            errorNumber = string.Empty;
            var QuotationList = new List<Quotation>();

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_SubmitQuotation"))
            {
                db.AddInParameter(dbCommandWrapper, "@invId", SqlDbType.VarChar, invId);
                db.AddInParameter(dbCommandWrapper, "@invitationNumber", SqlDbType.VarChar, invitationNumber);
                db.AddInParameter(dbCommandWrapper, "@biddingItemVendorID", SqlDbType.VarChar, biddingItemVendorID);
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
        public int submittechnicalquotationData(string UserId,List<Model.VendorSelectionModule.TechnicalQuotation> technicalQuotationlist, List<MaterialInvitation> materialInvitationlist, Quotation quotation, out string errorNumber)
        {




            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            var i = 0;
            int ID = 0;
            errorNumber = string.Empty;

            for (i = 0; i < technicalQuotationlist.Count; i++)
            {
                for (int j = 0; j < materialInvitationlist.Count; j++)
                {

                    if (technicalQuotationlist[i].rowIndex == materialInvitationlist[j].rowIndex)
                    {
                        using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_SubmitTechnicalQuotation"))
                        {



                            db.AddInParameter(dbCommandWrapper, "@MoleculeName", SqlDbType.VarChar, technicalQuotationlist[i].MoleculeName);
                            db.AddInParameter(dbCommandWrapper, "@SampleAvailable", SqlDbType.VarChar, technicalQuotationlist[i].SampleAvailable);
                            db.AddInParameter(dbCommandWrapper, "@OtherSample", SqlDbType.VarChar, technicalQuotationlist[i].OtherSample);
                            db.AddInParameter(dbCommandWrapper, "@CASNO", SqlDbType.VarChar, technicalQuotationlist[i].CASNO);
                            db.AddInParameter(dbCommandWrapper, "@RepresentativePackSize", SqlDbType.VarChar, technicalQuotationlist[i].RepresentativePackSize);
                            db.AddInParameter(dbCommandWrapper, "@Manufacturer", SqlDbType.VarChar, technicalQuotationlist[i].Manufacturer);
                            db.AddInParameter(dbCommandWrapper, "@Regulatory", SqlDbType.VarChar, technicalQuotationlist[i].Regulatory);
                            db.AddInParameter(dbCommandWrapper, "@Supplier", SqlDbType.VarChar, technicalQuotationlist[i].Supplier);
                            db.AddInParameter(dbCommandWrapper, "@CurrentStatus", SqlDbType.VarChar, technicalQuotationlist[i].CurrentStatus);
                            db.AddInParameter(dbCommandWrapper, "@ManufactureAddress", SqlDbType.VarChar, technicalQuotationlist[i].ManufactureAddress);
                            db.AddInParameter(dbCommandWrapper, "@ProdCapacity", SqlDbType.Int, technicalQuotationlist[i].ProdCapacity);
                            db.AddInParameter(dbCommandWrapper, "@RDPrice", SqlDbType.Decimal, technicalQuotationlist[i].RDPrice);
                            db.AddInParameter(dbCommandWrapper, "@Shelf", SqlDbType.Int, technicalQuotationlist[i].Shelf);
                            db.AddInParameter(dbCommandWrapper, "@CommercialPrice", SqlDbType.Decimal, technicalQuotationlist[i].CommercialPrice);
                            db.AddInParameter(dbCommandWrapper, "@Condition", SqlDbType.VarChar, technicalQuotationlist[i].Condition);
                            db.AddInParameter(dbCommandWrapper, "@OrderQty", SqlDbType.Int, technicalQuotationlist[i].OrderQty);
                            db.AddInParameter(dbCommandWrapper, "@Specification", SqlDbType.VarChar, technicalQuotationlist[i].Specification);
                            db.AddInParameter(dbCommandWrapper, "@OtherSpecification", SqlDbType.VarChar, technicalQuotationlist[i].OtherSpecification);
                            db.AddInParameter(dbCommandWrapper, "@CommercialConsignment", SqlDbType.Int, technicalQuotationlist[i].CommercialConsignment);
                            db.AddInParameter(dbCommandWrapper, "@AvailPackSize", SqlDbType.Int, technicalQuotationlist[i].AvailPackSize);
                            db.AddInParameter(dbCommandWrapper, "@MinPack", SqlDbType.Int, technicalQuotationlist[i].MinPack);
                            db.AddInParameter(dbCommandWrapper, "@Example", SqlDbType.VarChar, technicalQuotationlist[i].Example);

                            if (string.IsNullOrEmpty(technicalQuotationlist[i].Currency.MasterDataValue))
                            {
                                db.AddInParameter(dbCommandWrapper, "@Currency", SqlDbType.VarChar, DBNull.Value);
                            }
                            else
                            {
                                db.AddInParameter(dbCommandWrapper, "@Currency", SqlDbType.VarChar, technicalQuotationlist[i].Currency.MasterDataValue);
                            }


                            //db.AddInParameter(dbCommandWrapper, "@Currency", SqlDbType.VarChar, technicalQuotationlist[i].Currency.MasterDataValue);
                            db.AddInParameter(dbCommandWrapper, "@Reference", SqlDbType.VarChar, technicalQuotationlist[i].Reference);
                            db.AddInParameter(dbCommandWrapper, "@Validation", SqlDbType.VarChar, technicalQuotationlist[i].Validation);
                            db.AddInParameter(dbCommandWrapper, "@Training", SqlDbType.VarChar, technicalQuotationlist[i].Training);
                            db.AddInParameter(dbCommandWrapper, "@Prerequisite", SqlDbType.VarChar, technicalQuotationlist[i].Prerequisite);
                            db.AddInParameter(dbCommandWrapper, "@ManufacturerPart", SqlDbType.VarChar, technicalQuotationlist[i].ManufacturerPart);
                            db.AddInParameter(dbCommandWrapper, "@Installation", SqlDbType.VarChar, technicalQuotationlist[i].Installation);
                            //db.AddInParameter(dbCommandWrapper, "@Subcontractor", SqlDbType.Bit, technicalQuotationlist[i].Subcontractor);
                            db.AddInParameter(dbCommandWrapper, "@Subcontractor", SqlDbType.Bit, 1);
                            db.AddInParameter(dbCommandWrapper, "@ManufacturerOrigin", SqlDbType.VarChar, technicalQuotationlist[i].ManufacturerOrigin);
                            db.AddInParameter(dbCommandWrapper, "@Penalty", SqlDbType.VarChar, technicalQuotationlist[i].Penalty);
                            db.AddInParameter(dbCommandWrapper, "@Fat", SqlDbType.VarChar, technicalQuotationlist[i].Fat);
                            db.AddInParameter(dbCommandWrapper, "@Calibration", SqlDbType.VarChar, technicalQuotationlist[i].Calibration);
                            db.AddInParameter(dbCommandWrapper, "@Document", SqlDbType.VarChar, technicalQuotationlist[i].Alldocuments);

                            if (string.IsNullOrEmpty(technicalQuotationlist[i].RNDPriceCur.MasterDataValue))
                            {
                                db.AddInParameter(dbCommandWrapper, "@RNDPriceCur", SqlDbType.VarChar, DBNull.Value);
                            }
                            else
                            {
                                db.AddInParameter(dbCommandWrapper, "@RNDPriceCur", SqlDbType.VarChar, technicalQuotationlist[i].RNDPriceCur.MasterDataValue);
                            }
                            if (string.IsNullOrEmpty(technicalQuotationlist[i].ComPriceCur.MasterDataValue))
                            {
                                db.AddInParameter(dbCommandWrapper, "@ComPriceCur", SqlDbType.VarChar, DBNull.Value);
                            }
                            else
                            {
                                db.AddInParameter(dbCommandWrapper, "@ComPriceCur", SqlDbType.VarChar, technicalQuotationlist[i].ComPriceCur.MasterDataValue);
                            }



                            //db.AddInParameter(dbCommandWrapper, "@RNDPriceCur", SqlDbType.VarChar, technicalQuotationlist[i].RNDPriceCur);
                            //db.AddInParameter(dbCommandWrapper, "@ComPriceCur", SqlDbType.VarChar, technicalQuotationlist[i].ComPriceCur);
                            if (string.IsNullOrEmpty(technicalQuotationlist[i].OrderQtyUnit.Item_Code))
                            {
                                db.AddInParameter(dbCommandWrapper, "@OrderQtyUnit", SqlDbType.VarChar, DBNull.Value);
                            }
                            else
                            {
                                db.AddInParameter(dbCommandWrapper, "@OrderQtyUnit", SqlDbType.VarChar, technicalQuotationlist[i].OrderQtyUnit.Item_Code);
                            }
                            db.AddInParameter(dbCommandWrapper, "@LocalPartner", SqlDbType.VarChar, technicalQuotationlist[i].LocalPartner);
                            db.AddInParameter(dbCommandWrapper, "@ShelfLifeUnit", SqlDbType.VarChar, technicalQuotationlist[i].ShelfUnit);
                            db.AddInParameter(dbCommandWrapper, "@APIRegApproval", SqlDbType.VarChar, technicalQuotationlist[i].APIRegApproval);


                          



                            db.AddInParameter(dbCommandWrapper, "@MaterialQuantity", SqlDbType.VarChar, materialInvitationlist[j].MaterialQuantity);
                            db.AddInParameter(dbCommandWrapper, "@MatUnit", SqlDbType.VarChar, materialInvitationlist[j].Unit);
                            db.AddInParameter(dbCommandWrapper, "@MatInvType", SqlDbType.VarChar, materialInvitationlist[j].MatInvType);
                            db.AddInParameter(dbCommandWrapper, "@invitationNumber", SqlDbType.VarChar, materialInvitationlist[j].invitationNumber);
                            db.AddInParameter(dbCommandWrapper, "@departmentId", SqlDbType.Int, materialInvitationlist[j].departmentId);
                            db.AddInParameter(dbCommandWrapper, "@matCategory", SqlDbType.VarChar, materialInvitationlist[j].matCategory);
                            db.AddInParameter(dbCommandWrapper, "@itemNo", SqlDbType.Int, materialInvitationlist[j].itemNo);
                            db.AddInParameter(dbCommandWrapper, "@materialCode", SqlDbType.VarChar, materialInvitationlist[j].materialCode);
                            db.AddInParameter(dbCommandWrapper, "@materialName", SqlDbType.VarChar, materialInvitationlist[j].materialName);
                            db.AddInParameter(dbCommandWrapper, "@remarks", SqlDbType.VarChar, materialInvitationlist[j].remarks);
                            db.AddInParameter(dbCommandWrapper, "@sampleDocId", SqlDbType.VarChar, materialInvitationlist[j].sampleDocId);
                            db.AddInParameter(dbCommandWrapper, "@BiddingItemVendorID", SqlDbType.VarChar, materialInvitationlist[j].VendorID);
                            db.AddInParameter(dbCommandWrapper, "@proposalType", SqlDbType.VarChar, materialInvitationlist[j].proposalType);
                            db.AddInParameter(dbCommandWrapper, "@sharedToFactory", SqlDbType.Bit, materialInvitationlist[j].sharedToFactory);
                            db.AddInParameter(dbCommandWrapper, "@askFinanQoutations", SqlDbType.Bit, materialInvitationlist[j].askFinanQoutations);
                            db.AddInParameter(dbCommandWrapper, "@modificationType", SqlDbType.VarChar, materialInvitationlist[j].modificationType);
                            db.AddInParameter(dbCommandWrapper, "@setOn", SqlDbType.DateTime, materialInvitationlist[j].setOn);
                            db.AddInParameter(dbCommandWrapper, "@setBy", SqlDbType.VarChar, UserId);
                            db.AddInParameter(dbCommandWrapper, "@modifiedOn", SqlDbType.DateTime, materialInvitationlist[j].modifiedOn);
                            db.AddInParameter(dbCommandWrapper, "@modifiedBy", SqlDbType.VarChar, UserId);
                            //db.AddInParameter(dbCommandWrapper, "@status", SqlDbType.VarChar, materialInvitationlist[j].status);
                            db.AddInParameter(dbCommandWrapper, "@status", SqlDbType.VarChar, '1');
                            db.AddInParameter(dbCommandWrapper, "@SampleDocumentID", SqlDbType.VarChar, materialInvitationlist[j].SampleDocumentID);
                            db.AddInParameter(dbCommandWrapper, "@material_Category_Code", SqlDbType.VarChar, materialInvitationlist[j].material_Category_Code);
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



                    }
                }

            }
            return ID;













        }

        public List<Quotation> GetAllQuotationData(string userid,out string errorNumber)
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
                            MatInvType = reader.GetString("MatInvType"),
                            materialCode = reader.GetString("MaterialCode"),
                            material_Category_Code = reader.GetString("MatCategory"),
                            invitationNumber = reader.GetString("InvitationNumber"),
                            InvitationID = reader.GetString("InvitationID"),
                            VendorID = reader.GetString("VendorID"),
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
                            MoleculeName = reader["MoleculeName"] != DBNull.Value ? reader["MoleculeName"].ToString() : null,
                            SampleAvailable = reader["RepSample"] != DBNull.Value ? reader["RepSample"].ToString() : null,
                            OtherSample = reader["AssistanceAtSite"] != DBNull.Value ? reader["AssistanceAtSite"].ToString() : null,
                            CASNO = reader["CASNo"] != DBNull.Value ? reader["CASNo"].ToString() : null,
                            RepresentativePackSize = reader["RepSamplePackSize"] != DBNull.Value ? reader["RepSamplePackSize"].ToString() : null,
                            Manufacturer = reader["ManufactureName"] != DBNull.Value ? reader["ManufactureName"].ToString() : null,
                            Regulatory = reader["ProdRegularity"] != DBNull.Value ? reader["ProdRegularity"].ToString() : null,
                            Supplier = reader["SupplierName"] != DBNull.Value ? reader["SupplierName"].ToString() : null,
                            CurrentStatus = reader["CurApiStatus"] != DBNull.Value ? reader["CurApiStatus"].ToString() : null,
                            ManufactureAddress = reader["ManufacSiteAdd"] != DBNull.Value ? reader["ManufacSiteAdd"].ToString() : null,
                            ProdCapacity = reader["ProdCapacity"] != DBNull.Value ? Convert.ToInt32(reader["ProdCapacity"]) : 0,
                            RDPrice = reader["RNDPriceOffer"] != DBNull.Value ? Convert.ToDecimal(reader["RNDPriceOffer"]) : 0,
                            Shelf = reader["ShelfLife"] != DBNull.Value ? Convert.ToInt32(reader["ShelfLife"]) : 0,
                            CommercialPrice = reader["CommercialPrice"] != DBNull.Value ? Convert.ToDecimal(reader["CommercialPrice"]) : 0,
                            Condition = reader["StorageCondition"] != DBNull.Value ? reader["StorageCondition"].ToString() : null,
                            OrderQty = reader["MiniOrderQty"] != DBNull.Value ? Convert.ToInt32(reader["MiniOrderQty"]) : 0,
                           /* OrderUnit = reader["OrderQtyUnit"] != DBNull.Value  ? reader["OrderQtyUnit"].ToString() : null,*/
                            Specification = reader["SpecComplies"] != DBNull.Value ? reader["SpecComplies"].ToString() : null,

                            CommercialConsignment = reader["LeadTimeForCC"] != DBNull.Value ? Convert.ToInt32(reader["LeadTimeForCC"]) : 0,
                            AvailPackSize = reader["AvailComPackSize"] != DBNull.Value ? Convert.ToInt32(reader["AvailComPackSize"]) : 0,
                            MinPack = reader["MiniPackSize"] != DBNull.Value ? Convert.ToInt32(reader["MiniPackSize"]) : 0,
                            Example = reader["Refference"] != DBNull.Value ? reader["Refference"].ToString() : null,
                            Alldocuments = reader["QualificationDoc"] != DBNull.Value ? reader["QualificationDoc"].ToString() : null,
                            Installation = reader["InstallTestCom"] != DBNull.Value ? reader["InstallTestCom"].ToString() : null,
                            ShelfUnit = reader["ShelfLifeUnit"] != DBNull.Value ? reader["ShelfLifeUnit"].ToString() : null,
                            Calibration = reader["Calibration"] != DBNull.Value ? reader["Calibration"].ToString() : null,
                            ComPriceCur = reader["ComPriceCur"] != DBNull.Value ? new Currency { MasterDataValue = reader["ComPriceCur"].ToString() } : new Currency { MasterDataValue = null },
                            //OrderQtyUnit = reader["OrderQtyUnit"] != DBNull.Value ? new Item { Item_Code = reader["OrderQtyUnit"].ToString() } : null,
                            OrderQtyUnit = reader["OrderQtyUnit"] != DBNull.Value ? new Item { Item_Code = reader["OrderQtyUnit"].ToString() }: new Item { Item_Code = null },
                            Currency = reader["Currency"] != DBNull.Value ? new Currency { MasterDataValue = reader["Currency"].ToString() }: new Currency { MasterDataValue = null },
                            RNDPriceCur = reader["RNDPriceCur"] != DBNull.Value ? new Currency { MasterDataValue = reader["RNDPriceCur"].ToString() } : new Currency { MasterDataValue = null },
                            

                            APIRegApproval= reader["APIRegApproval"] != DBNull.Value ? reader["APIRegApproval"].ToString() : null





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

                db.AddInParameter(dbCommandWrapper, "@TechQuotationItemID", SqlDbType.VarChar, technicalQuotation.TechQuotationItemID);
                db.AddInParameter(dbCommandWrapper, "@MoleculeName", SqlDbType.VarChar, technicalQuotation.MoleculeName);
                db.AddInParameter(dbCommandWrapper, "@SampleAvailable", SqlDbType.VarChar, technicalQuotation.SampleAvailable);
                db.AddInParameter(dbCommandWrapper, "@OtherSample", SqlDbType.VarChar, technicalQuotation.OtherSample);
                db.AddInParameter(dbCommandWrapper, "@CASNO", SqlDbType.VarChar, technicalQuotation.CASNO);
                db.AddInParameter(dbCommandWrapper, "@RepresentativePackSize", SqlDbType.VarChar, technicalQuotation.RepresentativePackSize);
                db.AddInParameter(dbCommandWrapper, "@Manufacturer", SqlDbType.VarChar, technicalQuotation.Manufacturer);
                db.AddInParameter(dbCommandWrapper, "@Regulatory", SqlDbType.VarChar, technicalQuotation.Regulatory);
                db.AddInParameter(dbCommandWrapper, "@Supplier", SqlDbType.VarChar, technicalQuotation.Supplier);
                db.AddInParameter(dbCommandWrapper, "@CurrentStatus", SqlDbType.VarChar, technicalQuotation.CurrentStatus);
                db.AddInParameter(dbCommandWrapper, "@ManufactureAddress", SqlDbType.VarChar, technicalQuotation.ManufactureAddress);
                db.AddInParameter(dbCommandWrapper, "@ProdCapacity", SqlDbType.Int, technicalQuotation.ProdCapacity);
                db.AddInParameter(dbCommandWrapper, "@RDPrice", SqlDbType.Decimal, technicalQuotation.RDPrice);
                db.AddInParameter(dbCommandWrapper, "@Shelf", SqlDbType.Int, technicalQuotation.Shelf);
                db.AddInParameter(dbCommandWrapper, "@CommercialPrice", SqlDbType.Decimal, technicalQuotation.CommercialPrice);
                db.AddInParameter(dbCommandWrapper, "@Condition", SqlDbType.VarChar, technicalQuotation.Condition);
                db.AddInParameter(dbCommandWrapper, "@OrderQty", SqlDbType.Int, technicalQuotation.OrderQty);
                db.AddInParameter(dbCommandWrapper, "@Specification", SqlDbType.VarChar, technicalQuotation.Specification);
                db.AddInParameter(dbCommandWrapper, "@OtherSpecification", SqlDbType.VarChar, technicalQuotation.OtherSpecification);
                db.AddInParameter(dbCommandWrapper, "@CommercialConsignment", SqlDbType.Int, technicalQuotation.CommercialConsignment);
                db.AddInParameter(dbCommandWrapper, "@AvailPackSize", SqlDbType.Int, technicalQuotation.AvailPackSize);
                db.AddInParameter(dbCommandWrapper, "@MinPack", SqlDbType.Int, technicalQuotation.MinPack);
                db.AddInParameter(dbCommandWrapper, "@Example", SqlDbType.VarChar, technicalQuotation.Example);
                if (string.IsNullOrEmpty(technicalQuotation.Currency.MasterDataValue))
                {
                    db.AddInParameter(dbCommandWrapper, "@Currency", SqlDbType.VarChar, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommandWrapper, "@Currency", SqlDbType.VarChar, technicalQuotation.Currency.MasterDataValue);
                }

                //db.AddInParameter(dbCommandWrapper, "@Currency", SqlDbType.VarChar, technicalQuotation.Currency);
                db.AddInParameter(dbCommandWrapper, "@Reference", SqlDbType.VarChar, technicalQuotation.Reference);
                db.AddInParameter(dbCommandWrapper, "@Validation", SqlDbType.VarChar, technicalQuotation.Validation);
                db.AddInParameter(dbCommandWrapper, "@Training", SqlDbType.VarChar, technicalQuotation.Training);
                db.AddInParameter(dbCommandWrapper, "@Prerequisite", SqlDbType.VarChar, technicalQuotation.Prerequisite);
                db.AddInParameter(dbCommandWrapper, "@ManufacturerPart", SqlDbType.VarChar, technicalQuotation.ManufacturerPart);
                db.AddInParameter(dbCommandWrapper, "@Installation", SqlDbType.VarChar, technicalQuotation.Installation);
                db.AddInParameter(dbCommandWrapper, "@Subcontractor", SqlDbType.VarChar, technicalQuotation.Subcontractor);
                db.AddInParameter(dbCommandWrapper, "@ManufacturerOrigin", SqlDbType.VarChar, technicalQuotation.ManufacturerOrigin);
                db.AddInParameter(dbCommandWrapper, "@Penalty", SqlDbType.VarChar, technicalQuotation.Penalty);
                db.AddInParameter(dbCommandWrapper, "@Fat", SqlDbType.VarChar, technicalQuotation.Fat);
                db.AddInParameter(dbCommandWrapper, "@Calibration", SqlDbType.VarChar, technicalQuotation.Calibration);
                db.AddInParameter(dbCommandWrapper, "@Document", SqlDbType.VarChar, technicalQuotation.Alldocuments);
                if (string.IsNullOrEmpty(technicalQuotation.RNDPriceCur.MasterDataValue))
                {
                    db.AddInParameter(dbCommandWrapper, "@RNDPriceCur", SqlDbType.VarChar, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommandWrapper, "@RNDPriceCur", SqlDbType.VarChar, technicalQuotation.RNDPriceCur.MasterDataValue);
                }

                if (string.IsNullOrEmpty(technicalQuotation.ComPriceCur.MasterDataValue))
                {
                    db.AddInParameter(dbCommandWrapper, "@ComPriceCur", SqlDbType.VarChar, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommandWrapper, "@ComPriceCur", SqlDbType.VarChar, technicalQuotation.ComPriceCur.MasterDataValue);
                }
                //db.AddInParameter(dbCommandWrapper, "@RNDPriceCur", SqlDbType.VarChar, technicalQuotation.RNDPriceCur);
                //db.AddInParameter(dbCommandWrapper, "@ComPriceCur", SqlDbType.VarChar, technicalQuotation.ComPriceCur);

                if (string.IsNullOrEmpty(technicalQuotation.OrderQtyUnit.Item_Code))
                {
                    db.AddInParameter(dbCommandWrapper, "@OrderQtyUnit", SqlDbType.VarChar, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommandWrapper, "@OrderQtyUnit", SqlDbType.VarChar, technicalQuotation.OrderQtyUnit.Item_Code);
                }
                db.AddInParameter(dbCommandWrapper, "@LocalPartner", SqlDbType.VarChar, technicalQuotation.LocalPartner);
                db.AddInParameter(dbCommandWrapper, "@ShelfLifeUnit", SqlDbType.VarChar, technicalQuotation.ShelfUnit);
                db.AddInParameter(dbCommandWrapper, "@APIRegApproval", SqlDbType.VarChar, technicalQuotation.APIRegApproval);










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






    }
}
