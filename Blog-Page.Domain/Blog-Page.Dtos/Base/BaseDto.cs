using System;
using Blog_Page.Domain.Enums;

namespace Blog_Page.Domain.BlogPage.Dtos.Base
{
	public class BaseDto
	{
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public BaseDto()
        {
            Status = Status.Inserted;
            CreatedDate = DateTime.Now;
        }
    }
}

