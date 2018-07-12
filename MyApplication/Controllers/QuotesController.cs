using System.Web.Http.Results;
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
        [Authorize]
        public ViewResult New()
        {
            var movies = _unitOfWork.Movies.GetAllMovies();
            return View(model:movies);
        }

        [Authorize]
        public ViewResult MyQuotes()
        {
            return View();
        }

        public ViewResult AllQuotes()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return View("AllQuotesForAnonymous");
        }

        public ViewResult FindQuotes(string moviesName)
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("AllQuotes", model: moviesName);
            }
            return View("AllQuotesForAnonymous", model: moviesName);
        }

        public ViewResult Detail(int id)
        {
            return View(id);
        }
    }
}