using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreExpenseTracker.Models;

public class Wallet
{
    public Guid Id { get; set; }

    [Required]
    public string WalletName { get; set; }

    public int CurrencyId { get; set; }
    
    public decimal Amount { get; set; }
    
    public bool ExcludeFromTotal { get; set; }

    public Currency Currency { get; set; }
}