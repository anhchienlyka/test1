using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Enums
{
    public enum PostSearchBy
    {
        [Display(Name = "Title")]
        Title = 0,

        [Display(Name = "Content")]
        Content = 1,

        [Display(Name = "Short Desciption")]
        ShortDescription = 2
    }
}