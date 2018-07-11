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
    public class LearningsControllerTests
    {
        private LearningsController _controller;
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

            _controller = new LearningsController(mockUoW.Object);
            _controller.MockCurrentUser("1", "user1@domain.com");
        }

        [TestMethod]
        public void AddToLearningQuotes_QuoteWithGivenIdNotExists_ShouldReturnBadRequest()
        {
            var quote = new Quote();

            _mockQuoteRepository.Setup(r => r.GetQuoteById(1)).Returns(quote);

            var result=_controller.AddToLearningQuotes(2);

            result.Should().BeOfType<BadRequestResult>();
        }

        [TestMethod]
        public void AddToLearningQuotes_ValidRequest_ShouldReturnOk()
        {
            var quote = new Quote();

            _mockQuoteRepository.Setup(r => r.GetQuoteById(1)).Returns(quote);

            var result = _controller.AddToLearningQuotes(1);

            result.Should().BeOfType<OkResult>();
        }

        [TestMethod]
        public void AddToLearningQuotes_QuoteExistsInLearnings_ShouldReturnBadRequest()
        {
            var quote = new Quote();

            _mockQuoteRepository.Setup(r => r.GetQuoteById(1)).Returns(quote);

            _mockLearnedRepository.Setup(r => r.CheckQuoteExistsInLearnedList(1, "1")).Returns(true);

            var result = _controller.AddToLearningQuotes(1);

            result.Should().BeOfType<BadRequestResult>();
        }

        [TestMethod]
        public void AddToLearningQuotes_QuoteIsAlreadyAtLearnedList_ShouldReturnBadRequest()
        {
            var quote = new Quote();

            _mockQuoteRepository.Setup(r => r.GetQuoteById(1)).Returns(quote);

            _mockLearningRepository.Setup(r => r.CheckQuoteExistsInLearnings(1, "1")).Returns(true);

            var result = _controller.AddToLearningQuotes(1);

            result.Should().BeOfType<BadRequestResult>();
        }

        [TestMethod]
        public void GetLearningQuotes_ValidRequest_ShouldReturnOk()
        {
            IEnumerable<Learning> quotes = new List<Learning>();

            _mockLearningRepository.Setup(r => r.GetUserLearningQuotes("1")).Returns(quotes);

            var result = _controller.GetLearningQuotes();

            result.Should().BeOfType<OkNegotiatedContentResult<IEnumerable<Learning>>>();
        }

        [TestMethod]
        public void DeleteFromLearningQuotes_QuoteDoesntExists_ShouldReturnBadRequest()
        {
            var quote = new Learning();

            _mockLearningRepository.Setup(r => r.GetUserLearningQuoteById(1,"1")).Returns(quote);

            var result = _controller.DeleteFromLearningQuotes(2);

            result.Should().BeOfType<BadRequestResult>();
        }
    }    
}
