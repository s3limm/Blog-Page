namespace Blog_Page.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
                CreatedDate = DateTime.Now;
        }

        public DateTime CreatedDate { get; set; }
    }
}
