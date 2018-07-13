using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
                Id=1,
                Content = "Perfectly valid quote",
                MovieId = 1,
                PhraseToLearn = "Valid Phrase",
                UserId = user.Id,
                YoutubeLink = "https://www.youtube.com/watch?v=3nQNiWdeH2Q"
            };
            _controller.Request = new HttpRequestMessage()
            {
                RequestUri = new Uri("http://http://localhost:55966//api/quotes/" + quoteDto.Id)
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

            IEnumerable<Quote> quotes=new List<Quote> {new Quote
            {
                Content = "Perfectly valid quote",
                MovieId = 1,
                PhraseToLearn = "Valid Phrase",
                UserId = user.Id,
                YoutubeLink = "https://www.youtube.com/watch?v=3nQNiWdeH2Q"
            },new Quote
            {
                Content = "Another perfectly valid quote",
                MovieId = 1,
                PhraseToLearn = "Valid Phrase",
                UserId = user.Id,
                YoutubeLink = "https://www.youtube.com/watch?v=3nQNiWdeH2Q"
            }};

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

        [Test, Isolated]
        public void GetMyQuotes_WhenCalled_ShouldReturnUserQuotes()
        {
            //Arrange
            var user = _context.Users.OrderBy(u=>u.UserName).First();
            var user2 = _context.Users.OrderByDescending(u=>u.UserName).First();

            _controller.MockCurrentUser(user.Id, user.UserName);

            IEnumerable<Quote> quotes = new List<Quote> {new Quote
            {
                Content = "Quote for current user",
                MovieId = 1,
                PhraseToLearn = "Valid Phrase",
                UserId = user.Id,
                YoutubeLink = "https://www.youtube.com/watch?v=3nQNiWdeH2Q"
            },new Quote
            {
                Content = "Quote for another user",
                MovieId = 1,
                PhraseToLearn = "Valid Phrase",
                UserId = user2.Id,
                YoutubeLink = "https://www.youtube.com/watch?v=3nQNiWdeH2Q"
            }};

            _context.Quotes.AddRange(quotes);
            _context.SaveChanges();

            var quoteDtos = _context.Quotes.
                Where(q => q.UserId==user.Id)
                .ToList()
                .Select(Mapper.Map<Quote, QuoteDto>);

            //Act
            var result = _controller.GetMyQuotes();

            //Assert
            result.Should().BeOfType<OkNegotiatedContentResult<IEnumerable<QuoteDto>>>().Which.Content.ShouldAllBeEquivalentTo(quoteDtos);
        }

        [Test, Isolated]
        public void GetQuotesByMoviesNames_WhenCalled_ShouldReturnAppropriateQuotes()
        {
            //Arrange
            var user = _context.Users.First();
            _controller.MockCurrentUser(user.Id, user.UserName);

            IEnumerable<Quote> quotes = new List<Quote> {new Quote
            {
                Content = "This quote is going to be returned",
                MovieId = 1,
                PhraseToLearn = "Valid Phrase",
                UserId = user.Id,
                YoutubeLink = "https://www.youtube.com/watch?v=3nQNiWdeH2Q"
            },new Quote
            {
                Content = "This quote is going to be returned too",
                MovieId = 2,
                PhraseToLearn = "Valid Phrase",
                UserId = user.Id,
                YoutubeLink = "https://www.youtube.com/watch?v=3nQNiWdeH2Q"
            },new Quote
                {
                    Content = "This quote too...",
                    MovieId = 2,
                    PhraseToLearn = "Valid Phrase",
                    UserId = user.Id,
                    YoutubeLink = "https://www.youtube.com/watch?v=3nQNiWdeH2Q"
                },new Quote
                {
                    Content = "...but this quote is not",
                    MovieId = 3,
                    PhraseToLearn = "Valid Phrase",
                    UserId = user.Id,
                    YoutubeLink = "https://www.youtube.com/watch?v=3nQNiWdeH2Q"
                }};

            _context.Quotes.AddRange(quotes);
            _context.SaveChanges();

            //Act
            var movie1 = _context.Movies.Single(m=>m.Id==1).Title;
            var movie2 = _context.Movies.Single(m=>m.Id==2).Title;
            var movie3 = "Title which not exists in database";

            var result = _controller.GetQuotesByMoviesNames(movie1+","+movie2+","+movie3);

            var quoteDtos = _context.Quotes.
                Where(q=>q.MovieId==1 || q.MovieId==2)
                .ToList()
                .Select(Mapper.Map<Quote, QuoteDto>);

            //Assert
            result.Should().BeOfType<OkNegotiatedContentResult<IEnumerable<QuoteDto>>>().Which.Content.ShouldAllBeEquivalentTo(quoteDtos);
        }

        [Test, Isolated]
        public void GetQuoteById_WhenCalled_ShouldReturnQuote()
        {
            //Arrange
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

            var quoteFromDatabaseId = _context.Quotes.Single(q => q.Content == "Perfectly valid quote").Id;

            var quoteFromDatabase = _context.Quotes.Single(q => q.Id==quoteFromDatabaseId);

            var quoteDto=Mapper.Map<Quote, QuoteDto>(quoteFromDatabase);

            //Act
            var result = _controller.GetQuote(quoteFromDatabaseId);

            //Assert
            result.Should().BeOfType<OkNegotiatedContentResult<QuoteDto>>().Which.Content.ShouldBeEquivalentTo(quoteDto);
        }

        [Test, Isolated]
        public void DeleteQuote_WhenCalled_ShouldDeleteQuote()
        {
            //Arrange
            var user = _context.Users.First();
            _controller.MockCurrentUser(user.Id, user.UserName);

            var quote = new Quote
            {
                Content = "This quote is going to be deleted",
                MovieId = 1,
                PhraseToLearn = "Valid Phrase",
                UserId = user.Id,
                YoutubeLink = "https://www.youtube.com/watch?v=3nQNiWdeH2Q"
            };

            _context.Quotes.Add(quote);
            _context.SaveChanges();

            var quoteFromDatabaseId = _context.Quotes.Single(q => q.Content == "This quote is going to be deleted").Id;

            //Act
            var result = _controller.DeleteQuote(quoteFromDatabaseId);

            //Assert
            result.Should().BeOfType<OkResult>();
            _context.Quotes.SingleOrDefault(q => q.Id == quoteFromDatabaseId).Should().Be(null);
        }
    }
}
