using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Delirium.currency
{
    public partial class Currency
    {
        [JsonProperty("lines")]
        public List<Line> Lines { get; set; }

        [JsonProperty("currencyDetails")]
        public List<CurrencyDetail> CurrencyDetails { get; set; }

        [JsonProperty("language")]
        public Language Language { get; set; }
    }

    public class CurrencyDetail
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("icon")]
        public Uri Icon { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("poeTradeId")]
        public long PoeTradeId { get; set; }

        [JsonProperty("tradeId")]
        public string TradeId { get; set; }
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
        [JsonProperty("currencyTypeName")]
        public string CurrencyTypeName { get; set; }

        [JsonProperty("pay")]
        public Receive Pay { get; set; }

        [JsonProperty("receive")]
        public Receive Receive { get; set; }

        [JsonProperty("paySparkLine")]
        public PaySparkLine PaySparkLine { get; set; }

        [JsonProperty("receiveSparkLine")]
        public ReceiveSparkLine ReceiveSparkLine { get; set; }

        [JsonProperty("chaosEquivalent")]
        public double ChaosEquivalent { get; set; }

        [JsonProperty("lowConfidencePaySparkLine")]
        public PaySparkLine LowConfidencePaySparkLine { get; set; }

        [JsonProperty("lowConfidenceReceiveSparkLine")]
        public ReceiveSparkLine LowConfidenceReceiveSparkLine { get; set; }

        [JsonProperty("detailsId")]
        public string DetailsId { get; set; }
    }

    public class PaySparkLine
    {
        [JsonProperty("data")]
        public List<double?> Data { get; set; }

        [JsonProperty("totalChange")]
        public double TotalChange { get; set; }
    }

    public class ReceiveSparkLine
    {
        [JsonProperty("data")]
        public List<double?> Data { get; set; }

        [JsonProperty("totalChange")]
        public double TotalChange { get; set; }
    }

    public class Receive
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("league_id")]
        public long LeagueId { get; set; }

        [JsonProperty("pay_currency_id")]
        public long PayCurrencyId { get; set; }

        [JsonProperty("get_currency_id")]
        public long GetCurrencyId { get; set; }

        [JsonProperty("sample_time_utc")]
        public DateTimeOffset SampleTimeUtc { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("data_point_count")]
        public long DataPointCount { get; set; }

        [JsonProperty("includes_secondary")]
        public bool IncludesSecondary { get; set; }
    }

    public partial class Currency
    {
        public static Currency FromJson(string json) => JsonConvert.DeserializeObject<Currency>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Currency self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal },
            },
        };
    }
}
