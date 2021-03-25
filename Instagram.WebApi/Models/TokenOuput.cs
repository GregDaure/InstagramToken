using System;
using Newtonsoft.Json;

namespace Instagram.WebApi.Models
{
    public class TokenOuput
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }
    }

}
