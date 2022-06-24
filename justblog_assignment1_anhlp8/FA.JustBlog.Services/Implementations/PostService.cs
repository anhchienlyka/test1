using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Paging;
using FA.JustBlog.Data.UnitOfWorks;
using FA.JustBlog.Services.Interfaces;
using FA.JustBlog.Services.Models.Request;
using FA.JustBlog.Services.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FA.JustBlog.Services.Implementations
{
    public class PostService : IPostService
    {
        private readonly IBlogUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostService(IBlogUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreatePost(PostRequest request)
        {
            var postDbEntity = _mapper.Map<Post>(request);
            //add new post
            _unitOfWork.PostRepository.Add(postDbEntity);
            _unitOfWork.Save();
            //add new tags
            _unitOfWork.TagRepository.AddTagsByNames(request.TagNames);
            _unitOfWork.Save();
            //update post tag map in post
            var tagIds = _unitOfWork.TagRepository.GetIdsByTagNames(request.TagNames);
            _unitOfWork.PostRepository.UpdateTagInPost(postDbEntity, tagIds);
            _unitOfWork.Save();
        }

        public void DeletePost(int id)
        {
            _unitOfWork.PostRepository.Delete(id);
            _unitOfWork.Save();
        }

        public PagingResult<PostResponse> GetAllPosts(
            Expression<Func<Post, bool>> filter,
            Expression<Func<Post, object>> orderBy,
            bool isAsc = true,
            int pageOffset = 0, int pageSize = 5)
        {
            var posts = _unitOfWork.PostRepository.GetByCondition(pageSize, pageOffset, filter, orderBy, isAsc);
            return _mapper.Map<PagingResult<PostResponse>>(posts);
        }

        public PagingResult<PostResponse> GetAllPublishedPosts(int pageOffset = 0, int pageSize = 5)
        {
            var posts = _unitOfWork.PostRepository.GetPublisedPosts(pageSize, pageOffset);
            return _mapper.Map<PagingResult<PostResponse>>(posts);
        }

        public IEnumerable<PostResponse> GetLatestPosts(int pageOffset = 0, int pageSize = 5)
        {
            var posts = _unitOfWork.PostRepository.GetLatestPost(pageSize, pageOffset);
            return _mapper.Map<IEnumerable<PostResponse>>(posts.Items);
        }

        public IEnumerable<PostResponse> GetMostViewPost(int pageOffset = 0, int pageSize = 5, bool onlyPublished = true)
        {
            var posts = _unitOfWork.PostRepository.GetMostViewedPost(pageSize, pageOffset, onlyPublished);
            return _mapper.Map<IEnumerable<PostResponse>>(posts.Items);
        }

        public PagingResult<PostResponse> GetPostByCategory(
            int categoryId,
            Expression<Func<Post, bool>> filter,
            Expression<Func<Post, object>> orderBy,
            bool isAsc = true,
            int pageOffset = 0, int pageSize = 5, bool onlyPublished = false)
        {
            var posts = _unitOfWork.PostRepository.GetPostsByCategory(categoryId, pageSize, pageOffset, filter, orderBy, isAsc);
            return _mapper.Map<PagingResult<PostResponse>>(posts);
        }

        public PostResponse GetPostById(int id)
        {
            var post = _unitOfWork.PostRepository.Find(id);
            if (post == null)
                return null;
            var comments = _unitOfWork.CommentRepository.GetCommentsForPost(post.Id);
            post.Comments = comments.ToList();
            return _mapper.Map<PostResponse>(post);
        }

        public PostResponse GetPostBySlug(string slug)
        {
            var post = _unitOfWork.PostRepository.GetByCondition(1, 0, p => p.UrlSlug == slug)?.Items?.FirstOrDefault();
            if (post != null)
            {
                //call find from repo to get detail (category, tags, comment);
                post = _unitOfWork.PostRepository.Find(post.Id);
                return _mapper.Map<PostResponse>(post);
            }
            return null;
        }

        public PagingResult<PostResponse> GetPostsByTag(
            int tagId,
            Expression<Func<Post, bool>> filter,
            Expression<Func<Post, object>> orderBy,
            bool isAsc = true,
            int pageOffset = 0,
            int pageSize = 5,
            bool onlyPublished = false)
        {
            var posts = _unitOfWork.PostRepository.GetPostsByTag(tagId, pageSize, pageOffset, onlyPublished, filter, orderBy, isAsc);
            if (posts == null)
                return null;
            return _mapper.Map<PagingResult<PostResponse>>(posts);
        }

        public void Publish(int postId)
        {
            var post = _unitOfWork.PostRepository.Find(postId);
            if (post != null)
            {
                post.Published = DateTime.UtcNow;
                _unitOfWork.PostRepository.Update(post);
                _unitOfWork.Save();
            }
        }

        public void UnPublish(int postId)
        {
            var post = _unitOfWork.PostRepository.Find(postId);
            if (post != null)
            {
                post.Published = null;
                _unitOfWork.PostRepository.Update(post);
                _unitOfWork.Save();
            }
        }

        public void UpdatePost(PostRequest request)
        {
            var existPost = _unitOfWork.PostRepository.Find(request.Id);
            if (existPost == null)
                throw new ArgumentNullException(nameof(request));
            //add new tags
            _unitOfWork.TagRepository.AddTagsByNames(request.TagNames);
            _unitOfWork.Save();
            //update post tag map in post
            var tagIds = _unitOfWork.TagRepository.GetIdsByTagNames(request.TagNames);
            _unitOfWork.PostRepository.UpdateTagInPost(existPost, tagIds);
            _unitOfWork.Save();
            var postDbEntity = _mapper.Map<Post>(request);
            //update info about post
            _unitOfWork.PostRepository.Update(postDbEntity);
            _unitOfWork.Save();
        }

        public PostResponse ViewPost(int id)
        {
            var post = _unitOfWork.PostRepository.Find(id);
            if (post == null)
                return null;
            post.ViewCount++;
            _unitOfWork.PostRepository.Update(post);
            _unitOfWork.Save();
            var comments = _unitOfWork.CommentRepository.GetCommentsForPost(post.Id);
            post.Comments = comments.ToList();
            return _mapper.Map<PostResponse>(post);
        }

        public PostResponse ViewPost(string slug)
        {
            var post = _unitOfWork.PostRepository.GetPostBySlug(slug);
            if (post == null)
                return null;
            //call find from repo to get detail (category, tags, comment);
            post = _unitOfWork.PostRepository.Find(post.Id);
            //increase view count
            post.ViewCount++;
            _unitOfWork.PostRepository.Update(post);
            _unitOfWork.Save();
            //get comments in this post
            var comments = _unitOfWork.CommentRepository.GetCommentsForPost(post.Id);
            post.Comments = comments.ToList();
            return _mapper.Map<PostResponse>(post);
        }

        public PagingResult<PostResponse> ViewPostsByTag(
            int tagId,
            Expression<Func<Post, bool>> filter,
            Expression<Func<Post, object>> orderBy,
            bool isAsc = true,
            int pageOffset = 0, int pageSize = 5,
            bool onlyPublished = false)
        {
            var posts = _unitOfWork.PostRepository.GetPostsByTag(tagId, pageSize, pageOffset, onlyPublished, filter, orderBy, isAsc);
            if (posts == null)
                return null;

            return _mapper.Map<PagingResult<PostResponse>>(posts);
        }
    }
}