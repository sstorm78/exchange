using System;

namespace LondonExchange.Models
{
    public class TransactionModel
    {
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public decimal Volume { get; set; }
        public string ExchangeSymbol { get; set; }
        public Guid BrokerId { get; set; }
    }
}
