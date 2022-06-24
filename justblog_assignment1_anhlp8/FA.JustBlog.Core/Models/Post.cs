using FA.JustBlog.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Core.Models
{
    [Table("Posts")]
    public class Post : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(1024)]
        public string ShortDescription { get; set; }

        [Required]
        public string PostContent { get; set; }

        [Required]
        [MaxLength(255)]
        public string UrlSlug { get; set; }

        public DateTime? Published { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public List<PostTagMap> PostTagMap { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public ICollection<Comment> Comments { get; set; }

        [Required]
        public int ViewCount { get; set; }

        [Required]
        public int RateCount { get; set; }

        [Required]
        public int TotalRate { get; set; }

        [NotMapped]
        public decimal Rate
        {
            get
            {
                return RateCount == 0 ? 0 : (decimal)TotalRate / RateCount;
            }
        }
    }
}