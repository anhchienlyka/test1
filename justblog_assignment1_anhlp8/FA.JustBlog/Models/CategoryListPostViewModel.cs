using FA.JustBlog.Core.Paging;
using FA.JustBlog.Services.Models.Response;

namespace FA.JustBlog.Models
{
    public class CategoryListPostViewModel
    {
        public CategoryResponse Category { get; set; }
        public PagingResult<PostResponse> PostsOfCategory { get; set; }
    }
}