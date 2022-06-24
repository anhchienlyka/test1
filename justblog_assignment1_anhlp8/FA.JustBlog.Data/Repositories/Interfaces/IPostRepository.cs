using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Paging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FA.JustBlog.Data.Repositories.Interfaces
{
    public interface IPostRepository : IGenericRepostiory<Post>
    {
        Post FindPost(int year, int month, string urlSlug);

        //Post FindPost(int postId);

        //void AddPost(Post post);

        //void UpdatePost(Post post);

        //void DeletePost(Post post);

        //void DeletePost(int postId);

        //IList<Post> GetAllPosts();

        PagingResult<Post> GetPublisedPosts(int pageSize = 5, int pageOffset = 0);

        PagingResult<Post> GetUnpublisedPosts(int pageSize = 5, int pageOffset = 0);

        PagingResult<Post> GetLatestPost(int pageSize = 5, int pageOffset = 0);

        PagingResult<Post> GetPostsByMonth(DateTime monthYear, int pageSize = 5, int pageOffset = 0);

        int CountPostsForCategory(string category);

        PagingResult<Post> GetPostsByCategory(
            string category,
            int pageSize = 5,
            int pageOffset = 0,
            bool onlyPublised = false,
            Expression<Func<Post, bool>> filter = null,
            Expression<Func<Post, object>> orderBy = null,
            bool isAsc = true);

        int CountPostsForTag(string tag);

        PagingResult<Post> GetPostsByTag(
            string tag, int
            pageSize = 5,
            int pageOffset = 0,
            bool onlyPublised = false,
            Expression<Func<Post, bool>> filter = null,
            Expression<Func<Post, object>> orderBy = null,
            bool isAsc = true);

        PagingResult<Post> GetPostsByTag(
            int tagId,
            int pageSize = 5,
            int pageOffset = 0,
            bool onlyPublised = false,
            Expression<Func<Post, bool>> filter = null,
            Expression<Func<Post, object>> orderBy = null,
            bool isAsc = true);

        PagingResult<Post> GetMostViewedPost(int pageSize = 5, int pageOffset = 0, bool onlyPublised = false);

        PagingResult<Post> GetHighestPosts(int pageSize = 5, int pageOffset = 0, bool onlyPublised = false);

        void UpdateTagInPost(Post post, List<int> tagIds);

        PagingResult<Post> GetPostsByCategory(int categoryId, int pageSize = 5, int pageOffset = 0,
            Expression<Func<Post, bool>> filter = null,
            Expression<Func<Post, object>> orderBy = null,
            bool isAsc = true,
            bool onlyPublished = false);

        Post GetPostBySlug(string slug);
    }
}