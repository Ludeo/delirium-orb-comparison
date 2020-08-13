using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;


namespace delirium
{
    public class obscuredcalc
    {
        public static double calc()
        {
            var result1 = new WebClient().DownloadString("https://poe.ninja/api/data/CurrencyOverview?league=" + main.league + "&type=Currency&language=en");
            var data1 = currency.Currency.FromJson(result1);

            var result2 = new WebClient().DownloadString("https://poe.ninja/api/data/CurrencyOverview?league=" + main.league + "&type=Fragment&language=en");
            var data2 = fragment.Fragment.FromJson(result2);

            double chayu1 = 0.0, chayu2 = 0.0, chayu3 = 0.0, chayu4 = 0.0, chayu5 = 0.0;
            double uulne1 = 0.0, uulne2 = 0.0, uulne3 = 0.0, uulne4 = 0.0, uulne5 = 0.0;
            double xoph1 = 0.0, xoph2 = 0.0, xoph3 = 0.0, xoph4 = 0.0, xoph5 = 0.0;
            double esh1 = 0.0, esh2 = 0.0, esh3 = 0.0, esh4 = 0.0, esh5 = 0.0;
            double tul1 = 0.0, tul2 = 0.0, tul3 = 0.0, tul4 = 0.0, tul5 = 0.0;

            data2.Lines.ForEach(x =>
            {
                if (x.CurrencyTypeName == "Chayula's Breachstone")
                    chayu1 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Chayula's Charged Breachstone")
                    chayu2 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Chayula's Enriched Breachstone")
                    chayu3 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Chayula's Pure Breachstone")
                    chayu4 = x.ChaosEquivalent;


                if (x.CurrencyTypeName == "Uul-Netol's Breachstone")
                    uulne1 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Uul-Netol's Charged Breachstone")
                    uulne2 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Uul-Netol's Enriched Breachstone")
                    uulne3 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Uul-Netol's Pure Breachstone")
                    uulne4 = x.ChaosEquivalent;


                if (x.CurrencyTypeName == "Xoph's Breachstone")
                    xoph1 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Xoph's Charged Breachstone")
                    xoph2 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Xoph's Enriched Breachstone")
                    xoph3 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Xoph's Pure Breachstone")
                    xoph4 = x.ChaosEquivalent;


                if (x.CurrencyTypeName == "Esh's Breachstone")
                    esh1 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Esh's Charged Breachstone")
                    esh2 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Esh's Enriched Breachstone")
                    esh3 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Esh's Pure Breachstone")
                    esh4 = x.ChaosEquivalent;


                if (x.CurrencyTypeName == "Tul's Breachstone")
                    tul1 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Tul's Charged Breachstone")
                    tul2 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Tul's Enriched Breachstone")
                    tul3 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Tul's Pure Breachstone")
                    tul4 = x.ChaosEquivalent;
            });

            data1.Lines.ForEach(x =>
            {
                if (x.CurrencyTypeName == "Blessing of Chayula")
                    chayu5 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Blessing of Uul-Netol")
                    uulne5 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Blessing of Xoph")
                    xoph5 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Blessing of Esh")
                    esh5 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Blessing of Tul")
                    tul5 = x.ChaosEquivalent;
            });

            var chayus = chayu1 * 21.6 / 20 + chayu2 * 1 / 20 + chayu3 * 5 / 20 + chayu4 * 0 / 20 + chayu5 * 1 / 20;
            var uulnes = uulne1 * 78.9 / 20 + uulne2 * 6 / 20 + uulne3 * 5 / 20 + uulne4 * 2 / 20 + uulne5 * 9 / 20;
            var xophs = xoph1 * 82 / 20 + xoph2 * 4 / 20 + xoph3 * 4 / 20 + xoph4 * 6 / 20 + xoph5 * 34 / 20;
            var eshs = esh1 * 79.5 / 20 + esh2 * 7 / 20 + esh3 * 7 / 20 + esh4 * 6 / 20 + esh5 * 16 / 20;
            var tuls = tul1 * 87.1 / 20 + tul2 * 8 / 20 + tul3 * 8 / 20 + tul4 * 2 / 20 + tul5 * 24 / 20;

            return chayus + uulnes + xophs + eshs + tuls;
        }

    }
}
