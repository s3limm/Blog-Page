using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Blog_Page.Models
{
    public class Blog : BaseEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [AllowHtml]
        public string Content { get; set; }
        public string image1 { get; set; }
        public string image2 { get; set; }
        public string image3 { get; set; }
        public string image4 { get; set; }
        public string image5 { get; set; }
        public int WriterID { get; set; }
        public int CategoryID { get; set; }


        //Relational Property

        public virtual Category Category { get; set; }
    }
}
