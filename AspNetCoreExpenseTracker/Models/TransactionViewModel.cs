namespace AspNetCoreExpenseTracker.Models;

public class TransactionViewModel
{
    public Wallet Wallet { get; set; }

    public List<GroupedTransactionsViewModel> GroupedTransactions { get; set; }
    
    public List<Category> DebtsOrLoans { get; set; } = new List<Category>();

    public List<Category> Expenses { get; set; } = new List<Category>();

    public List<Category> Incomes { get; set; } = new List<Category>();
}