using System;
namespace Blog_Page.Model.User.Request
{
    public class CreateUserRequest
    {
        public string userName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

