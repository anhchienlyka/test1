namespace FA.JustBlog.Services.Models.Request
{
    public class CategoryRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UrlSlug { get; set; }

        public string Description { get; set; }
    }
}