using Newtonsoft.Json;

namespace ApiLibrary.RequestDTO
{
    public class NewUserCreationPayLoad
    {
        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }
    }
}
