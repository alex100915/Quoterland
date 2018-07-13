using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using FluentAssertions;
using MyApplication.Controllers.Api;
using MyApplication.Core.Models;
using MyApplication.IntegrationTests.Extensions;
using MyApplication.Persistence;
using NUnit.Framework;

namespace MyApplication.IntegrationTests.Controllers.Api
{
    [TestFixture]
    public class LearningsControllerTests
    {
        private LearningsController _controller;
        private ApplicationDbContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = new ApplicationDbContext();
            _controller = new LearningsController(new UnitOfWork(_context));
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test,Isolated]
        public void AddToLearningQuotes_WhenCalled_ShouldAddQuoteToLearning()
        {
            var user = _context.Users.First();
            _controller.MockCurrentUser(user.Id, user.UserName);

            var quote = new Quote
            {
                Content = "Perfectly valid quote",
                MovieId = 1,
                PhraseToLearn = "Valid Phrase",
                UserId = user.Id,
                YoutubeLink = "https://www.youtube.com/watch?v=3nQNiWdeH2Q"
            };

            _context.Quotes.Add(quote);
            _context.SaveChanges();

            var quoteId = _context.Quotes.First().Id;

            var result = _controller.AddToLearningQuotes(quoteId);

            result.Should().BeOfType<OkResult>();
            _context.Learnings.First().QuoteId.ShouldBeEquivalentTo(quoteId);
        }

        [Test, Isolated]
        public void GetLearningQuotes_WhenCalled_ShouldReturnUserLearningQuotes()
        {
            var user = _context.Users.First();
            _controller.MockCurrentUser(user.Id, user.UserName);

            var quote = new Quote
            {
                Content = "Perfectly valid quote",
                MovieId = 1,
                PhraseToLearn = "Valid Phrase",
                UserId = user.Id,
                YoutubeLink = "https://www.youtube.com/watch?v=3nQNiWdeH2Q"
            };

            _context.Quotes.Add(quote);
            _context.SaveChanges();

            var quoteId = _context.Quotes.First().Id;

            _controller.AddToLearningQuotes(quoteId);

            IEnumerable<Learning> learnings = new List<Learning> { _context.Learnings.First() };

            var result = _controller.GetLearningQuotes();

            result.Should().BeOfType<OkNegotiatedContentResult<IEnumerable<Learning>>>().Which.Content.ShouldBeEquivalentTo(learnings);
        }

        [Test, Isolated]
        public void DeleteFromLearningQuotes_WhenCalled_ShouldDeleteQuoteFromLearningQuotes()
        {
            var user = _context.Users.First();
            _controller.MockCurrentUser(user.Id, user.UserName);

            var quote = new Quote
            {
                Content = "Perfectly valid quote",
                MovieId = 1,
                PhraseToLearn = "Valid Phrase",
                UserId = user.Id,
                YoutubeLink = "https://www.youtube.com/watch?v=3nQNiWdeH2Q"
            };

            _context.Quotes.Add(quote);
            _context.SaveChanges();

            var quoteId = _context.Quotes.First().Id;

            _controller.AddToLearningQuotes(quoteId);

            var result = _controller.DeleteFromLearningQuotes(quoteId);

            result.Should().BeOfType<OkNegotiatedContentResult<byte>>().Which.Content.ShouldBeEquivalentTo(quoteId);
            _context.Learneds.SingleOrDefault(q => q.QuoteId == quoteId).ShouldBeEquivalentTo(null);
        }
    }
}
