using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SILDMS.Model.CBPSModule;
using SILDMS.Model.DocScanningModule;
using SILDMS.Model.VendorSelectionModule;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;

namespace SILDMS.DataAccess.FinancialQuotation
{
    public class FinancialQuotationData : IFinancialQuotationData
    {
        private readonly string spStatusParam = "@p_Status";
        public List<Invitation> GetAllInvitationData(string userid, out string errorNumber)
        {
            errorNumber = string.Empty;
            var invitationList = new List<Invitation>();

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_InvitationForFinancialQuotation"))
            {
                db.AddInParameter(dbCommandWrapper, "@UserId", SqlDbType.VarChar,  userid);
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
                            ProposalType = reader.GetString("PropasalType"),

                        }).ToList();
                    }
                }
            }
            return invitationList;
        }

        public List<MaterialInvitation> InvWiseMaterialData(string UserID, string invNumber,string ProposalType, out string errorNumber)
        {
            errorNumber = string.Empty;
            var InvMaterialList = new List<MaterialInvitation>();

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_InvMaterialForFinancialQuotation"))
            {
                db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.VarChar, UserID);
                db.AddInParameter(dbCommandWrapper, "@InvNumber", SqlDbType.VarChar, invNumber);
                db.AddInParameter(dbCommandWrapper, "@ProposalType", SqlDbType.VarChar, ProposalType);
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
                            MaterialQuantity = reader.GetString("RequestQty"),
                            Unit = reader.GetString("Unit"),
                            MatInvType = reader.GetString("MatInvType"),
                            materialCode = reader.GetString("MaterialCode"),
                            material_Category_Code = reader.GetString("MaterialCategory"),
                            invitationNumber = reader.GetString("InvitationNumber"),
                            InvitationID = reader.GetString("InvitationID"),
                            BiddingItemVendorID = reader.GetString("BiddingVendorID"),
                            VendorID = reader.GetString("VendorID"),
                            BiddingID = reader.GetString("BiddingID"),
                            //QuotationID = dt1.Columns.Contains("QuotationID") && !reader.IsNull("QuotationID") ? reader.Field<Int64>("QuotationID") : 0,
                            QuotationID = dt1.Columns.Contains("QuotationID") && !reader.IsNull("QuotationID") ? Convert.ToInt64(reader["QuotationID"]): 0,


                            QuotationNo = dt1.Columns.Contains("QuotationNo") && !reader.IsNull("QuotationNo") ? reader.Field<string>("QuotationNo") : null,
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

            using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("VCMS_Test2"))
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

        public List<Quotation> submitquotationData(string invId, string biddingItemVendorID, string invitationNumber, out string errorNumber)
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
        public int submitfinancialquotationData(string userid,List<FinancialQuotationDetail> financialQuotationList, List<MaterialInvitation> materialInvitationlist,string ProposalType, Quotation quotation, out string errorNumber)
        {




            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            var i = 0;
            int ID = 0;
      
            errorNumber = string.Empty;

            for (i = 0; i < financialQuotationList.Count; i++)
            {
                for (int j = 0; j < materialInvitationlist.Count; j++)
                {

                    if (financialQuotationList[i].rowIndex == materialInvitationlist[j].rowIndex)
                    {
                        using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_SubmitFinancialQuotation"))
                        {


                             db.AddInParameter(dbCommandWrapper, "@ProposeQty", SqlDbType.Decimal, financialQuotationList[i].ProposeQty);
                            if (string.IsNullOrEmpty(financialQuotationList[i].Unit.Item_Code))
                            {
                                db.AddInParameter(dbCommandWrapper, "@Unit", SqlDbType.VarChar, DBNull.Value);
                            }
                            else
                            {
                                db.AddInParameter(dbCommandWrapper, "@Unit", SqlDbType.VarChar, financialQuotationList[i].Unit.Item_Code);
                            }

                          
                            db.AddInParameter(dbCommandWrapper, "@UnitPrice", SqlDbType.Decimal, financialQuotationList[i].UnitPrice);

                            if (string.IsNullOrEmpty(financialQuotationList[i].Currency.MasterDataValue))
                            {
                                db.AddInParameter(dbCommandWrapper, "@Currency", SqlDbType.VarChar, DBNull.Value);
                            }
                            else
                            {
                                db.AddInParameter(dbCommandWrapper, "@Currency", SqlDbType.VarChar, financialQuotationList[i].Currency.MasterDataValue);
                            }

                            //db.AddInParameter(dbCommandWrapper, "@Currency", SqlDbType.VarChar, financialQuotationList[i].Currency.MasterDataValue);
                            db.AddInParameter(dbCommandWrapper, "@TotalPrice", SqlDbType.Decimal, financialQuotationList[i].TotalPrice);
                            db.AddInParameter(dbCommandWrapper, "@VatAmount", SqlDbType.Decimal, financialQuotationList[i].VatAmount);
                            db.AddInParameter(dbCommandWrapper, "@TaxAmount", SqlDbType.Decimal, financialQuotationList[i].TaxAmount);
                            db.AddInParameter(dbCommandWrapper, "@GrossPrice", SqlDbType.Decimal, financialQuotationList[i].GrossPrice);
                            db.AddInParameter(dbCommandWrapper, "@DiscountPrice", SqlDbType.Decimal, financialQuotationList[i].DiscountPrice);
                            db.AddInParameter(dbCommandWrapper, "@NetPrice", SqlDbType.Decimal, financialQuotationList[i].NetPrice);
                            db.AddInParameter(dbCommandWrapper, "@QuotValidDate", SqlDbType.DateTime, financialQuotationList[i].QuotValidDate);
                            db.AddInParameter(dbCommandWrapper, "@ExpecDeliDate", SqlDbType.DateTime, financialQuotationList[i].ExpecDeliDate);
                            //db.AddInParameter(dbCommandWrapper, "@ProposalType", SqlDbType.VarChar, financialQuotationList[i].ProposalType);




                            db.AddInParameter(dbCommandWrapper, "@invitationNumber", SqlDbType.VarChar, materialInvitationlist[j].invitationNumber);

                            //db.AddInParameter(dbCommandWrapper, "@itemNo", SqlDbType.Int, materialInvitationlist[j].itemNo);
                            db.AddInParameter(dbCommandWrapper, "@materialCode", SqlDbType.VarChar, materialInvitationlist[j].materialCode);
                            db.AddInParameter(dbCommandWrapper, "@materialName", SqlDbType.VarChar, materialInvitationlist[j].materialName);
                            db.AddInParameter(dbCommandWrapper, "@remarks", SqlDbType.VarChar, materialInvitationlist[j].remarks);
                            db.AddInParameter(dbCommandWrapper, "@sampleDocId", SqlDbType.VarChar, materialInvitationlist[j].SampleDocumentID);
                            db.AddInParameter(dbCommandWrapper, "@BiddingItemVendorID", SqlDbType.VarChar, materialInvitationlist[j].VendorID);
                            //db.AddInParameter(dbCommandWrapper, "@proposalType", SqlDbType.VarChar, materialInvitationlist[j].proposalType);
                           db.AddInParameter(dbCommandWrapper, "@modificationType", SqlDbType.VarChar, materialInvitationlist[j].modificationType);
                            db.AddInParameter(dbCommandWrapper, "@setOn", SqlDbType.DateTime, materialInvitationlist[j].setOn);
                            db.AddInParameter(dbCommandWrapper, "@setBy", SqlDbType.VarChar, userid);
                            db.AddInParameter(dbCommandWrapper, "@modifiedOn", SqlDbType.DateTime, materialInvitationlist[j].modifiedOn);
                            db.AddInParameter(dbCommandWrapper, "@modifiedBy", SqlDbType.VarChar, userid);
                            //db.AddInParameter(dbCommandWrapper, "@status", SqlDbType.VarChar, materialInvitationlist[j].status);
                            db.AddInParameter(dbCommandWrapper, "@status", SqlDbType.VarChar, '1');
                            db.AddInParameter(dbCommandWrapper, "@RequstedQty", SqlDbType.Decimal, Convert.ToDecimal(materialInvitationlist[j].MaterialQuantity));
                            db.AddInParameter(dbCommandWrapper, "@material_Category_Code", SqlDbType.VarChar, materialInvitationlist[j].material_Category_Code);

                            if (ProposalType == "F")
                            {
                                db.AddInParameter(dbCommandWrapper, "@quotationID", SqlDbType.VarChar,quotation.quotationID );
                                db.AddInParameter(dbCommandWrapper, "@quotationNo", SqlDbType.VarChar, quotation.quotationNo);
                            }
                            else
                            {
                                db.AddInParameter(dbCommandWrapper, "@quotationID", SqlDbType.VarChar, materialInvitationlist[j].QuotationID);
                                db.AddInParameter(dbCommandWrapper, "@quotationNo", SqlDbType.VarChar, materialInvitationlist[j].QuotationNo);
                            }
                            db.AddInParameter(dbCommandWrapper, "@proposalType", SqlDbType.VarChar, ProposalType);










                            // Example of retrieving results if the stored procedure returns data



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

        public List<Quotation> GetAllQuotationData(string userid, out string errorNumber)
        {
            errorNumber = string.Empty;
            var QuotationList = new List<Quotation>();

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_GetAllFinancialQuotation"))
            {
                db.AddInParameter(dbCommandWrapper, "@userid", SqlDbType.VarChar, userid);

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

        public List<MaterialInvitation> QuotWiseMaterialData(string UserId, string quotationNo, out string errorNumber)
        {
            errorNumber = string.Empty;
            var QuotMaterialList = new List<MaterialInvitation>();

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_QuoteFinancialQuotation"))
            {
                db.AddInParameter(dbCommandWrapper, "@quotationNo", SqlDbType.VarChar, quotationNo);
                db.AddInParameter(dbCommandWrapper, "@userid", SqlDbType.VarChar, UserId);
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

                            FinanQuotationItemID = reader.GetString("FinanQuotationItemID"),
                            materialName = reader.GetString("MaterialName"),
                            MaterialQuantity = reader.GetString("RequestQty"),
                            Unit = reader.GetString("Unit"),
                            MatInvType = reader.GetString("MatInvType"),
                            materialCode = reader.GetString("MaterialCode"),
                            //material_Category_Code = reader.GetString("MatCategory"),
                            invitationNumber = reader.GetString("InvitationNumber"),
                            InvitationID = reader.GetString("InvitationID"),
                            BiddingItemVendorID = reader.GetString("BiddingVendorID"),
                            VendorID = reader.GetString("VendorID"),
                            BiddingID = reader.GetString("BiddingID"),
                          
                            SampleDocumentID = reader.GetString("SampleDocId"),
                            Action = "E",




                        }).ToList();
                    }
                }
            }
            return QuotMaterialList;
        }

        public List<FinancialQuotationDetail> FinQuotwiseDetailsData(string finQuotationItemID, out string errorNumber)
        {
            errorNumber = string.Empty;
            var FinancialQuotationDetailList = new List<FinancialQuotationDetail>();

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_FinQuotMaterialDetail"))
            {
                db.AddInParameter(dbCommandWrapper, "@finQuotationItemID", SqlDbType.VarChar, finQuotationItemID);
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

                        FinancialQuotationDetailList = dt1.AsEnumerable().Select(reader => new FinancialQuotationDetail
                        {

                            FinanQuotationItemID = reader["FinanQuotationItemID"] != DBNull.Value ? reader["FinanQuotationItemID"].ToString() : null,
                            ProposeQty = reader["ProposeQty"] != DBNull.Value ? Convert.ToDouble(reader["ProposeQty"]) : 0.0,
                        
                            Unit = reader["Unit"] != DBNull.Value ? new Item { Item_Code = reader["Unit"].ToString() } : new Item { Item_Code = null },

                            UnitPrice = reader["UnitPrice"] != DBNull.Value ? Convert.ToDouble(reader["UnitPrice"]) : 0.0,
                            Currency = reader["Currency"] != DBNull.Value ? new Currency { MasterDataValue = reader["Currency"].ToString() } : new Currency { MasterDataValue = null },
                            TotalPrice = reader["TotalPrice"] != DBNull.Value ? Convert.ToDouble(reader["TotalPrice"]) : 0.0,
                            VatAmount = reader["VatAmount"] != DBNull.Value ? Convert.ToDouble(reader["VatAmount"]) : 0.0,
                            TaxAmount = reader["TaxAmount"] != DBNull.Value ? Convert.ToDouble(reader["TaxAmount"]) : 0.0,
                            GrossPrice = reader["GrossPrice"] != DBNull.Value ? Convert.ToDouble(reader["GrossPrice"]) : 0.0,
                            DiscountPrice = reader["DiscountPrice"] != DBNull.Value ? Convert.ToDouble(reader["DiscountPrice"]) : 0.0,
                            NetPrice = reader["NetPrice"] != DBNull.Value ? Convert.ToDouble(reader["NetPrice"]) : 0.0,
                            QuotValidDate = reader["QuotValidDate"] != DBNull.Value ? Convert.ToDateTime(reader["QuotValidDate"]) : DateTime.MinValue,
                            ExpecDeliDate = reader["ExpecDeliDate"] != DBNull.Value ? Convert.ToDateTime(reader["ExpecDeliDate"]) : DateTime.MinValue,
                            QuotValidDateString = reader.GetDateTime("QuotValidDate").ToString("dd/MM/yyyy"),
                            ExpecDeliDateString = reader.GetDateTime("ExpecDeliDate").ToString("dd/MM/yyyy"),
                            ProposalType = reader["ProposalType"] != DBNull.Value ? reader["ProposalType"].ToString() : null



                        }).ToList();
                    }
                }
            }
            return FinancialQuotationDetailList;
        }

        public Model.VendorSelectionModule.Server FetchServerDetailsData(string billReceiveID, out string errorNumber)
        {
            errorNumber = string.Empty;
            var ServerList = new Model.VendorSelectionModule.Server();

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_GetVendorMaterialDocStatusFinancial"))
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

        public long SaveFinQuotwiseDetailsData(FinancialQuotationDetail financialQuotation, out string errorNumber)
        {

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            var i = 0;
            long ID = 0;
            errorNumber = string.Empty;


            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_UpdateFinancialQuotation"))
            {



                db.AddInParameter(dbCommandWrapper, "@FinanQuotationItemID", SqlDbType.Decimal, financialQuotation.FinanQuotationItemID);
                db.AddInParameter(dbCommandWrapper, "@ProposeQty", SqlDbType.Decimal, financialQuotation.ProposeQty);
                if (string.IsNullOrEmpty(financialQuotation.Unit.Item_Code))
                {
                    db.AddInParameter(dbCommandWrapper, "@Unit", SqlDbType.VarChar, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommandWrapper, "@Unit", SqlDbType.VarChar, financialQuotation.Unit.Item_Code);
                }


                db.AddInParameter(dbCommandWrapper, "@UnitPrice", SqlDbType.Decimal, financialQuotation.UnitPrice);

                if (string.IsNullOrEmpty(financialQuotation.Currency.MasterDataValue))
                {
                    db.AddInParameter(dbCommandWrapper, "@Currency", SqlDbType.VarChar, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommandWrapper, "@Currency", SqlDbType.VarChar, financialQuotation.Currency.MasterDataValue);
                }
                //db.AddInParameter(dbCommandWrapper, "@Unit", SqlDbType.VarChar, financialQuotation.Unit.Item_Code);
                //db.AddInParameter(dbCommandWrapper, "@UnitPrice", SqlDbType.Decimal, financialQuotation.UnitPrice);
                //db.AddInParameter(dbCommandWrapper, "@Currency", SqlDbType.VarChar, financialQuotation.Currency);
                db.AddInParameter(dbCommandWrapper, "@TotalPrice", SqlDbType.Decimal, financialQuotation.TotalPrice);
                db.AddInParameter(dbCommandWrapper, "@VatAmount", SqlDbType.Decimal, financialQuotation.VatAmount);
                db.AddInParameter(dbCommandWrapper, "@TaxAmount", SqlDbType.Decimal, financialQuotation.TaxAmount);
                db.AddInParameter(dbCommandWrapper, "@GrossPrice", SqlDbType.Decimal, financialQuotation.GrossPrice);
                db.AddInParameter(dbCommandWrapper, "@DiscountPrice", SqlDbType.Decimal, financialQuotation.DiscountPrice);
                db.AddInParameter(dbCommandWrapper, "@NetPrice", SqlDbType.Decimal, financialQuotation.NetPrice);
                db.AddInParameter(dbCommandWrapper, "@QuotValidDate", SqlDbType.DateTime, financialQuotation.QuotValidDate);
                db.AddInParameter(dbCommandWrapper, "@ExpecDeliDate", SqlDbType.DateTime, financialQuotation.ExpecDeliDate);








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

        public DSM_Documents GetMaterialDocStatus(out bool docStatus, string materialCode, out string errorNumber)
        {

            errorNumber = string.Empty;
            docStatus = true;
            var document = new DSM_Documents();

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_GetMaterialDocStatus"))
            {

                db.AddInParameter(dbCommandWrapper, "@MaterialCode", SqlDbType.NVarChar, materialCode);
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

    }
}
