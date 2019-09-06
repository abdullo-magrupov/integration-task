using Synel.DAL.Repositories;
using Synel.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Synel.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeRepository repo;

        public EmployeeController()
        {
            repo = new EmployeeRepository();
        }

        public ActionResult Index()
        {
            LogHelper.Info("Employee list view");
            return View(repo.GetAll().OrderBy(x => x.LastName).ToList());
        }
    }
}