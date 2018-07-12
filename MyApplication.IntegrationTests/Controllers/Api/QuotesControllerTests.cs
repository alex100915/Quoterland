using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using AutoMapper;
using FluentAssertions;
using MyApplication.App_Start;
using MyApplication.Core.Dtos;
using MyApplication.Core.Models;
using MyApplication.IntegrationTests.Extensions;
using MyApplication.Persistence;
using NUnit.Framework;
using QuotesController = MyApplication.Controllers.Api.QuotesController;

namespace MyApplication.IntegrationTests.Controllers.Api
{
    [TestFixture]
    public class QuotesControllerTests
    {
        private QuotesController _controller;
        private ApplicationDbContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = new ApplicationDbContext();
            _controller = new QuotesController(new UnitOfWork(_context));

            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test,Isolated]
        public void CreateNewQuote_WhenCalled_ShouldCreateNewQuote()
        {
            var user = _context.Users.First();
            _controller.MockCurrentUser(user.Id, user.UserName);

            var quoteDto = new QuoteDto
            {
                Content = "Perfectly valid quote",
                MovieId = 1,
                PhraseToLearn = "Valid Phrase",
                UserId = user.Id,
                YoutubeLink = "https://www.youtube.com/watch?v=3nQNiWdeH2Q"
            };
            _controller.CreateNewQuote(quoteDto);

            _context.Quotes.Should().Contain(q=>q.Content=="Perfectly valid quote");
        }

        [Test, Isolated]
        public void GetAllQuotes_WhenCalled_ShouldReturnQuotes()
        {
            //Arrange
            var user = _context.Users.First();
            _controller.MockCurrentUser(user.Id, user.UserName);

            var movie = _context.Movies.Single(m => m.Id == 1);

            var quote1 = new Quote
            {
                Content = "Perfectly valid quote",
                MovieId = 1,
                Movie = movie,
                PhraseToLearn = "Valid Phrase",
                UserId = user.Id,
                YoutubeLink = "https://www.youtube.com/watch?v=3nQNiWdeH2Q"
            };

            var quote2 = new Quote
            {
                Content = "Another perfectly valid quote",
                MovieId = 1,
                Movie = movie,
                PhraseToLearn = "Valid Phrase",
                UserId = user.Id,
                YoutubeLink = "https://www.youtube.com/watch?v=3nQNiWdeH2Q"
            };

            IEnumerable<Quote> quotes=new List<Quote> {quote1,quote2};

            _context.Quotes.AddRange(quotes);
            _context.SaveChanges();

            var quoteDtos = _context.Quotes.
                Where(q=>q.Content== "Perfectly valid quote" || q.Content=="Another perfectly valid quote")
                .ToList()
                .Select(Mapper.Map<Quote, QuoteDto>);
            
            //Act
            var result =_controller.GetAllQuotes();
            
            //Assert
            result.Should().BeOfType<OkNegotiatedContentResult<IEnumerable<QuoteDto>>>().Which.Content.ShouldAllBeEquivalentTo(quoteDtos);
        }
    }
}
