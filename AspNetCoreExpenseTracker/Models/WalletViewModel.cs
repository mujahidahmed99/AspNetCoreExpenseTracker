namespace AspNetCoreExpenseTracker.Models;

public class WalletViewModel
{
    public List<Wallet> Wallets { get; set; } = new List<Wallet>();
    
    public List<Currency> Currencies { get; set; } = new List<Currency>();
}