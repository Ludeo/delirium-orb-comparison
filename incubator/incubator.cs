using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Delirium.incubator
{
    public enum ItemType
    {
        Unknown,
    }

    public partial class Incubator
    {
        [JsonProperty("lines")]
        public List<Line> Lines { get; set; }

        [JsonProperty("language")]
        public Language Language { get; set; }
    }

    public class Language
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("translations")]
        public Translations Translations { get; set; }
    }

    public class Translations
    {
    }

    public class Line
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public Uri Icon { get; set; }

        [JsonProperty("mapTier")]
        public long MapTier { get; set; }

        [JsonProperty("levelRequired")]
        public long LevelRequired { get; set; }

        [JsonProperty("baseType")]
        public object BaseType { get; set; }

        [JsonProperty("stackSize")]
        public long StackSize { get; set; }

        [JsonProperty("variant")]
        public object Variant { get; set; }

        [JsonProperty("prophecyText")]
        public object ProphecyText { get; set; }

        [JsonProperty("artFilename")]
        public object ArtFilename { get; set; }

        [JsonProperty("links")]
        public long Links { get; set; }

        [JsonProperty("itemClass")]
        public long ItemClass { get; set; }

        [JsonProperty("sparkline")]
        public Sparkline Sparkline { get; set; }

        [JsonProperty("lowConfidenceSparkline")]
        public LowConfidenceSparkline LowConfidenceSparkline { get; set; }

        [JsonProperty("implicitModifiers")]
        public List<object> ImplicitModifiers { get; set; }

        [JsonProperty("explicitModifiers")]
        public List<ExplicitModifier> ExplicitModifiers { get; set; }

        [JsonProperty("flavourText")]
        public string FlavourText { get; set; }

        [JsonProperty("corrupted")]
        public bool Corrupted { get; set; }

        [JsonProperty("gemLevel")]
        public long GemLevel { get; set; }

        [JsonProperty("gemQuality")]
        public long GemQuality { get; set; }

        [JsonProperty("itemType")]
        public ItemType ItemType { get; set; }

        [JsonProperty("chaosValue")]
        public double ChaosValue { get; set; }

        [JsonProperty("exaltedValue")]
        public double ExaltedValue { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("detailsId")]
        public string DetailsId { get; set; }

        [JsonProperty("tradeInfo")]
        public object TradeInfo { get; set; }

        [JsonProperty("mapRegion")]
        public object MapRegion { get; set; }
    }

    public class ExplicitModifier
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("optional")]
        public bool Optional { get; set; }
    }

    public class LowConfidenceSparkline
    {
        [JsonProperty("data")]
        public List<double?> Data { get; set; }

        [JsonProperty("totalChange")]
        public double TotalChange { get; set; }
    }

    public class Sparkline
    {
        [JsonProperty("data")]
        public List<double?> Data { get; set; }

        [JsonProperty("totalChange")]
        public double TotalChange { get; set; }
    }

    public partial class Incubator
    {
        public static Incubator FromJson(string json) => JsonConvert.DeserializeObject<Incubator>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Incubator self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ItemTypeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal },
            },
        };
    }

    internal class ItemTypeConverter : JsonConverter
    {
        public static readonly ItemTypeConverter Singleton = new ItemTypeConverter();

        public override bool CanConvert(Type t) => t == typeof(ItemType) || t == typeof(ItemType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            string value = serializer.Deserialize<string>(reader);

            if (value == "Unknown")
            {
                return ItemType.Unknown;
            }

            throw new Exception("Cannot unmarshal type ItemType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }

            ItemType value = (ItemType)untypedValue;

            if (value == ItemType.Unknown)
            {
                serializer.Serialize(writer, "Unknown");
                return;
            }

            throw new Exception("Cannot marshal type ItemType");
        }
    }
}
