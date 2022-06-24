using FA.JustBlog.Core.Exceptions;
using FA.JustBlog.Core.Models.Base;
using FA.JustBlog.Core.Paging;
using FA.JustBlog.Data.Contexts;
using FA.JustBlog.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FA.JustBlog.Data.Repositories.Implements
{
    public abstract class GenericRepostiory<T> : IGenericRepostiory<T> where T : BaseEntity
    {
        protected readonly JustBlogContext _context;

        protected GenericRepostiory(JustBlogContext context)
        {
            _context = context;
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void Delete(int key)
        {
            var entity = _context.Set<T>().Find(key);
            if (entity == null)
                throw new JustBlogException("This entity is not exist.");
            _context.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            var state = _context.Entry(entity).State;
            if (state == EntityState.Detached)
                _context.Set<T>().Attach(entity);
            if (_context.Entry(entity).State != EntityState.Modified)
                _context.Entry(entity).State = EntityState.Modified;
            //ef core will prevent update on properties have falsed modified state
            _context.Entry(entity).Property(p => p.PostedOn).IsModified = false;
            _context.Entry(entity).Property(p => p.Modified).IsModified = true;
        }

        public virtual PagingResult<T> GetAll(int pageSize = 5, int pageOffset = 0)
        {
            return new PagingList<T>().GetPage(pageSize, pageOffset, _context.Set<T>().AsNoTracking());
        }

        public virtual T Find(int key)
        {
            return _context.Set<T>().Find(key);
        }

        public PagingResult<T> GetByCondition(int pageSize = 5, int pageOffset = 0, Expression<Func<T, bool>> filter = null, Expression<Func<T, object>> orderBy = null, bool isAsc = true)
        {
            return new PagingList<T>().GetPage(pageSize, pageOffset, _context.Set<T>(), filter, orderBy, isAsc);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
    }
}