using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreExpenseTracker.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    public int FinancialStatementId { get; set; }
    
    [Required]
    public string Name { get; set; }

    public FinancialStatement FinancialStatement { get; set; }
}