using FA.JustBlog.Core.Enums;
using FA.JustBlog.Core.Paging;
using FA.JustBlog.Data.Contexts;
using FA.JustBlog.Services.Interfaces;
using FA.JustBlog.Services.Models.Request;
using FA.JustBlog.Services.Models.Response;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IPasswordHasher<IdentityUser> _passwordHasher;
        private readonly JustBlogIdentityDbContext _identityContext;

        public UserService(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IPasswordHasher<IdentityUser> passwordHasher,
            JustBlogIdentityDbContext identityContext
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
            _identityContext = identityContext;
        }

        public async Task<PagingResult<UserResponse>> GetUsers(int pageIndex = 1, int pageSize = 3)
        {
            var users = _userManager.Users;
            var vmList = new List<UserResponse>();
            foreach (var user in users)
            {
                var vm = await GetUserDetail(user.Id);
                vmList.Add(vm);
            }
            var model = new PagingList<UserResponse>().GetPage(pageSize, pageIndex - 1, vmList.AsQueryable(), null, u => u.UserName);
            return model;
        }

        public List<IdentityRole> GetRoles()
        {
            return _roleManager.Roles.ToList();
        }

        public async Task<IdentityResult> Create(CreateUserRequest request)
        {
            var user = new IdentityUser()
            {
                UserName = request.Username,
                Email = request.Email,
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return await _userManager.AddToRolesAsync(user, request.UserRoleNames);
            }
            return result;
        }

        public async Task<IdentityResult> Edit(EditUserRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user != null)
            {
                if (user.UserName != request.Username)
                    user.UserName = request.Username;
                if (user.Email != request.Email)
                    user.Email = request.Email;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    result = await ResetPassword(user, request.Password);
                if (result.Succeeded)
                    result = await UpdateRoleForUser(user, request.UserRoleNames);

                return result;
            }
            return IdentityResult.Failed(new IdentityError() { Description = "Cannot find user with this id" });
        }

        public async Task<IdentityResult> UpdateRoleForUser(IdentityUser user, List<string> userRoleNames)
        {
            var oldRoles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, oldRoles);
            if (result.Succeeded)
                result = await _userManager.AddToRolesAsync(user, userRoleNames);
            return result;
        }

        public async Task<IdentityResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                return await _userManager.DeleteAsync(user);
            }
            return IdentityResult.Failed(new IdentityError() { Description = "Cannot find user with this id" });
        }

        public async Task<IdentityResult> ResetPassword(IdentityUser user, string password)
        {
            if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) != PasswordVerificationResult.Success)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                return await _userManager.ResetPasswordAsync(user, token, password);
            }
            return IdentityResult.Success;
        }

        public async Task<UserResponse> GetUserDetail(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var response = new UserResponse()
                {
                    UserId = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    Roles = roles
                };

                return response;
            }
            return null;
        }

        public async Task<UserResponse> GetUserDetail(ClaimsPrincipal user)
        {
            var userIdentity = await _userManager.GetUserAsync(user);
            if (userIdentity != null)
            {
                var response = new UserResponse()
                {
                    Email = userIdentity.Email,
                    UserName = userIdentity.UserName,
                    UserId = userIdentity.Id
                };
                response.Roles = await _userManager.GetRolesAsync(userIdentity);
                return response;
            }
            return null;
        }

        public async Task<PagingResult<UserResponse>> GetUsers(int pageOffset = 0, int pageSize = 5, string keyword = "", UserSearchBy searchBy = UserSearchBy.UserName, UserOrderBy orderBy = UserOrderBy.UserName, bool isAsc = true, string roleName = "")
        {
            IList<IdentityUser> roleUsers = new List<IdentityUser>();

            var filterExp = GetUserSearchByFunc(keyword, searchBy);
            var orderByExp = GetUserOrderByFunc(orderBy);

            if (!string.IsNullOrWhiteSpace(roleName))
                roleUsers = await _userManager.GetUsersInRoleAsync(roleName);
            else
                roleUsers = _userManager.Users.ToList();

            var pagedUsers = new PagingList<IdentityUser>().GetPage(pageSize, pageOffset, roleUsers, filterExp, orderByExp);
            return new PagingResult<UserResponse>()
            {
                ItemCount = pagedUsers.ItemCount,
                Items = pagedUsers.Items
                    .Select(u => new UserResponse()
                    {
                        Email = u.Email,
                        Roles = _userManager.GetRolesAsync(u).Result,
                        UserId = u.Id,
                        UserName = u.UserName
                    }),
                PageOffset = pagedUsers.PageOffset,
                PageSize = pagedUsers.PageSize,
                TotalPage = pagedUsers.TotalPage
            };
        }

        private Func<IdentityUser, object> GetUserOrderByFunc(UserOrderBy orderBy)
        {
            switch (orderBy)
            {
                case UserOrderBy.Id:
                    return u => u.Id;

                case UserOrderBy.UserName:
                    return u => u.UserName;

                case UserOrderBy.Email:
                    return u => u.Email;
            }
            return null;
        }

        private Func<IdentityUser, bool> GetUserSearchByFunc(string keyword, UserSearchBy searchBy)
        {
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim().ToLower();
                switch (searchBy)
                {
                    case UserSearchBy.Id:
                        return u => u.Id.ToLower().Contains(keyword);

                    case UserSearchBy.Email:
                        return u => u.Email.ToLower().Contains(keyword);

                    case UserSearchBy.UserName:
                        return u => u.UserName.ToLower().Contains(keyword);
                }
            }
            return null;
        }
    }
}