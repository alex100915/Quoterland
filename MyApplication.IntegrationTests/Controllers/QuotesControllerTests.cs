using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using FluentAssertions;
using Moq;
using MyApplication.Controllers;
using MyApplication.Core.Models;
using MyApplication.IntegrationTests.Extensions;
using MyApplication.Persistence;
using NUnit.Framework;

namespace MyApplication.IntegrationTests.Controllers
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
            _controller=new QuotesController(new UnitOfWork(_context));
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test,Isolated]
        public void New_WhenCalled_ShouldReturnNewViewWithListOfMovies()
        {
            var user = _context.Users.First();

            _controller.MockCurrentUser(user.Id,user.UserName);
            var movies = _context.Movies.Count();

            var result = _controller.New();

            (result.ViewData.Model as IEnumerable<Movie>).Should().HaveCount(movies);
            result.Should().BeOfType<ViewResult>();
        }
    }
}
