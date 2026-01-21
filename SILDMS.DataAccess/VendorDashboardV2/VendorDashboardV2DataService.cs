using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SILDMS.DataAccessInterface.VendorDashboard;
using SILDMS.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SILDMS.Model.VendorSelectionModule;

namespace SILDMS.DataAccess.VendorDashboardV2
{
    public class VendorDashboardV2DataService : IVendorDashboardV2DataService
    {
        //public List<DashBoardInvitationTecnicalList> GetInvDetailList(object userId, string action)
        //{
        //    List<DashBoardInvitationTecnicalList> pd1 = new List<DashBoardInvitationTecnicalList>();
        //    DatabaseProviderFactory factory = new DatabaseProviderFactory();
        //    SqlDatabase db = factory.CreateDefault() as SqlDatabase;
        //    using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("GetVCMSVendorDashBordInfo"))
        //    {
        //        db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.NVarChar, userId);
        //        db.AddInParameter(dbCommandWrapper, "@Action", SqlDbType.NVarChar, action);

        //        DataSet ds = db.ExecuteDataSet(dbCommandWrapper);
        //        if (ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                DataTable dt1 = ds.Tables[0];

        //                pd1 = dt1.AsEnumerable().Select(reader => new DashBoardInvitationTecnicalList
        //                {
        //                    InnvitationNumber = reader.GetString("TechInvToRespTotal"),
        //                    InnvitationDt = reader.GetString("FinanInvToRespTotal"),
        //                    QuotationlastDt = reader.GetString("RunInvTotal"),

        //                }).ToList();
        //            }
        //        }

        //    }
        //    return null;
        //}

        public RequisitionUnassaign GetPlantWiseUnAssignedResult(string _userId, string action)
        {
            var pd = new RequisitionUnassaign();
            var invitationTecnicalList = new List<DashBoardInvitationTecnicalList>();
            var invitationFinanList = new List<DashBoardInvitationFinanList>();
            var invitationRunninglList = new List<DashBoardInvitationRunninglList>();
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("GetVCMSVendorDashBordInfo"))
            {
                db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.NVarChar, _userId);
                db.AddInParameter(dbCommandWrapper, "@Action", SqlDbType.NVarChar, action);

                DataSet ds = db.ExecuteDataSet(dbCommandWrapper);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        pd = dt.AsEnumerable().Select(reader => new RequisitionUnassaign
                        {
                            TechInvToRespTotal = reader.GetString("TechInvToRespTotal"),
                            FinanInvToRespTotal = reader.GetString("FinanInvToRespTotal"),
                            RunInvTotal = reader.GetString("RunInvTotal"),

                        }).FirstOrDefault();
                    }

                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    DataTable dt1 = ds.Tables[1];

                    invitationTecnicalList = dt1.AsEnumerable().Select(reader => new DashBoardInvitationTecnicalList
                    {
                        InnvitationNumber = reader.GetString("InvitationNumber"),
                        InnvitationDt = reader.GetString("InvitationSendingDate"),
                        QuotationlastDt = reader.GetString("QuotationSendingLastDate"),

                    }).ToList();
                    pd.InvitationTecnicalList = invitationTecnicalList;
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    DataTable dt1 = ds.Tables[2];

                    invitationFinanList = dt1.AsEnumerable().Select(reader => new DashBoardInvitationFinanList
                    {
                        InnvitationNumber = reader.GetString("InvitationNumber"),
                        InnvitationDt = reader.GetString("InvitationSendingDate"),
                        QuotationlastDt = reader.GetString("QuotationSendingLastDate"),

                    }).ToList();
                    pd.InvitationFinanList = invitationFinanList;
                }

                if (ds.Tables[3].Rows.Count > 0)
                {
                    DataTable dt1 = ds.Tables[3];

                    invitationRunninglList = dt1.AsEnumerable().Select(reader => new DashBoardInvitationRunninglList
                    {
                        InnvitationNumber = reader.GetString("InvitationNumber"),
                        QuotationSetOn = reader.GetString("QuotationSetOn"),
                        QuotationlastDt = reader.GetString("QuotationSendingLastDate"),
                        QuotationNo = reader.GetString("QuotationNo"),
                        TechQuotationItemID = reader.GetString("TechQuotationItemID"),
                        FinanQuotationItemID = reader.GetString("FinanQuotationItemID"),

                    }).ToList();
                    pd.InvitationRunninglList = invitationRunninglList;
                }
                return pd;
            }
        }

        public InvitationDetail GetUserWiseInvDetailList(string invitationNumber, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
