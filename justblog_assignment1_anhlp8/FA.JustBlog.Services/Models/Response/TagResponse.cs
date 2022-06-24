using FA.JustBlog.Services.Models.Response;

namespace FA.JustBlog.Services.Models.Response
{
    public class TagResponse : BaseResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UrlSlug { get; set; }

        public string Description { get; set; }

        public int Count { get; set; }
    }
}