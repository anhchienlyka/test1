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
    public class TagController : BaseController
    {
        private readonly ILogger<TagController> _logger;
        private readonly ITagService _tagService;
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public TagController(
            ILogger<TagController> logger,
            ITagService tagService,
            IPostService postService,
            IMapper mapper)
        {
            _logger = logger;
            _tagService = tagService;
            _postService = postService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            try
            {
                var tags = _tagService.GetAll();
                return View(tags);
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
            var tag = new CreateTagViewModel();
            return View(tag);
        }

        [HttpPost]
        [Authorize(Roles = Role.ADMIN_CONTRIBUTOR)]
        public ActionResult Create(CreateTagViewModel tag)
        {
            if (!ModelState.IsValid) return View(tag);
            try
            {
                var tagRequest = _mapper.Map<TagRequest>(tag);
                _tagService.CreateTag(tagRequest);
                SetAlertInTempData("Create tag", true);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                SetAlertInTempData("Create tag", false);
                return View(tag);
            }
        }

        [HttpGet]
        [Authorize(Roles = Role.ADMIN_CONTRIBUTOR)]
        public ActionResult Edit(int id)
        {
            TagResponse response = _tagService.GetTagById(id);
            if (response != null)
            {
                var tag = _mapper.Map<EditTagViewModel>(response);
                return View(tag);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = Role.ADMIN_CONTRIBUTOR)]
        public ActionResult Edit(EditTagViewModel tag)
        {
            if (!ModelState.IsValid) return View(tag);
            try
            {
                var tagRequest = _mapper.Map<TagRequest>(tag);
                _tagService.UpdateTag(tagRequest);
                SetAlertInTempData("Edit tag", true);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                SetAlertInTempData("Edit tag", false);
                return View(tag);
            }
        }

        [Authorize(Roles = Role.ADMIN)]
        public ActionResult Delete(int id)
        {
            try
            {
                _tagService.DeleteTag(id);
                SetAlertInTempData("Delete tag", true);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                SetAlertInTempData("Delete tag", false);
                return RedirectToAction("Index");
            }
        }

        public ActionResult ListPost(int tagId, string keyword = "", int pageSize = 3, int pageIndex = 1, PostSearchBy searchBy = PostSearchBy.Title, PostOrderBy orderBy = PostOrderBy.ID, bool isAsc = true)
        {
            try
            {
                ViewData["filter"] = keyword;
                ViewData["searchBy"] = searchBy;
                ViewData["orderBy"] = orderBy;
                ViewData["isAsc"] = isAsc;
                var tagResponse = _tagService.GetTagById(tagId);
                if (tagResponse == null) return NotFound();
                var filterQuery = FilterHelper.GetFilterBySearchConstant(searchBy, keyword);
                var orderByQuery = OrderByHelper.GetOrderByByConstant(orderBy);
                var posts = _postService.GetPostsByTag(tagId, filterQuery, orderByQuery, isAsc, pageIndex - 1, pageSize);
                var vm = new TagListPostViewModel()
                {
                    Tag = tagResponse,
                    PostsOfTag = posts
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