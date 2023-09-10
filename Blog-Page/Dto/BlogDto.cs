using Blog_Page.Dto;
using Blog_Page.Enums;

namespace Blog_Page.Dto
{
    public class BlogDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int WriterID { get; set; }
        public int CategoryID { get; set; }

         
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public List<CategoryDto> Categories { get; set; }


    }
}
