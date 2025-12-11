using SILDMS.DataAccessInterface.DataMigration;
using SILDMS.Utillity;
using SILDMS.Utillity.Localization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Service.DataMigration
{
    public class DataMigrationService : IDataMigrationService
    {
        #region Fields

        private readonly IDataMigrationDataService _dataMigrationService;
        //private readonly ILocalizationService _localizationService;
        //private string _errorNumber = string.Empty;

        #endregion

        #region Constructor

        public DataMigrationService(IDataMigrationDataService dataMigrationService)
        {
            _dataMigrationService = dataMigrationService;
            //_localizationService = localizationService;
        }

        #endregion
        //public ValidationResult GetDataMigrationErrorData(DataTable DataMigrationErrorData, out DataTable dt)
        //{
        //    dt = _dataMigrationService.GetDataMigrationErrorData(DataMigrationErrorData);
        //    //if (_errorNumber.Length > 0)
        //    //{
        //    //    return new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber));
        //    //}
        //    return ValidationResult.Success;
        //}

        public ValidationResult GetDataMigrationErrorData(DataTable DataMigrationErrorData)
        {
            DataTable dt = _dataMigrationService.GetDataMigrationErrorData(DataMigrationErrorData);
            //if (_errorNumber.Length > 0)
            //{
            //    return new ValidationResult(_errorNumber, _localizationService.GetResource(_errorNumber));
            //}
            return ValidationResult.Success;
        }
    }
}
