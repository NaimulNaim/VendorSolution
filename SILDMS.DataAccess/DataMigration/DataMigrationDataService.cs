using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using SILDMS.DataAccessInterface.DataMigration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.DataAccess.DataMigration
{
    public class DataMigrationDataService : IDataMigrationDataService
    {
        public DataTable GetDataMigrationErrorData(DataTable DataMigrationErrorData)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("TestCBPS_MigrData"))
            {
                dbCommandWrapper.CommandTimeout = 300;

                var ds = db.ExecuteDataSet(dbCommandWrapper);
                DataTable dt1 = ds.Tables[0];
                return dt1;
            }
        }
    }
}
