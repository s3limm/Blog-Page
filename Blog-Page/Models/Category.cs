namespace Blog_Page.Models
{
    public class Category : BaseEntity
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }

        //Relational Property 
        public virtual List<Blog> Blog { get; set; } 
    }
}
