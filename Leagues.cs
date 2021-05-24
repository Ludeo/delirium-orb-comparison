namespace Delirium
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Leagues
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("realm")]
        public string Realm { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("startAt")]
        public DateTimeOffset StartAt { get; set; }

        [JsonProperty("endAt")]
        public DateTimeOffset? EndAt { get; set; }
    }

    public partial class Leagues
    {
        public static List<Leagues> FromJson(string json) => JsonConvert.DeserializeObject<List<Leagues>>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<Leagues> self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}