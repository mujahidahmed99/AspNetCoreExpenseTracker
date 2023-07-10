using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreExpenseTracker.Models;

public class FinancialStatement
{
    public int Id { get; set; }

    [Required]
    public string Type { get; set; }

}