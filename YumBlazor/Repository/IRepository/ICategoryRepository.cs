using YumBlazor.Data;

namespace YumBlazor.Repository.IRepository;

public interface ICategoryRepository
{
    public Task<IEnumerable<Category>> GetAllCategories();
    public Task<Category> GetCategoryById(int id);
    public Task<Category> AddCategory(Category category);
    public Task<Category> UpdateCategory(Category category);
    public Task<bool> DeleteCategory(int id);
}