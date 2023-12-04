namespace Blog_Page.API.Core.Domain
{
    public class AppRole:BaseEntity
    {
        public int Id { get; set; }
        public string? Definition { get; set; }

        //Relational Properties
        public List<AppUser>? AppUser{ get; set; }
    }
}
