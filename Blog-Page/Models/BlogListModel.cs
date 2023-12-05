using Blog_Page.API.Core.Domain;

namespace Blog_Page.Models
{
    public class BlogListModel : BaseModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

        //Relational Properties
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
