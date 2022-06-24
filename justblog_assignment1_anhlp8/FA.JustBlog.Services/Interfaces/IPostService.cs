using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Paging;
using FA.JustBlog.Services.Models.Request;
using FA.JustBlog.Services.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FA.JustBlog.Services.Interfaces
{
    public interface IPostService
    {
        PagingResult<PostResponse> GetAllPublishedPosts(int pageOffset = 0, int pageSize = 5);

        PagingResult<PostResponse> GetAllPosts(
            Expression<Func<Post, bool>> filter,
            Expression<Func<Post, object>> orderBy,
            bool isAsc = true,
            int pageOffset = 0, int pageSize = 5);

        IEnumerable<PostResponse> GetLatestPosts(int pageOffset = 0, int pageSize = 5);

        PostResponse GetPostBySlug(string slug);

        void CreatePost(PostRequest request);

        PostResponse GetPostById(int id);

        void UpdatePost(PostRequest request);

        void DeletePost(int id);

        IEnumerable<PostResponse> GetMostViewPost(int pageOffset = 0, int pageSize = 5, bool onlyPublished = true);

        PagingResult<PostResponse> GetPostByCategory(
            int categoryId,
            Expression<Func<Post, bool>> filter,
            Expression<Func<Post, object>> orderBy,
            bool isAsc = true,
            int pageOffset = 0, int pageSize = 5,
            bool onlyPublished = false);

        PagingResult<PostResponse> GetPostsByTag(
            int tagId,
            Expression<Func<Post, bool>> filter,
            Expression<Func<Post, object>> orderBy,
            bool isAsc = true,
            int pageOffset = 0, int pageSize = 5,
            bool onlyPublished = false);

        PagingResult<PostResponse> ViewPostsByTag(
            int tagId,
            Expression<Func<Post, bool>> filter,
            Expression<Func<Post, object>> orderBy,
            bool isAsc = true,
            int pageOffset = 0, int pageSize = 5,
            bool onlyPublished = false);

        void Publish(int postId);

        void UnPublish(int postId);

        PostResponse ViewPost(int id);

        PostResponse ViewPost(string slug);
    }
}