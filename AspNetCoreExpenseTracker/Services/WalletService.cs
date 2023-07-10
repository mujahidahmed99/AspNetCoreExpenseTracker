using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreExpenseTracker.Data;
using AspNetCoreExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreExpenseTracker.Services;

public class WalletService : IWalletService
{
    private readonly ApplicationDbContext _context;

    public WalletService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Wallet>> GetWalletsAsync()
    {
        var wallets = await _context.Wallets.ToListAsync();
        return wallets;
    }

    public async Task<bool> AddWalletAsync(Wallet newWallet)
    {
        newWallet.Id = Guid.NewGuid();
        _context.Wallets.Add(newWallet);

        var saveResult = await _context.SaveChangesAsync();
        return saveResult == 1;
    }

    public async Task<Wallet> GetWalletByIdAsync(Guid id)
    {
        return await _context.Wallets.Where(x => x.Id == id).FirstOrDefaultAsync();
    }
}