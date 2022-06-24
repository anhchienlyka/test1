using AutoMapper;
using FA.JustBlog.Core.Base.Enums;
using FA.JustBlog.Core.Enums;
using FA.JustBlog.Core.Helpers;
using FA.JustBlog.Models;
using FA.JustBlog.Services.Interfaces;
using FA.JustBlog.Services.Models.Request;
using FA.JustBlog.Services.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace FA.JustBlog.Areas.Admin.Controllers
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

        [HttpGet]
        [Authorize(Roles = Role.ADMIN_CONTRIBUTOR)]
        public ActionResult Create()
        {
            var category = new CreateCategoryViewModel();
            return View(category);
        }

        [HttpPost]
        [Authorize(Roles = Role.ADMIN_CONTRIBUTOR)]
        public ActionResult Create(CreateCategoryViewModel category)
        {
            if (!ModelState.IsValid) return View(category);
            try
            {
                var categoryRequest = _mapper.Map<CategoryRequest>(category);
                _categoryService.CreateCategory(categoryRequest);
                SetAlertInTempData("Create category", true);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                SetAlertInTempData("Create category", false);
                return View(category);
            }
        }

        [HttpGet]
        [Authorize(Roles = Role.ADMIN_CONTRIBUTOR)]
        public ActionResult Edit(int id)
        {
            CategoryResponse response = _categoryService.GetCategory(id);
            if (response != null)
            {
                var category = _mapper.Map<EditCategoryViewModel>(response);
                return View(category);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = Role.ADMIN_CONTRIBUTOR)]
        public ActionResult Edit(EditCategoryViewModel category)
        {
            if (!ModelState.IsValid) return View(category);
            try
            {
                var categoryRequest = _mapper.Map<CategoryRequest>(category);
                _categoryService.UpdateCategory(categoryRequest);
                SetAlertInTempData("Edit category", true);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                SetAlertInTempData("Edit category", false);
                return View(category);
            }
        }

        [Authorize(Roles = Role.ADMIN)]
        public ActionResult Delete(int id)
        {
            try
            {
                _categoryService.DeleteCategory(id);
                SetAlertInTempData("Delete category", true);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                SetAlertInTempData("Delete category", false);
                return RedirectToAction("Index");
            }
        }

        public ActionResult ListPost(int categoryId, string keyword = "", int pageSize = 3, int pageIndex = 1, PostSearchBy searchBy = PostSearchBy.Title, PostOrderBy orderBy = PostOrderBy.ID, bool isAsc = true)
        {
            try
            {
                ViewData["filter"] = keyword;
                ViewData["searchBy"] = searchBy;
                ViewData["orderBy"] = orderBy;
                ViewData["isAsc"] = isAsc;
                var categoryRes = _categoryService.GetCategory(categoryId);
                if (categoryRes == null) return NotFound();
                var filterQuery = FilterHelper.GetFilterBySearchConstant(searchBy, keyword);
                var orderByQuery = OrderByHelper.GetOrderByByConstant(orderBy);
                var posts = _postService.GetPostByCategory(categoryId, filterQuery, orderByQuery, isAsc, pageIndex - 1, pageSize);
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