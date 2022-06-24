using FA.JustBlog.Core.Paging;
using FA.JustBlog.Services.Models.Response;

namespace FA.JustBlog.Models
{
    public class TagListPostViewModel
    {
        public TagResponse Tag { get; set; }

        public PagingResult<PostResponse> PostsOfTag { get; set; }
    }
}