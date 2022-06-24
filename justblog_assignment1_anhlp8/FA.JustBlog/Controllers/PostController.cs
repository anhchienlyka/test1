using AutoMapper;
using FA.JustBlog.Core.Base.Enums;
using FA.JustBlog.Models;
using FA.JustBlog.Services.Interfaces;
using FA.JustBlog.Services.Models.Request;
using FA.JustBlog.Services.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace FA.JustBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public PostController(ILogger<PostController> logger,
            IPostService postService,
            ICommentService commentService,
            IUserService userService,
            IMapper mapper)
        {
            _logger = logger;
            _postService = postService;
            _commentService = commentService;
            _mapper = mapper;
            _userService = userService;
        }

        public ActionResult Index()
        {
            var posts = _postService.GetAllPublishedPosts();
            if (posts != null)
            {
                return View(posts);
            }
            return NotFound();
        }

        [HttpGet("post/{slug}")]
        public ActionResult Detail(string slug)
        {
            var post = _postService.ViewPost(slug);
            if (post != null)
            {
                return View(post);
            }
            return NotFound();
        }

        public ActionResult Detail(int id)
        {
            var post = _postService.ViewPost(id);

            if (post != null)
            {
                return View(post);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] CreateCommentViewModel comment)
        {
            try
            {
                if (!ModelState.IsValid) return null;
                var user = await _userService.GetUserDetail(User);
                var request = new CommentRequest()
                {
                    PostId = comment.PostId,
                    CommandTime = DateTime.UtcNow,
                    CommentText = comment.CommentText,
                    CommentHeader = comment.CommentHeader,
                    Email = user?.Email ?? string.Empty,
                    Name = user?.UserName ?? "Anonymous"
                };
                _commentService.CreateComment(request);
                return Ok(new CommentResponse()
                {
                    CommandTime = request.CommandTime,
                    CommentHeader = request.CommentHeader,
                    CommentText = request.CommentText,
                    Name = request.Name,
                    Email = request.Email,
                    PostId = request.PostId
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}