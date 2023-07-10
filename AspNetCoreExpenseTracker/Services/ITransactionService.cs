using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreExpenseTracker.Models;

namespace AspNetCoreExpenseTracker.Services;

public interface ITransactionService
{
    Task<List<Transaction>> GetTransactionsAsync();

    Task<bool> AddTransactionAsync(Transaction newTransaction);
}