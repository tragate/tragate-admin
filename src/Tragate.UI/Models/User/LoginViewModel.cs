using Newtonsoft.Json;

namespace Tragate.UI.Models.User {
    public class LoginViewModel {
        [JsonProperty ("email")]
        public string Email { get; set; }

        [JsonProperty ("password")]
        public string Password { get; set; }

        [JsonProperty ("platformId")]
        public int PlatformId { get; set; }
    }
}