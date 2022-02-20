using System;
using System.ComponentModel.DataAnnotations;

namespace LondonExchange.Data.Entities
{
    public class Stock
    {
        [MaxLength(5)]
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
