using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Delirium.map
{
    public enum ItemType
    {
        Unknown,
    }

    public enum MapRegion
    {
        GlennachCairns,
        HaewarkHamlet,
        LexEjoris,
        LexProxima,
        LiraArthain,
        NewVastir,
        TirnSEnd,
        ValdoSRest,
    }

    // add a new league here
    public enum Variant {
        Atlas,
        Atlas2,
        Atlas234,
        Blight,
        Delirium,
        Delerium,
        Harvest,
        Legion,
        Metamorph,
        Pre20,
        Pre24,
        Synthesis,
        Heist,
        Ritual,
        Ultimatum,
        Expedition,
        Scourge,
    }

    public partial class Map
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
        public string BaseType { get; set; }

        [JsonProperty("stackSize")]
        public long StackSize { get; set; }

        [JsonProperty("variant")]
        public Variant Variant { get; set; }

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
        public Sparkline LowConfidenceSparkline { get; set; }

        [JsonProperty("implicitModifiers")]
        public List<object> ImplicitModifiers { get; set; }

        [JsonProperty("explicitModifiers")]
        public List<object> ExplicitModifiers { get; set; }

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
        public MapRegion? MapRegion { get; set; }
    }

    public class Sparkline
    {
        [JsonProperty("data")]
        public List<double?> Data { get; set; }

        [JsonProperty("totalChange")]
        public double TotalChange { get; set; }
    }

    public partial class Map
    {
        public static Map FromJson(string json) => JsonConvert.DeserializeObject<Map>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Map self) => JsonConvert.SerializeObject(self, Converter.Settings);
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
                MapRegionConverter.Singleton,
                VariantConverter.Singleton,
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

    internal class MapRegionConverter : JsonConverter
    {
        public static readonly MapRegionConverter Singleton = new MapRegionConverter();

        public override bool CanConvert(Type t) => t == typeof(MapRegion) || t == typeof(MapRegion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            string value = serializer.Deserialize<string>(reader);

            return value switch
            {
                "Glennach Cairns" => MapRegion.GlennachCairns,
                "Haewark Hamlet"  => MapRegion.HaewarkHamlet,
                "Lira Arthain"    => MapRegion.LiraArthain,
                "Valdo's Rest"    => MapRegion.ValdoSRest,
                var _             => throw new Exception("Cannot unmarshal type MapRegion"),
            };
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }

            MapRegion value = (MapRegion)untypedValue;

            switch (value)
            {
                case MapRegion.GlennachCairns:
                    serializer.Serialize(writer, "Glennach Cairns");

                    return;
                case MapRegion.HaewarkHamlet:
                    serializer.Serialize(writer, "Haewark Hamlet");

                    return;
                case MapRegion.LiraArthain:
                    serializer.Serialize(writer, "Lira Arthain");

                    return;
                case MapRegion.ValdoSRest:
                    serializer.Serialize(writer, "Valdo's Rest");

                    return;
                default: throw new Exception("Cannot marshal type MapRegion");
            }
        }
    }

    internal class VariantConverter : JsonConverter
    {
        public static readonly VariantConverter Singleton = new VariantConverter();

        public override bool CanConvert(Type t) => t == typeof(Variant) || t == typeof(Variant?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            string value = serializer.Deserialize<string>(reader);

            return value switch
            {
                // add a new league here
                "Atlas"      => Variant.Atlas,
                "Atlas2"     => Variant.Atlas2,
                "Atlas2-3.4" => Variant.Atlas234,
                "Blight"     => Variant.Blight,
                "Delirium"   => Variant.Delirium,
                "Delerium"   => Variant.Delerium,
                "Harvest"    => Variant.Harvest,
                "Legion"     => Variant.Legion,
                "Metamorph"  => Variant.Metamorph,
                "Pre 2.0"    => Variant.Pre20,
                "Pre 2.4"    => Variant.Pre24,
                "Synthesis"  => Variant.Synthesis,
                "Heist"      => Variant.Heist,
                "Ritual"     => Variant.Ritual,
                "Ultimatum"  => Variant.Ultimatum,
                "Expedition" => Variant.Expedition,
                ", Gen-12" => Variant.Scourge,
                var _ => throw new Exception("Cannot unmarshal type Variant"),
            };
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }

            Variant value = (Variant)untypedValue;

            switch (value)
            {
                //add a new league here
                case Variant.Atlas:
                    serializer.Serialize(writer, "Atlas");
                    return;
                case Variant.Atlas2:
                    serializer.Serialize(writer, "Atlas2");
                    return;
                case Variant.Atlas234:
                    serializer.Serialize(writer, "Atlas2-3.4");
                    return;
                case Variant.Blight:
                    serializer.Serialize(writer, "Blight");
                    return;
                case Variant.Delirium:
                    serializer.Serialize(writer, "Delirium");
                    return;
                case Variant.Delerium:
                    serializer.Serialize(writer, "Delerium");
                    return;
                case Variant.Harvest:
                    serializer.Serialize(writer, "Harvest");
                    return;
                case Variant.Legion:
                    serializer.Serialize(writer, "Legion");
                    return;
                case Variant.Metamorph:
                    serializer.Serialize(writer, "Metamorph");
                    return;
                case Variant.Pre20:
                    serializer.Serialize(writer, "Pre 2.0");
                    return;
                case Variant.Pre24:
                    serializer.Serialize(writer, "Pre 2.4");
                    return;
                case Variant.Synthesis:
                    serializer.Serialize(writer, "Synthesis");
                    return;
                case Variant.Heist:
                    serializer.Serialize(writer, "Heist");
                    return;
                case Variant.Ritual:
                    serializer.Serialize(writer, "Ritual");
                    return;
                case Variant.Ultimatum:
                    serializer.Serialize(writer, "Ultimatum");
                    return;
                case Variant.Expedition:
                    serializer.Serialize(writer, "Expedition");
                    return;
                case Variant.Scourge:
                    serializer.Serialize(writer, "Scourge");
                    return;
                default: throw new Exception("Cannot marshal type Variant");
            }
        }
    }
}
