namespace Blog_Page.Models
{
    public class Writer : BaseEntity
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        //Relational Property 

        public virtual List<Blog> Blog { get; set; }
        public virtual List<Category> Category { get; set; }
    }
}
