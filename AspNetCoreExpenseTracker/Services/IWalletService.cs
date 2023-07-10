using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreExpenseTracker.Models;

namespace AspNetCoreExpenseTracker.Services;

public interface IWalletService
{
    Task<List<Wallet>> GetWalletsAsync();

    Task<bool> AddWalletAsync(Wallet newWallet);

    Task<Wallet> GetWalletByIdAsync(Guid id);
}