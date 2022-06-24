using FA.JustBlog.Data.Contexts;
using FA.JustBlog.Data.Repositories.Interfaces;

namespace FA.JustBlog.Data.UnitOfWorks
{
    public interface IBlogUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        ICommentRepository CommentRepository { get; }
        JustBlogContext Context { get; }
        IPostRepository PostRepository { get; }
        ITagRepository TagRepository { get; }

        void Save();
    }
}