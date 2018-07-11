using System.Collections.Generic;
using System.Web.Mvc;
using FluentAssertions;
using Moq;
using MyApplication.Controllers;
using MyApplication.Core;
using MyApplication.Core.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyApplication.Core.Models;

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
    }
}
