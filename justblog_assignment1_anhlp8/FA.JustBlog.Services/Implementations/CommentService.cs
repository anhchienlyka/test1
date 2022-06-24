using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Paging;
using FA.JustBlog.Data.UnitOfWorks;
using FA.JustBlog.Services.Interfaces;
using FA.JustBlog.Services.Models.Request;
using FA.JustBlog.Services.Models.Response;
using System.Collections.Generic;

namespace FA.JustBlog.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private readonly IMapper _mapper;
        private readonly IBlogUnitOfWork _unitOfWork;

        public CommentService(IMapper mapper, IBlogUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public void CreateComment(CommentRequest request)
        {
            if (request != null)
            {
                var comment = _mapper.Map<Comment>(request);
                comment.CommandTime = System.DateTime.UtcNow;
                _unitOfWork.CommentRepository.Add(comment);
                _unitOfWork.Save();
            }
        }

        public void DeleteComment(int id)
        {
            _unitOfWork.CommentRepository.Delete(id);
            _unitOfWork.Save();
        }

        public PagingResult<CommentResponse> GetAllComments(int pageSize = 5, int pageOffset = 0)
        {
            var comments = _unitOfWork.CommentRepository.GetAll(pageSize, pageOffset);
            return _mapper.Map<PagingResult<CommentResponse>>(comments);
        }

        public CommentResponse GetCommentById(int id)
        {
            var comment = _unitOfWork.CommentRepository.Find(id);
            if (comment != null)
                return _mapper.Map<CommentResponse>(comment);
            return null;
        }

        public PagingResult<CommentResponse> GetCommentsOfPost(int postId, int pageSize = 5, int pageOffset = 0)
        {
            var comments = _unitOfWork.CommentRepository.GetCommentsForPost(postId, pageSize, pageOffset);
            return _mapper.Map<PagingResult<CommentResponse>>(comments);
        }

        public IEnumerable<CommentResponse> GetCommentsOfPost(int postId)
        {
            var comments = _unitOfWork.CommentRepository.GetCommentsForPost(postId);
            return _mapper.Map<IEnumerable<CommentResponse>>(comments);
        }

        public void UpdateComment(CommentRequest request)
        {
            var comment = _mapper.Map<Comment>(request);
            _unitOfWork.CommentRepository.Update(comment);
            _unitOfWork.Save();
        }
    }
}