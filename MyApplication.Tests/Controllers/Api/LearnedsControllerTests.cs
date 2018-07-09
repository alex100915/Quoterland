using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyApplication.Controllers.Api;
using MyApplication.Core;
using MyApplication.Core.Repositories;
using MyApplication.Tests.Extensions;

namespace MyApplication.Tests.Controllers.Api
{
    [TestClass]
    public class LearnedsControllerTests
    {
        private LearnedsController _controller;
        private Mock<IQuoteRepository> _mockRepository;

        public LearnedsControllerTests()
        {
            _mockRepository = new Mock<IQuoteRepository>();

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Quotes).Returns(_mockRepository.Object);

            _controller = new LearnedsController(mockUoW.Object);
            _controller.MockCurrentUser("1", "user1@domain.com");
        }

        [TestMethod]
        public void MyTestMethod()
        {

        }
    }    
}
