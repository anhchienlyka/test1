using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FA.JustBlog.Data.Contexts
{
    public class EntityConfigurator
    {
        public void Config(ModelBuilder modelBuilder)
        {
            ConfigPost(modelBuilder.Entity<Post>());
            ConfigPostTagMap(modelBuilder.Entity<PostTagMap>());
            ConfigComment(modelBuilder.Entity<Comment>());
        }

        private void ConfigComment(EntityTypeBuilder<Comment> eb)
        {
            eb.HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId);

            eb.Property(c => c.CommandTime)
                .HasDefaultValue(DateTime.UtcNow);
        }

        private void ConfigPost(EntityTypeBuilder<Post> eb)
        {
            eb.HasOne(p => p.Category)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.CategoryId);

            eb.HasMany(p => p.Tags)
                .WithMany(p => p.Posts)
                .UsingEntity<PostTagMap>(
                    j => j
                        .HasOne(pt => pt.Tag)
                        .WithMany(t => t.PostTagMap)
                        .HasForeignKey(pt => pt.TagId),
                    j => j
                        .HasOne(pt => pt.Post)
                        .WithMany(p => p.PostTagMap)
                        .HasForeignKey(pt => pt.PostId));

            eb.Property(p => p.ViewCount)
                .HasDefaultValue(0);

            eb.Property(p => p.RateCount)
                .HasDefaultValue(0);

            eb.Property(p => p.TotalRate)
                .HasDefaultValue(0);
        }

        private void ConfigTag(EntityTypeBuilder<Tag> eb)
        {
            eb.ToTable("Tags");

            eb.HasKey(t => new { t.Id })
                .IsClustered();

            eb.Property(t => t.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(255);

            eb.Property(t => t.UrlSlug)
                .HasColumnType("varchar")
                .HasMaxLength(255);

            eb.Property(t => t.Description)
                .HasColumnType("nvarchar")
                .HasMaxLength(1000);

            eb.Property(t => t.Count)
                .HasColumnType("int");
        }

        private void ConfigCategory(EntityTypeBuilder<Category> eb)
        {
            eb.ToTable("Categories");

            eb.HasKey(eb => eb.Id).IsClustered();

            eb.Property(c => c.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(255);

            eb.Property(c => c.UrlSlug)
                .HasColumnType("varchar")
                .HasMaxLength(255);

            eb.Property(t => t.Description)
                .HasColumnType("nvarchar")
                .HasMaxLength(1000);
        }

        private void ConfigPostTagMap(EntityTypeBuilder<PostTagMap> eb)
        {
            //eb.HasKey(pt => new { pt.PostId, pt.TagId });

            //eb.HasOne(pt => pt.Post)
            //    .WithMany(p => p.PostTagMap)
            //    .HasForeignKey(pt => pt.PostId);

            //eb.HasOne(pt => pt.Tag)
            //   .WithMany(t => t.PostTagMap)
            //   .HasForeignKey(pt => pt.TagId);
        }
    }
}