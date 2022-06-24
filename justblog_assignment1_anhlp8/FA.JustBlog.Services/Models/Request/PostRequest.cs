using System;

namespace FA.JustBlog.Services.Models.Request
{
    public class PostRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string PostContent { get; set; }

        public string UrlSlug { get; set; }

        public DateTime? Published { get; set; }

        public int CategoryId { get; set; }

        public string TagNames { get; set; }
    }
}