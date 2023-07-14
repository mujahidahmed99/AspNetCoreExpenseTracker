using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreExpenseTracker.Models;

public class CreateWalletViewModel
{
    [Required]
    public string WalletName { get; set; }

    [Required]
    public int CurrencyId { get; set; }
    
    [Required]
    public decimal Amount { get; set; }
    
    public bool ExcludeFromTotal { get; set; }
}