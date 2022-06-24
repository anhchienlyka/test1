using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Models
{
    public class CreateTagViewModel
    {
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