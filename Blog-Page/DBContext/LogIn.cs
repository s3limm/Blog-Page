using System.ComponentModel.DataAnnotations;

namespace Blog_Page.DBContext
{
    public class LogIn
    {
        [Key]
        public int ID { get; set; }

        [StringLength(100)]
        public string NameSurname { get; set; }

        [StringLength(100)]
        public string EMail { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        public DateTime AddedDate { get; set; }

        [StringLength(50)]
        public string AddedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(150)]
        public string About{ get; set; } 

        [StringLength(200)]
        public string Image { get; set; }


    }
}
