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
        var transactions = await _context.Transactions
            .Include(x => x.Category)
            .Include(x => x.Wallet)
            .ToListAsync();

        return transactions;
    }

    public async Task<Transaction> AddTransactionAsync(Transaction newTransaction)
    {
        _context.Transactions.Add(newTransaction);
        await _context.SaveChangesAsync();

        var addedTransaction = await _context.Transactions
            .Include(x => x.Category)
                .ThenInclude(x => x.FinancialStatement)
            .Include(x => x.Wallet)
                .ThenInclude(x => x.Currency)
            .FirstOrDefaultAsync(x => x.Id == newTransaction.Id);

        return addedTransaction;
    }

    public async Task<List<GroupedTransactionsViewModel>> GroupByCategoryAsync()
    {
        var groupedTransactions = await _context.Transactions
            .Include(x => x.Category)
            .Include(x => x.Wallet)
            .GroupBy(x => x.CategoryId)
            .Select(g => new GroupedTransactionsViewModel
            {
                CategoryName = g.First().Category.Name,
                TotalAmount = g.Sum(t => t.Amount),
                Transactions = g.ToList()
            })
            .ToListAsync();

        return(groupedTransactions);
    }
}