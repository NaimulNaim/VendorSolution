using SILDMS.DataAccessInterface.ResendFailedSmsEmail;
//using SILDMS.Model.CheckPrintModule;
using SILDMS.Utillity;
using SILDMS.Utillity.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Service.ResendFailedSmsEmail
{
    public class ResendFailedSmsEmailService : IResendFailedSmsEmailService
    {
        //#region Fields

        //private readonly IResendFailedSmsEmailDataService resendFailedSmsEmailDataService;
        //private readonly ILocalizationService localizationService;
        //private string status = "";
        //private string _errorNumber = string.Empty;
        //#endregion

        //#region Constractor
        //public ResendFailedSmsEmailService(IResendFailedSmsEmailDataService repository, ILocalizationService localizationService)
        //{
        //    this.resendFailedSmsEmailDataService = repository;
        //    this.localizationService = localizationService;
        //    _errorNumber = string.Empty;
        //}

        //#endregion

        //public ValidationResult GetBills(string OwnerID, string OpType, string BillType, string VendorCode, int page, int itemsPerPage, string sortBy, bool reverse, string VendorName, string Company, string ClearingNo, out List<SmsEmailSend> bills)
        //{
        //    bills = resendFailedSmsEmailDataService.GetBills(OwnerID, OpType, BillType, VendorCode, page, itemsPerPage, sortBy, reverse, VendorName, Company, ClearingNo, out _errorNumber);
        //    return _errorNumber.Length > 0
        //        ? new ValidationResult(_errorNumber, localizationService.GetResource(_errorNumber))
        //        : ValidationResult.Success;
        //}


        //public ValidationResult GetBillsByDate(string OwnerID, string OpType, string BillType, string VendorCode, string FDate, string EDtae, int page, int itemsPerPage, string sortBy, bool reverse, string VendorName, string Company, string ClearingNo, out List<SmsEmailSend> bills)
        //{
        //    bills = resendFailedSmsEmailDataService.GetBillsByDate(OwnerID, OpType, BillType, VendorCode, FDate, EDtae, page, itemsPerPage, sortBy, reverse, VendorName, Company, ClearingNo, out _errorNumber);
        //    return _errorNumber.Length > 0
        //        ? new ValidationResult(_errorNumber, localizationService.GetResource(_errorNumber))
        //        : ValidationResult.Success;
        //}
    }
}
