using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Models
{
    public class EditCommentViewModel
    {
        public int Id { get; set; }

        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string CommentHeader { get; set; }

        [Required]
        [MaxLength(1024)]
        public string CommentText { get; set; }
    }
}