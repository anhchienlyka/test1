using FA.JustBlog.Core.Enums;
using FA.JustBlog.Core.Models;
using System;
using System.Linq.Expressions;

namespace FA.JustBlog.Core.Helpers
{
    public static class OrderByHelper
    {
        public static Expression<Func<Post, object>> GetOrderByByConstant(PostOrderBy orderBy)
        {
            switch (orderBy)
            {
                case PostOrderBy.ID:
                    return p => p.Id;

                case PostOrderBy.TITLE:
                    return p => p.Title;

                case PostOrderBy.POSTED_DATE:
                    return p => p.PostedOn;

                case PostOrderBy.MODIFIED_DATE:
                    return p => p.Modified;

                case PostOrderBy.PUBLISHED_DATE:
                    return p => p.Published;

                case PostOrderBy.VIEW:
                    return p => p.ViewCount;

                case PostOrderBy.RATE:
                    return p => p.Rate;
            }
            return null;
        }
    }
}