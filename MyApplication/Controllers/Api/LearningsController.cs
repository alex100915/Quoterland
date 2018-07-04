using Microsoft.AspNet.Identity;
using MyApplication.Dtos;
using MyApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyApplication.Controllers.Api
{
    public class LearningsController : ApiController
    {
        ApplicationDbContext _context;

        public LearningsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();    
        }

        [HttpPost]
        public IHttpActionResult AddToLearningQuotes(byte id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userId = User.Identity.GetUserId();

            var quote = new Learning
            {
                ApplicationUserId = userId,
                QuoteId = id
            };

            if (_context.Learneds.Any(q => q.ApplicationUserId == userId && q.QuoteId == id))
                return BadRequest();

            _context.Learnings.Add(quote);

            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetLearningQuotes()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userId = User.Identity.GetUserId();

            var quotes = _context.Learnings.Where(l => l.ApplicationUserId == userId).ToList();
            List<Quote> returnedlist = new List<Quote>();
            foreach (var quote in quotes)
            {
                returnedlist.Add(_context.Quotes.Single(q => q.Id == quote.QuoteId));
            }

            return Ok(returnedlist);
        }

        [HttpDelete]
        public IHttpActionResult DeleteFromLearningQuotes(byte id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userId = User.Identity.GetUserId();

            var quote=_context.Learnings.Single(q => q.QuoteId == id && q.ApplicationUserId==userId);

            _context.Learnings.Remove(quote);

            _context.SaveChanges();

            return Ok(id);
        }
    }
}
