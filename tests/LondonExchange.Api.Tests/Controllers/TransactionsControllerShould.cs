using FluentAssertions;
using LondonExchange.Api.Controllers;
using LondonExchange.Models;
using LondonExchange.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Net;
using System.Threading.Tasks;

namespace LondonExchange.Api.Tests.Controllers
{
    [TestFixture]
    public class TransactionsControllerShould
    {
        private Mock<ITransactionService> _mockTransactionService;

        [SetUp]
        public void Setup()
        {
            _mockTransactionService = new Mock<ITransactionService>();
        }

        [Test]
        public async Task Post_Should_Return_Created_Result()
        {
            var request = new TransactionModel();

            var response = Guid.NewGuid();

            _mockTransactionService.Setup(i => i.Store(It.IsAny<TransactionModel>()))
                .Returns(response);

            var controller = new TransactionsController(_mockTransactionService.Object);

            var result = controller.Post(request);

            _mockTransactionService.Verify(i => i.Store(It.IsAny<TransactionModel>()), Times.Once);

            ((CreatedResult)result).StatusCode.Should().Be((int)HttpStatusCode.Created);
            ((CreatedResult)result).Location.Should().Be($"http://localhost:5000/transactions/{response}");
        }
    }
}
