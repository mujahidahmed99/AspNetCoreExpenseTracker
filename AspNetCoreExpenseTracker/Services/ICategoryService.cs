using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreExpenseTracker.Models;

namespace AspNetCoreExpenseTracker.Services;

public interface ICategoryService
{
    Task<List<Category>> GetCategoriesAsync();

    Task<Category> GetCategoryByIdAsync(int id);
}