using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Page.Domain.Entities
{
    public class AppUser:BaseEntity
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Lütfen bir kullanıcı adı giriniz.")]
        [MaxLength(100, ErrorMessage = "En fazla 100 karakter kullanabilirsiniz.")]
        public string userName { get; set; }
        public string? Email { get; set; }
        [Required(ErrorMessage = "Lütfen bir şifre giriniz.")]
        [MaxLength(100, ErrorMessage = "En fazla 100 karakter kullanabilirsiniz.")]
        public string Password { get; set; }
        public int? AppRoleId { get; set; }

        //Relational Properties
        public AppRole? AppRole { get; set; }
    }
}
