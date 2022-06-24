using FA.JustBlog.Core.Paging;
using FA.JustBlog.Services.Models;
using FA.JustBlog.Services.Models.Request;
using FA.JustBlog.Services.Models.Response;

namespace FA.JustBlog.Services.Interfaces
{
    public interface ICommentService
    {
        CommentResponse GetCommentById(int id);

        PagingResult<CommentResponse> GetCommentsOfPost(int postId, int pageSize = 5, int pageOffset = 0);

        PagingResult<CommentResponse> GetAllComments(int pageSize = 5, int pageOffset = 0);

        void CreateComment(CommentRequest request);

        void UpdateComment(CommentRequest request);

        void DeleteComment(int id);
    }
}