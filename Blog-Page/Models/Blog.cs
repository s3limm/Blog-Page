namespace Blog_Page.Models
{
    public class Blog : BaseEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int WriterID { get; set; }
        public int CategoryID { get; set; }


        //Relational Property

        public virtual Writer Writer { get; set; }
        public virtual Category Category { get; set; }  
    }
}
