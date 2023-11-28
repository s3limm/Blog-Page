using Blog_Page.API.Core.Application.Enums;

namespace Blog_Page.API.Core.Domain
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Status = Status.Inserted;
            CreatedDate = DateTime.Now;
        }

        //public int ID { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
