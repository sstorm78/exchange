using LondonExchange.Data;
using LondonExchange.Data.Entities;
using LondonExchange.Models;
using System;
using System.Linq;

namespace LondonExchange.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IDbContext _dbContext;

        public TransactionService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Guid Store(TransactionModel transaction)
        {
            var newGuid = Guid.NewGuid();

            var entity = new Transaction
            {
                Id = newGuid,
                Symbol = transaction.Symbol,
                Price = transaction.Price,
                Volume = transaction.Volume,
                ExchangeSymbol = transaction.ExchangeSymbol,
                BrokerId = transaction.BrokerId,
                DateTime = DateTime.UtcNow
            };

            _dbContext.Transactions.Add(entity);

            AddUpdateStockValue(transaction.Symbol, transaction.Price);

            return newGuid;
        }

        private void AddUpdateStockValue(string symbol, decimal price)
        {
            var stock = _dbContext.Stocks.FirstOrDefault(i => i.Symbol == symbol);

            if (stock != null)
            {
                stock.Price = price;
                return;
            }

            _dbContext.Stocks.Add(new Stock
            {
                Symbol = symbol,
                Price = price,
                LastUpdated = DateTime.UtcNow
            });
        }
    }
}
