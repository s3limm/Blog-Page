using System;
namespace Blog_Page.Model.User.Request
{
	public class CheckUserRequest
	{
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsExist { get; set; }
        public string Role { get; set; }
    }
}

