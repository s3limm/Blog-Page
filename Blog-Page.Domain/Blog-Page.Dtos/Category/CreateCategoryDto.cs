using System;
using Blog_Page.Domain.BlogPage.Dtos.Base;

namespace Blog_Page.Domain.BlogPage.Dtos.Category
{
	public class CreateCategoryDto:BaseDto
	{
        public string CategoryName { get; set; }
    }
}

