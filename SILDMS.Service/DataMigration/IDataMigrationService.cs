using SILDMS.Utillity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Service.DataMigration
{
    public interface IDataMigrationService
    {
        //ValidationResult GetDataMigrationErrorData(DataTable DataMigrationErrorData, out DataTable dt);
        ValidationResult GetDataMigrationErrorData(DataTable DataMigrationErrorData); 
    }
}
