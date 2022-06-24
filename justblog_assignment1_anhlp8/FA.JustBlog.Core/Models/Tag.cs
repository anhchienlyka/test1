using FA.JustBlog.Core.Models.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Core.Models
{
    [Table("Tags")]
    public class Tag : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(255)]
        [Required]
        public string UrlSlug { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(1024)]
        public string Description { get; set; }

        [DefaultValue(0)]
        [Required]
        public int Count { get; set; }

        public ICollection<PostTagMap> PostTagMap { get; set; }

        public List<Post> Posts { get; set; }
    }
}