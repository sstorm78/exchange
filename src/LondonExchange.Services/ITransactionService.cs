using LondonExchange.Models;
using System;

namespace LondonExchange.Services
{
    public interface ITransactionService
    {
        Guid Store(TransactionModel transaction);
    }
}