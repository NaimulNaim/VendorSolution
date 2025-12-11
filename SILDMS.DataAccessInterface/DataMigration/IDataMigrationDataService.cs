using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.DataAccessInterface.DataMigration
{
    public interface IDataMigrationDataService
    {
        DataTable GetDataMigrationErrorData(DataTable DataMigrationErrorData);
    }
}
