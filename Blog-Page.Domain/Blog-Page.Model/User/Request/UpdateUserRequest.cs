using System;
using Blog_Page.Domain.Enums;

namespace Blog_Page.Model.User.Request
{
	public class UpdateUserRequest
	{
        public int Id { get; set; }
        public string userName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}

