using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Enums
{
    public enum UserSearchBy
    {
        [Display(Name = "Id")]
        Id,
        [Display(Name = "Username")]
        UserName,
        [Display(Name = "Email")]
        Email,
        [Display(Name = "Role")]
        Role
    }
}