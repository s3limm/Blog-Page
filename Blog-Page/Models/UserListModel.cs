using Blog_Page.Domain.Entities;

namespace Blog_Page.Models
{
    public class UserListModel : BaseModel
    {
        public int ID { get; set; }
        public string userName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //Relational Properties 
        public int AppRoleId { get; set; }
        public AppRole AppRole { get; set; }

    }
}
