using FA.JustBlog.Core.Enums;
using FA.JustBlog.Core.Models;
using System;
using System.Linq.Expressions;

namespace FA.JustBlog.Core.Helpers
{
    public class FilterHelper
    {
        public static Expression<Func<Post, bool>> GetFilterBySearchConstant(PostSearchBy searchConst, string keyword, bool onlyPublised = false)
        {
            Expression<Func<Post, bool>> filter = null;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                switch (searchConst)
                {
                    case PostSearchBy.Title:
                        filter = p => p.Title.Contains(keyword);
                        break;

                    case PostSearchBy.ShortDescription:
                        filter = p => p.ShortDescription.Contains(keyword);
                        break;

                    case PostSearchBy.Content:
                        filter = p => p.PostContent.Contains(keyword);
                        break;
                }
            }
            return filter;
        }
    }
}