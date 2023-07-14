using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreExpenseTracker.Data;
using AspNetCoreExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreExpenseTracker.Services;

public class CurrencyService : ICurrencyService
{
    private readonly ApplicationDbContext _context;

    public CurrencyService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Currency>> GetCurrenciesAsync()
    {
        var currencies = await _context.Currencies.ToListAsync();
        return currencies;
    }

    public async Task<Currency> GetCurrencyByIdAsync(int id)
    {
        var currency = await _context.Currencies.FirstOrDefaultAsync(x => x.Id == id);

        return currency;
    }
}