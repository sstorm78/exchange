using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonExchange.Models
{
    public class StockModel
    {
        public string Symbol { get; private set; }
        public decimal Value { get; private set; }

        public StockModel(string symbol, decimal price)
        {
            Symbol = symbol;
            Value = price;
        }
    }
}
