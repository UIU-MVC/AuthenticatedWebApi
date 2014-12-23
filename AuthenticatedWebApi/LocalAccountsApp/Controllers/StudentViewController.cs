using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocalAccountsApp.Controllers
{
    public class StudentViewController : Controller
    {
        // GET: StudentView
        public ActionResult Index()
        {
            return View();
        }
    }
}