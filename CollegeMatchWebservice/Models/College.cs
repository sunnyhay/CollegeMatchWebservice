using Newtonsoft.Json;

namespace CollegeMatchWebservice.Models
{
    public class College
    {
        [JsonProperty(PropertyName = "UNITID")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "INSTNM")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "CITY")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "STABBR")]
        public string StateBrief { get; set; }

        [JsonProperty(PropertyName = "INSTURL")]
        public string Url { get; set; }
    }
}
