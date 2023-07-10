using AspNetCoreExpenseTracker.Models;
using AspNetCoreExpenseTracker.Data;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreExpenseTracker.Services;

public class TransactionService : ITransactionService
{
    private readonly ApplicationDbContext _context;

    public TransactionService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Transaction>> GetTransactionsAsync()
    {
        var transactions = await _context.Transactions.ToListAsync();
        return transactions;
    }

    public async Task<bool> AddTransactionAsync(Transaction newTransaction)
    {
        return false;
    }
}