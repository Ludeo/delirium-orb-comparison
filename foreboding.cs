using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;

namespace Delirium
{
    public class forebodingcalc
    {

        public static double calc()
        {
            var result1 = new WebClient().DownloadString("https://poe.ninja/api/data/CurrencyOverview?league=" + Program.League + "&type=Currency&language=en");
            var data1 = currency.Currency.FromJson(result1);

            var result2 = new WebClient().DownloadString("https://poe.ninja/api/data/ItemOverview?league=" + Program.League + "&type=UniqueMap&language=en");
            var data2 = uniquemap.UniqueMap.FromJson(result2);

            double harb1 = 0.0, harb2 = 0.0, harb3 = 0.0, harb4 = 0.0, harb5 = 0.0, harb6 = 0.0;

            data1.Lines.ForEach(x =>
            {
                if (x.CurrencyTypeName == "Ancient Orb")
                    harb1 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Exalted Orb")
                    harb2 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Harbinger's Orb")
                    harb3 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Orb of Horizons")
                    harb4 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Orb of Annulment")
                    harb5 = x.ChaosEquivalent;

            });

            data2.Lines.ForEach(x =>
            {
                if (x.Name == "The Beachhead" && x.MapTier == 15)
                    harb6 = x.ChaosValue;
            });

            var harbs = harb1 * 12.05 / 5 + harb2 * 2.65 / 5 + harb3 * 17.35 / 5 + harb4 * 73 / 5 + harb5 * 2.75 / 5 + harb6 * 7 / 5;

            return harbs;
        }

    }

}