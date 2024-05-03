using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Page.Domain.Entities
{
    public class Category:BaseEntity
    {
        
        public int ID { get; set; }

        [Required(ErrorMessage = "Lütfen bir kategori adı giriniz.")]
        [MaxLength(100, ErrorMessage = "En fazla 100 karakter kullanabilirsiniz.")]
        public string? CategoryName { get; set; }

        //Relational Property 
        public virtual List<Blog> Blog { get; set; }
    }
}
