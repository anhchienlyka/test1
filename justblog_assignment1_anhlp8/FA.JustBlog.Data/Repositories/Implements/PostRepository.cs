using FA.JustBlog.Core.Models;
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
    public class PostRepository : GenericRepostiory<Post>, IPostRepository
    {
        public PostRepository(JustBlogContext context) : base(context)
        {
        }

        public int CountPostsForCategory(string category)
        {
            var existCat = _context.Categories.AsNoTracking().FirstOrDefault(c => c.Name.Equals(category));
            if (existCat != null)
                return _context.Posts.AsNoTracking()
                    .Where(p => p.CategoryId == existCat.Id)
                    .Count();
            return 0;
        }

        public int CountPostsForTag(string tag)
        {
            Tag existTag = _context.Tags.AsNoTracking().FirstOrDefault(t => t.Name.Equals(tag));
            if (existTag != null)
                return _context.Set<PostTagMap>().AsNoTracking()
                    .Where(p => p.TagId == existTag.Id)
                    .Count();

            return 0;
        }

        public Post FindPost(int year, int month, string urlSlug)
        {
            return _context.Posts
                .Include(p => p.Category)
                .Include(p => p.Tags)
                .Include(p => p.Comments)
                .FirstOrDefault(p =>
                p.UrlSlug.Equals(urlSlug) &&
                (
                    (p.Published.HasValue && p.Published.Value.Year == year && p.Published.Value.Month == month)
                    || (p.PostedOn.Year == year && p.PostedOn.Month == month)
                    || (p.Modified.Year == year && p.Modified.Month == month)
                ));
        }

        public PagingResult<Post> GetLatestPost(int pageSize = 5, int pageOffset = 0)
        {
            return GetByCondition(
                pageSize,
                pageOffset,
                p => p.Published.HasValue && p.Published.Value <= DateTime.UtcNow,
                p => p.Published.Value,
                false);
        }

        public PagingResult<Post> GetPostsByCategory(string category, int pageSize = 5, int pageOffset = 0, bool onlyPublised = false,
            Expression<Func<Post, bool>> filter = null,
            Expression<Func<Post, object>> orderBy = null,
            bool isAsc = true)
        {
            var cat = _context.Categories.FirstOrDefault(c => c.Name.Equals(category));
            //build query by expression tree
            Expression<Func<Post, bool>> finalFilter = null;
            Expression<Func<Post, bool>> categoryFilter = p => p.CategoryId == cat.Id;
            Expression<Func<Post, bool>> onlyPublishedFilter = p => p.Published.HasValue && p.Published.Value <= DateTime.Now;
            if (onlyPublised)
            {
                var body = Expression.AndAlso(onlyPublishedFilter.Body, categoryFilter.Body);
                finalFilter = Expression.Lambda<Func<Post, bool>>(body, categoryFilter.Parameters[0]);
            }
            else
                finalFilter = categoryFilter;
            if (filter != null)
                finalFilter = Expression.Lambda<Func<Post, bool>>(Expression.AndAlso(finalFilter.Body, filter.Body), finalFilter.Parameters[0]);
            if (cat == null)
                return null;
            return GetByCondition(pageSize, pageOffset, finalFilter, orderBy, isAsc);
        }

        public PagingResult<Post> GetPostsByMonth(DateTime monthYear, int pageSize = 5, int pageOffset = 0)
        {
            return GetByCondition(
                pageSize, pageOffset,
                p => p.Published.HasValue && p.Published.Value.Month == monthYear.Month && p.Published.Value.Year == monthYear.Year,
                null, true);
        }

        public PagingResult<Post> GetPostsByTag(string tag, int pageSize = 5, int pageOffset = 0, bool onlyPublised = false,
            Expression<Func<Post, bool>> filter = null,
            Expression<Func<Post, object>> orderBy = null,
            bool isAsc = true)
        {
            var existTag = _context.Tags.FirstOrDefault(t => t.Equals(tag));
            if (existTag == null)
                return null;
            var posts = _context.Posts.AsQueryable();
            if (onlyPublised)
                posts = posts.Where(p => p.Published.HasValue && p.Published.Value <= DateTime.UtcNow);

            posts = posts
                .Join(
                    _context.Set<PostTagMap>().Where(pt => pt.TagId == existTag.Id),
                    p => p.Id,
                    pt => pt.PostId, (post, tag) => post);
            if (filter != null) posts = posts.Where(filter);
            return new PagingList<Post>().GetPage(pageSize, pageOffset, posts, null, orderBy, isAsc);
        }

        public PagingResult<Post> GetPublisedPosts(int pageSize = 5, int pageOffset = 0)
        {
            return GetByCondition(pageSize, pageOffset,
                p => p.Published.HasValue && p.Published.Value <= DateTime.Now,
                null, true);
        }

        public PagingResult<Post> GetUnpublisedPosts(int pageSize = 5, int pageOffset = 0)
        {
            return GetByCondition(pageSize, pageOffset,
                p => !p.Published.HasValue || p.Published.Value > DateTime.Now,
                null, true);
        }

        public override PagingResult<Post> GetAll(int pageSize = 5, int pageOffset = 0)
        {
            var posts = _context.Posts
                .Include(p => p.Category)
                .AsNoTracking();
            return new PagingList<Post>().GetPage(pageSize, pageOffset, posts);
        }

        public PagingResult<Post> GetMostViewedPost(int pageSize = 5, int pageOffset = 0, bool onlyPublised = false)
        {
            Expression<Func<Post, bool>> filter = null;
            if (onlyPublised)
                filter = p => p.Published.HasValue && p.Published.Value <= DateTime.UtcNow;
            var posts = GetByCondition(pageSize, pageOffset,
                filter,
                p => p.ViewCount, false);
            return posts;
        }

        public PagingResult<Post> GetHighestPosts(int pageSize = 5, int pageOffset = 0, bool onlyPublised = false)
        {
            Expression<Func<Post, bool>> filter = null;
            if (onlyPublised)
                filter = p => p.Published.HasValue && p.Published.Value <= DateTime.UtcNow;
            return GetByCondition(pageSize, pageOffset, filter, p => p.Rate, false);
        }

        public override Post Find(int key)
        {
            return _context.Posts
                .Include(p => p.Category)
                .Include(p => p.Comments)
                .Include(p => p.Tags)
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == key);
        }

        public void UpdateTagInPost(Post post, List<int> tagIds)
        {
            var existPostTags = _context.Set<PostTagMap>().AsNoTracking().Where(pt => pt.PostId == post.Id);
            if (existPostTags != null && tagIds != null)
            {
                //delete old post tag
                foreach (var tag in existPostTags)
                {
                    if (!tagIds.Contains(tag.TagId))
                    {
                        _context.Set<PostTagMap>().Remove(tag);
                    }
                }
                //add new post tag
                foreach (var tagId in tagIds)
                {
                    if (existPostTags.FirstOrDefault(pt => pt.TagId == tagId) == null)
                    {
                        _context.Set<PostTagMap>().Add(new PostTagMap() { PostId = post.Id, TagId = tagId });
                    }
                }
                return;
            }
            throw new ArgumentNullException(nameof(post));
        }

        public PagingResult<Post> GetPostsByTag(int tagId, int pageSize = 5, int pageOffset = 0, bool onPublished = false,
            Expression<Func<Post, bool>> filter = null,
            Expression<Func<Post, object>> orderBy = null,
            bool isAsc = true)
        {
            var existTag = _context.Tags.Find(tagId);
            if (existTag == null)
                return null;
            var posts = _context.Posts.AsQueryable();
            if (onPublished)
                posts = posts.Where(p => p.Published.HasValue && p.Published.Value <= DateTime.UtcNow);
            posts = posts
                .Join(
                    _context.Set<PostTagMap>().Where(pt => pt.TagId == existTag.Id),
                    p => p.Id,
                    pt => pt.PostId, (post, tag) => post);
            if (filter != null) posts = posts.Where(filter);
            return new PagingList<Post>().GetPage(pageSize, pageOffset, posts, null, orderBy, isAsc);
        }

        public PagingResult<Post> GetPostsByCategory(int categoryId, int pageSize = 5, int pageOffset = 0, Expression<Func<Post, bool>> filter = null, Expression<Func<Post, object>> orderBy = null, bool isAsc = true, bool onlyPublished = false)
        {
            var existTag = _context.Categories.Find(categoryId);
            if (existTag == null)
                return null;
            var posts = _context.Posts.Where(p => p.CategoryId == categoryId);
            if (onlyPublished)
                posts = posts.Where(p => p.Published.HasValue && p.Published.Value <= DateTime.UtcNow);

            if (filter != null) posts = posts.Where(filter);
            return new PagingList<Post>().GetPage(pageSize, pageOffset, posts, null, orderBy, isAsc);
        }

        public Post GetPostBySlug(string slug)
        {
            return _context.Posts
                .AsNoTracking()
                .Include(p => p.Tags)
                .Include(p => p.Comments)
                .FirstOrDefault(p => p.UrlSlug.Equals(slug));
        }
    }
}