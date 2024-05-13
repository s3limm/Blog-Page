using Blog_Page.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Blog_Page.Models
{
    public class BlogListModel : BaseModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Lütfen bir başlık giriniz.")]
        [MaxLength(100, ErrorMessage = "En fazla 100 karakter kullanabilirsiniz.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Lütfen bir açıklama giriniz.")]
        [MaxLength(200, ErrorMessage = "En fazla 200 karakter kullanabilirsiniz.")]
        public string Description { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Lütfen bir içerik giriniz.")]
        [MaxLength(10000, ErrorMessage = "En fazla 10000 karakter kullanabilirsiniz.")]
        public string Content { get; set; }
        public int WriterID { get; set; }
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "6 tane görssel girilmelidir.")]
        public string FileNames { get; set; }

        //Relational Property
        public virtual Category? Category { get; set; }
    }
}
