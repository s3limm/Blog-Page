using System.ComponentModel.DataAnnotations;

namespace Blog_Page.Models
{
    public class UserLoginModel : BaseModel
    {
        [Required(ErrorMessage = "Username gereklidir")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Password gereklidir")]
        public string Password { get; set; } = null!;
    }
}

