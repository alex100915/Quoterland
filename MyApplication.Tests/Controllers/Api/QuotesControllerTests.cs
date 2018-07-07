using System.Collections.Generic;
using System.Web.Http.Results;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyApplication.Controllers.Api;
using MyApplication.Core;
using MyApplication.Core.Dtos;
using MyApplication.Core.Models;
using MyApplication.Core.Repositories;
using MyApplication.Tests.Extensions;

namespace MyApplication.Tests.Controllers.Api
{
    [TestClass]
    public class QuotesControllerTests
    {
        private QuotesController _controller;
        private Mock<IQuoteRepository> _mockRepository;

        public QuotesControllerTests()
        {
            _mockRepository = new Mock<IQuoteRepository>();

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Quotes).Returns(_mockRepository.Object);

            _controller = new QuotesController(mockUoW.Object);
            _controller.MockCurrentUser("1","user1@domain.com");
        }

        //[TestMethod]
        //public void CreateNewQuote_UserIdIsNull_ShouldReturnNotAuthorized()
        //{
        //    var unvalidUser = new ApplicationUserDto { Id = null };
        //    var result = _controller.CreateNewQuote(new QuoteDto { Content = "This is valid quote", PhraseToLearn = "This is valid phrase to learn", Id = 5, MovieId = 3, YoutubeLink = "https://www.youtube.com/" });

        //    result.Should().BeOfType<AutoMapperMappingException>();
        //}

        [TestMethod]
        public void GetAllQuotes_ValidRequest_ShouldReturnOk()
        {
            var result = _controller.GetAllQuotes();

            result.Should().BeOfType<OkNegotiatedContentResult<IEnumerable<QuoteDto>>>();
        }

        [TestMethod]
        public void GetQuotesByMoviesNames_MoviesNamesAreInvalid_ShouldReturnOkWithEmptyColletion()
        {
            var unvalidMoviesNames = "The Office";

            var result = _controller.GetQuotesByMoviesNames(unvalidMoviesNames);

            //result.Should().BeOfType<OkNegotiatedContentResult<List<Quote>>>().Which.Content.Count().ShouldBeEquivalentTo(1);

            result.Should().BeOfType<OkNegotiatedContentResult<IEnumerable<QuoteDto>>>();
        }

        [TestMethod]
        public void DeleteQuote_QuoteDoesntExists_ShouldReturnHttpNotFound()
        {
            var quote = new Quote {Id = 1};

            _mockRepository.Setup(r => r.GetQuoteById(1)).Returns(quote);

            var result = _controller.DeleteQuote(2);

            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void DeleteQuote_ValidRequest_ShouldReturnOk()
        {
            var quote = new Quote();

            _mockRepository.Setup(r => r.GetQuoteById(1)).Returns(quote);

            var result = _controller.DeleteQuote(1);

            result.Should().BeOfType<OkResult>();
        }

        [TestMethod]
        public void GetQuote_QuoteDoesntExists_ShouldReturnHttpNotFound()
        {
            var quote = new Quote();

            _mockRepository.Setup(r => r.GetQuoteById(1)).Returns(quote);

            var result = _controller.GetQuote(2);

            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void GetQuote_ValidRequest_ShouldReturnOkNegotiatedContedResult()
        {
            var quote = new Quote
            {
                Content = "This is valid quote",
                Id = 1,
                MovieId = 2,
                PhraseToLearn = "Valid phrase",
                UserId = "1",
                YoutubeLink = "https://www.youtube.com/watch?v=3nQNiWdeH2Q"
            };

            _mockRepository.Setup(r => r.GetQuoteById(1)).Returns(quote);

            var result = _controller.GetQuote(1);

            result.Should().BeOfType<OkNegotiatedContentResult<QuoteDto>>();
        }
    }
}
