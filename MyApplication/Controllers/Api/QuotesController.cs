using System;
using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MyApplication.Core;
using MyApplication.Core.Dtos;
using MyApplication.Core.Models;

namespace MyApplication.Controllers.Api
{
    public class QuotesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuotesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult CreateNewQuote(QuoteDto quoteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userId = User.Identity.GetUserId();

            if (userId == null)
                return Unauthorized();

            quoteDto.UserId= User.Identity.GetUserId();

            var quote = Mapper.Map<QuoteDto, Quote>(quoteDto);

            _unitOfWork.Quotes.Add(quote);

            _unitOfWork.Complete();

            return Created(new Uri(Request.RequestUri + "/" + quote.Id), quoteDto);
        }
        
        [HttpGet]
        public IHttpActionResult GetAllQuotes()
        {
            var allQuotes = _unitOfWork.Quotes.GetAllQuotesInDatabase();

            var allQuotesDto = allQuotes
                .Select(Mapper.Map<Quote, QuoteDto>);

            return Ok(allQuotesDto);
        }

        [HttpGet]
        [Route("api/quotes/mine")]
        public IHttpActionResult GetMyQuotes()
        {
            var userId = User.Identity.GetUserId();

            if (userId == null)
                return Unauthorized();

            var myQuotes = _unitOfWork.Quotes.GetAllUserQuotes(userId).Select(Mapper.Map<Quote, QuoteDto>);

            return Ok(myQuotes);
        }

        public IHttpActionResult GetQuotesByMoviesNames(string moviesNames)
        {
            moviesNames=moviesNames.Replace("singleQuote", "'");
            string[] moviesName = moviesNames.Split(',').ToArray();

            var quotesByMoviesNames = new List<Quote>();

            foreach (var movie in moviesName)
            {
                var quotesForCurrentMovie = _unitOfWork.Quotes.GetQuotesByMovieTitle(movie);
                quotesByMoviesNames.AddRange(quotesForCurrentMovie);
            }
            var result=quotesByMoviesNames.Select(Mapper.Map<Quote, QuoteDto>);

            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetQuote(int id)
        {          
            var quote = _unitOfWork.Quotes.GetQuoteById(id);

            if (quote == null)
                return NotFound();

            var quoteDto = Mapper.Map<Quote, QuoteDto>(quote);

            return Ok(quoteDto);
        }

        [HttpDelete]
        public IHttpActionResult DeleteQuote(int id)
        {
            var quoteInDb = _unitOfWork.Quotes.GetQuoteById(id);

            if (quoteInDb == null)
                return NotFound();

            _unitOfWork.Quotes.Remove(quoteInDb);
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
