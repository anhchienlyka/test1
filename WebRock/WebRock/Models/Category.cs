using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebRock.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        //gan ten hien ra Ui cho display
        [DisplayName("Display order")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Display order for category must be greater than 0")]
        public int DisplayOrder { get; set; }
    }
}
