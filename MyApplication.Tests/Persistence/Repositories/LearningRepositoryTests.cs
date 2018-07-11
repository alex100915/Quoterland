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
    public class LearningRepositoryTests
    {
        private Mock<DbSet<Learning>> _mockLearnings;

        private LearningRepository _repository;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockLearnings = new Mock<DbSet<Learning>>();


            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.SetupGet(c => c.Learnings).Returns(_mockLearnings.Object);


            _repository = new LearningRepository(mockContext.Object);
        }

        [TestMethod]
        public void CheckQuoteExistsInLearningList_QuoteNotExists_ShouldReturnFalse()
        {
            var quote = new Learning() { ApplicationUserId = "1", QuoteId = 1 };

            _mockLearnings.SetSource(new[] { quote });

            var result = _repository.CheckQuoteExistsInLearnings(2, "1");

            result.Should().BeFalse();
        }

        [TestMethod]
        public void CheckQuoteExistsInLearningList_QuoteExistsButUserIsDifferent_ShouldReturnFalse()
        {
            var quote = new Learning() { ApplicationUserId = "1", QuoteId = 1 };

            _mockLearnings.SetSource(new[] { quote });

            var result = _repository.CheckQuoteExistsInLearnings(1, "2");

            result.Should().BeFalse();
        }

        [TestMethod]
        public void CheckQuoteExistsInLearningList_QuoteExists_ShouldReturnTrue()
        {
            var quote = new Learning() { ApplicationUserId = "1", QuoteId = 1 };

            _mockLearnings.SetSource(new[] { quote });

            var result = _repository.CheckQuoteExistsInLearnings(1, "1");

            result.Should().BeTrue();
        }

        [TestMethod]
        public void GetUserLearningQuoteById_QuoteNotExists_ShouldNotBeReturned()
        {
            var quote = new Learning() { ApplicationUserId = "1", QuoteId = 1 };

            _mockLearnings.SetSource(new[] { quote });

            var result = _repository.GetUserLearningQuoteById(2, "1");

            result.Should().BeNull();
        }

        [TestMethod]
        public void GetUserLearningQuoteById_QuoteExistsButUserIsDifferent_ShouldNotBeReturned()
        {
            var quote = new Learning() { ApplicationUserId = "1", QuoteId = 1 };

            _mockLearnings.SetSource(new[] { quote });

            var result = _repository.GetUserLearningQuoteById(1, "2");

            result.Should().BeNull();
        }

        [TestMethod]
        public void GetUserLearningQuoteById_ValidRequest_ShouldReturnQuote()
        {
            var quote = new Learning() { ApplicationUserId = "1", QuoteId = 1 };

            _mockLearnings.SetSource(new[] { quote });

            var result = _repository.GetUserLearningQuoteById(1, "1");

            result.ShouldBeEquivalentTo(quote);
        }
    }
}
