using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Models.Contexts;
using FA.JustBlog.Core.Repositories.Implements;
using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;
using System.Linq;

namespace FA.JustBlog.UnitTest
{
    public class TagRepositoryTests
    {
        private JustBlogContext _context;
        private TagRepository _repository;
        private Tag _tag;
        private IDbContextTransaction _transaction;

        [SetUp]
        public void Setup()
        {
            _context = new JustBlogContext();
            _repository = new TagRepository(_context);
            _tag = new Tag() { Name = "tag", Count = 0, UrlSlug = "tag" };
            _transaction = _context.Database.BeginTransaction();
            _transaction.CreateSavepoint("beginTest");
        }

        [Test]
        public void Add_ValidTag_Successfully()
        {
            _repository.Add(_tag);
            var result = _context.Tags.FirstOrDefault(t => t.UrlSlug.Equals(_tag.UrlSlug));
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Add_TagHasNameIsNull_Failed()
        {
            _tag.Name = null;
            Assert.That(() => _repository.Add(_tag), Throws.Exception);
        }

        [Test]
        public void Get_Tag_Successfully()
        {
            var result = _repository.GetAll();
            Assert.That(result.Count, Is.GreaterThan(2));
        }

        [Test]
        public void Find_Tag_Correct()
        {
            var result = _repository.Find(2);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Update_Tag_Successfull()
        {
            var tag = _repository.Find(2);
            var newCount = tag.Count + 1;
            tag.Count = newCount;
            _repository.Update(tag);
            tag = _repository.Find(2);
            Assert.That(tag.Count, Is.EqualTo(newCount));
        }

        [Test]
        public void Delete_Tag_Successfull()
        {
            _repository.Delete(1);
            var result = _repository.Find(1);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetTagByUrlSlug_ExistUrlSlug_ReturnCorrect()
        {
            var result = _repository.GetTagByUrlSlug("tag-3");
            Assert.That(result, Is.Not.Null);
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