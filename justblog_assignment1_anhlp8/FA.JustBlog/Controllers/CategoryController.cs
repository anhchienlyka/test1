using AutoMapper;
using FA.JustBlog.Core.Enums;
using FA.JustBlog.Core.Helpers;
using FA.JustBlog.Models;
using FA.JustBlog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace FA.JustBlog.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public CategoryController(
            ILogger<CategoryController> logger,
            ICategoryService categoryService,
            IPostService postService,
            IMapper mapper)
        {
            _logger = logger;
            _categoryService = categoryService;
            _postService = postService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            try
            {
                var categories = _categoryService.GetCategories();
                return View(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }

        public ActionResult ListPost(int categoryId, int pageSize = 3, int pageIndex = 1)
        {
            try
            {
                var categoryRes = _categoryService.GetCategory(categoryId);
                if (categoryRes == null) return NotFound();
                var orderByQuery = OrderByHelper.GetOrderByByConstant(PostOrderBy.VIEW);
                var posts = _postService.GetPostByCategory(categoryId, null, orderByQuery, false, pageIndex - 1, pageSize, true);
                var vm = new CategoryListPostViewModel()
                {
                    Category = categoryRes,
                    PostsOfCategory = posts
                };
                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }
    }
}