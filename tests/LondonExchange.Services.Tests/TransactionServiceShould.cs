using FluentAssertions;
using LondonExchange.Data;
using NUnit.Framework;
using System.Linq;

namespace LondonExchange.Services.Tests
{
    [TestFixture]
    public class TransactionServiceShould
    {
        [Test]
        public void Store_Should_Add_Transaction_Record_And_Update_Stock_Price()
        {
            // arrange
            var dbContext = new DbContext();
            dbContext.Stocks.Add(new Data.Entities.Stock
            {
                Symbol = "A",
                Price = 10
            });

            var sut = new TransactionService(dbContext);

            // act
            sut.Store(new Models.TransactionModel
            {
                Symbol = "A",
                Price = 20
            });

            // assert
            dbContext.Stocks.First(i => i.Symbol == "A").Price.Should().Be(20);
        }

        [Test]
        public void Store_Should_Add_Transaction_Record_And_Create_Stock_Price()
        {
            // arrange
            var dbContext = new DbContext();
            var sut = new TransactionService(dbContext);

            // act
            sut.Store(new Models.TransactionModel
            {
                Symbol = "A",
                Price = 20
            });

            // assert
            dbContext.Stocks.First(i => i.Symbol == "A").Price.Should().Be(20);
        }
    }
}
