using FA.JustBlog.Services.Models.Request;
using FA.JustBlog.Services.Models.Response;
using System.Collections.Generic;

namespace FA.JustBlog.Services.Interfaces
{
    public interface ICategoryService
    {
        public IEnumerable<CategoryResponse> GetCategories();

        public void CreateCategory(CategoryRequest request);

        public void UpdateCategory(CategoryRequest request);

        public void DeleteCategory(int id);

        CategoryResponse GetCategory(int id);
    }
}