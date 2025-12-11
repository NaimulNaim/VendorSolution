using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SILDMS.Model.VendorSelectionModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SILDMS.DataAccess;
using System.Threading.Tasks;

namespace SILDMS.Web.UI.Areas.VendorSelectionModule.Controllers
{
    public class TemporaryRegistrationController : Controller
    {

        // GET: VendorSelectionModule/TemporaryRegistration
        public ActionResult Index()
        {
            return View();
        }


        private readonly string _spStatusParam;
        public TemporaryRegistrationController()
        {
            _spStatusParam = "@p_Status";
        }


    }
}