namespace Blog_Page.Models
{
    public class AppUser : BaseEntity
    {
        public int ID { get; set; }
        public string userName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
