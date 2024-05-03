using System;
using Microsoft.AspNetCore.Http;

namespace Blog_Page.Model.Blog.Request
{
    public class CreateBlogRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int CategoryID { get; set; }
        public List<IFormFile>? files { get; set; }


    }
}

