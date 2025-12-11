using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using SILDMS.DataAccessInterface.DashboardV2;
using SILDMS.Model.CBPSModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SILDMS.Model;

namespace SILDMS.DataAccess.DashboardV2
{
    public class DashboardV2DataService : IDashboardV2DataService
    {
        #region Unused Code
        //public string WaitingforParking(string userid)
        //{
        //    string WaitingforParking = string.Empty;
        //    DatabaseProviderFactory factory = new DatabaseProviderFactory();
        //    SqlDatabase db = factory.CreateDefault() as SqlDatabase;
        //    using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("CBPS_WaitingforParkingV2"))
        //    {
        //        db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.VarChar, userid);
        //        dbCommandWrapper.CommandTimeout = 300;
        //        var ds = db.ExecuteDataSet(dbCommandWrapper);
        //        DataTable dt1 = ds.Tables[0];
        //        if (dt1.Rows.Count > 0)
        //            WaitingforParking = dt1.Rows[0]["WaitingforParking"].ToString();
        //        else
        //            WaitingforParking = "0";
        //    }
        //    return WaitingforParking;
        //}
        //public string WithinBenchMarkPark(string userid)
        //{
        //    string WithinBenchMarkPark = string.Empty;
        //    DatabaseProviderFactory factory = new DatabaseProviderFactory();
        //    SqlDatabase db = factory.CreateDefault() as SqlDatabase;
        //    using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("CBPS_WithinBenchMarkParkV2"))
        //    {
        //        db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.VarChar, userid);
        //        dbCommandWrapper.CommandTimeout = 300;
        //        var ds = db.ExecuteDataSet(dbCommandWrapper);
        //        DataTable dt1 = ds.Tables[0];
        //        if (dt1.Rows.Count > 0)
        //            WithinBenchMarkPark = dt1.Rows[0]["WithinBenchMarkPark"].ToString();
        //        else
        //            WithinBenchMarkPark = "0";
        //    }
        //    return WithinBenchMarkPark;
        //}
        //public string OverBenchMarkPark(string userid)
        //{
        //    string OverBenchMarkPark = string.Empty;
        //    DatabaseProviderFactory factory = new DatabaseProviderFactory();
        //    SqlDatabase db = factory.CreateDefault() as SqlDatabase;
        //    using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("CBPS_OverBenchMarkParkV2"))
        //    {
        //        db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.VarChar, userid);
        //        dbCommandWrapper.CommandTimeout = 300;
        //        var ds = db.ExecuteDataSet(dbCommandWrapper);
        //        DataTable dt1 = ds.Tables[0];
        //        if (dt1.Rows.Count > 0)
        //            OverBenchMarkPark = dt1.Rows[0]["OverBenchMarkPark"].ToString();
        //        else
        //            OverBenchMarkPark = "0";
        //    }
        //    return OverBenchMarkPark;
        //}
        //public string WaitingforPosting(string userid)
        //{
        //    string WaitingforPosting = string.Empty;
        //    DatabaseProviderFactory factory = new DatabaseProviderFactory();
        //    SqlDatabase db = factory.CreateDefault() as SqlDatabase;
        //    using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("CBPS_WaitingforPostingV2"))
        //    {
        //        db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.VarChar, userid);
        //        dbCommandWrapper.CommandTimeout = 300;
        //        var ds = db.ExecuteDataSet(dbCommandWrapper);
        //        DataTable dt1 = ds.Tables[0];
        //        if (dt1.Rows.Count > 0)
        //            WaitingforPosting = dt1.Rows[0]["WaitingforPosting"].ToString();
        //        else
        //            WaitingforPosting = "0";
        //    }
        //    return WaitingforPosting;
        //}
        //public string WithinBenchMarkPost(string userid)
        //{
        //    string WithinBenchMarkPost = string.Empty;
        //    DatabaseProviderFactory factory = new DatabaseProviderFactory();
        //    SqlDatabase db = factory.CreateDefault() as SqlDatabase;
        //    using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("CBPS_WithinBenchMarkPostV2"))
        //    {
        //        db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.VarChar, userid);
        //        dbCommandWrapper.CommandTimeout = 300;
        //        var ds = db.ExecuteDataSet(dbCommandWrapper);
        //        DataTable dt1 = ds.Tables[0];
        //        if (dt1.Rows.Count > 0)
        //            WithinBenchMarkPost = dt1.Rows[0]["WithinBenchMarkPost"].ToString();
        //        else
        //            WithinBenchMarkPost = "0";
        //    }
        //    return WithinBenchMarkPost;
        //}
        //public string OverBenchMarkPost(string userid)
        //{
        //    string OverBenchMarkPost = string.Empty;
        //    DatabaseProviderFactory factory = new DatabaseProviderFactory();
        //    SqlDatabase db = factory.CreateDefault() as SqlDatabase;
        //    using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("CBPS_OverBenchMarkPostV2"))
        //    {
        //        db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.VarChar, userid);
        //        dbCommandWrapper.CommandTimeout = 300;
        //        var ds = db.ExecuteDataSet(dbCommandWrapper);
        //        DataTable dt1 = ds.Tables[0];
        //        if (dt1.Rows.Count > 0)
        //            OverBenchMarkPost = dt1.Rows[0]["OverBenchMarkPost"].ToString();
        //        else
        //            OverBenchMarkPost = "0";
        //    }
        //    return OverBenchMarkPost;
        //}
        //public string WaitingforClearing(string userid)
        //{
        //    string WaitingforClearing = string.Empty;
        //    DatabaseProviderFactory factory = new DatabaseProviderFactory();
        //    SqlDatabase db = factory.CreateDefault() as SqlDatabase;
        //    using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("CBPS_WaitingforClearingV2"))
        //    {
        //        db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.VarChar, userid);
        //        dbCommandWrapper.CommandTimeout = 300;
        //        var ds = db.ExecuteDataSet(dbCommandWrapper);
        //        DataTable dt1 = ds.Tables[0];
        //        if (dt1.Rows.Count > 0)
        //            WaitingforClearing = dt1.Rows[0]["WaitingforClearing"].ToString();
        //        else
        //            WaitingforClearing = "0";
        //    }
        //    return WaitingforClearing;
        //}
        //public string WithinBenchMarkClear(string userid)
        //{
        //    string WithinBenchMarkClear = string.Empty;
        //    DatabaseProviderFactory factory = new DatabaseProviderFactory();
        //    SqlDatabase db = factory.CreateDefault() as SqlDatabase;
        //    using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("CBPS_WithinBenchMarkClearV2"))
        //    {
        //        db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.VarChar, userid);
        //        dbCommandWrapper.CommandTimeout = 300;
        //        var ds = db.ExecuteDataSet(dbCommandWrapper);
        //        DataTable dt1 = ds.Tables[0];
        //        if (dt1.Rows.Count > 0)
        //            WithinBenchMarkClear = dt1.Rows[0]["WithinBenchMarkClear"].ToString();
        //        else
        //            WithinBenchMarkClear = "0";
        //    }
        //    return WithinBenchMarkClear;
        //}
        //public string OverBenchMarkClear(string userid)
        //{
        //    string OverBenchMarkClear = string.Empty;
        //    DatabaseProviderFactory factory = new DatabaseProviderFactory();
        //    SqlDatabase db = factory.CreateDefault() as SqlDatabase;
        //    using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("CBPS_OverBenchMarkClearV2"))
        //    {
        //        db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.VarChar, userid);
        //        dbCommandWrapper.CommandTimeout = 300;
        //        var ds = db.ExecuteDataSet(dbCommandWrapper);
        //        DataTable dt1 = ds.Tables[0];
        //        if (dt1.Rows.Count > 0)
        //            OverBenchMarkClear = dt1.Rows[0]["OverBenchMarkClear"].ToString();
        //        else
        //            OverBenchMarkClear = "0";
        //    }
        //    return OverBenchMarkClear;
        //}
        //public DataTable GetUserWiseAssignmentBillV2(string userid)
        //{

        //    DataTable dt = new DataTable();
        //    DatabaseProviderFactory factory = new DatabaseProviderFactory();
        //    SqlDatabase db = factory.CreateDefault() as SqlDatabase;
        //    using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("CBPS_GetUsersBySupervisorV2"))
        //    {
        //        db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.NVarChar, userid);
        //        DataSet ds = db.ExecuteDataSet(dbCommandWrapper);
        //        dt = ds.Tables[0];
        //    }
        //    return dt;
        //}
        #endregion
        public List<ParkingForDashbord> GetParkingForDashbord(string _userId, string action)
        {
            List<ParkingForDashbord> pd = new List<ParkingForDashbord>();
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("GetDashBordParkingInfo"))
            {
                db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.NVarChar, _userId);
                db.AddInParameter(dbCommandWrapper, "@Action", SqlDbType.NVarChar, action);
                DataSet ds = db.ExecuteDataSet(dbCommandWrapper);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt1 = ds.Tables[0];

                        pd = dt1.AsEnumerable().Select(reader => new ParkingForDashbord
                        {
                            BillTrackingNo = reader.GetString("BillTrackingNo"),
                            BenchMark = reader.GetString("BenchMark"),
                            OrigineBenchMark = reader.GetString("OrigineBenchMark"),
                            EmployeeID = action == "me" ? "" : reader.GetString("EmployeeID"),
                            UserName = action == "me" ? "" : reader.GetString("UserFullName"),
                            UserID = action == "me" ? "" : reader.GetString("UserID"),
                            CompanyCode = action == "me" ? "" : reader.GetString("CompanyCode"),
                            CompanyName = action == "me" ? "" : reader.GetString("CompanyName"),
                        }).ToList();
                    }
                }

            }
            return pd;


            //List<ParkingForDashbord> pd = new List<ParkingForDashbord>();
            //DatabaseProviderFactory factory = new DatabaseProviderFactory();
            //SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            //string query = "";

            //if (action == "me")
            //{
            //    query = "SELECT bal.BillTrackingNo,bal.BenchMark,bal.OrigineBenchMark FROM (SELECT BillTrackingNo, ISNULL(DATEDIFF(dd, GETDATE(), BenchMarkEndDate),0) BenchMark, ISNULL(OrigineBenchMark,0) OrigineBenchMark FROM BPS_BillAssignmentLog WHERE BillAssignmentLogID IN (select MAX(BillAssignmentLogID) BillAssignmentLogID from BPS_BillAssignmentLog WHERE StageNameFrom = (SELECT StageID FROM BPS_BillProcessingStage WHERE StageName = 'Bill Parking')  and AssignmentTo='" + _userId + "' and [Status] = 1 group by BillTrackingNo)) bal INNER JOIN BPS_BillParking bk on bal.BillTrackingNo = bk.BillTrackingNo LEFT JOIN(SELECT BillTrackingNo, BillParkingID FROM BPS_BillParking where ProcessState = 'BPKD')bkt on bk.BillTrackingNo = bkt.BillTrackingNo WHERE bk.ProcessState = 'BRPK' AND bkt.BillParkingID IS NULL AND bk.BillTrackingNo IS NOT NULL AND bk.EmployeeID = '" + _userId + "' AND (bk.[Status] = 1 OR bk.[Status] IS NULL)";
            //}
            //else
            //{
            //    query = "SELECT bal.BillTrackingNo,bal.BenchMark,bal.OrigineBenchMark,usr.UserID,usr.EmployeeID,usr.UserFullName,ow.UDOwnerCode CompanyCode,ow.OwnerName CompanyName FROM (SELECT BillTrackingNo, DATEDIFF(dd, GETDATE(), BenchMarkEndDate) BenchMark, OrigineBenchMark FROM BPS_BillAssignmentLog WHERE BillAssignmentLogID IN (select MAX(BillAssignmentLogID)BillAssignmentLogID from BPS_BillAssignmentLog WHERE StageNameFrom IN (SELECT StageID FROM BPS_BillProcessingStage WHERE StageName = 'Bill Parking') group by BillTrackingNo )) bal INNER JOIN BPS_BillParking bk on bal.BillTrackingNo = bk.BillTrackingNo LEFT JOIN(SELECT BillTrackingNo, BillParkingID FROM BPS_BillParking where ProcessState = 'BPKD')bkt on bk.BillTrackingNo = bkt.BillTrackingNo LEFT JOIN SEC_User usr ON bk.EmployeeID = usr.UserID LEFT JOIN DSM_Owner ow ON usr.OwnerID = ow.OwnerID WHERE bk.ProcessState = 'BRPK' AND bkt.BillParkingID IS NULL AND bk.BillTrackingNo IS NOT NULL AND usr.ParentUserID = '" + _userId + "' AND usr.ParentUserID != usr.UserID AND(bk.[Status] = 1 OR bk.[Status] IS NULL)";
            //}
            //using (DbCommand dbCommandWrapper = db.GetSqlStringCommand(query))
            //{
            //    DataSet ds = db.ExecuteDataSet(dbCommandWrapper);
            //    if (ds.Tables.Count > 0)
            //    {
            //        if (ds.Tables[0].Rows.Count > 0)
            //        {
            //            DataTable dt1 = ds.Tables[0];

            //            pd = dt1.AsEnumerable().Select(reader => new ParkingForDashbord
            //            {
            //                BillTrackingNo = reader.GetString("BillTrackingNo"),
            //                BenchMark = reader.GetString("BenchMark"),
            //                OrigineBenchMark = reader.GetString("OrigineBenchMark"),
            //                EmployeeID = action == "me" ? "" : reader.GetString("EmployeeID"),
            //                UserID = action == "me" ? "" : reader.GetString("UserID"),
            //                UserName = action == "me" ? "" : reader.GetString("UserFullName"),
            //                CompanyCode = action == "me" ? "" : reader.GetString("CompanyCode"),
            //                CompanyName = action == "me" ? "" : reader.GetString("CompanyName"),
            //            }).ToList();
            //        }
            //    }
            //}
            //return pd;
        }


        public List<ParkingForDashbord> GetPostingForDashbord(string _userId, string action)
        {
            List<ParkingForDashbord> pd = new List<ParkingForDashbord>();
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("GetDashBordPostingInfo"))
            {
                db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.NVarChar, _userId);
                db.AddInParameter(dbCommandWrapper, "@Action", SqlDbType.NVarChar, action);

                DataSet ds = db.ExecuteDataSet(dbCommandWrapper);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt1 = ds.Tables[0];

                        pd = dt1.AsEnumerable().Select(reader => new ParkingForDashbord
                        {
                            BillTrackingNo = reader.GetString("BillTrackingNo"),
                            BenchMark = reader.GetString("BenchMark"),
                            OrigineBenchMark = reader.GetString("OrigineBenchMark"),
                            EmployeeID = action == "me" ? "" : reader.GetString("EmployeeID"),
                            UserID = action == "me" ? "" : reader.GetString("UserID"),
                            UserName = action == "me" ? "" : reader.GetString("UserFullName"),
                            CompanyCode = action == "me" ? "" : reader.GetString("CompanyCode"),
                            CompanyName = action == "me" ? "" : reader.GetString("CompanyName"),
                        }).ToList();
                    }
                }

            }
            return pd;


            //List<ParkingForDashbord> pd = new List<ParkingForDashbord>();
            //DatabaseProviderFactory factory = new DatabaseProviderFactory();
            //SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            //string query = "";

            //if (action == "me")
            //{
            //    query = "SELECT bal.BillTrackingNo,bal.BenchMark,bal.OrigineBenchMark FROM (SELECT BillTrackingNo, DATEDIFF(dd, GETDATE(), BenchMarkEndDate) BenchMark, OrigineBenchMark FROM BPS_BillAssignmentLog WHERE BillAssignmentLogID IN(select MAX(BillAssignmentLogID)BillAssignmentLogID from BPS_BillAssignmentLog WHERE StageNameFrom = (SELECT StageID FROM BPS_BillProcessingStage WHERE StageName = 'Bill Posting') and AssignmentTo='" + _userId + "' and [Status] = 1 group by BillTrackingNo)) bal INNER JOIN BPS_BillPosting bp on bal.BillTrackingNo = bp.BillTrackingNo LEFT JOIN (SELECT BillTrackingNo, BillPostingID FROM BPS_BillPosting where ProcessState = 'BPTD') bpt on bp.BillTrackingNo = bpt.BillTrackingNo WHERE ProcessState = 'BRPT' AND bpt.BillPostingID IS NULL AND bp.BillTrackingNo IS NOT NULL AND bp.EmployeeID = '" + _userId + "' AND(bp.[Status] = 1 OR bp.[Status] IS NULL)";
            //}
            //else
            //{
            //    query = "SELECT bal.BillTrackingNo,bal.BenchMark,bal.OrigineBenchMark,usr.EmployeeID,usr.UserID,usr.UserFullName,ow.UDOwnerCode CompanyCode,ow.OwnerName CompanyName FROM (SELECT BillTrackingNo, DATEDIFF(dd, GETDATE(), BenchMarkEndDate) BenchMark, OrigineBenchMark FROM BPS_BillAssignmentLog WHERE BillAssignmentLogID IN(select MAX(BillAssignmentLogID)BillAssignmentLogID from BPS_BillAssignmentLog WHERE StageNameFrom IN(SELECT StageID FROM BPS_BillProcessingStage WHERE StageName = 'Bill Posting') group by BillTrackingNo)) bal INNER JOIN BPS_BillPosting bp on bal.BillTrackingNo = bp.BillTrackingNo LEFT JOIN (SELECT BillTrackingNo, BillPostingID FROM BPS_BillPosting where ProcessState = 'BPTD') bpt on bp.BillTrackingNo = bpt.BillTrackingNo LEFT JOIN SEC_User usr ON bp.EmployeeID = usr.UserID LEFT JOIN DSM_Owner ow ON usr.OwnerID = ow.OwnerID WHERE bp.ProcessState = 'BRPT' AND bpt.BillPostingID IS NULL AND bp.BillTrackingNo IS NOT NULL AND usr.ParentUserID = '" + _userId + "' AND usr.ParentUserID != usr.UserID AND (bp.[Status] = 1 OR bp.[Status] IS NULL)";
            //}
            //using (DbCommand dbCommandWrapper = db.GetSqlStringCommand(query))
            //{
            //    DataSet ds = db.ExecuteDataSet(dbCommandWrapper);
            //    if (ds.Tables.Count > 0)
            //    {
            //        if (ds.Tables[0].Rows.Count > 0)
            //        {
            //            DataTable dt1 = ds.Tables[0];

            //            pd = dt1.AsEnumerable().Select(reader => new ParkingForDashbord
            //            {
            //                BillTrackingNo = reader.GetString("BillTrackingNo"),
            //                BenchMark = reader.GetString("BenchMark"),
            //                OrigineBenchMark = reader.GetString("OrigineBenchMark"),
            //                EmployeeID = action == "me" ? "" : reader.GetString("EmployeeID"),
            //                UserID = action == "me" ? "" : reader.GetString("UserID"),
            //                UserName = action == "me" ? "" : reader.GetString("UserFullName"),
            //                CompanyCode = action == "me" ? "" : reader.GetString("CompanyCode"),
            //                CompanyName = action == "me" ? "" : reader.GetString("CompanyName"),
            //            }).ToList();
            //        }
            //    }
            //}
            //return pd;
        }

        public List<ParkingForDashbord> GetClearingForDashbord(string userid, string action)
        {
            List<ParkingForDashbord> pd = new List<ParkingForDashbord>();
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("GetDashBordClearingInfo"))
            {
                db.AddInParameter(dbCommandWrapper, "@UserID", SqlDbType.NVarChar, userid);
                db.AddInParameter(dbCommandWrapper, "@Action", SqlDbType.NVarChar, action);
                dbCommandWrapper.CommandTimeout = 300;
                DataSet ds = db.ExecuteDataSet(dbCommandWrapper);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt1 = ds.Tables[0];

                        pd = dt1.AsEnumerable().Select(reader => new ParkingForDashbord
                        {
                            BillTrackingNo = reader.GetString("BillTrackingNo"),
                            BenchMark = reader.GetString("BenchMark"),
                            OrigineBenchMark = reader.GetString("OrigineBenchMark"),
                            EmployeeID = action == "me" ? "" : reader.GetString("EmployeeID"),
                            UserID = action == "me" ? "" : reader.GetString("UserID"),
                            UserName = action == "me" ? "" : reader.GetString("UserFullName"),
                            CompanyCode = action == "me" ? "" : reader.GetString("CompanyCode"),
                            CompanyName = action == "me" ? "" : reader.GetString("CompanyName"),
                        }).ToList();
                    }
                }

            }
            return pd;


            //List<ParkingForDashbord> pd = new List<ParkingForDashbord>();
            //DatabaseProviderFactory factory = new DatabaseProviderFactory();
            //SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            //string query = "";

            //if (action == "me")
            //{
            //    query = "SELECT bal.BillTrackingNo,bal.BenchMark,bal.OrigineBenchMark FROM (SELECT BillTrackingNo, DATEDIFF(dd, GETDATE(), BenchMarkEndDate) BenchMark, OrigineBenchMark FROM BPS_BillAssignmentLog WHERE BillAssignmentLogID IN(select MAX(BillAssignmentLogID)BillAssignmentLogID from BPS_BillAssignmentLog WHERE  StageNameFrom = (SELECT StageID FROM BPS_BillProcessingStage WHERE StageName = 'Bill Clearing') and AssignmentTo='" + userid + "' and [Status] = 1 group by BillTrackingNo)) bal INNER JOIN BPS_BillClearing bp on bal.BillTrackingNo = bp.BillTrackingNo LEFT JOIN (SELECT BillTrackingNo, BillClearingID FROM BPS_BillClearingTrack where ProcessState = 'BCLD' AND (IsReference = 1 OR IsReference IS NULL)) bpt on bp.BillTrackingNo = bpt.BillTrackingNo WHERE ProcessState = 'BRCL' AND bp.BillTrackingNo IS NOT NULL AND bpt.BillClearingID IS NULL AND (bp.IsReference = 1 OR bp.IsReference IS NULL) AND bp.EmployeeID = '" + userid + "' AND(bp.[Status] = 1 OR bp.[Status] IS NULL)";
            //}
            //else
            //{
            //    query = "SELECT bal.BillTrackingNo,bal.BenchMark,bal.OrigineBenchMark,usr.EmployeeID,usr.UserID,usr.UserFullName,ow.UDOwnerCode CompanyCode,ow.OwnerName CompanyName FROM (SELECT BillTrackingNo, DATEDIFF(dd, GETDATE(), BenchMarkEndDate) BenchMark, OrigineBenchMark FROM BPS_BillAssignmentLog WHERE BillAssignmentLogID IN(select MAX(BillAssignmentLogID)BillAssignmentLogID from BPS_BillAssignmentLog WHERE StageNameFrom = (SELECT StageID FROM BPS_BillProcessingStage WHERE StageName = 'Bill Clearing') group by BillTrackingNo)) bal INNER JOIN BPS_BillClearing bp on bal.BillTrackingNo = bp.BillTrackingNo LEFT JOIN (SELECT BillTrackingNo, BillClearingID FROM BPS_BillClearingTrack where ProcessState = 'BCLD' AND (IsReference = 1 OR IsReference IS NULL)) bpt on bp.BillTrackingNo = bpt.BillTrackingNo LEFT JOIN SEC_User usr ON bp.EmployeeID = usr.UserID LEFT JOIN DSM_Owner ow ON usr.OwnerID = ow.OwnerID WHERE ProcessState = 'BRCL' AND bp.BillTrackingNo IS NOT NULL AND bpt.BillClearingID IS NULL AND (bp.IsReference = 1 OR bp.IsReference IS NULL) AND usr.ParentUserID = '" + userid + "' AND usr.ParentUserID != usr.UserID AND(bp.[Status] = 1 OR bp.[Status] IS NULL)";
            //}
            //using (DbCommand dbCommandWrapper = db.GetSqlStringCommand(query))
            //{
            //    DataSet ds = db.ExecuteDataSet(dbCommandWrapper);
            //    if (ds.Tables.Count > 0)
            //    {
            //        if (ds.Tables[0].Rows.Count > 0)
            //        {
            //            DataTable dt1 = ds.Tables[0];

            //            pd = dt1.AsEnumerable().Select(reader => new ParkingForDashbord
            //            {
            //                BillTrackingNo = reader.GetString("BillTrackingNo"),
            //                BenchMark = reader.GetString("BenchMark"),
            //                OrigineBenchMark = reader.GetString("OrigineBenchMark"),
            //                EmployeeID = action == "me" ? "" : reader.GetString("EmployeeID"),
            //                UserID = action == "me" ? "" : reader.GetString("UserID"),
            //                UserName = action == "me" ? "" : reader.GetString("UserFullName"),
            //                CompanyCode = action == "me" ? "" : reader.GetString("CompanyCode"),
            //                CompanyName = action == "me" ? "" : reader.GetString("CompanyName"),
            //            }).ToList();
            //        }
            //    }
            //}
            //return pd;

        }

        public bool IsASuperVisor(string _userId)
        {
            bool isSuperVisor = false;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            using (DbCommand dbCommandWrapper = db.GetSqlStringCommand("SELECT Count(UserID) as Count FROM SEC_User where ParentUserID = '" + _userId + "'"))
            {
                int count = (int)db.ExecuteScalar(dbCommandWrapper);

                if (count > 0)
                {
                    isSuperVisor = true;
                }
            }
            return isSuperVisor;
        }

        public PendingBillsCount GetPendingBillCount(string _userId)
        {
            PendingBillsCount pbc = new PendingBillsCount();
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("CBPS_GetPendingBillCount"))
            {
                DataSet ds = db.ExecuteDataSet(dbCommandWrapper);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt1 = ds.Tables[0];
                        pbc.ParkingCount = Convert.ToInt32(dt1.Rows[0].ItemArray[0]);
                        pbc.PostingCount = Convert.ToInt32(dt1.Rows[0].ItemArray[1]);
                        pbc.ClearingCount = Convert.ToInt32(dt1.Rows[0].ItemArray[2]);
                    }
                }

            }
            return pbc;
        }
    }
}
