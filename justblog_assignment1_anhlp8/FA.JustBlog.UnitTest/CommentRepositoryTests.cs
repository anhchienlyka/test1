using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Models.Contexts;
using FA.JustBlog.Core.Repositories.Implements;
using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;
using System.Linq;

namespace FA.JustBlog.UnitTest
{
    [TestFixture]
    public class CommentRepositoryTests
    {
        private JustBlogContext _context;
        private CommentRepository _repository;
        private Comment _comment;
        private IDbContextTransaction _transaction;

        [SetUp]
        public void Setup()
        {
            _context = new JustBlogContext();
            _repository = new CommentRepository(_context);
            _comment = new Comment()
            {
                PostId = 1,
                Name = "admin",
                Email = "admin@fsoft.com.vn",
                CommentHeader = "header",
                CommentText = "comment content"
            };
            _transaction = _context.Database.BeginTransaction();
            _transaction.CreateSavepoint("beginTest");
        }

        [Test]
        public void Add_ValidComment_Successfully()
        {
            _repository.Add(_comment);
            var result = _context.Comments.FirstOrDefault(t => t.Email.Equals(_comment.Email));
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Add_CommentHasNameIsNull_Failed()
        {
            _comment.Name = null;
            Assert.That(() => _repository.Add(_comment), Throws.Exception);
        }

        [Test]
        public void Get_Comment_Successfully()
        {
            var result = _repository.GetAll();
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Find_Comment_ReturnCorrect()
        {
            var result = _repository.Find(2);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Update_Comment_Successfull()
        {
            var Comment = _repository.Find(2);
            var newName = "new name-updated";
            Comment.Name = newName;
            _repository.Update(Comment);
            Comment = _repository.Find(2);
            Assert.That(Comment.Name, Is.EqualTo(newName));
        }

        [Test]
        public void Delete_Comment_Successfull()
        {
            _repository.Delete(1);
            var result = _repository.Find(1);
            Assert.That(result, Is.Null);
        }

        [TearDown]
        public void TearDown()
        {
            _transaction.RollbackToSavepoint("beginTest");
            System.Console.WriteLine("Rollback");
            _context.Dispose();
        }
    }
}