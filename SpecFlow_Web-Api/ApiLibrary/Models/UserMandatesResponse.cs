using Newtonsoft.Json;

namespace ApiLibrary.Models
{
    public class UserMandatesResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}