using LondonExchange.Data;
using System.Collections.Generic;
using System.Linq;

namespace LondonExchange.Services
{
    public class StockService : IStockService
    {
        private readonly IDbContext _dbContext;

        public StockService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<KeyValuePair<string, decimal>> GetStockValues(IList<string> symbols = null)
        {
            var query = _dbContext.Stocks.Select(i => new KeyValuePair<string, decimal>(i.Symbol, i.Price));

            if (symbols != null && symbols.Any())
            {
                query = query.Where(i => symbols.Contains(i.Key));
            }

            return query.ToList();
        }
    }
}
