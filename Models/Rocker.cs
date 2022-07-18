using Newtonsoft.Json;

namespace RockersAPI.Models
{
    [Serializable]
    [JsonObject]
    public class Rocker
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Band { get; set; }
    }
}
