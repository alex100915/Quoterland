using Microsoft.AspNet.Identity;
using MyApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApplication.Persistence;

namespace MyApplication.Controllers
{
    public class QuotesController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public QuotesController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Quotes
        public ActionResult New()
        {
            var movies = _unitOfWork.Movies.GetAllMovies();
            return View(model:movies);
        }

        [Authorize]
        public ActionResult MyQuotes(string id)
        {
            id = User.Identity.GetUserId();
            return View(model:id);
        }

        public ActionResult AllQuotes()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return View("AllQuotesForAnonymous");
        }

        public ActionResult FindQuotes(string moviesName)
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("AllQuotes", model: moviesName);
            }
            return View("AllQuotesForAnonymous", model: moviesName);
        }

        public ActionResult Detail(int id)
        {
            return View(id);
        }
    }
}