using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Page.Domain.Entities
{
    public class AppRole:BaseEntity
    {
        public int Id { get; set; }
        public string? Definition { get; set; }

        //Relational Properties
        public List<AppUser>? AppUser { get; set; }
    }
}
