using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.UI.WebControls;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyApplication.App_Start;
using MyApplication.Controllers.Api;
using MyApplication.Core;
using MyApplication.Core.Dtos;
using MyApplication.Core.Models;
using MyApplication.Core.Repositories;
using MyApplication.Tests.Extensions;
using RouteParameter = System.Web.Http.RouteParameter;

namespace MyApplication.Tests.Controllers.Api
{
    [TestClass]
    public class QuotesControllerTests
    {
        private QuotesController _controller;
        private Mock<IQuoteRepository> _mockRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new Mock<IQuoteRepository>();

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Quotes).Returns(_mockRepository.Object);

            _controller = new QuotesController(mockUoW.Object);
            _controller.MockCurrentUser("1","user1@domain.com");

            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
        }

        [TestMethod]
        public void CreateNewQuote_ValidRequest_ShouldReturnOkResult()
        {
            var quoteDto = new QuoteDto();
            var quote = Mapper.Map<QuoteDto, Quote>(quoteDto);

            _controller.Request = new HttpRequestMessage()
            {
                RequestUri = new Uri("http://http://localhost:55966//api/quotes/" + quote.Id)
            };

            var result = _controller.CreateNewQuote(quoteDto);

            result.Should().BeOfType<CreatedNegotiatedContentResult<QuoteDto>>();
        }

        [TestMethod]
        public void GetAllQuotes_ValidRequest_ShouldReturnOk()
        {
            var result = _controller.GetAllQuotes();

            result.Should().BeOfType<OkNegotiatedContentResult<IEnumerable<QuoteDto>>>();
        }

        [TestMethod]
        public void GetQuotesByMoviesNames_MoviesNamesAreInvalid_ShouldReturnOkWithEmptyColletion()
        {
            var validMoviesNames = "Valid, Movie, Names";

            var unvalidMoviesNames = "Unvalid, Movie, Names";

            IEnumerable<Quote> quotes = new List<Quote>();

            _mockRepository.Setup(r => r.GetQuotesByMovieTitle(validMoviesNames)).Returns(quotes);

            var result = _controller.GetQuotesByMoviesNames(unvalidMoviesNames);

            result.Should().BeOfType<OkNegotiatedContentResult<IEnumerable<QuoteDto>>>().Which.Content.Count().ShouldBeEquivalentTo(0);

        }

        [TestMethod]
        public void GetQuotesByMoviesNames_ValidRequest_ShouldReturnOkWithCollection()
        {
            var validMoviesNames = "Valid, Movie, Names";

            IEnumerable<Quote> quotes = new List<Quote> {new Quote()};

            _mockRepository.Setup(r => r.GetQuotesByMovieTitle(validMoviesNames)).Returns(quotes);

            var result = _controller.GetQuotesByMoviesNames(validMoviesNames);

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
            var quote = new Quote();
            _mockRepository.Setup(r => r.GetQuoteById(1)).Returns(quote);

            var result = _controller.GetQuote(1);

            result.Should().BeOfType<OkNegotiatedContentResult<QuoteDto>>();
        }

        [TestMethod]
        public void MyQuotes_ValidRequest_ShouldReturnOkNegotiatedContedResult()
        {
            IEnumerable<Quote> quotes = new List<Quote>();

            _mockRepository.Setup(r => r.GetAllUserQuotes("1")).Returns(quotes);

            var result = _controller.GetMyQuotes();

            result.Should().BeOfType<OkNegotiatedContentResult<IEnumerable<QuoteDto>>>();
        }
    }
}
