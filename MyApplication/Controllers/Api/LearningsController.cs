using Microsoft.AspNet.Identity;
using System.Web.Http;
using MyApplication.Core;
using MyApplication.Core.Models;
using MyApplication.Persistence;

namespace MyApplication.Controllers.Api
{
    public class LearningsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public LearningsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpPost]
        [Route("api/learnings/addtolearningquotes/{id}/{translation}")]
        public IHttpActionResult AddToLearningQuotes(int id, string translation)
        {
            var userId = User.Identity.GetUserId();

            if (_unitOfWork.Quotes.GetQuoteById(id) == null)
                return BadRequest();

            if (_unitOfWork.Learnings.CheckQuoteExistsInLearnings(id, userId))
                return BadRequest();

            var quote = new Learning
            {
                ApplicationUserId = userId,
                QuoteId = id,
                Translation = translation
            };

            _unitOfWork.Learnings.Add(quote);
            
            _unitOfWork.Complete();

            return Ok();
        }
        [HttpPost]
        [Route("api/learnings/movetolearningstable/{id}")]
        public IHttpActionResult MoveToLearningsTable(int id)
        {
            var userId = User.Identity.GetUserId();

            if (!_unitOfWork.Learneds.CheckQuoteExistsInLearnedList(id, userId))
                return BadRequest();

            var quoteToDelete = _unitOfWork.Learneds.GetUserLearnedQuoteById(id, userId);

            var quoteToAdd = new Learning
            {
                ApplicationUserId = userId,
                QuoteId = id,
                Translation = quoteToDelete.Translation
            };

            _unitOfWork.Learnings.Add(quoteToAdd);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetLearningQuotes()
        {
            var userId = User.Identity.GetUserId();

            var quotes = _unitOfWork.Learnings.GetUserLearningQuotes(userId);

            return Ok(quotes);
        }

        [HttpGet]
        [Route("api/learnings/getlearningsquotesids")]
        public IHttpActionResult GetLearningQuotesIds()
        {
            var userId = User.Identity.GetUserId();

            var quotes = _unitOfWork.Learnings.GetUserLearningQuotesIds(userId);

            return Ok(quotes);
        }

        //[HttpGet]
        //[Route("api/learnings/getlearningquotes")]
        //public IHttpActionResult GetLearningQuotes()
        //{
        //    var userId = User.Identity.GetUserId();

        //    if (userId == null)
        //        return Unauthorized();

        //    var quotes = _unitOfWork.Quotes.GetUserLearningQuotes(userId);

        //    return Ok(quotes);
        //}

        [HttpDelete]
        public IHttpActionResult DeleteFromLearningQuotes(int id)
        {
            var userId = User.Identity.GetUserId();

            var quote = _unitOfWork.Learnings.GetUserLearningQuoteById(id,userId);

            if (quote == null)
                return BadRequest();

            _unitOfWork.Learnings.Remove(quote);

            _unitOfWork.Complete();

            return Ok(id);
        }
    }
}
