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
            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_InvMaterialForFinancialQuotation"))
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
                            // Existing mappings
                            sampleDocId = reader.GetString("DocumentID"),
                            materialName = reader.GetString("MaterialName"),
                            materialCode = reader.GetString("MaterialCode"),
                            material_Category_Code = reader.GetString("MaterialCategory"),

                            MaterialQuantity = reader.GetString("RFQQty"),
                            Unit = reader.GetString("RFQQtyUnit"),

                            //MatInvType = reader.GetString("MatInvType"),

                            invitationNumber = reader.GetString("InvitationNumber"),
                            RFQDeadline = reader.GetDateTime("QuotationSendingLastDate"),
                            RFQDeadlineString = reader.GetDateTime("QuotationSendingLastDate").ToString("dd/MM/yyyy"),
                            InvitationID = reader.GetString("InvitationID"),
                            BiddingItemVendorID = reader.GetString("BiddingVendorID"),
                            VendorID = reader.GetString("VendorID"),
                            BiddingID = reader.GetString("BiddingID"),
                            Status = reader.GetInt32("Status"),
                            Fintype = reader.GetString("Fintype"),
                            Proposal = reader.GetString("Proposal"),

                            QuotationID = dt1.Columns.Contains("QuotationID") && !reader.IsNull("QuotationID")
                       ? Convert.ToInt64(reader["QuotationID"])
                       : 0,

                            QuotationNo = dt1.Columns.Contains("QuotationNo") && !reader.IsNull("QuotationNo")
                       ? reader.Field<string>("QuotationNo")
                       : null,

                            Action = "A",

                            // 🔽 Newly added fields
                            DeliveryTimeline = dt1.Columns.Contains("DeliveryTimeline") && !reader.IsNull("DeliveryTimeline")
                           ? reader.Field<string>("DeliveryTimeline")
                           : null,

                            Incoterms = dt1.Columns.Contains("Incoterms") && !reader.IsNull("Incoterms")
                           ? reader.Field<string>("Incoterms")
                           : null,

                            IncotermsLocation = dt1.Columns.Contains("IncotermsLocation") && !reader.IsNull("IncotermsLocation")
                           ? reader.Field<string>("IncotermsLocation")
                           : null,

                            ShipmentMode = dt1.Columns.Contains("ShipmentMode") && !reader.IsNull("ShipmentMode")
                           ? reader.Field<string>("ShipmentMode")
                           : null,

                            PaymentMode = dt1.Columns.Contains("PaymentMode") && !reader.IsNull("PaymentMode")
                           ? reader.Field<string>("PaymentMode")
                           : null,

                            PartDelivery = dt1.Columns.Contains("PartDelivery") && !reader.IsNull("PartDelivery")
                           ? reader.Field<string>("PartDelivery")
                           : null,

                            PaymentTerms = dt1.Columns.Contains("PaymentTerms") && !reader.IsNull("PaymentTerms")
                           ? reader.Field<string>("PaymentTerms")
                           : null,

                            ManufacturerPartNo = dt1.Columns.Contains("ManufacturerPartNo") && !reader.IsNull("ManufacturerPartNo")
                           ? reader.Field<string>("ManufacturerPartNo")
                           : null,

                            ManufacturerName = dt1.Columns.Contains("ManufacturerName") && !reader.IsNull("ManufacturerName")
                           ? reader.Field<string>("ManufacturerName")
                           : null,

                            Warranty = dt1.Columns.Contains("Warranty") && !reader.IsNull("Warranty")
                           ? reader.Field<string>("Warranty")
                           : null,

                            Installation = dt1.Columns.Contains("Installation") && !reader.IsNull("Installation")
                           ? reader.Field<string>("Installation")
                           : null,

                            Servicing = dt1.Columns.Contains("Servicing") && !reader.IsNull("Servicing")
                           ? reader.Field<string>("Servicing")
                           : null,

                            PenaltyClause = dt1.Columns.Contains("PenaltyClause") && !reader.IsNull("PenaltyClause")
                           ? reader.Field<string>("PenaltyClause")
                           : null,

                            Remarks = dt1.Columns.Contains("Remarks") && !reader.IsNull("Remarks")
                           ? reader.Field<string>("Remarks")
                           : null,

                            DeliveryLocation = dt1.Columns.Contains("DeliveryLocation") && !reader.IsNull("DeliveryLocation")
                           ? reader.Field<string>("DeliveryLocation")
                           : null
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
        public int submitfinancialquotationData(string userid, FinancialQuotationDetail financialQuotationDetail, SimplifiedMaterialInvitation materialInvitation, string ProposalType, Quotation quotation, out string errorNumber)
        {
            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            int ID = 0;
            errorNumber = string.Empty;

            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_SubmitFinancialQuotation"))
            {
                // =======================
                // Supplier and Agent Information
                // =======================
                db.AddInParameter(dbCommandWrapper, "@SupplierName", SqlDbType.VarChar, financialQuotationDetail.SupplierName);
                db.AddInParameter(dbCommandWrapper, "@LocalAgentName", SqlDbType.VarChar, financialQuotationDetail.LocalAgentName);

                // =======================
                // Quantity and Unit (Existing)
                // =======================
                db.AddInParameter(dbCommandWrapper, "@ProposeQty", SqlDbType.Decimal, financialQuotationDetail.ProposeQty);



                // =======================
                // Pricing Information
                // =======================

                db.AddInParameter(dbCommandWrapper, "@Price", SqlDbType.Decimal, financialQuotationDetail.Price ?? (object)DBNull.Value);
                db.AddInParameter(dbCommandWrapper, "@Per", SqlDbType.Decimal, financialQuotationDetail.Per);
                if (string.IsNullOrEmpty(financialQuotationDetail.PriceUnit.Item_Code))
                {
                    db.AddInParameter(dbCommandWrapper, "@PriceUnit", SqlDbType.VarChar, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommandWrapper, "@PriceUnit", SqlDbType.VarChar, financialQuotationDetail.PriceUnit.Item_Code);
                }


                if (string.IsNullOrEmpty(financialQuotationDetail.Currency.MasterDataID))
                {
                    db.AddInParameter(dbCommandWrapper, "@Currency", SqlDbType.VarChar, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommandWrapper, "@Currency", SqlDbType.VarChar, financialQuotationDetail.Currency.MasterDataID);
                }

                // =======================
                // Calculated Prices (Existing)
                // =======================


                // =======================
                // Taxes and Charges
                // =======================


                db.AddInParameter(dbCommandWrapper, "@VAT", SqlDbType.VarChar, financialQuotationDetail.VAT);
                db.AddInParameter(dbCommandWrapper, "@Tax", SqlDbType.VarChar, financialQuotationDetail.Tax);
                db.AddInParameter(dbCommandWrapper, "@Freight", SqlDbType.Decimal, financialQuotationDetail.Freight ?? (object)DBNull.Value);
                db.AddInParameter(dbCommandWrapper, "@FreightPer", SqlDbType.VarChar, financialQuotationDetail.FreightPer);
                db.AddInParameter(dbCommandWrapper, "@Discount", SqlDbType.Decimal, financialQuotationDetail.Discount ?? (object)DBNull.Value);

                db.AddInParameter(dbCommandWrapper, "@DiscountPer", SqlDbType.VarChar, financialQuotationDetail.DiscountPer);
                db.AddInParameter(dbCommandWrapper, "@OrderHandlingCharges", SqlDbType.Decimal, financialQuotationDetail.OrderHandlingCharges ?? (object)DBNull.Value);
                db.AddInParameter(dbCommandWrapper, "@PackingCharges", SqlDbType.Decimal, financialQuotationDetail.PackingCharges ?? (object)DBNull.Value);
                db.AddInParameter(dbCommandWrapper, "@SundryCharges", SqlDbType.Decimal, financialQuotationDetail.SundryCharges ?? (object)DBNull.Value);
                db.AddInParameter(dbCommandWrapper, "@DeliveryCharge", SqlDbType.Decimal, financialQuotationDetail.DeliveryCharge ?? (object)DBNull.Value);
                db.AddInParameter(dbCommandWrapper, "@DeliveryPer", SqlDbType.VarChar, financialQuotationDetail.DeliveryPer);

                // =======================
                // Quantity Information
                // =======================
                db.AddInParameter(dbCommandWrapper, "@QuotationQty", SqlDbType.Decimal, financialQuotationDetail.QuotationQty);

                if (string.IsNullOrEmpty(financialQuotationDetail.QuotationQtyUnit.Item_Code))
                {
                    db.AddInParameter(dbCommandWrapper, "@QuotationQtyUnit", SqlDbType.VarChar, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommandWrapper, "@QuotationQtyUnit", SqlDbType.VarChar, financialQuotationDetail.QuotationQtyUnit.Item_Code);
                }

                db.AddInParameter(dbCommandWrapper, "@QtyTolerance", SqlDbType.Decimal, financialQuotationDetail.QtyTolerance);
                db.AddInParameter(dbCommandWrapper, "@MinimumOrderQty", SqlDbType.Decimal, financialQuotationDetail.MinimumOrderQty);
                db.AddInParameter(dbCommandWrapper, "@PackSize", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.PackSize) ? (object)DBNull.Value : financialQuotationDetail.PackSize);

                // =======================
                // Delivery Information
                // =======================
                db.AddInParameter(dbCommandWrapper, "@DeliveryTimeline", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.DeliveryTimeline) ? (object)DBNull.Value : financialQuotationDetail.DeliveryTimeline);
                //db.AddInParameter(dbCommandWrapper, "@ExpecDeliDate", SqlDbType.DateTime, financialQuotationDetail.ExpecDeliDate);
                db.AddInParameter(dbCommandWrapper, "@PartDelivery", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.PartDelivery) ? (object)DBNull.Value : financialQuotationDetail.PartDelivery);
                db.AddInParameter(dbCommandWrapper, "@Incoterms", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.Incoterms?.MasterDataID) ? (object)DBNull.Value : financialQuotationDetail.Incoterms.MasterDataID);
                db.AddInParameter(dbCommandWrapper, "@IncotermsLocation", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.IncotermsLocation?.MasterDataID) ? (object)DBNull.Value : financialQuotationDetail.IncotermsLocation.MasterDataID);
                db.AddInParameter(dbCommandWrapper, "@ShipmentMode", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.ShipmentMode) ? (object)DBNull.Value : financialQuotationDetail.ShipmentMode);
                db.AddInParameter(dbCommandWrapper, "@InlandTransportation", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.InlandTransportation) ? (object)DBNull.Value : financialQuotationDetail.InlandTransportation);

                // =======================
                // Payment Information
                // =======================
                db.AddInParameter(dbCommandWrapper, "@PaymentMode", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.PaymentMode?.MasterDataID) ? (object)DBNull.Value : financialQuotationDetail.PaymentMode.MasterDataID);
                db.AddInParameter(dbCommandWrapper, "@PaymentTerms", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.PaymentTerms) ? (object)DBNull.Value : financialQuotationDetail.PaymentTerms);

                // =======================
                // Validity and Terms
                // =======================
                db.AddInParameter(dbCommandWrapper, "@QuotationValidity", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.QuotationValidity) ? (object)DBNull.Value : financialQuotationDetail.QuotationValidity);
                //db.AddInParameter(dbCommandWrapper, "@QuotValidDate", SqlDbType.DateTime, financialQuotationDetail.QuotValidDate);

                // =======================
                // Manufacturer Information
                // =======================
                db.AddInParameter(dbCommandWrapper, "@ManufacturerPartNo", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.ManufacturerPartNo) ? (object)DBNull.Value : financialQuotationDetail.ManufacturerPartNo);
                db.AddInParameter(dbCommandWrapper, "@ManufacturerName", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.ManufacturerName) ? (object)DBNull.Value : financialQuotationDetail.ManufacturerName);
                db.AddInParameter(dbCommandWrapper, "@ManufacturerSiteAddress", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.ManufacturerSiteAddress) ? (object)DBNull.Value : financialQuotationDetail.ManufacturerSiteAddress);

                // =======================
                // Service and Support
                // =======================
                db.AddInParameter(dbCommandWrapper, "@Warranty", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.Warranty) ? (object)DBNull.Value : financialQuotationDetail.Warranty);
                db.AddInParameter(dbCommandWrapper, "@Installation", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.Installation) ? (object)DBNull.Value : financialQuotationDetail.Installation);
                db.AddInParameter(dbCommandWrapper, "@Servicing", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.Servicing) ? (object)DBNull.Value : financialQuotationDetail.Servicing);

                // =======================
                // Additional Details
                // =======================
                db.AddInParameter(dbCommandWrapper, "@KeyCustomerList", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.KeyCustomerList) ? (object)DBNull.Value : financialQuotationDetail.KeyCustomerList);
                db.AddInParameter(dbCommandWrapper, "@Subcontractor", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.Subcontractor) ? (object)DBNull.Value : financialQuotationDetail.Subcontractor);
                db.AddInParameter(dbCommandWrapper, "@SubcontractorDetails", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.SubcontractorDetails) ? (object)DBNull.Value : financialQuotationDetail.SubcontractorDetails);
                db.AddInParameter(dbCommandWrapper, "@ReturnableItem", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.ReturnableItem) ? (object)DBNull.Value : financialQuotationDetail.ReturnableItem);
                db.AddInParameter(dbCommandWrapper, "@PenaltyClause", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.PenaltyClause) ? (object)DBNull.Value : financialQuotationDetail.PenaltyClause);
                db.AddInParameter(dbCommandWrapper, "@Remarks", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.Remarks) ? (object)DBNull.Value : financialQuotationDetail.Remarks);
                db.AddInParameter(dbCommandWrapper, "@Deliverylocation", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.DeliveryLocation) ? (object)DBNull.Value : financialQuotationDetail.DeliveryLocation);

                // =======================
                // Material Invitation Parameters
                // =======================
                db.AddInParameter(dbCommandWrapper, "@invitationNumber", SqlDbType.VarChar, materialInvitation.invitationNumber);
                db.AddInParameter(dbCommandWrapper, "@materialCode", SqlDbType.VarChar, materialInvitation.materialCode);
                db.AddInParameter(dbCommandWrapper, "@materialName", SqlDbType.VarChar, materialInvitation.materialName);

                db.AddInParameter(dbCommandWrapper, "@sampleDocId", SqlDbType.VarChar,
                string.IsNullOrEmpty(financialQuotationDetail.SampleDocumentID) ? (object)DBNull.Value : financialQuotationDetail.SampleDocumentID);
                db.AddInParameter(dbCommandWrapper, "@VendorID", SqlDbType.VarChar, materialInvitation.VendorID);
                db.AddInParameter(dbCommandWrapper, "@modificationType", SqlDbType.VarChar, materialInvitation.modificationType);
                db.AddInParameter(dbCommandWrapper, "@setOn", SqlDbType.DateTime, materialInvitation.setOn);
                db.AddInParameter(dbCommandWrapper, "@setBy", SqlDbType.VarChar, userid);
                db.AddInParameter(dbCommandWrapper, "@modifiedOn", SqlDbType.DateTime, materialInvitation.modifiedOn);
                db.AddInParameter(dbCommandWrapper, "@modifiedBy", SqlDbType.VarChar, userid);
                db.AddInParameter(dbCommandWrapper, "@status", SqlDbType.VarChar, '1');
                db.AddInParameter(dbCommandWrapper, "@RequstedQty", SqlDbType.Decimal, Convert.ToDecimal(materialInvitation.MaterialQuantity));

                db.AddInParameter(dbCommandWrapper, "@Unit", SqlDbType.VarChar, materialInvitation.Unit);
                db.AddInParameter(dbCommandWrapper, "@material_Category_Code", SqlDbType.VarChar, materialInvitation.material_Category_Code);

                // =======================
                // Quotation ID/No based on ProposalType
                // =======================
                if (ProposalType == "FINANCIAL")
                {
                    db.AddInParameter(dbCommandWrapper, "@quotationID", SqlDbType.VarChar, quotation.quotationID);
                    db.AddInParameter(dbCommandWrapper, "@quotationNo", SqlDbType.VarChar, quotation.quotationNo);
                }
                else
                {
                    db.AddInParameter(dbCommandWrapper, "@quotationID", SqlDbType.VarChar, materialInvitation.QuotationID);
                    db.AddInParameter(dbCommandWrapper, "@quotationNo", SqlDbType.VarChar, materialInvitation.QuotationNo);
                }
                db.AddInParameter(dbCommandWrapper, "@proposalType", SqlDbType.VarChar, ProposalType);
                db.AddInParameter(dbCommandWrapper, "@Fintype", SqlDbType.VarChar, financialQuotationDetail.Fintype);

                // =======================
                // Execute and Get Result
                // =======================
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
                            RFQDate = reader.GetDateTime("InvitationSendingDate").ToString("dd/MM/yyyy"),
                            RFQDeadline = reader.GetDateTime("QuotationSendingLastDate").ToString("dd/MM/yyyy"),





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
                            MaterialQuantity = reader.GetString("RFQQty"),
                            Unit = reader.GetString("RFQQtyUnit"),
                            MatInvType = reader.GetString("Proposal"),
                            Fintype = reader.GetString("Fintype"),
                            materialCode = reader.GetString("MaterialCode"),
                            //material_Category_Code = reader.GetString("MatCategory"),
                            invitationNumber = reader.GetString("InvitationNumber"),
                            InvitationID = reader.GetString("InvitationID"),
                            BiddingItemVendorID = reader.GetString("BiddingVendorID"),
                            VendorID = reader.GetString("VendorID"),
                            BiddingID = reader.GetString("BiddingID"),

                            sampleDocId = reader.GetString("DocumentID"),
                            SampleDocumentID = reader.GetString("SampleDocId"),
                            LowestNetUnitPrice = reader.GetString("LowestNetUnitPrice"),
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


                            QuotationID = reader["QuotationID"] as string,
                            QuotationNo = reader["QuotationNo"] as string,
                            InvitationNumber = reader["InvitationNumber"] as string,

                            // =====================
                            // Quantities
                            // =====================
                            ProposeQty = reader["ProposeQty"] != DBNull.Value ? Convert.ToDecimal(reader["ProposeQty"]) : 0m,

                            QuotationQty = reader["QuotationQty"] != DBNull.Value ? Convert.ToDecimal(reader["QuotationQty"]) : 0m,

                            QtyTolerance = reader["QtyTolerance"] != DBNull.Value ? Convert.ToDecimal(reader["QtyTolerance"]) : 0m,

                            MinimumOrderQty = reader["MinimumOrderQty"] != DBNull.Value ? Convert.ToDecimal(reader["MinimumOrderQty"]) : 0m,
                            PackSize = reader["PackSize"] as string,

                            // =====================
                            // Units
                            // =====================
                            QuotationQtyUnit = reader["QuotationQtyUnit"] != DBNull.Value
        ? new Item { Item_Code = reader["QuotationQtyUnit"].ToString() }
        : null,

                            PriceUnit = reader["PriceUnit"] != DBNull.Value
        ? new Item { Item_Code = reader["PriceUnit"].ToString() }
        : null,

                            // =====================
                            // Pricing
                            // =====================
                            Price = reader["Price"] != DBNull.Value ? Convert.ToDecimal(reader["Price"]) : (decimal?)null,
                            Per = reader["Per"] != DBNull.Value ? Convert.ToDecimal(reader["Per"]) : 0,

                            Freight = reader["Freight"] != DBNull.Value ? Convert.ToDecimal(reader["Freight"]) : (decimal?)null,
                            FreightPer = reader["FreightPer"] != DBNull.Value ? Convert.ToString(reader["FreightPer"]) : "",
                            Discount = reader["Discount"] != DBNull.Value ? Convert.ToDecimal(reader["Discount"]) : (decimal?)null,
                            DiscountPer = reader["DiscountPer"] != DBNull.Value ? Convert.ToString(reader["DiscountPer"]):"",
                            OrderHandlingCharges = reader["OrderHandlingCharges"] != DBNull.Value ? Convert.ToDecimal(reader["OrderHandlingCharges"]) : (decimal?)null,
                            PackingCharges = reader["PackingCharges"] != DBNull.Value ? Convert.ToDecimal(reader["PackingCharges"]) : (decimal?)null,
                            SundryCharges = reader["SundryCharges"] != DBNull.Value ? Convert.ToDecimal(reader["SundryCharges"]) : (decimal?)null,
                            DeliveryCharge = reader["DeliveryCharge"] != DBNull.Value ? Convert.ToDecimal(reader["DeliveryCharge"]) : (decimal?)null,
                            DeliveryPer = reader["DeliveryPer"] != DBNull.Value ? Convert.ToString(reader["DeliveryPer"]) : "",

                            // =====================
                            // Currency & Tax
                            // =====================
                            Currency = reader["Currency"] != DBNull.Value
        ? new MasterData { MasterDataID = reader["Currency"].ToString() }
        : null,

                            VAT = reader["VAT"] as string,
                            Tax = reader["Tax"] as string,

                            // =====================
                            // Delivery
                            // =====================
                            DeliveryTimeline = reader["DeliveryTimeline"] as string,
                            DeliveryLocation = reader["Deliverylocation"] as string,
                            PartDelivery = reader["PartDelivery"] as string,
                            ShipmentMode = reader["ShipmentMode"] as string,
                            InlandTransportation = reader["InlandTransportation"] as string,


                            // =====================
                            // Incoterms
                            // =====================
                            Incoterms = reader["Incoterms"] != DBNull.Value
        ? new MasterData { MasterDataID = reader["Incoterms"].ToString() }
        : null,

                            IncotermsLocation = reader["IncotermsLocation"] != DBNull.Value
        ? new MasterData { MasterDataID = reader["IncotermsLocation"].ToString() }
        : null,

                            // =====================
                            // Payment
                            // =====================
                            PaymentMode = reader["PaymentMode"] != DBNull.Value
        ? new MasterData { MasterDataID = reader["PaymentMode"].ToString() }
        : null,

                            PaymentTerms = reader["PaymentTerms"] as string,

                            // =====================
                            // Validity
                            // =====================
                            QuotationValidity = reader["QuotationValidity"] as string,


                            // =====================
                            // Manufacturer
                            // =====================
                            ManufacturerPartNo = reader["ManufacturerPartNo"] as string,
                            ManufacturerName = reader["ManufacturerName"] as string,
                            ManufacturerSiteAddress = reader["ManufacturerSiteAddress"] as string,

                            // =====================
                            // Services
                            // =====================
                            Warranty = reader["Warranty"] as string,
                            Installation = reader["Installation"] as string,
                            Servicing = reader["Servicing"] as string,

                            // =====================
                            // Misc
                            // =====================
                            KeyCustomerList = reader["KeyCustomerList"] as string,
                            Subcontractor = reader["Subcontractor"] as string ?? "No",
                            SubcontractorDetails = reader["SubcontractorDetails"] as string,
                            ReturnableItem = reader["ReturnableItem"] as string,
                            PenaltyClause = reader["PenaltyClause"] as string,
                            Remarks = reader["Remarks"] as string,

                            SupplierName = reader["SupplierName"] as string,
                            LocalAgentName = reader["LocalAgentName"] as string,

                            ProposalType = reader["ProposalType"] as string,
                            Fintype = reader["FinType"] as string,

                            SampleDocumentID = reader["SampleDocId"] as string
                 

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

        public long SaveFinQuotwiseDetailsData(FinancialQuotationDetail financialQuotationDetail, out string errorNumber)
        {

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;
            var i = 0;
            long ID = 0;
            errorNumber = string.Empty;


            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_UpdateFinancialQuotation"))
            {



                db.AddInParameter(dbCommandWrapper, "@FinanQuotationItemID", SqlDbType.Decimal, financialQuotationDetail.FinanQuotationItemID);
                db.AddInParameter(dbCommandWrapper, "@SupplierName", SqlDbType.VarChar, financialQuotationDetail.SupplierName);
                db.AddInParameter(dbCommandWrapper, "@LocalAgentName", SqlDbType.VarChar, financialQuotationDetail.LocalAgentName);

                // =======================
                // Quantity and Unit (Existing)
                // =======================




                // =======================
                // Pricing Information
                // =======================

                db.AddInParameter(dbCommandWrapper, "@Price", SqlDbType.Decimal, financialQuotationDetail.Price ?? (object)DBNull.Value);
                db.AddInParameter(dbCommandWrapper, "@Per", SqlDbType.Decimal, financialQuotationDetail.Per);
                if (string.IsNullOrEmpty(financialQuotationDetail.PriceUnit.Item_Code))
                {
                    db.AddInParameter(dbCommandWrapper, "@PriceUnit", SqlDbType.VarChar, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommandWrapper, "@PriceUnit", SqlDbType.VarChar, financialQuotationDetail.PriceUnit.Item_Code);
                }


                if (string.IsNullOrEmpty(financialQuotationDetail.Currency.MasterDataID))
                {
                    db.AddInParameter(dbCommandWrapper, "@Currency", SqlDbType.VarChar, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommandWrapper, "@Currency", SqlDbType.VarChar, financialQuotationDetail.Currency.MasterDataID);
                }

                // =======================
                // Calculated Prices (Existing)
                // =======================


                // =======================
                // Taxes and Charges
                // =======================


                db.AddInParameter(dbCommandWrapper, "@VAT", SqlDbType.VarChar, financialQuotationDetail.VAT);
                db.AddInParameter(dbCommandWrapper, "@Tax", SqlDbType.VarChar, financialQuotationDetail.Tax);
                db.AddInParameter(dbCommandWrapper, "@Freight", SqlDbType.Decimal, financialQuotationDetail.Freight ?? (object)DBNull.Value);
                db.AddInParameter(dbCommandWrapper, "@FreightPer", SqlDbType.VarChar, financialQuotationDetail.FreightPer ?? (object)DBNull.Value);
                db.AddInParameter(dbCommandWrapper, "@Discount", SqlDbType.Decimal, financialQuotationDetail.Discount ?? (object)DBNull.Value);
                db.AddInParameter(dbCommandWrapper, "@DiscountPer", SqlDbType.VarChar, financialQuotationDetail.DiscountPer ?? (object)DBNull.Value);
                db.AddInParameter(dbCommandWrapper, "@OrderHandlingCharges", SqlDbType.Decimal, financialQuotationDetail.OrderHandlingCharges ?? (object)DBNull.Value);
                db.AddInParameter(dbCommandWrapper, "@PackingCharges", SqlDbType.Decimal, financialQuotationDetail.PackingCharges ?? (object)DBNull.Value);
                db.AddInParameter(dbCommandWrapper, "@SundryCharges", SqlDbType.Decimal, financialQuotationDetail.SundryCharges ?? (object)DBNull.Value);
                db.AddInParameter(dbCommandWrapper, "@DeliveryCharge", SqlDbType.Decimal, financialQuotationDetail.DeliveryCharge ?? (object)DBNull.Value);
                db.AddInParameter(dbCommandWrapper, "@DeliveryPer", SqlDbType.VarChar, financialQuotationDetail.DeliveryPer ?? (object)DBNull.Value);

                // =======================
                // Quantity Information
                // =======================
                db.AddInParameter(dbCommandWrapper, "@QuotationQty", SqlDbType.Decimal, financialQuotationDetail.QuotationQty);

                if (string.IsNullOrEmpty(financialQuotationDetail.QuotationQtyUnit.Item_Code))
                {
                    db.AddInParameter(dbCommandWrapper, "@QuotationQtyUnit", SqlDbType.VarChar, DBNull.Value);
                }
                else
                {
                    db.AddInParameter(dbCommandWrapper, "@QuotationQtyUnit", SqlDbType.VarChar, financialQuotationDetail.QuotationQtyUnit.Item_Code);
                }

                db.AddInParameter(dbCommandWrapper, "@QtyTolerance", SqlDbType.Decimal, financialQuotationDetail.QtyTolerance);
                db.AddInParameter(dbCommandWrapper, "@MinimumOrderQty", SqlDbType.Decimal, financialQuotationDetail.MinimumOrderQty);
                db.AddInParameter(dbCommandWrapper, "@PackSize", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.PackSize) ? (object)DBNull.Value : financialQuotationDetail.PackSize);

                // =======================
                // Delivery Information
                // =======================
                db.AddInParameter(dbCommandWrapper, "@DeliveryTimeline", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.DeliveryTimeline) ? (object)DBNull.Value : financialQuotationDetail.DeliveryTimeline);
                //db.AddInParameter(dbCommandWrapper, "@ExpecDeliDate", SqlDbType.DateTime, financialQuotationDetail.ExpecDeliDate);
                db.AddInParameter(dbCommandWrapper, "@PartDelivery", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.PartDelivery) ? (object)DBNull.Value : financialQuotationDetail.PartDelivery);
                db.AddInParameter(dbCommandWrapper, "@Incoterms", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.Incoterms?.MasterDataID) ? (object)DBNull.Value : financialQuotationDetail.Incoterms.MasterDataID);
                db.AddInParameter(dbCommandWrapper, "@IncotermsLocation", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.IncotermsLocation?.MasterDataID) ? (object)DBNull.Value : financialQuotationDetail.IncotermsLocation.MasterDataID);
                db.AddInParameter(dbCommandWrapper, "@ShipmentMode", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.ShipmentMode) ? (object)DBNull.Value : financialQuotationDetail.ShipmentMode);
                db.AddInParameter(dbCommandWrapper, "@InlandTransportation", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.InlandTransportation) ? (object)DBNull.Value : financialQuotationDetail.InlandTransportation);

                // =======================
                // Payment Information
                // =======================
                db.AddInParameter(dbCommandWrapper, "@PaymentMode", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.PaymentMode?.MasterDataID) ? (object)DBNull.Value : financialQuotationDetail.PaymentMode.MasterDataID);
                db.AddInParameter(dbCommandWrapper, "@PaymentTerms", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.PaymentTerms) ? (object)DBNull.Value : financialQuotationDetail.PaymentTerms);

                // =======================
                // Validity and Terms
                // =======================
                db.AddInParameter(dbCommandWrapper, "@QuotationValidity", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.QuotationValidity) ? (object)DBNull.Value : financialQuotationDetail.QuotationValidity);
                //db.AddInParameter(dbCommandWrapper, "@QuotValidDate", SqlDbType.DateTime, financialQuotationDetail.QuotValidDate);

                // =======================
                // Manufacturer Information
                // =======================
                db.AddInParameter(dbCommandWrapper, "@ManufacturerPartNo", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.ManufacturerPartNo) ? (object)DBNull.Value : financialQuotationDetail.ManufacturerPartNo);
                db.AddInParameter(dbCommandWrapper, "@ManufacturerName", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.ManufacturerName) ? (object)DBNull.Value : financialQuotationDetail.ManufacturerName);
                db.AddInParameter(dbCommandWrapper, "@ManufacturerSiteAddress", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.ManufacturerSiteAddress) ? (object)DBNull.Value : financialQuotationDetail.ManufacturerSiteAddress);

                // =======================
                // Service and Support
                // =======================
                db.AddInParameter(dbCommandWrapper, "@Warranty", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.Warranty) ? (object)DBNull.Value : financialQuotationDetail.Warranty);
                db.AddInParameter(dbCommandWrapper, "@Installation", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.Installation) ? (object)DBNull.Value : financialQuotationDetail.Installation);
                db.AddInParameter(dbCommandWrapper, "@Servicing", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.Servicing) ? (object)DBNull.Value : financialQuotationDetail.Servicing);

                // =======================
                // Additional Details
                // =======================
                db.AddInParameter(dbCommandWrapper, "@KeyCustomerList", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.KeyCustomerList) ? (object)DBNull.Value : financialQuotationDetail.KeyCustomerList);
                db.AddInParameter(dbCommandWrapper, "@Subcontractor", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.Subcontractor) ? (object)DBNull.Value : financialQuotationDetail.Subcontractor);
                db.AddInParameter(dbCommandWrapper, "@SubcontractorDetails", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.SubcontractorDetails) ? (object)DBNull.Value : financialQuotationDetail.SubcontractorDetails);
                db.AddInParameter(dbCommandWrapper, "@ReturnableItem", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.ReturnableItem) ? (object)DBNull.Value : financialQuotationDetail.ReturnableItem);
                db.AddInParameter(dbCommandWrapper, "@PenaltyClause", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.PenaltyClause) ? (object)DBNull.Value : financialQuotationDetail.PenaltyClause);
                db.AddInParameter(dbCommandWrapper, "@Remarks", SqlDbType.VarChar,
                    string.IsNullOrEmpty(financialQuotationDetail.Remarks) ? (object)DBNull.Value : financialQuotationDetail.Remarks);

                // =======================
                // Material Invitation Parameters
                // =======================


                db.AddInParameter(dbCommandWrapper, "@sampleDocId", SqlDbType.VarChar,
                string.IsNullOrEmpty(financialQuotationDetail.SampleDocumentID) ? (object)DBNull.Value : financialQuotationDetail.SampleDocumentID);








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

        public bool DeleteFinquot(string finanQuotationItemID, out string errorNumber)
        {
            errorNumber = string.Empty;
            bool isDeleted = false;

            var factory = new DatabaseProviderFactory();
            var db = factory.CreateDefault() as SqlDatabase;

            using (var dbCommandWrapper = db.GetStoredProcCommand("VCMS_DeleteFinquot"))
            {
                // INPUT parameter (same pattern as above)
                db.AddInParameter(dbCommandWrapper, "@finanQuotationItemID", SqlDbType.VarChar, finanQuotationItemID);
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