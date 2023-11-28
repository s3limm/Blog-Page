namespace Blog_Page.API.Core.Application.Dtos
{
    public class BlogListDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int CategoryID { get; set; }
    }
}
