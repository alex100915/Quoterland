using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web.Http.Results;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using MyApplication.Core;
using MyApplication.Core.Models;
using MyApplication.Persistence;

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

        public ViewResult AllQuotes(string moviesName=null)
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("AllQuotes", model: moviesName);
            }
            return View("AllQuotesForAnonymous", model: moviesName);
        }

        public ViewResult FindQuotes()
        {
            dynamic myModel = new ExpandoObject();

            myModel.Movies = _unitOfWork.Movies.GetAllMovies();
            myModel.Genres = _unitOfWork.Genres.GetAllGenres();

            return View(myModel);
        }

        public ViewResult Detail(int id)
        {
            return View(id);
        }
    }
}