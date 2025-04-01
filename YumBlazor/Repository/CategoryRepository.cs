using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;
    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category> GetCategoryById(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)   
            return new Category();
        
        return category;
    }

    public async Task<Category> AddCategory(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateCategory(Category category)
    {
        var oldCategory = await _context.Categories.FindAsync(category.Id);
        if (oldCategory == null)
        {
            return category;
        }
        else
        {
            oldCategory.Name = category.Name;
            await _context.SaveChangesAsync();
            return oldCategory;
        }
    }

    public async Task<bool> DeleteCategory(int id)
    {
       var category = await _context.Categories.FindAsync(id);
       if (category != null)
       {
           _context.Categories.Remove(category);
           await _context.SaveChangesAsync();
           return true;
       }
return false;
    }
}