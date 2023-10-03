using Blog_Page.Enums;

namespace Blog_Page.Dto
{
    public class IDto
    {
        public IDto()
        {
            Status = Status.Inserted;
            CreatedDate = DateTime.Now;
        }

        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
