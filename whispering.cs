using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;

namespace delirium
{
    public class whisperingcalc
    {

        public static double calc()
        {
            var result = new WebClient().DownloadString("https://poe.ninja/api/data/ItemOverview?league=" + main.league + "&type=Essence&language=en");
            var data = essence.Essence.FromJson(result);

            double ess1 = 0.0, ess2 = 0.0, ess3 = 0.0, ess4 = 0.0, ess5 = 0.0, ess6 = 0.0, ess7 = 0.0, ess8 = 0.0, ess9 = 0.0, ess10 = 0.0, ess11 = 0.0, ess12 = 0.0, ess13 = 0.0, ess14 = 0.0,
                ess15 = 0.0, ess16 = 0.0, ess17 = 0.0, ess18 = 0.0, ess19 = 0.0, ess20 = 0.0, ess21 = 0.0, ess22 = 0.0, ess23 = 0.0, ess24 = 0.0, ess25 = 0.0;

            data.Lines.ForEach(x =>
            {
                if (x.Name == "Deafening Essence of Spite")
                    ess1 = x.ChaosValue;

                else if (x.Name == "Deafening Essence of Sorrow")
                    ess2 = x.ChaosValue;

                else if (x.Name == "Deafening Essence of Scorn")
                    ess3 = x.ChaosValue;

                else if (x.Name == "Deafening Essence of Woe")
                    ess4 = x.ChaosValue;

                else if (x.Name == "Deafening Essence of Zeal")
                    ess5 = x.ChaosValue;

                else if (x.Name == "Deafening Essence of Envy")
                    ess6 = x.ChaosValue;

                else if (x.Name == "Deafening Essence of Greed")
                    ess7 = x.ChaosValue;

                else if (x.Name == "Deafening Essence of Rage")
                    ess8 = x.ChaosValue;

                else if (x.Name == "Deafening Essence of Anger")
                    ess9 = x.ChaosValue;

                else if (x.Name == "Deafening Essence of Loathing")
                    ess10 = x.ChaosValue;

                else if (x.Name == "Deafening Essence of Contempt")
                    ess11 = x.ChaosValue;

                else if (x.Name == "Deafening Essence of Fear")
                    ess12 = x.ChaosValue;

                else if (x.Name == "Deafening Essence of Misery")
                    ess13 = x.ChaosValue;

                else if (x.Name == "Deafening Essence of Wrath")
                    ess14 = x.ChaosValue;

                else if (x.Name == "Deafening Essence of Anguish")
                    ess15 = x.ChaosValue;

                else if (x.Name == "Deafening Essence of Doubt")
                    ess16 = x.ChaosValue;

                else if (x.Name == "Deafening Essence of Dread")
                    ess17 = x.ChaosValue;

                else if (x.Name == "Deafening Essence of Hatred")
                    ess18 = x.ChaosValue;

                else if (x.Name == "Deafening Essence of Suffering")
                    ess19 = x.ChaosValue;

                else if (x.Name == "Deafening Essence of Torment")
                    ess20 = x.ChaosValue;

                else if (x.Name == "Essence of Horror")
                    ess21 = x.ChaosValue;

                else if (x.Name == "Essence of Delirium")
                    ess22 = x.ChaosValue;

                else if (x.Name == "Essence of Insanity")
                    ess23 = x.ChaosValue;

                else if (x.Name == "Essence of Hysteria")
                    ess24 = x.ChaosValue;

                else if (x.Name == "Essence of Corruption")
                    ess25 = x.ChaosValue;
            });

            var esss = ess1 * 1.33 / 5 + ess2 * 3.33 / 5 + ess3 * 1 / 5 + ess4 * 2.33 / 5 + ess5 * 1.66 / 5 + ess6 * 0.66 / 5 + ess7 * 2 / 5 + ess8 * 2.33 / 5 + ess9 * 2.33 / 5 + ess10 * 1.66 / 5 
                + ess11 * 2.66 / 5 + ess12 * 2.66 / 5 + ess13 * 1.33 / 5 + ess14 * 1.66 / 5 + ess15 * 2.33 / 5 + ess16 * 2.66 / 5 + ess17 * 1.66 / 5 + ess18 * 2.66 / 5 + ess19 * 2 / 5 
                + ess20 * 2 / 5 + ess21 * 2 / 5 + ess22 * 4 / 5 + ess23 * 1 / 5 + ess24 * 2 / 5 + ess25 * 21 / 5;

            return esss;
        }

    }

}
