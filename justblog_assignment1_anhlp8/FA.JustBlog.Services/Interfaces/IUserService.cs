using FA.JustBlog.Core.Enums;
using FA.JustBlog.Core.Paging;
using FA.JustBlog.Services.Models.Request;
using FA.JustBlog.Services.Models.Response;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Interfaces
{
    public interface IUserService
    {
        Task<PagingResult<UserResponse>> GetUsers(int pageIndex = 1, int pageSize = 3);

        List<IdentityRole> GetRoles();

        Task<IdentityResult> Edit(EditUserRequest request);

        Task<IdentityResult> Create(CreateUserRequest request);

        Task<IdentityResult> ResetPassword(IdentityUser user, string password);

        Task<IdentityResult> DeleteUser(string userId);

        Task<UserResponse> GetUserDetail(string userId);

        Task<UserResponse> GetUserDetail(ClaimsPrincipal user);

        Task<PagingResult<UserResponse>> GetUsers(int pageOffset = 0, int pageSize = 5, string keyword = "", UserSearchBy searchBy = UserSearchBy.UserName, UserOrderBy orderBy = UserOrderBy.UserName, bool isAsc = true, string roleName = "");
    }
}