using Microsoft.AspNet.Identity;
using System.Web.Http;
using MyApplication.Core.Models;
using MyApplication.Persistence;

namespace MyApplication.Controllers.Api
{
    public class LearningsController : ApiController
    {
        private readonly UnitOfWork _unitOfWork;

        public LearningsController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

            if (_unitOfWork.Learneds.CheckQuoteExistsInLearnedList(id,userId))
                return BadRequest();

            _unitOfWork.Learnings.Add(quote);

            _unitOfWork.Complete();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetLearningQuotes()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userId = User.Identity.GetUserId();

            var quotes = _unitOfWork.Learnings.GetUserLearningQuotes(userId);

            return Ok(quotes);
        }

        [HttpDelete]
        public IHttpActionResult DeleteFromLearningQuotes(byte id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var quote = _unitOfWork.Learnings.GetUserLearningQuoteById(id, User.Identity.GetUserId());

            _unitOfWork.Learnings.Remove(quote);

            _unitOfWork.Complete();

            return Ok(id);
        }
    }
}
