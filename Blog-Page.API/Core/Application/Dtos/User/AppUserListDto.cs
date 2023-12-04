using Blog_Page.API.Core.Application.Enums;
using System.ComponentModel.DataAnnotations;

namespace Blog_Page.API.Core.Application.Dtos.User
{
    public class AppUserListDto
    {
        public AppUserListDto()
        {
        }

        public int ID { get; set; }
        public string userName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int AppRoleId { get; set; }
    }
}
