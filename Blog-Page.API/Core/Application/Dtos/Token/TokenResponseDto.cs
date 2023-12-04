namespace Blog_Page.API.Core.Application.Dtos.Token
{
    public class TokenResponseDto
    {
        public TokenResponseDto(string token, DateTime expireDate)
        {
            ExpireDate = expireDate;
            Token = token;
        }

        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
