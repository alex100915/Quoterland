using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MyApplication.Core;
using MyApplication.Core.Models;
using MyApplication.Persistence;

namespace MyApplication.Controllers.Api
{
    public class LearnedsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public LearnedsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult AddToLearnedQuotes(byte id)
        {
            if (_unitOfWork.Quotes.GetQuoteById(id) == null)
                return BadRequest();

            var userId = User.Identity.GetUserId();

            if (_unitOfWork.Learnings.CheckQuoteExistsInLearnings(id, userId))
                return BadRequest();

            if (_unitOfWork.Learneds.CheckQuoteExistsInLearnedList(id, userId))
                return BadRequest();

            _unitOfWork.Learneds.Add(new Learned
            {
                ApplicationUserId = userId,
                QuoteId = id
            });

            _unitOfWork.Complete();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetLearnedQuotes()
        {
            var quotes = _unitOfWork.Learneds.GetUserLearnedQuotes(User.Identity.GetUserId());

            return Ok(quotes);
        }

        [HttpDelete]
        public IHttpActionResult DeleteFromLearnedQuotes(byte id)
        {
            var userId = User.Identity.GetUserId();

            var quote = _unitOfWork.Learneds.GetUserLearnedQuoteById(id, userId);

            if (quote == null)
                return BadRequest();

            _unitOfWork.Learneds.Remove(quote);

            _unitOfWork.Complete();

            return Ok(id);
        }
    }
}
