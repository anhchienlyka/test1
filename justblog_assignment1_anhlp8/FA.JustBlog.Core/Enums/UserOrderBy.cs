using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Enums
{
    public enum UserOrderBy
    {
        [Display(Name = "Id")]
        Id,
        [Display(Name = "Name")]
        UserName,
        [Display(Name = "Email")]
        Email
    }
}
