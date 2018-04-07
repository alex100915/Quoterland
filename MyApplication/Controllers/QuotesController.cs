using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApplication.Controllers
{
    public class QuotesController : Controller
    {
        // GET: Quotes
        public ActionResult New()
        {
            return View();
        }

        [Authorize]
        public ActionResult MyQuotes(string id)
        {
            id = User.Identity.GetUserId();
            return View(model:id);
        }

        public ActionResult AllQuotes()
        {
            return View();
        }

        public ActionResult FindQuotes(string moviesName)
        {
            return View(model:moviesName);
        }

        public ActionResult Detail(int id)
        {
            int Id = id;
            return View(Id);
        }
    }
}