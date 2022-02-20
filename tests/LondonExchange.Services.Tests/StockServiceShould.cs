using FluentAssertions;
using LondonExchange.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LondonExchange.Services.Tests
{
    [TestFixture]
    public class StockServiceShould
    {
        private IDbContext _dbContext;

        [SetUp]
        public void SetUp()
        {
            _dbContext = new DbContext();

            _dbContext.Stocks.Add(new Data.Entities.Stock { Symbol = "A", Price = 10, LastUpdated = DateTime.UtcNow });
            _dbContext.Stocks.Add(new Data.Entities.Stock { Symbol = "B", Price = 20, LastUpdated = DateTime.UtcNow });
            _dbContext.Stocks.Add(new Data.Entities.Stock { Symbol = "C", Price = 30, LastUpdated = DateTime.UtcNow });
        }

        [Test]
        public void GetStockValues_Should_Return_Expected_Single_Result()
        {
            // arrange

            var sut = new StockService(_dbContext);

            // act
            var result = sut.GetStockValues(new List<string> { "B" });

            // assert
            result.Count.Should().Be(1);
            result.First().Key.Should().Be("B");
        }

        [Test]
        public void GetStockValues_Should_Return_Expected_Two_Results()
        {
            // arrange

            var sut = new StockService(_dbContext);

            // act
            var result = sut.GetStockValues(new List<string> { "B", "C" });

            // assert
            result.Count.Should().Be(2);
            result.First().Key.Should().Be("B");
            result.Last().Key.Should().Be("C");
        }

        [Test]
        public void GetStockValues_Should_Return_Expected_Three_Results_If_No_Specific_List_Passed()
        {
            // arrange

            var sut = new StockService(_dbContext);

            // act
            var result = sut.GetStockValues(null);

            // assert
            result.Count.Should().Be(3);
            result.First().Key.Should().Be("A");
            result[1].Key.Should().Be("B");
            result.Last().Key.Should().Be("C");
        }
    }
}
