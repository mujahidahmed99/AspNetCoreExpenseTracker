using System;

namespace AspNetCoreExpenseTracker.Models;

public class GroupedTransactionsViewModel
{
    public string CategoryName { get; set; }

    public int TotalAmount { get; set; }

    public List<Transaction> Transactions { get; set; }
}