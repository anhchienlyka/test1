using FA.JustBlog.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Models
{
    public class CreateCategoryViewModel : BaseEntity
    {
        [Required]
        [Display(Name = "Category Name")]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        [Display(Name = "Category Url Slug")]
        public string UrlSlug { get; set; }

        [MaxLength(1024)]
        [Display(Name = "Category Description")]
        public string Description { get; set; }
    }
}