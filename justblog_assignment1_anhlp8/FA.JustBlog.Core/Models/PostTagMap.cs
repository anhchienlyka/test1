using FA.JustBlog.Core.Models.Base;

namespace FA.JustBlog.Core.Models
{
    public class PostTagMap
    {
        public int TagId { get; set; }

        public Tag Tag { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}