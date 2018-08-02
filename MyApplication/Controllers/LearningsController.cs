using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApplication.Controllers
{
    public class LearningsController : Controller
    {
        // GET: Learnings
        public ActionResult Index()
        {
            return View();
        }
    }
}