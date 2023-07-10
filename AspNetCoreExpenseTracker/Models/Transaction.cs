using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreExpenseTracker.Models;

public class Transaction
{
    public int Id { get; set; }

    [Required]
    public Guid WalletId { get; set; }
    
    [Required]
    public int CategoryId { get; set; }

    [Required]
    public int Amount { get; set; }
    
    [Required]
    public DateTime date { get; set; }

    public string Comments { get; set; }

    public Wallet Wallet { get; set; }

    public Category Category { get; set; }
}