using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Paging;
using System.Collections.Generic;

namespace FA.JustBlog.Data.Repositories.Interfaces
{
    public interface ICommentRepository : IGenericRepostiory<Comment>
    {
        void Add(int postId, string commentName, string commentEmail, string commentTitle, string commentBody);

        PagingResult<Comment> GetCommentsForPost(int postId, int pageSize = 5, int pageOffset = 0);

        IEnumerable<Comment> GetCommentsForPost(int postId);
    }
}