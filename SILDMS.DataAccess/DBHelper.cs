using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OracleClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.DataAccess
{
    public class DBHelper
    {
        OracleDBConnection OracleDBConnection = new OracleDBConnection();
        public DataTable GetDataTable(string Qry)
        {
            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(Qry, OracleDBConnection.ConnectionStringRead());
            DataTable dt = new DataTable();
            oracleDataAdapter.Fill(dt);
            return dt;
        }

        public int CmdExecute(string Qry)
        {
            int noOfRows = 0;
            using (OracleConnection con = new OracleConnection(OracleDBConnection.ConnectionStringRead()))
            {
                OracleCommand cmd = new OracleCommand(Qry, con);
                con.Open();
                noOfRows = cmd.ExecuteNonQuery();
            }
            return noOfRows;
        }
        public string GetStatusAndMessage(string fromName, string outParam)
        {
            string status = string.Empty, message = string.Empty;
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDBConnection.ConnectionStringRead()))
                {
                    string OraMsgStsQuery = "SELECT msg_code, msg_value FROM pms_form_msg WHERE submenu_id =" + "'" + fromName + "'" + " AND msg_code= '" + outParam + "'";
                    OracleCommand OracleMsgStscmd = new OracleCommand(OraMsgStsQuery, connection);

                    OracleDataAdapter OracleMDa = new OracleDataAdapter(OracleMsgStscmd);
                    DataTable OracleMDt = new DataTable();
                    OracleMDa.Fill(OracleMDt);
                    if (OracleMDt.Rows.Count > 0)
                    {
                        status = OracleMDt.Rows[0]["msg_code"].ToString();
                        message = OracleMDt.Rows[0]["msg_value"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                status = "101";
                message = ex.InnerException.Message.ToString();
            }
            return status + "-" + message;
        }
    }
}