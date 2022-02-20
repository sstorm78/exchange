using FluentAssertions;
using LondonExchange.Api.Controllers;
using LondonExchange.Models;
using LondonExchange.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace LondonExchange.Api.Tests.Controllers
{
    [TestFixture]
    public class StocksControllerShould
    {
        private Mock<IStockService> _mockStockService;

        [SetUp]
        public void Setup()
        {
            _mockStockService = new Mock<IStockService>();
        }

        [Test]
        public void GetSingle_Should_Return_Stock_Details()
        {
            var response = new List<KeyValuePair<string, decimal>> { new KeyValuePair<string, decimal>("A",20)};

            _mockStockService.Setup(i => i.GetStockValues(It.IsAny<List<string>>()))
                .Returns(response);

            var controller = new StocksController(_mockStockService.Object);

            var result = controller.GetSingle("A");

            ((ObjectResult)result).StatusCode.Should().Be((int)HttpStatusCode.OK);

            var objectResult = result as OkObjectResult;
            objectResult.Should().NotBeNull();

            var details = objectResult.Value as StockModel;

            details.Should().NotBeNull();
            details.Symbol.Should().Be("A");
            details.Value.Should().Be(20);
        }

        [Test]
        public void GetList_Should_Return_Two_Stock_Details()
        {
            var response = new List<KeyValuePair<string, decimal>> { new KeyValuePair<string, decimal>("A", 20), new KeyValuePair<string, decimal>("B", 20) };

            _mockStockService.Setup(i => i.GetStockValues(It.IsAny<List<string>>()))
                .Returns(response);

            var controller = new StocksController(_mockStockService.Object);

            var result = controller.GetList("A,B");

            ((ObjectResult)result).StatusCode.Should().Be((int)HttpStatusCode.OK);

            var objectResult = result as OkObjectResult;
            objectResult.Should().NotBeNull();

            var details = objectResult.Value as List<StockModel>;

            details.Should().NotBeNull();
            details.First().Symbol.Should().Be("A");
            details.First().Value.Should().Be(20);
            details.Last().Symbol.Should().Be("B");
            details.Last().Value.Should().Be(20);
        }
    }
}
