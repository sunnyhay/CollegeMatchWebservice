using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeMatchWebservice.Models
{
    public class Input
    {
        [JsonProperty(PropertyName = "gpa")]
        public string Gpa { get; set; }

        [JsonProperty(PropertyName = "satAvg")]
        public string SatAvg { get; set; }

        [JsonProperty(PropertyName = "satRead")]
        public string SatRead { get; set; }

        [JsonProperty(PropertyName = "satMath")]
        public string SatMath { get; set; }

        [JsonProperty(PropertyName = "satWrt")]
        public string SatWrt { get; set; }

        [JsonProperty(PropertyName = "actCum")]
        public string ActCum { get; set; }

        [JsonProperty(PropertyName = "actEng")]
        public string ActEng { get; set; }

        [JsonProperty(PropertyName = "actMath")]
        public string ActMath { get; set; }

        [JsonProperty(PropertyName = "actWrt")]
        public string ActWrt { get; set; }

        [JsonProperty(PropertyName = "rank")]
        public string Rank { get; set; }
    }
}
