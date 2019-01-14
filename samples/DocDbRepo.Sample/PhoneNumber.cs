﻿using Newtonsoft.Json;

namespace DocDbRepo.Sample
{
    public class PhoneNumber
    {
        [JsonProperty(PropertyName = "Number")]
        public string Number { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        public override string ToString() => $"{Type}: {Number}";
    }
}