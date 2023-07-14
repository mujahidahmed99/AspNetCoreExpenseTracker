using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreExpenseTracker.Models;

public class CreateTransactionViewModel
{
    [Required]
    public Guid WalletId { get; set; }
    [Required]
    public int CategoryId { get; set; }
    [Required]
    public int Amount { get; set; }
    [Required]
    public DateTime Date { get; set; }
    public string? Comments { get; set; }
}