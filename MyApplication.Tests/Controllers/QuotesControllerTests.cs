using System.Collections.Generic;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using FluentAssertions;
using Moq;
using MyApplication.Controllers;
using MyApplication.Core;
using MyApplication.Core.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyApplication.Core.Models;
using MyApplication.Tests.Extensions;

namespace MyApplication.Tests.Controllers
{
    [TestClass]
    public class QuotesControllerTests
    {
        private QuotesController _controller;
        private Mock<IMovieRepository> _mockRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new Mock<IMovieRepository>();

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Movies).Returns(_mockRepository.Object);

            _controller = new QuotesController(mockUoW.Object);
        }

        [TestMethod]
        public void New_ValidRequest_ShouldReturnViewResult()
        {
            IEnumerable<Movie> movies = new List<Movie>();
            _mockRepository.Setup(r => r.GetAllMovies()).Returns(movies);

            var result = _controller.New();

            result.Should().BeOfType<ViewResult>();
        }

        [TestMethod]
        public void FindQuotes_WhenCalledWithAuthenticatedUser_ShouldReturnAllQuotesView()
        {
            _controller.MockCurrentUser("1", "user1@domain.com");

            var moviesName = "I am looking for quotes";

            var result = _controller.FindQuotes(moviesName);

            result.ViewName.ShouldAllBeEquivalentTo("AllQuotes");
            (result.ViewData.Model as string).ShouldBeEquivalentTo(moviesName);
        }

        [TestMethod]
        public void FindQuotes_WhenCalledWithoutAuthenticatedUser_ShouldReturnAllQuotesForAnonymousView()
        {
            var identity = new GenericIdentity("");
            var principal = new GenericPrincipal(identity, null);

            _controller.ControllerContext = Mock.Of<ControllerContext>(ctx =>
                ctx.HttpContext == Mock.Of<HttpContextBase>(http => http.User == principal));

            var moviesName = "I am looking for quotes";
            var result = _controller.FindQuotes(moviesName);

            result.ViewName.ShouldAllBeEquivalentTo("AllQuotesForAnonymous");
            (result.ViewData.Model as string).ShouldBeEquivalentTo(moviesName);
        }

        [TestMethod]
        public void AllQuotes_WhenCalledWithAuthenticatedUser_ShouldReturnAllQuotesView()
        {
            _controller.MockCurrentUser("1", "user1@domain.com");

            var result = _controller.AllQuotes();

            result.Should().BeOfType<ViewResult>();
        }

        [TestMethod]
        public void AllQuotes_WhenCalledWithoutAuthenticatedUser_ShouldReturnAllQuotesForAnonymousView()
        {
            var identity = new GenericIdentity("");
            var principal = new GenericPrincipal(identity, null);

            _controller.ControllerContext = Mock.Of<ControllerContext>(ctx =>
                ctx.HttpContext == Mock.Of<HttpContextBase>(http => http.User == principal));

            var result = _controller.AllQuotes();

            result.ViewName.ShouldAllBeEquivalentTo("AllQuotesForAnonymous");
        }

        [TestMethod]
        public void MyQuotes_WhenCalledWithAuthenticatedUser_ShouldReturnMyQuotesView()
        {
            _controller.MockCurrentUser("1", "user1@domain.com");

            var result = _controller.MyQuotes();

            result.Should().BeOfType<ViewResult>();
        }
    }
}
