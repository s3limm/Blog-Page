using System.ComponentModel.DataAnnotations;

namespace Blog_Page.Models
{
    public class UpdateCategoryModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Lütfen bir kategori adı giriniz.")]
        [MaxLength(100, ErrorMessage = "En fazla 100 karakter kullanabilirsiniz.")]
        public string CategoryName { get; set; }
    }
}
