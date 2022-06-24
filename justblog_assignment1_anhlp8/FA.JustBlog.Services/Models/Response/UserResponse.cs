using System.Collections.Generic;

namespace FA.JustBlog.Services.Models.Response
{
    public class UserResponse
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IList<string> Roles { get; set; }
    }
}