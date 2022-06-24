using System;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Models.Base
{
    public class BaseEntity
    {
        [Required]
        public DateTime PostedOn { get; set; }

        [Required]
        public DateTime Modified { get; set; }
    }
}