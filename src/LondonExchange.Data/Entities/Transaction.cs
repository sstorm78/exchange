using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LondonExchange.Data.Entities
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(5)]
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public decimal Volume { get; set; }

        [MaxLength(5)]
        public string ExchangeSymbol { get; set; }
        [ForeignKey("ExchangeSymbol")]
        public Exchange Exchange { get; set; }

        public Guid BrokerId { get; set; }
        [ForeignKey("BrokerId")]
        public Broker Broker { get; set; }

        public DateTime DateTime { get; set; }

    }
}
