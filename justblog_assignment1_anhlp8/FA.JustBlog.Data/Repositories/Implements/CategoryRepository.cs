using FA.JustBlog.Core.Models;
using FA.JustBlog.Data.Contexts;
using FA.JustBlog.Data.Repositories.Interfaces;

namespace FA.JustBlog.Data.Repositories.Implements
{
    public class CategoryRepository : GenericRepostiory<Category>, ICategoryRepository
    {
        public CategoryRepository(JustBlogContext context) : base(context)
        {
        }
    }
}