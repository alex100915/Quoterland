using Microsoft.AspNet.Identity;
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
    }
}
