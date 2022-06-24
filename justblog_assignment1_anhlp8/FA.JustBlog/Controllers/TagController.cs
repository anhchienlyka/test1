using AutoMapper;
using FA.JustBlog.Core.Enums;
using FA.JustBlog.Core.Helpers;
using FA.JustBlog.Models;
using FA.JustBlog.Services.Interfaces;
using FA.JustBlog.Services.Models.Request;
using FA.JustBlog.Services.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace FA.JustBlog.Controllers
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

        public ActionResult ListPost(int tagId, int pageSize = 3, int pageIndex = 1)
        {
            try
            {
                var tagResponse = _tagService.ViewTagById(tagId);
                if (tagResponse == null) return NotFound();
                var orderByQuery = OrderByHelper.GetOrderByByConstant(PostOrderBy.VIEW);
                var posts = _postService.ViewPostsByTag(tagId, null, orderByQuery, false, pageIndex - 1, pageSize, true);
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