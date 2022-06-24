using AutoMapper;
using FA.JustBlog.Core.Base.Enums;
using FA.JustBlog.Models;
using FA.JustBlog.Services.Interfaces;
using FA.JustBlog.Services.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    public class CommentController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CommentController> _logger;
        private readonly ICommentService _commentService;
        private readonly IPostService _postService;

        public CommentController(
            IMapper mapper,
            ILogger<CommentController> logger,
            ICommentService commentService,
            IPostService postService)
        {
            _mapper = mapper;
            _logger = logger;
            _commentService = commentService;
            _postService = postService;
        }

        public ActionResult Index(int pageSize = 3, int pageIndex = 1)
        {
            try
            {
                var comments = _commentService.GetAllComments(pageSize, pageIndex - 1);
                return View(comments);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }

        [Authorize(Roles = Role.ADMIN)]
        public ActionResult Edit(int id)
        {
            try
            {
                var comment = _commentService.GetCommentById(id);
                if (comment == null)
                    return NotFound();
                var commentVM = _mapper.Map<EditCommentViewModel>(comment);
                return View(commentVM);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize(Roles = Role.ADMIN)]
        public ActionResult Edit(EditCommentViewModel comment)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(comment);

                var request = _mapper.Map<CommentRequest>(comment);
                _commentService.UpdateComment(request);
                SetAlertInTempData("Update comment", true);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                SetAlertInTempData("Update comment", false);
                return NotFound();
            }
        }

        [Authorize(Roles = Role.ADMIN)]
        public ActionResult Delete(int id)
        {
            try
            {
                _commentService.DeleteComment(id);
                SetAlertInTempData("Delete comment", true);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                SetAlertInTempData("Delete comment", false);
                return NotFound();
            }
        }

        [Authorize(Roles = Role.ADMIN_CONTRIBUTOR)]
        public ActionResult Create(int postId)
        {
            var post = _postService.GetPostById(postId);
            if (post == null)
                return NotFound();
            var comment = new CreateCommentViewModel()
            {
                PostTitle = post.Title,
                PostId = postId
            };
            return View(comment);
        }

        [HttpPost]
        [Authorize(Roles = Role.ADMIN_CONTRIBUTOR)]
        public ActionResult Create(CreateCommentViewModel comment)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(comment);

                var request = _mapper.Map<CommentRequest>(comment);
                _commentService.CreateComment(request);
                SetAlertInTempData("Update comment", true);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                SetAlertInTempData("Update comment", false);
                return NotFound();
            }
        }
    }
}