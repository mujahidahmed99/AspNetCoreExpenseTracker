using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreExpenseTracker.Data;
using AspNetCoreExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreExpenseTracker.Services;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _context;

    public CategoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        var categories = await _context.Categories.ToListAsync();
        return categories;
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

        return category;
    }
}