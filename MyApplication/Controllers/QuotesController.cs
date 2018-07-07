using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using MyApplication.Core;

namespace MyApplication.Controllers
{
    public class QuotesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuotesController(IUnitOfWork unitOfWork)
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