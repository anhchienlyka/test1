using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Models.Contexts;
using FA.JustBlog.Core.Repositories.Implements;
using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;
using System.Linq;

namespace FA.JustBlog.UnitTest
{
    [TestFixture]
    public class CategoryRepositoryTests
    {
        private JustBlogContext _context;
        private CategoryRepository _repository;
        private Category _category;
        private IDbContextTransaction _transaction;

        [SetUp]
        public void Setup()
        {
            _context = new JustBlogContext();
            _repository = new CategoryRepository(_context);
            _category = new Category()
            {
                Name = "new cat",
                UrlSlug = "new-cat"
            };
            _transaction = _context.Database.BeginTransaction();
            _transaction.CreateSavepoint("beginTest");
        }

        [Test]
        public void Add_ValidCategory_Successfully()
        {
            _repository.Add(_category);
            var result = _context.Categories.FirstOrDefault(t => t.UrlSlug.Equals(_category.UrlSlug));
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Add_CategoryHasNameIsNull_Failed()
        {
            _category.Name = null;
            Assert.That(() => _repository.Add(_category), Throws.Exception);
        }

        [Test]
        public void Get_Category_Successfully()
        {
            var result = _repository.GetAll();
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Find_Category_ReturnCorrect()
        {
            var result = _repository.Find(2);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Update_Category_Successfull()
        {
            var category = _repository.Find(2);
            var newName = "new name-updated";
            category.Name = newName;
            _repository.Update(category);
            category = _repository.Find(2);
            Assert.That(category.Name, Is.EqualTo(newName));
        }

        [Test]
        public void Delete_Category_Successfull()
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