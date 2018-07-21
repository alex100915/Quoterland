using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AutoMapper;
using MyApplication.Core;
using MyApplication.Core.Dtos;
using MyApplication.Core.Models;
using NUnit.Framework;

namespace MyApplication.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public MoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IHttpActionResult GetAllMovies()
        {
            var allMovies = _unitOfWork.Movies.GetAllMovies();

            return Ok(allMovies);
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _unitOfWork.Movies.GetMovieById(id);

            if (movieInDb == null)
                return NotFound();

            _unitOfWork.Movies.Remove(movieInDb);
            _unitOfWork.Complete();

            return Ok();
        }

        public HttpResponseMessage Post()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;

            // Check if files are available
            if (httpRequest.Files.Count > 0)
            {
                var files = new List<string>();

                string imageName = "";

                // interate the files and save on the server
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    imageName = postedFile.FileName;
                    var filePath = HttpContext.Current.Server.MapPath("~/images/" + imageName);
                    postedFile.SaveAs(filePath);

                    files.Add(filePath);
                }
                var movie = new Movie { Title = imageName.Replace(".jpg", "") };

                _unitOfWork.Movies.Add(movie);
                _unitOfWork.Complete();

                result = Request.CreateResponse(HttpStatusCode.Created, files);
            }
            else
            {
                // return BadRequest (no file(s) available)
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return result;
        }
    }
}
