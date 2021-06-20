using Newtonsoft.Json;

namespace ApiLibrary.Models
{
    public class UsersResponse
    {
        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }
    }
}