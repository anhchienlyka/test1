using FA.JustBlog.Core.Models.Base;
using FA.JustBlog.Services.Models.Response;
using System;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Models
{
    public class CreateCommentViewModel : BaseEntity
    {
        [MaxLength(255)]
        public string Name { get; set; }

        public string PostTitle { get; set; }

        public string Email { get; set; }

        public int PostId { get; set; }

        [Required]
        [MaxLength(255)]
        public string CommentHeader { get; set; }

        [Required]
        [MaxLength(1024)]
        public string CommentText { get; set; }

        public DateTime CommandTime { get; set; }
    }
}