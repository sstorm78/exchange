using LondonExchange.Data.Entities;
using System.Collections.Generic;

namespace LondonExchange.Data
{
    public class DbContext : IDbContext
    {
        public DbContext(){
            Transactions = new List<Transaction>();
            Exchanges = new List<Exchange>();
            Brokers = new List<Broker>();
            Stocks = new List<Stock>();

            Stocks.Add(new Stock { Symbol = "A", Price = 10 });
            Stocks.Add(new Stock { Symbol = "B", Price = 10 });
            Stocks.Add(new Stock { Symbol = "C", Price = 10 });
        }

        public List<Transaction> Transactions { get; set; }
        public List<Exchange> Exchanges { get; set; }
        public List<Broker> Brokers { get; set; }
        public List<Stock> Stocks { get; set; }
    }
}
