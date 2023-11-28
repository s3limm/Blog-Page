using Blog_Page.API.Core.Application.Enums;
using System.ComponentModel.DataAnnotations;

namespace Blog_Page.API.Core.Domain
{
    public class AppUser:BaseEntity
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Lütfen bir kullanıcı adı giriniz.")]
        [MaxLength(100, ErrorMessage = "En fazla 100 karakter kullanabilirsiniz.")]
        public string userName { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Lütfen bir şifre giriniz.")]
        [MaxLength(100, ErrorMessage = "En fazla 100 karakter kullanabilirsiniz.")]
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
