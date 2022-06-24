using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Models
{
    public class EditUserViewModel
    {
        [ReadOnly(true)]
        public string UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public List<SelectRoleViewModel> SelectRoles { get; set; }
    }
}