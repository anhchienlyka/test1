using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Models.Contexts;
using FA.JustBlog.Core.Repositories.Implements;
using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;
using System.Linq;

namespace FA.JustBlog.UnitTest
{
    public class PostRepositoryTests
    {
        private JustBlogContext _context;
        private PostRepository _repository;
        private Post _post;
        private IDbContextTransaction _transaction;

        [SetUp]
        public void Setup()
        {
            _context = new JustBlogContext();
            _repository = new PostRepository(_context);
            _post = new Post()
            {
                Title = "title",
                CategoryId = 2,
                PostContent = "content",
                UrlSlug = "new post",
            };
            _transaction = _context.Database.BeginTransaction();
            _transaction.CreateSavepoint("beginTest");
        }

        [Test]
        public void Add_ValidPost_Successfully()
        {
            _repository.Add(_post);
            var result = _context.Posts.FirstOrDefault(t => t.UrlSlug.Equals(_post.UrlSlug));
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Add_PostHasTitleIsNull_Failed()
        {
            _post.Title = null;
            Assert.That(() => _repository.Add(_post), Throws.Exception);
        }

        [Test]
        public void FindPost_ExistPost_ReturnCorrect()
        {
            var result = _repository.FindPost(2021, 09, "title-1");
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Get_Post_Successfully()
        {
            var result = _repository.GetAll();
            Assert.That(result.Count, Is.GreaterThan(2));
        }

        [Test]
        public void Find_Post_Correct()
        {
            var result = _repository.Find(2);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void GetPublisedPosts_PostIsPublished_ReturnCorrect()
        {
            var result = _repository.GetPublisedPosts();
            Assert.That(result[0].Title, Is.EqualTo("title 1"));
        }

        [Test]
        public void GetUnPublishedPosts_HasUnpublishedPost_ReturnCorrect()
        {
            var result = _repository.GetUnpublisedPosts();
            Assert.That(result[result.Count - 1].Title, Is.EqualTo("title 3"));
        }

        [Test]
        public void GetLatestPost_PostIsPublished_ReturnCorrect()
        {
            var result = _repository.GetLatestPost(3);
            Assert.That(result[result.Count - 1].Title, Is.EqualTo("title 1"));
        }

        [Test]
        public void GetPostsByMonth_PostIsPublishedInMonth_ReturnCorrect()
        {
            var dateTime = new System.DateTime(2021, 9, 1);
            var result = _repository.GetPostsByMonth(dateTime);
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void CountPostsForCategory_OnePostForOneCategory_ReturnOne()
        {
            var result = _repository.CountPostsForCategory("cat 1");
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void CountPostsForTag_ExistPost_ReturnCorrect()
        {
            var result = _repository.CountPostsForTag("tag 3");
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void GetMostViewedPost_ContainPosts_ReturnCorrect()
        {
            var result = _repository.GetMostViewedPost(2);
            Assert.That(result[0].Title, Is.EqualTo("title 2"));
        }

        [Test]
        public void GetHighestPosts_ContainPosts_ReturnCorrect()
        {
            var result = _repository.GetHighestPosts(1);
            Assert.That(result[0].Title, Is.EqualTo("title 3"));
        }

        [Test]
        public void Update_Post_Successfull()
        {
            var post = _repository.Find(2);
            var newTitle = post.Title + " updated";
            post.Title = newTitle;
            _repository.Update(post);
            post = _repository.Find(2);
            Assert.That(post.Title, Is.EqualTo(newTitle));
        }

        [Test]
        public void Delete_Post_Successfull()
        {
            _repository.Delete(2);
            var result = _repository.Find(2);
            Assert.That(result, Is.Null);
        }

        [TearDown]
        public void TearDown()
        {
            _transaction.RollbackToSavepoint("beginTest");
            _context.Dispose();
        }
    }
}