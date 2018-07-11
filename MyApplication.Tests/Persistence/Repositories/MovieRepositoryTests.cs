using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyApplication.Core.Models;
using MyApplication.Persistence;
using MyApplication.Persistence.Repositories;
using MyApplication.Tests.Extensions;

namespace MyApplication.Tests.Persistence.Repositories
{
    [TestClass]
    public class MovieRepositoryTests
    {
        private Mock<DbSet<Movie>> _mockMovies;
        private MovieRepository _repository;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockMovies = new Mock<DbSet<Movie>>();

            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.SetupGet(c => c.Movies).Returns(_mockMovies.Object);


            _repository = new MovieRepository(mockContext.Object);
        }
        [TestMethod]
        public void GetAllMovies_ValidRequest_ShouldReturnMovie()
        {
            var movie = new Movie();

            _mockMovies.SetSource(new[] {movie});

            var result = _repository.GetAllMovies();

            result.Should().Contain(movie);
        }
    }
}
