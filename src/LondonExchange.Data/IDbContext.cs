using LondonExchange.Data.Entities;
using System.Collections.Generic;

namespace LondonExchange.Data
{
    public interface IDbContext
    {
        List<Stock> Stocks { get; set; }
        List<Broker> Brokers { get; set; }
        List<Exchange> Exchanges { get; set; }
        List<Transaction> Transactions { get; set; }
    }
}