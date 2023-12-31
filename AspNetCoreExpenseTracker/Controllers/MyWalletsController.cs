using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreExpenseTracker.Models;
using AspNetCoreExpenseTracker.Services;

namespace AspNetCoreExpenseTracker.Controllers;

public class MyWalletsController : Controller
{
    private readonly IWalletService _walletService;
    private readonly ICurrencyService _currencyService;

    public MyWalletsController(IWalletService walletService, ICurrencyService currencyService)
    {
        _walletService = walletService;
        _currencyService = currencyService;
    }

    public async Task<IActionResult> Index() 
    {
        var wallets = await _walletService.GetWalletsAsync();
        var Currencies = await _currencyService.GetCurrenciesAsync();

        var model = new WalletViewModel()
        {
            Wallets = wallets,
            Currencies = Currencies
        };

        return View(model);
    }

    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddWallet(CreateWalletViewModel newWallet)
    {
        if(!ModelState.IsValid)
        {
            return RedirectToAction("Index");
        }

        var wallet = new Wallet
        {
            WalletName = newWallet.WalletName,
            CurrencyId = newWallet.CurrencyId,
            Amount = newWallet.Amount,
            ExcludeFromTotal = newWallet.ExcludeFromTotal
        };

        var currency = await _currencyService.GetCurrencyByIdAsync(newWallet.CurrencyId);

        if(currency == null)
        {
            return BadRequest("Could not create objects.");
        }

        wallet.Currency = currency;

        var successful = await _walletService.AddWalletAsync(wallet);

        if(!successful)
        {
            return BadRequest("Could not add wallet.");
        }

        return RedirectToAction("Index");
    }

}