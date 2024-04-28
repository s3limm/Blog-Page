using Blog_Page.Domain.Entities;
using System;
namespace Blog_Page.Model.User.Request
{
	public class CheckUserRequest
	{
        public string userName { get; set; }
        public string passWord { get; set; }
    }
}

