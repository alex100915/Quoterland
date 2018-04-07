using AutoMapper;
using Microsoft.AspNet.Identity;
using MyApplication.Dtos;
using MyApplication.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyApplication.Controllers.Api
{
    public class QuotesController : ApiController
    {
        private ApplicationDbContext _context;

        public QuotesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewQuote(QuoteDto quoteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var quote = Mapper.Map<QuoteDto, Quote>(quoteDto);
            quote.UserId = User.Identity.GetUserId();
            _context.Quotes.Add(quote);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri+"/"+quote.Id),quoteDto);
        }

        [HttpGet]
        public IHttpActionResult GetAllQuotes()
        {            
            var allQuotes = _context.Quotes;

            var allQuotesDto = allQuotes
                .ToList()
                .Select(Mapper.Map<Quote, QuoteDto>);

            return Ok(allQuotesDto);
        }

        [HttpGet]
        public IHttpActionResult GetMyQuotes(string userId)
        {
            var myQuotes = _context.Quotes.Where(q => q.UserId == userId).ToList();
            return Ok(myQuotes);
        }

        public IHttpActionResult GetQuotesByMoviesNames(string moviesNames)
        {

            string[] moviesName = moviesNames.Split(',').ToArray();
            List<Quote> quotesByMoviesNames = new List<Quote>();
            foreach (var movie in moviesName)
            {
                var quotes = _context.Quotes.Where(q => q.MovieName == movie);
                foreach (var quote in quotes)
                {
                    quotesByMoviesNames.Add(quote);
                }
            }
            return Ok(quotesByMoviesNames);
        }

        public IHttpActionResult GetQuote(int id)
        {          
            var quote = _context.Quotes.SingleOrDefault(q=>q.Id==id);

            if (quote == null)
                return NotFound();
            var quoteDto = Mapper.Map<Quote, QuoteDto>(quote);

            return Ok(quoteDto);
        }

        public IHttpActionResult DeleteQuote(int id)
        {
            var quoteInDb = _context.Quotes.SingleOrDefault(c => c.Id == id);

            if (quoteInDb == null)
                return NotFound();

            _context.Quotes.Remove(quoteInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
