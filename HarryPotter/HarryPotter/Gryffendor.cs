using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace HarryPotter
{
    public class Gryffendor
    {

        [JsonProperty("name")]
        [DefaultValue("")]
        public string Name { get; set; }

        [JsonProperty("species")]
        [DefaultValue("")]
        public string Species { get; set; }

        [JsonProperty("gender")]
        [DefaultValue("")]
        public string Gender { get; set; }

        [JsonProperty("house")]
        [DefaultValue("")]
        public string House { get; set; }

        [JsonProperty("dateOfBirth")]
        [DefaultValue("")]
        public string DateOfBirth { get; set; }

        [JsonProperty("yearOfBirth")]
        public int YearOfBirth { get; set; }

        [JsonProperty("ancestry")]
        [DefaultValue("")]
        public string Ancestry { get; set; }

        [JsonProperty("eyeColour")]
        [DefaultValue("")]
        public string EyeColour { get; set; }

        [JsonProperty("hairColour")]
        [DefaultValue("")]
        public string HairColour { get; set; }

        [JsonProperty("wand")]
        public Wand Wand { get; set; }

        [JsonProperty("patronus")]
        [DefaultValue("")]
        public string Patronus { get; set; }

        [JsonProperty("hogwartsStudent")]
        public bool HogwartsStudent { get; set; }

        [JsonProperty("hogwartsStaff")]
        public bool HogwartsStaff { get; set; }

        [JsonProperty("actor")]
        [DefaultValue("")]
        public string Actor { get; set; }

        [JsonProperty("alive")]
        public bool Alive { get; set; }

        [JsonProperty("image")]
        [DefaultValue("")]
        public string Image { get; set; }
    }

}
