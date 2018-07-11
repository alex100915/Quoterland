using System.Data.Entity;
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
    public class LearnedRepositoryTests
    {
        private Mock<DbSet<Learned>> _mockLearneds;

        private LearnedRepository _repository;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockLearneds = new Mock<DbSet<Learned>>();


            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.SetupGet(c => c.Learneds).Returns(_mockLearneds.Object);


            _repository = new LearnedRepository(mockContext.Object);
        }

        [TestMethod]
        public void CheckQuoteExistsInLearnedList_QuoteNotExists_ShouldReturnFalse()
        {
            var quote=new Learned() {ApplicationUserId = "1",QuoteId = 1};

            _mockLearneds.SetSource(new[] {quote});

            var result = _repository.CheckQuoteExistsInLearnedList(2, "1");

            result.Should().BeFalse();
        }

        [TestMethod]
        public void CheckQuoteExistsInLearnedList_QuoteExistsButUserIsDifferent_ShouldReturnFalse()
        {
            var quote = new Learned() { ApplicationUserId = "1", QuoteId = 1 };

            _mockLearneds.SetSource(new[] { quote });

            var result = _repository.CheckQuoteExistsInLearnedList(1, "2");

            result.Should().BeFalse();
        }

        [TestMethod]
        public void CheckQuoteExistsInLearnedList_QuoteExists_ShouldReturnTrue()
        {
            var quote = new Learned() { ApplicationUserId = "1", QuoteId = 1 };

            _mockLearneds.SetSource(new[] { quote });

            var result = _repository.CheckQuoteExistsInLearnedList(1, "1");

            result.Should().BeTrue();
        }

        [TestMethod]
        public void GetUserLearnedQuoteById_QuoteNotExists_ShouldNotBeReturned()
        {
            var quote = new Learned() { ApplicationUserId = "1", QuoteId = 1 };

            _mockLearneds.SetSource(new[] { quote });

            var result = _repository.GetUserLearnedQuoteById(2, "1");

            result.Should().BeNull();
        }

        [TestMethod]
        public void GetUserLearnedQuoteById_QuoteExistsButUserIsDifferent_ShouldNotBeReturned()
        {
            var quote = new Learned() { ApplicationUserId = "1", QuoteId = 1 };

            _mockLearneds.SetSource(new[] { quote });

            var result = _repository.GetUserLearnedQuoteById(1, "2");

            result.Should().BeNull();
        }

        [TestMethod]
        public void GetUserLearnedQuoteById_ValidRequest_ShouldReturnQuote()
        {
            var quote = new Learned() { ApplicationUserId = "1", QuoteId = 1 };

            _mockLearneds.SetSource(new[] { quote });

            var result = _repository.GetUserLearnedQuoteById(1, "1");

            result.ShouldBeEquivalentTo(quote);
        }

    }
}
