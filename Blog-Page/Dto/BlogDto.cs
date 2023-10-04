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

        //public string image1 { get; set; }
        //public string image2 { get; set; }
        //public string image3 { get; set; }
        //public string image4 { get; set; }
        //public string image5 { get; set; }


        //Relational Property

        public CategoryDto Category { get; set; }
        public List<CategoryDto> Categories { get; set; }
    }
}
