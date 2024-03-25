using System;
using Blog_Page.Domain.BlogPage.Dtos.Base;

namespace Blog_Page.Domain.BlogPage.Dtos.User
{
	public class UpdateUserDto:BaseDto
	{
        public int ID { get; set; }
        public string userName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int AppRoleId { get; set; }
    }
}

