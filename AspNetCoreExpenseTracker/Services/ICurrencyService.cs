using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreExpenseTracker.Models;

namespace AspNetCoreExpenseTracker.Services;

public interface ICurrencyService
{
    Task<List<Currency>> GetCurrenciesAsync();

    Task<Currency> GetCurrencyByIdAsync(int id);
}