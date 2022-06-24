using AutoMapper;
using FA.JustBlog.Core.Base.Enums;
using FA.JustBlog.Core.Enums;
using FA.JustBlog.Core.Paging;
using FA.JustBlog.Models;
using FA.JustBlog.Services.Interfaces;
using FA.JustBlog.Services.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Authorize(Roles = Role.ADMIN)]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, ILogger<UserController> logger, IMapper mapper)
        {
            _userService = userService;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 3, string keyword = "", UserSearchBy searchBy = UserSearchBy.UserName, UserOrderBy orderBy = UserOrderBy.UserName, bool isAsc = true, string roleName = "")
        {
            ViewData["filter"] = keyword;
            ViewData["searchBy"] = searchBy;
            ViewData["orderBy"] = orderBy;
            ViewData["isAsc"] = isAsc;
            ViewData["roleName"] = roleName;
            var response = await _userService.GetUsers(pageIndex - 1, pageSize, keyword, searchBy, orderBy, isAsc, roleName);
            var model = _mapper.Map<PagingResult<UserViewModel>>(response);
            return View(model);
        }

        [Authorize(Roles = Role.ADMIN)]
        public IActionResult Create()
        {
            var vm = new CreateUserViewModel();
            var roles = _userService.GetRoles();
            vm.SelectRoles = roles.Select(r => new SelectRoleViewModel()
            {
                RoleId = r.Id,
                RoleName = r.Name,
            }).ToList();
            return View(vm);
        }

        [HttpPost]
        [Authorize(Roles = Role.ADMIN)]
        public async Task<IActionResult> Create(CreateUserViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);
            var request = _mapper.Map<CreateUserRequest>(vm);
            var result = await _userService.Create(request);
            if (result.Succeeded)
            {
                SetAlertInTempData("Create user", true);
                return RedirectToAction("Index");
            }
            SetAlertInTempData("Create user", false, string.Join(" ", result.Errors.Select(e => e.Description)));
            return View(vm);
        }

        [Authorize(Roles = Role.ADMIN)]
        public async Task<ActionResult> Edit(string userId)
        {
            var user = await _userService.GetUserDetail(userId);
            if (user == null)
            {
                _logger.LogError("Cannot find user");
                return NotFound();
            }
            var model = _mapper.Map<EditUserViewModel>(user);
            //get roles list and map with selected ones of user
            var roles = _userService.GetRoles();
            model.SelectRoles = roles.Select(r => new SelectRoleViewModel()
            {
                RoleId = r.Id,
                RoleName = r.Name,
                IsSelected = user.Roles.Contains(r.Name)
            }).ToList();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = Role.ADMIN)]
        public async Task<IActionResult> Edit(EditUserViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);
            var request = _mapper.Map<EditUserRequest>(vm);
            var result = await _userService.Edit(request);
            if (result.Succeeded)
            {
                SetAlertInTempData("Edit user", true);
                return RedirectToAction("Index");
            }
            SetAlertInTempData("Edit user", false, string.Join(" ", result.Errors.Select(e => e.Description)));
            return View(vm);
        }

        [Authorize(Roles = Role.ADMIN)]
        public async Task<ActionResult> Delete(string userId)
        {
            var result = await _userService.DeleteUser(userId);
            if (result.Succeeded)
            {
                SetAlertInTempData("Delete user", true);
            }
            else
            {
                var err = string.Join(" ", result.Errors.Select(e => e.Description));
                _logger.LogError(err);
                SetAlertInTempData("Delete user", false, err);
            }
            return RedirectToAction("Index");
        }
    }
}