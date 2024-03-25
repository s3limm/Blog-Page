using System;
namespace Blog_Page.Model.User.Request
{
	public class ListUserRequest
	{
        public int ID { get; set; }
        public string userName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int AppRoleId { get; set; }
    }
}

