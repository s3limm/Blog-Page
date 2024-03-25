using System;
namespace Blog_Page.Model.Blog.Request
{
    public class BlogListRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int CategoryID { get; set; }
    }
}

