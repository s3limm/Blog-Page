namespace Blog_Page.Models
{
    public class JwtTokenResponseModel : BaseModel
    {
        public string? Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
