using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApplication.Core;
using MyApplication.Core.Models;
using MyApplication.Persistence;

namespace MyApplication.Controllers
{
    [Authorize(Roles = "CanManageMovies")]
    public class MoviesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            dynamic myModel = new ExpandoObject();
            myModel.ProductionTypes = _unitOfWork.ProductionTypes.GetAllProductionTypes();
            myModel.Genres = _unitOfWork.Genres.GetAllGenres();

            return View(myModel);
        }
    }
}