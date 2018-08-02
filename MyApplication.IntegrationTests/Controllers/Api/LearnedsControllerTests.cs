using System.Collections.Generic;
using System.Linq;
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
    public class LearnedsControllerTests
    {
        private LearnedsController _controller;
        private ApplicationDbContext _context;

        [SetUp]
        public void SetUp()
        {
            _context=new ApplicationDbContext();
            _controller=new LearnedsController(new UnitOfWork(_context));
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test,Isolated]
        public void AddToLearnedQuotes_WhenCalled_ShouldAddQuoteToLearned()
        {
            var user = _context.Users.First();
            _controller.MockCurrentUser(user.Id,user.UserName);

            var quote = new Quote
            {
                Content = "Perfectly valid quote",
                MovieId = _context.Movies.First().Id,
                PhraseToLearn = "Valid Phrase",
                UserId = user.Id,
                YoutubeLink = "https://www.youtube.com/watch?v=3nQNiWdeH2Q"
            };

            _context.Quotes.Add(quote);
            _context.SaveChanges();

            var quoteId = _context.Quotes.First().Id;

            var result = _controller.AddToLearnedQuotes(quoteId);

            result.Should().BeOfType<OkResult>();
            _context.Learneds.First().QuoteId.ShouldBeEquivalentTo(quoteId);
        }

        [Test,Isolated]
        public void GetLearnedQuotes_WhenCalled_ShouldReturnUserLearnedQuotes()
        {
            var user = _context.Users.First();
            _controller.MockCurrentUser(user.Id, user.UserName);

            var quote = new Quote
            {
                Content = "Perfectly valid quote",
                MovieId = _context.Movies.First().Id,
                PhraseToLearn = "Valid Phrase",
                UserId = user.Id,
                YoutubeLink = "https://www.youtube.com/watch?v=3nQNiWdeH2Q"
            };

            _context.Quotes.Add(quote);
            _context.SaveChanges();

            var quoteId = _context.Quotes.First().Id;

            _controller.AddToLearnedQuotes(quoteId);

            IEnumerable<Learned> learneds=new List<Learned> { _context.Learneds.First()};

            var result = _controller.GetLearnedQuotesIds();

            result.Should().BeOfType<OkNegotiatedContentResult<IEnumerable<Learned>>>().Which.Content.ShouldBeEquivalentTo(learneds);
        }

        [Test,Isolated]
        public void DeleteFromLearnedQuotes_WhenCalled_ShouldDeleteQuoteFromLearnedQuotes()
        {
            var user = _context.Users.First();
            _controller.MockCurrentUser(user.Id, user.UserName);

            var quote = new Quote
            {
                Content = "Perfectly valid quote",
                MovieId = _context.Movies.First().Id,
                PhraseToLearn = "Valid Phrase",
                UserId = user.Id,
                YoutubeLink = "https://www.youtube.com/watch?v=3nQNiWdeH2Q"
            };

            _context.Quotes.Add(quote);
            _context.SaveChanges();

            var quoteId = _context.Quotes.First().Id;

            _controller.AddToLearnedQuotes(quoteId);

            var result = _controller.DeleteFromLearnedQuotes(quoteId);

            result.Should().BeOfType<OkNegotiatedContentResult<int>>().Which.Content.ShouldBeEquivalentTo(quoteId);
            _context.Learneds.SingleOrDefault(q=>q.QuoteId==quoteId).ShouldBeEquivalentTo(null);
        }
    }
}
