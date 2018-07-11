using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyApplication.Core.Models;
using MyApplication.Persistence;
using MyApplication.Persistence.Repositories;
using MyApplication.Tests.Extensions;
using FluentAssertions;

namespace MyApplication.Tests.Persistence.Repositories
{
    [TestClass]
    public class QuoteRepositoryTests
    {
        private Mock<DbSet<Quote>> _mockQuotes;
        private QuoteRepository _repository;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockQuotes = new Mock<DbSet<Quote>>();

            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.SetupGet(c => c.Quotes).Returns(_mockQuotes.Object);
            

            _repository=new QuoteRepository(mockContext.Object);

        }

        [TestMethod]
        public void GetQuotesByMovieTitle_TitleIsNotExists_ShouldNotBeReturned()
        {
            string invalidTitle = "NotExistingTitle";

            string validTitle = "ValidTitle";

            var quote =  new Quote() { Movie = new Movie {Title = validTitle }};

            _mockQuotes.SetSource(new[] { quote });

            var result = _repository.GetQuotesByMovieTitle(invalidTitle);

            result.Should().BeEmpty();
        }

        [TestMethod]
        public void GetQuotesByMovieTitle_ValidMovieTitle_QuotesShouldBeReturned()
        {
            var validTitle = "ValidTitle";

            var quote = new Quote() { Movie = new Movie { Title = validTitle } };

            _mockQuotes.SetSource(new[] { quote });

            var result = _repository.GetQuotesByMovieTitle(validTitle);

            result.Should().Contain(quote);
        }

        [TestMethod]
        public void GetAllUserQuotes_QuotesAreForDifferentUser_ShouldNotBeReturned()
        {
            var quote = new Quote() { UserId="1"};

            _mockQuotes.SetSource(new[] { quote });

            var result = _repository.GetAllUserQuotes("2");

            result.Should().NotContain(quote);
        }

        [TestMethod]
        public void GetAllUserQuotes_ValidRequest_ShouldReturnedQuotes()
        {
            var quote = new Quote() { UserId = "1" };

            _mockQuotes.SetSource(new[] { quote });

            var result = _repository.GetAllUserQuotes("1");

            result.Should().Contain(quote);
        }
        [TestMethod]
        public void GetQuoteById_QuoteWithGivenIdDoesntExists_ShouldNotBeReturned()
        {
            var quote = new Quote() { Id=1};

            _mockQuotes.SetSource(new[] { quote });

            var result = _repository.GetQuoteById(2);

            result.Should().BeNull();
        }

        [TestMethod]
        public void GetQuoteById_ValidRequest_ShouldBeReturned()
        {
            var quote = new Quote() { Id = 1 };

            _mockQuotes.SetSource(new[] { quote });

            var result = _repository.GetQuoteById(1);

            result.ShouldBeEquivalentTo(quote);
        }
    }
}
