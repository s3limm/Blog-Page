using Blog_Page.Dto;
using Blog_Page.Enums;

namespace Blog_Page.Dto
{
    public class BlogDto
    {

        public BlogDto()
        {
            Status = Status.Inserted;
            CreatedDate = DateTime.Now;
        }
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int WriterID { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string image1 { get; set; }
        public string image2 { get; set; }
        public string image3 { get; set; }
        public string image4 { get; set; }
        public string image5 { get; set; }


        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public List<CategoryDto> Categories { get; set; }


    }
}
