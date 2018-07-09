using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
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

            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
        }

        [TestMethod]
        public void CreateNewQuote_Validrequest_ShouldReturnOkResult()
        {

            var quoteDto = new QuoteDto();

            var result = _controller.CreateNewQuote(quoteDto);

            result.Should().BeOfType<OkResult>();
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
            var unvalidMoviesNames = "The Office";

            IEnumerable<Quote> quotes = new List<Quote>();

            _mockRepository.Setup(r => r.GetQuotesByMovieTitle(unvalidMoviesNames)).Returns(quotes);

            var result = _controller.GetQuotesByMoviesNames(unvalidMoviesNames);

            //result.Should().BeOfType<OkNegotiatedContentResult<IEnumerable<QuoteDto>>>().Which.Content.Count().ShouldBeEquivalentTo(1);

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
    }
}
