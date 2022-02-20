using LondonExchange.Models;
using LondonExchange.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LondonExchange.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StocksController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StocksController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        public IActionResult GetList([FromQuery] string symbols = null)
        {
            var querySymbols = new List<string>();
            if (!string.IsNullOrEmpty(symbols))
            {
                querySymbols = symbols.Split(',').ToList();
            }

            var values = _stockService.GetStockValues(querySymbols);

            return Ok(values.Select(i => new StockModel(i.Key, i.Value)).ToList());
        }

        [Route("{symbol}")]
        [HttpGet]
        public IActionResult GetSingle(string symbol)
        {
            var querySymbols = new List<string> { symbol };

            var values = _stockService.GetStockValues(querySymbols);

            if (values == null || !values.Any())
            {
                return NotFound();
            }

            return Ok(values.Select(i => new StockModel(i.Key, i.Value)).First());
        }
    }
}
