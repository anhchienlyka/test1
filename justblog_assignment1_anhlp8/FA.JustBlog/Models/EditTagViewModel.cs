using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Models
{
    public class EditTagViewModel
    {
        [ReadOnly(true)]
        public int Id { get; set; }

        [MaxLength(255)]
        [Required]
        [Display(Name = "Tag Name")]
        public string Name { get; set; }

        [MaxLength(255)]
        [Required]
        [Display(Name = "Tag Slug")]
        public string UrlSlug { get; set; }

        [MaxLength(1024)]
        [Display(Name = "Tag Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Tag Count")]
        public int Count { get; set; }
    }
}