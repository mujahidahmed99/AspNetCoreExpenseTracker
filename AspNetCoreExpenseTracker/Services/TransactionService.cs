using AspNetCoreExpenseTracker.Models;
using AspNetCoreExpenseTracker.Data;
using Microsoft.EntityFrameworkCore;
using AspNetCoreExpenseTracker.Enums;

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
                .ThenInclude(x => x.FinancialStatement)
            .Include(x => x.Wallet)
                .ThenInclude(x => x.Currency)
            .ToListAsync();

        return transactions;
    }

    public async Task<Transaction> AddTransactionAsync(Transaction newTransaction)
    {
        if(newTransaction.Category.FinancialStatementId == (int)FinancialStatementId.Expense)
        {
            newTransaction.Amount = -newTransaction.Amount;
        }
        
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
                .ThenInclude(x => x.FinancialStatement)
            .Include(x => x.Wallet)
                .ThenInclude(x => x.Currency)
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