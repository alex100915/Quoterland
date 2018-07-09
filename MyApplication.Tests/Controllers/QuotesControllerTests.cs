using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using MyApplication.App_Start;
using MyApplication.Controllers;
using MyApplication.Core;
using MyApplication.Core.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyApplication.Tests.Controllers
{
    public class QuotesControllerTests
    {
        private QuotesController _controller;
        private Mock<IQuoteRepository> _mockRepository;

        public QuotesControllerTests()
        {
            _mockRepository = new Mock<IQuoteRepository>();

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Quotes).Returns(_mockRepository.Object);

            _controller = new QuotesController(mockUoW.Object);
        }

        [TestMethod]
        public void MyQuotes_UserNotLogged_HttpNotFound()
        {
            _controller.MyQuotes(null);
        }
    }
}
