using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Models
{
    public class EditCategoryViewModel
    {
        [ReadOnly(true)]
        public int Id { get; set; }

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