using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dangerouswildcats.Models
{
    public class QualidadeArApi
    {
        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        [Required(ErrorMessage = "Por favor introduza a cidade")]
        [JsonProperty("city_name")]
        public string CityName { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("state_code")]
        public string StateCode { get; set; }
    }

    public class Datum
    {
        [JsonProperty("mold_level")]
        public int MoldLevel { get; set; }

        [JsonProperty("aqi")]
        public int Aqi { get; set; }

        [JsonProperty("pm10")]
        public double Pm10 { get; set; }

        [JsonProperty("co")]
        public double Co { get; set; }

        [JsonProperty("o3")]
        public double O3 { get; set; }

        [JsonProperty("predominant_pollen_type")]
        public string PredominantPollenType { get; set; }

        [JsonProperty("so2")]
        public double So2 { get; set; }

        [JsonProperty("pollen_level_tree")]
        public int PollenLevelTree { get; set; }

        [JsonProperty("pollen_level_weed")]
        public int PollenLevelWeed { get; set; }

        [JsonProperty("no2")]
        public double No2 { get; set; }

        [JsonProperty("pm25")]
        public double Pm25 { get; set; }

        [JsonProperty("pollen_level_grass")]
        public int PollenLevelGrass { get; set; }
    }

   

}
