using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;

namespace Delirium
{
    public class amorphouscalc
    {

        public static double calc()
        {
            var result = new WebClient().DownloadString("https://poe.ninja/api/data/CurrencyOverview?league=" + Program.League + "&type=Currency&language=en");
            var data = currency.Currency.FromJson(result);

            double cat1 = 0.0, cat2 = 0.0, cat3 = 0.0, cat4 = 0.0, cat5 = 0.0, cat6 = 0.0, cat7 = 0.0;

            data.Lines.ForEach(x =>
            {
                if (x.CurrencyTypeName == "Tempering Catalyst")
                    cat1 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Prismatic Catalyst")
                    cat2 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Fertile Catalyst")
                    cat3 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Intrinsic Catalyst")
                    cat4 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Imbued Catalyst")
                    cat5 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Abrasive Catalyst")
                    cat6 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Turbulent Catalyst")
                    cat7 = x.ChaosEquivalent;
            });

            var cats = cat1 * 15 / 5 + cat2 * 28 / 5 + cat3 * 48 / 5 + cat4 * 268 / 5 + cat5 * 193 / 5 + cat6 * 177 / 5 + cat7 * 181 / 5;

            return cats;
        }

    }

}
