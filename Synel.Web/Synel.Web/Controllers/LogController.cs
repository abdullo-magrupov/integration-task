using Synel.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Synel.Web.Controllers
{
    public class LogController : Controller
    {
        private LogRepository repo;

        public LogController()
        {
            repo = new LogRepository();
        }

        public ActionResult Index()
        {
            return View(repo.GetAll().OrderByDescending(x => x.LogDate).ToList());
        }
    }
}