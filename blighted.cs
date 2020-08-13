using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;

namespace delirium
{
    public class blightedcalc
    {

        public static double calc()
        {
            var result1 = new WebClient().DownloadString("https://poe.ninja/api/data/ItemOverview?league=" + main.league + "&type=Map&language=en");
            var data1 = map.Map.FromJson(result1);

            var result2 = new WebClient().DownloadString("https://poe.ninja/api/data/ItemOverview?league=" + main.league + "&type=Oil&language=en");
            var data2 = map.Map.FromJson(result2);

            double bmap1 = 0.0, bmap2 = 0.0, bmap3 = 0.0, bmap4 = 0.0, bmap5 = 0.0, bmap6 = 0.0;
            double oil1 = 0.0, oil2 = 0.0, oil3 = 0.0, oil4 = 0.0;

            data1.Lines.ForEach(x =>
            {
                if (x.Name == "Blighted Geode Map")
                    bmap1 = x.ChaosValue;

                else if (x.Name == "Blighted Siege Map")
                    bmap2 = x.ChaosValue;

                else if (x.Name == "Blighted Alleyways Map")
                    bmap3 = x.ChaosValue;

                else if (x.Name == "Blighted Estuary Map")
                    bmap4 = x.ChaosValue;

                else if (x.Name == "Blighted Spider Lair Map")
                    bmap5 = x.ChaosValue;

                else if (x.Name == "Blighted Thicket Map")
                    bmap6 = x.ChaosValue;

            });

            data2.Lines.ForEach(x =>
            {
                if (x.Name == "Golden Oil")
                    oil1 = x.ChaosValue;

                else if (x.Name == "Silver Oil")
                    oil2 = x.ChaosValue;

                else if (x.Name == "Opalescent Oil")
                    oil3 = x.ChaosValue;

                else if (x.Name == "Crimson Oil")
                    oil4 = x.ChaosValue;
            });

            var bmaps = bmap1 * 45 / 20 + bmap2 * 45 / 20 + bmap3 * 93 / 4 / 20 + bmap4 * 93 / 4 / 20 + bmap5 * 93 / 4 / 20 + bmap6 * 93 / 4 / 20;
            var oils = oil1 * 2 / 20 + oil2 * 9 / 20 + oil3 * 17 / 20 + oil4 * 53 / 20;

            return bmaps + oils;
        }

    }
}
