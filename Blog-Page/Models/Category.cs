namespace Blog_Page.Models
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }

        //Relational Property 
        public virtual List<Blog> Blog { get; set; } 
    }
}
