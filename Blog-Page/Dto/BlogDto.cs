using Blog_Page.Dto;
using Blog_Page.Enums;
using Blog_Page.Models;
using System.Web.Mvc;

namespace Blog_Page.Dto
{
    public class BlogDto : IDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [AllowHtml]
        public string Content { get; set; }
        public int WriterID { get; set; }
        public int CategoryID { get; set; }

        //Relational Property

        public List<Image> Images { get; set; }
        public CategoryDto Category { get; set; }
        public List<CategoryDto> Categories { get; set; }
    }
}
