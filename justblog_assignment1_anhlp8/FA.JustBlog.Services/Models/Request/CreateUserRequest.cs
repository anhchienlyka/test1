using System.Collections.Generic;

namespace FA.JustBlog.Services.Models.Request
{
    public class CreateUserRequest
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<string> UserRoleNames { get; set; }
    }
}