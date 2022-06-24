using FA.JustBlog.Core.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Core.Models
{
    [Table("Comments")]
    public class Comment : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        [MaxLength(255)]
        [Required]
        public string Email { get; set; }

        public Post Post { get; set; }

        public int PostId { get; set; }

        [Required]
        [MaxLength(255)]
        public string CommentHeader { get; set; }

        [Required]
        [MaxLength(1024)]
        public string CommentText { get; set; }

        [Required]
        public DateTime CommandTime { get; set; }
    }
}