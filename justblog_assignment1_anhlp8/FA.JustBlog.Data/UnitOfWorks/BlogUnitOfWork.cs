using FA.JustBlog.Data.Contexts;
using FA.JustBlog.Data.Repositories.Interfaces;

namespace FA.JustBlog.Data.UnitOfWorks
{
    public class BlogUnitOfWork : IBlogUnitOfWork
    {
        public BlogUnitOfWork(
            IPostRepository postRepository,
            ITagRepository tagRepository,
            ICommentRepository commentRepository,
            ICategoryRepository categoryRepository,
            JustBlogContext context)
        {
            PostRepository = postRepository;
            TagRepository = tagRepository;
            CommentRepository = commentRepository;
            CategoryRepository = categoryRepository;
            Context = context;
        }

        public IPostRepository PostRepository { get; private set; }

        public ITagRepository TagRepository { get; private set; }

        public ICommentRepository CommentRepository { get; private set; }

        public ICategoryRepository CategoryRepository { get; private set; }

        public JustBlogContext Context { get; private set; }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}