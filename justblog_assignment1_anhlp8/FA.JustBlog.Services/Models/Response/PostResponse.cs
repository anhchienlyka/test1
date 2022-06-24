using System;
using System.Collections.Generic;

namespace FA.JustBlog.Services.Models.Response
{
    public class PostResponse : BaseResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string PostContent { get; set; }

        public string UrlSlug { get; set; }

        public DateTime? Published { get; set; }

        public int CategoryId { get; set; }

        public CategoryResponse Category { get; set; }

        public ICollection<TagResponse> Tags { get; set; }

        public ICollection<CommentResponse> Comments { get; set; }

        public int ViewCount { get; set; }

        public int RateCount { get; set; }

        public int TotalRate { get; set; }

        public decimal Rate
        {
            get
            {
                return RateCount == 0 ? 0 : (decimal)TotalRate / RateCount;
            }
        }
    }
}