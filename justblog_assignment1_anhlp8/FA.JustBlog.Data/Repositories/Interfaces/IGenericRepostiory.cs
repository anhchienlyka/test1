using FA.JustBlog.Core.Models.Base;
using FA.JustBlog.Core.Paging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FA.JustBlog.Data.Repositories.Interfaces
{
    public interface IGenericRepostiory<T> where T : BaseEntity
    {
        void Add(T entity);

        void Delete(int key);

        void Delete(T entity);

        T Find(int key);

        PagingResult<T> GetAll(int pageSize = 5, int pageOffset = 0);

        IEnumerable<T> GetAll();

        void Update(T entity);

        PagingResult<T> GetByCondition(
            int pageSize = 5, int pageOffset = 0,
            Expression<Func<T, bool>> filter = null,
            Expression<Func<T, object>> orderBy = null,
            bool isAsc = true);
    }
}