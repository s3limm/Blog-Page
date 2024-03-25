using System;
using Blog_Page.Domain.BlogPage.Dtos.Base;

namespace Blog_Page.Domain.BlogPage.Dtos.Blog
{
	public class CreateBlogDto:BaseDto
	{
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int CategoryID { get; set; }
    }
}

