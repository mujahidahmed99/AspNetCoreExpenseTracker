using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreExpenseTracker.Models;

public class Wallet
{
    public Guid Id { get; set; }

    [Required]
    public string WalletName { get; set; }

    [Required]
    public int CurrencyId { get; set; }
    
    [Required]
    public decimal Amount { get; set; }
    
    [Required]
    public bool ExcludeFromTotal { get; set; }

    public Currency Currency { get; set; }
}