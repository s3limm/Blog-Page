using System;
using Blog_Page.Domain.BlogPage.Dtos.Base;

namespace Blog_Page.Domain.BlogPage.Dtos.Category
{
	public class CategoryListDto:BaseDto
	{
        public int ID { get; set; }
        public string CategoryName { get; set; }
    }
}

