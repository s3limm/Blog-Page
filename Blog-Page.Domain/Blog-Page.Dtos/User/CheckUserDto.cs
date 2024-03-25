using System;
namespace Blog_Page.Domain.BlogPage.Dtos.User
{
	public class CheckUserDto
	{
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsExist { get; set; }
        public string Role { get; set; }
    }
}

