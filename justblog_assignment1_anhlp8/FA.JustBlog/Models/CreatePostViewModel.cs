using FA.JustBlog.Core.Models.Base;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Models
{
    public class CreatePostViewModel : BaseEntity
    {
        [ReadOnly(true)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Name")]
        public string Title { get; set; }

        [MaxLength(1024)]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string PostContent { get; set; }

        [Required]
        [MaxLength(255)]
        public string UrlSlug { get; set; }

        [ReadOnly(true)]
        public DateTime? Published { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Tags")]
        public string TagNames { get; set; }
    }
}