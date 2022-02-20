using System.Collections.Generic;

namespace LondonExchange.Services
{
    public interface IStockService
    {
        IList<KeyValuePair<string, decimal>> GetStockValues(IList<string> symbols = null);
    }
}
