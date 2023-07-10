using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreExpenseTracker.Models;
using AspNetCoreExpenseTracker.Services;
using AspNetCoreExpenseTracker.Enums;

namespace AspNetCoreExpenseTracker.Controllers;

public class HomeController : Controller
{
    private readonly IWalletService _walletService;
    private readonly ICategoryService _categoryService;
    private readonly ITransactionService _transactionService;

    public HomeController(IWalletService walletService, ICategoryService categoryService, ITransactionService transactionService)
    {
        _walletService = walletService;
        _categoryService = categoryService;
        _transactionService = transactionService;
    }

    public async Task<IActionResult> Index()
    {
        var wallet = await _walletService.GetWalletByIdAsync(new Guid("2434F5D5-53B6-4E22-8885-018968ED148D"));
        var transactions = await _transactionService.GetTransactionsAsync();
        var categories = await _categoryService.GetCategoriesAsync();

        var model = new TransactionViewModel()
        {
            Wallet = wallet,
            Transactions = transactions,
            DebtsOrLoans = categories.Where(x => x.FinancialStatementId == (int)FinancialStatementId.DebtsOrLoans).ToList(),
            Expenses = categories.Where(x => x.FinancialStatementId == (int)FinancialStatementId.Expense).ToList(),
            Incomes = categories.Where(x => x.FinancialStatementId == (int)FinancialStatementId.Income).ToList()
        };

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
