using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Enums
{
    public enum PostOrderBy
    {
        [Display(Name = "Id")]
        ID = 0,

        [Display(Name = "Title")]
        TITLE = 1,

        [Display(Name = "Posted Date")]
        POSTED_DATE = 2,

        [Display(Name = "Modified Date")]
        MODIFIED_DATE = 3,

        [Display(Name = "Published Date")]
        PUBLISHED_DATE = 4,

        [Display(Name = "View Count")]
        VIEW = 5,

        [Display(Name = "Rate")]
        RATE = 6,
    }
}