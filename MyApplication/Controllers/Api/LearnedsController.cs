using AutoMapper;
using Microsoft.AspNet.Identity;
using MyApplication.Dtos;
using MyApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace MyApplication.Controllers.Api
{
    public class LearnedsController : ApiController
    {
        private ApplicationDbContext _context;

        public LearnedsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        public IHttpActionResult AddToLearnedQuotes(QuoteDto quoteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userId = User.Identity.GetUserId();

            _context.Learneds.Where(l => l.ApplicationUserId == userId).ToList();

            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetLearnedQuotes()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userId = User.Identity.GetUserId();

            var quotes=_context.Learneds.Where(l => l.ApplicationUserId == userId).ToList();
            List<Quote> returnedlist = new List<Quote>();
            foreach (var quote in quotes)
            {
                returnedlist.Add(_context.Quotes.Single(q => q.Id == quote.QuoteId));
            }

            return Ok(returnedlist);
        }
    }
}
