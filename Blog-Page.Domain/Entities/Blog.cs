using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Blog_Page.Domain.Entities
{
    public class Blog : BaseEntity
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
        public string FileNames { get; set; }

        //Relational Property
        public virtual Category? Category { get; set; }
    }
}
