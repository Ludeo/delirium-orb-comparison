using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;

namespace Delirium
{
    public class fossilisedcalc
    {

        public static double calc()
        {
            var result1 = new WebClient().DownloadString("https://poe.ninja/api/data/ItemOverview?league=" + Program.League + "&type=Fossil&language=en");
            var data1 = fossil.Fossil.FromJson(result1);

            var result2 = new WebClient().DownloadString("https://poe.ninja/api/data/ItemOverview?league=" + Program.League + "&type=Resonator&language=en");
            var data2 = resonator.Resonator.FromJson(result2);

            double fossil1 = 0.0, fossil2 = 0.0, fossil3 = 0.0, fossil4 = 0.0, fossil5 = 0.0, fossil6 = 0.0, fossil7 = 0.0, fossil8 = 0.0, fossil9 = 0.0, fossil10 = 0.0, fossil11 = 0.0
                , fossil12 = 0.0, fossil13 = 0.0, fossil14 = 0.0, fossil15 = 0.0, fossil16 = 0.0, fossil17 = 0.0, fossil18 = 0.0, fossil19 = 0.0, fossil20 = 0.0;

            data1.Lines.ForEach(x =>
            {
                if (x.Name == "Aberrant Fossil")
                    fossil1 = x.ChaosValue;

                else if (x.Name == "Frigid Fossil")
                    fossil2 = x.ChaosValue;

                else if (x.Name == "Scorched Fossil")
                    fossil3 = x.ChaosValue;

                else if (x.Name == "Pristine Fossil")
                    fossil4 = x.ChaosValue;

                else if (x.Name == "Dense Fossil")
                    fossil5 = x.ChaosValue;

                else if (x.Name == "Jagged Fossil")
                    fossil6 = x.ChaosValue;

                else if (x.Name == "Metallic Fossil")
                    fossil7 = x.ChaosValue;

                else if (x.Name == "Bound Fossil")
                    fossil8 = x.ChaosValue;

                else if (x.Name == "Perfect Fossil")
                    fossil9 = x.ChaosValue;

                else if (x.Name == "Aetheric Fossil")
                    fossil10 = x.ChaosValue;

                else if (x.Name == "Prismatic Fossil")
                    fossil11 = x.ChaosValue;

                else if (x.Name == "Serrated Fossil")
                    fossil12 = x.ChaosValue;

                else if (x.Name == "Enchanted Fossil")
                    fossil13 = x.ChaosValue;

                else if (x.Name == "Shuddering Fossil")
                    fossil14 = x.ChaosValue;

                else if (x.Name == "Gilded Fossil")
                    fossil15 = x.ChaosValue;

                else if (x.Name == "Sanctified Fossil")
                    fossil16 = x.ChaosValue;

                else if (x.Name == "Lucent Fossil")
                    fossil17 = x.ChaosValue;

                else if (x.Name == "Corroded Fossil")
                    fossil18 = x.ChaosValue;

                else if (x.Name == "Encrusted Fossil")
                    fossil19 = x.ChaosValue;

            });

            data2.Lines.ForEach(x =>
            {
                if (x.Name == "Prime Alchemical Resonator")
                    fossil20 = x.ChaosValue;
            });

            var fossils = fossil1 * 56 / 5 + fossil2 * 69 / 5 + fossil3 * 68 / 5 + fossil4 * 78 / 5 + fossil5 * 56 / 5 + fossil6 * 62 / 5 + fossil7 * 71 / 5 + fossil8 * 11 / 5 + fossil9 * 6 / 5 
                + fossil10 * 8 / 5 + fossil11 * 4 / 5 + fossil12 * 7 / 5 + fossil13 * 6 / 5 + fossil14 * 4 / 5 + fossil15 * 2 / 5 + fossil16 * 2 / 5 + fossil17 * 2 / 5 + fossil18 * 2 / 5 
                + fossil19 * 1 / 5 + fossil20 * 1 / 5;

            return fossils;
        }

    }

}
