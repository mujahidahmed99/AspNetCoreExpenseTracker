using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreExpenseTracker.Models;

public class Currency
{
    public int Id { get; set; }

    [Required]
    public string CurrencyName { get; set; }

    public string CurrencySymbol { get; set; }
}