using FA.JustBlog.Core.Models.Base;

namespace FA.JustBlog.Services.Models.Response
{
    public class CategoryResponse : BaseResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UrlSlug { get; set; }

        public string Description { get; set; }
    }
}