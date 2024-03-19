using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Page.Domain.Entities
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
