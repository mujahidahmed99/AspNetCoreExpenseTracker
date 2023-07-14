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
        var transactions = await _transactionService.GroupByCategoryAsync();
        var categories = await _categoryService.GetCategoriesAsync();

        var model = new TransactionViewModel()
        {
            Wallet = wallet,
            GroupedTransactions = transactions,
            DebtsOrLoans = categories.Where(x => x.FinancialStatementId == (int)FinancialStatementId.DebtsOrLoans).ToList(),
            Expenses = categories.Where(x => x.FinancialStatementId == (int)FinancialStatementId.Expense).ToList(),
            Incomes = categories.Where(x => x.FinancialStatementId == (int)FinancialStatementId.Income).ToList()
        };

        return View(model);
    }

    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<ActionResult> AddTransaction(CreateTransactionViewModel newTransaction)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest("Invalid Input");
        }

        var transaction = new Transaction
        {
            WalletId = newTransaction.WalletId,
            CategoryId = newTransaction.CategoryId,
            Amount = newTransaction.Amount,
            Date = newTransaction.Date,
            Comments = newTransaction.Comments
        };

        var category = await _categoryService.GetCategoryByIdAsync(newTransaction.CategoryId);
        var wallet = await _walletService.GetWalletByIdAsync(newTransaction.WalletId);

        if(category == null || wallet == null)
        {
            return BadRequest("Could not create objects.");
        }

        transaction.Category = category;
        transaction.Wallet = wallet;

        var addedTransaction = await _transactionService.AddTransactionAsync(transaction);

        if(addedTransaction == null)
        {
            return BadRequest("Could not add transaction.");
        }

        return Json(addedTransaction);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllTransactions()
    {
        var transactions = await _transactionService.GroupByCategoryAsync();

        return Json(transactions);
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
