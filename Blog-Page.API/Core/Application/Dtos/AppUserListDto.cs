using Blog_Page.API.Core.Application.Enums;
using System.ComponentModel.DataAnnotations;

namespace Blog_Page.API.Core.Application.Dtos
{
    public class AppUserListDto
    {
        public int ID { get; set; }
        public string userName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
