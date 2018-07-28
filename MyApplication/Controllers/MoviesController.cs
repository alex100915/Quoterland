using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApplication.Core;
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
            ApplicationDbContext _context=new ApplicationDbContext();
            var productionTypes = _context.ProductionTypes.ToList();
            var genres = _context.Genres.ToList();

            dynamic myModel = new ExpandoObject();
            myModel.ProductionTypes = productionTypes;
            myModel.Genres = genres;

            return View(myModel);
        }
    }
}