using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FA.JustBlog.Core.Paging
{
    public class PagingList<T> where T : class
    {
        public int PageSize { get; set; }

        public int PageOffset { get; set; }

        public int ItemCount { get; set; }

        public int TotalPage { get => (ItemCount / PageSize) + (ItemCount % PageSize > 0 ? 1 : 0); }

        public IQueryable<T> QueryableData { get; set; }

        public IEnumerable<T> Data { get; set; }

        public PagingList(int pageSize, int pageOffset, IQueryable<T> queryableData)
        {
            PageSize = pageSize;
            PageOffset = pageOffset;
            QueryableData = queryableData;
            ItemCount = QueryableData.Count();
        }

        public PagingList()
        {
        }

        public IEnumerable<T> GetPage()
        {
            if (PageSize == 0 && PageOffset == 0)
                return QueryableData.ToList();

            var offsetPosts = PageSize * PageOffset;
            if (PageOffset + 1 > TotalPage)
                offsetPosts = (TotalPage - 1) * PageOffset;

            if (QueryableData != null)
                return QueryableData.Skip(offsetPosts).Take(PageSize);
            else
                return Data.Skip(offsetPosts).Take(PageSize);
        }

        public PagingResult<T> GetPage(int pageSize, int pageOffset, IEnumerable<T> data)
        {
            PageSize = pageSize;
            PageOffset = pageOffset;
            Data = data;
            ItemCount = data.Count();
            var items = GetPage();
            return new PagingResult<T>()
            {
                PageOffset = pageOffset,
                PageSize = pageSize,
                ItemCount = items.Count(),
                Items = items,
                TotalPage = TotalPage
            };
        }

        public PagingResult<T> GetPage(int pageSize, int pageOffset, IQueryable<T> queryableData)
        {
            PageSize = pageSize;
            PageOffset = pageOffset;
            QueryableData = queryableData;
            ItemCount = queryableData.Count();
            var items = GetPage();
            return new PagingResult<T>()
            {
                PageOffset = pageOffset,
                PageSize = pageSize,
                ItemCount = items.Count(),
                Items = items,
                TotalPage = TotalPage
            };
        }

        public PagingResult<T> GetPage(
            int pageSize,
            int pageOffset,
            IQueryable<T> queryableData,
            Expression<Func<T, bool>> filter,
            Expression<Func<T, object>> orderBy,
            bool isAsc = true)
        {
            PageSize = pageSize;
            PageOffset = pageOffset;
            if (filter != null)
            {
                queryableData = queryableData.Where(filter);
            }
            if (orderBy != null)
            {
                if (isAsc) queryableData = queryableData.OrderBy(orderBy);
                else queryableData = queryableData.OrderByDescending(orderBy);
            }
            QueryableData = queryableData;
            if (queryableData == null)
                ItemCount = 0;
            else
                ItemCount = queryableData.Count();
            var items = GetPage();
            return new PagingResult<T>()
            {
                PageOffset = pageOffset,
                PageSize = pageSize,
                ItemCount = items.Count(),
                Items = items,
                TotalPage = TotalPage
            };
        }

        public PagingResult<T> GetPage(
            int pageSize,
            int pageOffset,
            IEnumerable<T> data,
            Func<T, bool> filter,
            Func<T, object> orderBy,
            bool isAsc = true)
        {
            PageSize = pageSize;
            PageOffset = pageOffset;
            if (filter != null)
            {
                data = data.Where(filter);
            }
            if (orderBy != null)
            {
                if (isAsc) data = data.OrderBy(orderBy);
                else data = data.OrderByDescending(orderBy);
            }
            Data = data;
            if (data == null)
                ItemCount = 0;
            else
                ItemCount = data.Count();
            var items = GetPage();
            return new PagingResult<T>()
            {
                PageOffset = pageOffset,
                PageSize = pageSize,
                ItemCount = items.Count(),
                Items = items,
                TotalPage = TotalPage
            };
        }
    }
}