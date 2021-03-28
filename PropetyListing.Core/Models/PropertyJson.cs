using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace PropertyListing.Core.Models
{
    public class PropertyJson
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("physical")]
        public Physical Physical { get; set; }

        [JsonProperty("financial")]
        public Financial Financial { get; set; }

        public float GrossYield { get; set; }

    }


    public class PropertiesJson
    {
        [JsonProperty("properties")] public List<PropertyJson> properties { get; set; }
    }


    public class Address
    {
        [JsonProperty("address1")] public string Address1 { get; set; }

        [JsonProperty("address2")] public string Address2 { get; set; }

        [JsonProperty("city")] public string City { get; set; }

        [JsonProperty("country")] public string Country { get; set; }

        [JsonProperty("county")] public string County { get; set; }

        [JsonProperty("district")] public string District { get; set; }

        [JsonProperty("state")] public string State { get; set; }

        [JsonProperty("Zip")] public string Zip { get; set; }

        [JsonProperty("zipPlus4")] public string ZipPlus4 { get; set; }

    }

    public class Physical
    {
        [JsonProperty("yearBuilt")] public string YearBuilt { get; set; }
    }

    public class Financial
    {
        [JsonProperty("listPrice")] public string ListPrice { get; set; }

        [JsonProperty("monthlyRent")] public string MonthlyRent { get; set; }

    }
}
