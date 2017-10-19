
namespace WebAPITestApp.Models
{
    public class TokenResponse
    {
        private int statusCode;
        private string accessToken;

        public int StatusCode { get => statusCode; set => statusCode = value; }
        public string AccessToken { get => accessToken; set => accessToken = value; }
    }
}
