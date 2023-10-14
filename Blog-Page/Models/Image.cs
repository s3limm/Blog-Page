using System.ComponentModel.DataAnnotations;

namespace Blog_Page.Models
{
    public class Image : BaseEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Lütfen bir resim giriniz.")]
        public string ImageFileName { get; set; }
    }
}
