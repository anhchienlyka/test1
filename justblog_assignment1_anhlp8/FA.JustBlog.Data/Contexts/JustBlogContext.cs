using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Models.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;

namespace FA.JustBlog.Data.Contexts
{
    public class JustBlogContext : DbContext
    {
        private readonly ILogger<JustBlogContext> _logger;

        public JustBlogContext(DbContextOptions<JustBlogContext> options, ILogger<JustBlogContext> logger) : base(options)
        {
            _logger = logger;
        }

        public override int SaveChanges()
        {
            var now = DateTime.UtcNow;

            foreach (var changedEntity in ChangeTracker.Entries())
            {
                if ((changedEntity.Entity).GetType().IsSubclassOf(typeof(BaseEntity)))
                {
                    var entity = (BaseEntity)changedEntity.Entity;
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            _logger.LogInformation("Added time: " + now);
                            entity.Modified = now;
                            entity.PostedOn = now;
                            break;

                        case EntityState.Modified:
                            _logger.LogInformation("Edited time: " + now);
                            entity.Modified = now;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configurator = new EntityConfigurator();
            configurator.Config(modelBuilder);
            var dataInit = new JustBlogInitializer();
            dataInit.SeedData(modelBuilder);
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}