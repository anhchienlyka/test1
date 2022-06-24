using AutoMapper;
using FA.JustBlog.Core.Base.Enums;
using FA.JustBlog.Core.Enums;
using FA.JustBlog.Core.Helpers;
using FA.JustBlog.Models;
using FA.JustBlog.Services.Interfaces;
using FA.JustBlog.Services.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    public class DashboardPostController : BaseController
    {
        private readonly ILogger<DashboardPostController> _logger;
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public DashboardPostController(
            ILogger<DashboardPostController> logger,
            IPostService postService,
            IMapper mapper)
        {
            _logger = logger;
            _postService = postService;
            _mapper = mapper;
        }

        public ActionResult Index(string keyword = "", int pageSize = 3, int pageIndex = 1, PostSearchBy searchBy = PostSearchBy.Title, PostOrderBy orderBy = PostOrderBy.ID, bool isAsc = true)
        {
            try
            {
                ViewData["filter"] = keyword;
                ViewData["searchBy"] = searchBy;
                ViewData["orderBy"] = orderBy;
                ViewData["isAsc"] = isAsc;
                var filterQuery = FilterHelper.GetFilterBySearchConstant(searchBy, keyword);
                var orderByQuery = OrderByHelper.GetOrderByByConstant(orderBy);
                var posts = _postService.GetAllPosts(filterQuery, orderByQuery, isAsc, pageIndex - 1, pageSize);
                return View(posts);
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
            try
            {
                var post = InitView(null);
                return View(post);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NoContent();
            }
        }

        [HttpPost]
        [Authorize(Roles = Role.ADMIN_CONTRIBUTOR)]
        public ActionResult Create(CreatePostViewModel post)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    post = InitView(post);
                    return View(post);
                }
                var postRequest = _mapper.Map<PostRequest>(post);
                _postService.CreatePost(postRequest);
                SetAlertInTempData("Create", true);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                SetAlertInTempData("Create", false);

                return View(post);
            }
        }

        [HttpGet]
        [Authorize(Roles = Role.ADMIN_CONTRIBUTOR)]
        public ActionResult Edit(int id)
        {
            var post = InitView(new CreatePostViewModel() { Id = id });
            if (post != null)
            {
                return View(post);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = Role.ADMIN_CONTRIBUTOR)]
        public ActionResult Edit(CreatePostViewModel post)
        {
            if (!ModelState.IsValid)
            {
                post = InitView(post);
                return View(post);
            }

            try
            {
                var request = _mapper.Map<PostRequest>(post);
                _postService.UpdatePost(request);
                SetAlertInTempData("Edit post", true);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                SetAlertInTempData("Edit post", false);
                return View(post);
            }
        }

        [Authorize(Roles = Role.ADMIN)]
        public ActionResult Delete(int id)
        {
            try
            {
                _postService.DeletePost(id);
                SetAlertInTempData("Delete post", true);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                SetAlertInTempData("Delete post", false);
                return RedirectToAction("Index");
            }
        }

        [Authorize(Roles = Role.ADMIN)]
        public ActionResult Publish(int postId)
        {
            try
            {
                _postService.Publish(postId);
                SetAlertInTempData("Publish post", true);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                SetAlertInTempData("Publish post", false);
                return RedirectToAction("Index");
            }
        }

        [Authorize(Roles = Role.ADMIN)]
        public ActionResult UnPublish(int postId)
        {
            try
            {
                _postService.UnPublish(postId);
                SetAlertInTempData("UnPublish post", true);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                SetAlertInTempData("UnPublish post", false);
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// Init view model for view
        /// </summary>
        /// <param name="postVM">pass null to init create new post, pass model with id to init edit post</param>
        /// <returns>model for view using</returns>
        private CreatePostViewModel InitView(CreatePostViewModel postVM)
        {
            if (postVM != null)
            {
                var existPost = _postService.GetPostById(postVM.Id);
                if (existPost != null)
                {
                    postVM = _mapper.Map<CreatePostViewModel>(existPost);
                    postVM.TagNames = string.Join(";", existPost.Tags.Select(t => t.Name));
                }
            }
            else
            {
                postVM = new CreatePostViewModel();
            }
            return postVM;
        }
    }
}