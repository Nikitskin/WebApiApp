
namespace WebAPITestApp.Models
{
    public class TokenResponse
    {
        // TODO You don't need these private fields, because property already incapsulates it.

        private int statusCode;
        private string accessToken;

        public int StatusCode { get => statusCode; set => statusCode = value; }
        public string AccessToken { get => accessToken; set => accessToken = value; }
    }
}
