using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyApplication.App_Start;
using MyApplication.Controllers.Api;
using MyApplication.Core;
using MyApplication.Core.Dtos;
using MyApplication.Core.Repositories;
using MyApplication.Tests.Extensions;

namespace MyApplication.Tests.Controllers.Api
{
    public class QuotesControllerTestsWithoutLoggedUser
    {
        private QuotesController _controller;
        private Mock<IQuoteRepository> _mockRepository;

        public QuotesControllerTestsWithoutLoggedUser()
        {
            _mockRepository = new Mock<IQuoteRepository>();

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Quotes).Returns(_mockRepository.Object);

            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
        }

        [TestMethod]
        public void CreateNewQuote_UserNotLogged_ShouldReturnUnauthorizedResult()
        {
            var quoteDto = new QuoteDto();
            var result = _controller.CreateNewQuote(quoteDto);
            result.Should().BeOfType<UnauthorizedResult>();
        }
    }
}
