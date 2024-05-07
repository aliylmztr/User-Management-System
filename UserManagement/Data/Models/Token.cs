using Newtonsoft.Json;

namespace UserManagement.Data.Models
{
    public class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken;

        [JsonProperty("token_type")]
        public string TokenType;

        [JsonProperty("expires_in")]
        public int ExpiresIn;
    }
}
