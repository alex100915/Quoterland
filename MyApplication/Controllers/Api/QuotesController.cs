using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using MyApplication.Core.Dtos;
using MyApplication.Core.Models;
using MyApplication.Persistence;

namespace MyApplication.Controllers.Api
{
    public class QuotesController : ApiController
    {
        private readonly UnitOfWork _unitOfWork;

        public QuotesController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult CreateNewQuote(QuoteDto quoteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var quote = Mapper.Map<QuoteDto, Quote>(quoteDto);

            quote.UserId = User.Identity.GetUserId();

            _unitOfWork.Quotes.Add(quote);

            _unitOfWork.Complete();
            return Created(new Uri(Request.RequestUri+"/"+quote.Id),quoteDto);
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
        public IHttpActionResult GetMyQuotes(string userId)
        {
            var myQuotes = _unitOfWork.Quotes.GetAllUserQuotes(userId);
            return Ok(myQuotes);
        }

        public IHttpActionResult GetQuotesByMoviesNames(string moviesNames)
        {
            string[] moviesName = moviesNames.Split(',').ToArray();

            var quotesByMoviesNames = new List<Quote>();

            foreach (var movie in moviesName)
            {
                var quotes = _unitOfWork.Quotes.GetQuotesByMovieTitle(movie);
                quotesByMoviesNames.AddRange(quotes);
            }

            return Ok(quotesByMoviesNames);
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
