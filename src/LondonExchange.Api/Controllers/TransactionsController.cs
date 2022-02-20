using LondonExchange.Models;
using LondonExchange.Services;
using Microsoft.AspNetCore.Mvc;

namespace LondonExchange.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] TransactionModel transaction)
        {
            var transactionId = _transactionService.Store(transaction);

            return Created($"http://localhost:5000/transactions/{transactionId}", null);
        }
    }
}
