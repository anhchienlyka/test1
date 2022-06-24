using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Paging;
using FA.JustBlog.Data.Contexts;
using FA.JustBlog.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FA.JustBlog.Data.Repositories.Implements
{
    public class CommentRepository : GenericRepostiory<Comment>, ICommentRepository
    {
        public CommentRepository(JustBlogContext context) : base(context)
        {
        }

        public void Add(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            var comment = new Comment()
            {
                PostId = postId,
                Name = commentName,
                Email = commentEmail,
                CommentHeader = commentTitle,
                CommentText = commentBody,
                CommandTime = DateTime.UtcNow
            };
            base.Add(comment);
        }

        public PagingResult<Comment> GetCommentsForPost(int postId, int pageSize = 5, int pageOffset = 0)
        {
            return GetByCondition(pageSize, pageOffset, c => c.PostId == postId, null, false);
        }

        public IEnumerable<Comment> GetCommentsForPost(int postId)
        {
            return _context.Comments
                .Where(c => c.PostId == postId)
                .OrderBy(c => c.CommandTime)
                .ToList();
        }
    }
}