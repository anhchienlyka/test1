using FA.JustBlog.Data.Contexts;
using FA.JustBlog.Data.Repositories.Implements;
using FA.JustBlog.Data.Repositories.Interfaces;
using FA.JustBlog.Data.UnitOfWorks;
using FA.JustBlog.Mapper;
using FA.JustBlog.Services.Implementations;
using FA.JustBlog.Services.Interfaces;
using FA.JustBlog.Services.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace FA.JustBlog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //register identity
            services.AddDbContext<JustBlogIdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("IdentityDatabase")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                //.AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<JustBlogIdentityDbContext>()
                .AddDefaultTokenProviders() //add token for reset passwork, email,...
                .AddDefaultUI();

            services.Configure<IdentityOptions>(o =>
            {
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            //register DbContext
            services.AddDbContext<JustBlogContext>(o =>
            {
                o.UseSqlServer(Configuration.GetConnectionString("JustBlogDatabase"));
                o.EnableSensitiveDataLogging();
                o.UseLoggerFactory(LoggerFactory.Create(c => c.AddConsole()));
            });

            //register repos
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            //register unit of work
            services.AddScoped<IBlogUnitOfWork, BlogUnitOfWork>();

            //register services
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IUserService, UserService>();

            //register mapper
            services.AddAutoMapper(c =>
            {
                c.AddProfile<ServiceMapperProfile>();
                c.AddProfile<WebMapperProfile>();
            });

            //register MVC services
            services.AddControllersWithViews();

            //register service for custom tag helper
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
            services.AddTransient<IUrlHelperFactory, UrlHelperFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=DashboardPost}/{action=Index}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Post}/{action=Index}");

                endpoints.MapRazorPages();
            });
        }
    }
}