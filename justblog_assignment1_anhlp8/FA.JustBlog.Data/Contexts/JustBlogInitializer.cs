using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FA.JustBlog.Data.Contexts
{
    public class JustBlogInitializer
    {
        public void SeedData(ModelBuilder mb)
        {
            var date = new DateTime(2021, 3, 20, 5, 21, 32);
            mb.Entity<Category>().HasData(new[]
            {
                new Category{Id = 1, Name = "cat 1", Description = "des 1", UrlSlug = "cat-1", PostedOn = date, Modified = date},
                new Category{Id = 2, Name = "cat 2", Description = "des 2", UrlSlug = "cat-2", PostedOn = date, Modified = date},
                new Category{Id = 3, Name = "cat 3", Description = "des 3", UrlSlug = "cat-3", PostedOn = date, Modified = date},
            });

            mb.Entity<Tag>().HasData(new[] {
                new Tag {Id = 1, Name = "tag 1", Description = "des 1", Count = 109, UrlSlug = "tag-1", PostedOn = date, Modified = date},
                new Tag {Id = 2, Name = "tag 2", Description = "des 2", Count = 400, UrlSlug = "tag-2", PostedOn = date, Modified = date},
                new Tag {Id = 3, Name = "tag 3", Description = "des 3", Count = 500, UrlSlug = "tag-3", PostedOn = date, Modified = date},
            });

            mb.Entity<Post>().HasData(new[]
            {
                new Post{
                    Modified = date,
                    Id = 1,
                    Title = "title 1",
                    UrlSlug = "title-1",
                    CategoryId = 1,
                    ShortDescription = "des 1",
                    PostContent = "content 1",
                    PostedOn = date,
                    ViewCount = 100,
                    RateCount = 10,
                    TotalRate = 109,
                    Published = date
                },
                new Post{
                    Modified = date,
                    Id = 2,
                    Title = "title 2",
                    UrlSlug = "title-2",
                    CategoryId = 2,
                    ShortDescription = "des 2",
                    PostContent = "content 2",
                    PostedOn = date,
                    ViewCount = 200,
                    RateCount = 10,
                    TotalRate = 200,
                    Published = date
                },
                new Post{
                    Modified = date,
                    Id = 3,
                    Title = "title 3",
                    UrlSlug = "title-3",
                    CategoryId = 3,
                    ShortDescription = "des 3",
                    PostContent = "content 3",
                    PostedOn = date,
                    ViewCount = 150,
                    RateCount = 200,
                    TotalRate = 400
                },
            });

            mb.Entity<PostTagMap>().HasData(new[]
            {
                new PostTagMap{PostId = 1, TagId = 1},
                new PostTagMap{PostId = 1, TagId = 2},
                new PostTagMap{PostId = 2, TagId = 3},
                new PostTagMap{PostId = 3, TagId = 1},
                new PostTagMap{PostId = 3, TagId = 3},
            });

            mb.Entity<Comment>().HasData(new[]
            {
                new Comment
                {
                    Id = 1,
                    PostId = 1,
                    Name = "user 1",
                    Email = "user1@mail.com",
                    CommentHeader = "header 1",
                    CommentText = "text 1",
                    CommandTime = date,
                    PostedOn = date,
                    Modified = date
                },
                new Comment
                {
                    Id = 2,
                    PostId = 2,
                    Name = "user 2",
                    Email = "user2@mail.com",
                    CommentHeader = "header 2",
                    CommentText = "text 2",
                    CommandTime = date,
                    PostedOn = date,
                    Modified = date
                },
                new Comment
                {
                    Id = 3,
                    PostId = 3,
                    Name = "user 3",
                    Email = "user3@mail.com",
                    CommentHeader = "header 3",
                    CommentText = "text 3",
                    CommandTime = date,
                    PostedOn = date,
                    Modified = date
                }
            });
        }
    }
}