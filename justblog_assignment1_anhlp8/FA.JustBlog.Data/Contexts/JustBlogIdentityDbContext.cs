using FA.JustBlog.Core.Base.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Data.Contexts
{
    public class JustBlogIdentityDbContext : IdentityDbContext
    {
        public JustBlogIdentityDbContext(DbContextOptions<JustBlogIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedData(builder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            //Seeding a  'Administrator' role to AspNetRoles table
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = RoleType.Adminstrator.ToString(), NormalizedName = RoleType.Adminstrator.ToString().ToUpper() });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "dba9da8e-249f-4a64-92da-41ff8c51d3f9", Name = RoleType.User.ToString(), NormalizedName = RoleType.User.ToString().ToUpper() });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "c50cc491-7280-4125-8f9e-8c7700210e09", Name = RoleType.Contributor.ToString(), NormalizedName = RoleType.Contributor.ToString().ToUpper() });

            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<IdentityUser>();

            //Seeding the User to AspNetUsers table
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                    UserName = "admin",
                    Email = "admin@mail.com",
                    NormalizedUserName = "admin",
                    PasswordHash = hasher.HashPassword(null, "admin")
                }
            );
            //Seeding the User to AspNetUsers table
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "f3d3decd-257c-45b0-9f46-40e9f8a4be81", // primary key
                    UserName = "user",
                    Email = "user@mail.com",
                    NormalizedUserName = "user",
                    PasswordHash = hasher.HashPassword(null, "admin")
                }
            );
            //Seeding the User to AspNetUsers table
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "f79377cb-bece-436f-b615-2a4fd073568c", // primary key
                    UserName = "user2",
                    Email = "user2@mail.com",
                    NormalizedUserName = "user2",
                    PasswordHash = hasher.HashPassword(null, "admin")
                }
            );
            //Seeding the User to AspNetUsers table
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "4d5d159a-f9ef-450f-94cb-8d5a15ddda13", // primary key
                    UserName = "user3",
                    Email = "user3@mail.com",
                    NormalizedUserName = "user3",
                    PasswordHash = hasher.HashPassword(null, "admin")
                }
            );

            //Seeding the relation between our user and role to AspNetUserRoles table
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                }
            );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "c50cc491-7280-4125-8f9e-8c7700210e09",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                }
            );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "c50cc491-7280-4125-8f9e-8c7700210e09",
                    UserId = "f3d3decd-257c-45b0-9f46-40e9f8a4be81"
                }
            );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
               new IdentityUserRole<string>
               {
                   RoleId = "dba9da8e-249f-4a64-92da-41ff8c51d3f9",
                   UserId = "f79377cb-bece-436f-b615-2a4fd073568c"
               }
            );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
              new IdentityUserRole<string>
              {
                  RoleId = "dba9da8e-249f-4a64-92da-41ff8c51d3f9",
                  UserId = "4d5d159a-f9ef-450f-94cb-8d5a15ddda13"
              }
           );
        }
    }
}