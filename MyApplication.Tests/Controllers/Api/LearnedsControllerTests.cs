using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyApplication.Controllers.Api;
using MyApplication.Core;
using MyApplication.Core.Models;
using MyApplication.Core.Repositories;
using MyApplication.Tests.Extensions;

namespace MyApplication.Tests.Controllers.Api
{
    [TestClass]
    public class LearnedsControllerTests
    {
        private LearnedsController _controller;
        private Mock<IQuoteRepository> _mockQuoteRepository;
        private Mock<ILearnedRepository> _mockLearnedRepository;
        private Mock<ILearningRepository> _mockLearningRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockQuoteRepository = new Mock<IQuoteRepository>();
            _mockLearnedRepository = new Mock<ILearnedRepository>();
            _mockLearningRepository = new Mock<ILearningRepository>();


            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Quotes).Returns(_mockQuoteRepository.Object);
            mockUoW.SetupGet(u => u.Learneds).Returns(_mockLearnedRepository.Object);
            mockUoW.SetupGet(u => u.Learnings).Returns(_mockLearningRepository.Object);

            _controller = new LearnedsController(mockUoW.Object);
            _controller.MockCurrentUser("1", "user1@domain.com");
        }

        [TestMethod]
        public void AddToLearnedQuotes_QuoteWithGivenIdNotExists_ShouldReturnBadRequest()
        {
            var quote = new Quote();

            _mockQuoteRepository.Setup(r => r.GetQuoteById(1)).Returns(quote);

            var result=_controller.AddToLearnedQuotes(2);

            result.Should().BeOfType<BadRequestResult>();
        }

        [TestMethod]
        public void AddToLearnedQuotes_ValidRequest_ShouldReturnOk()
        {
            var quote = new Quote();

            _mockQuoteRepository.Setup(r => r.GetQuoteById(1)).Returns(quote);

            var result = _controller.AddToLearnedQuotes(1);

            result.Should().BeOfType<OkResult>();
        }

        [TestMethod]
        public void AddToLearnedQuotes_QuoteExistsInLearnings_ShouldReturnBadRequest()
        {
            var quote = new Quote();

            _mockQuoteRepository.Setup(r => r.GetQuoteById(1)).Returns(quote);

            _mockLearningRepository.Setup(r => r.CheckQuoteExistsInLearnings(1, "1")).Returns(true);

            var result = _controller.AddToLearnedQuotes(1);

            result.Should().BeOfType<BadRequestResult>();
        }

        [TestMethod]
        public void AddToLearnedQuotes_QuoteIsAlreadyAtLearnedList_ShouldReturnBadRequest()
        {
            var quote = new Quote();

            _mockQuoteRepository.Setup(r => r.GetQuoteById(1)).Returns(quote);

            _mockLearnedRepository.Setup(r => r.CheckQuoteExistsInLearnedList(1, "1")).Returns(true);

            var result = _controller.AddToLearnedQuotes(1);

            result.Should().BeOfType<BadRequestResult>();
        }

        [TestMethod]
        public void GetLearnedQuotes_ValidRequest_ShouldReturnOk()
        {
            IEnumerable<Learned> quotes = new List<Learned>();

            _mockLearnedRepository.Setup(r => r.GetUserLearnedQuotesIds("1")).Returns(quotes);

            var result = _controller.GetLearnedQuotesIds();

            result.Should().BeOfType<OkNegotiatedContentResult<IEnumerable<Learned>>>();
        }

        [TestMethod]
        public void DeleteFromLearnedQuotes_QuoteDoesntExists_ShouldReturnBadRequest()
        {
            var quote = new Learned();

            _mockLearnedRepository.Setup(r => r.GetUserLearnedQuoteById(1,"1")).Returns(quote);

            var result = _controller.DeleteFromLearnedQuotes(2);

            result.Should().BeOfType<BadRequestResult>();
        }

        [TestMethod]
        public void DeleteFromLearnedQuotes_ValidRequest_ShouldReturnOkResult()
        {
            var quote = new Learned();

            _mockLearnedRepository.Setup(r => r.GetUserLearnedQuoteById(1, "1")).Returns(quote);

            var result = _controller.DeleteFromLearnedQuotes(1);

            result.Should().BeOfType<OkNegotiatedContentResult<int>>();
        }
    }    
}
