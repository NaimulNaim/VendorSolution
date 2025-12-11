using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.DataAccess
{
    public class OracleDBConnection
    {
        string connectionString = "";
        public OracleDBConnection()
        {
            ConnectionStringRead();
        }

        public string ConnectionStringRead()
        {
            connectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ToString();
            return connectionString;
        }
    }
}
