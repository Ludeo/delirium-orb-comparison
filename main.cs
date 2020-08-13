using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;

namespace delirium
{
    class main
    {

        public static String league { get; private set;}

        static public void Main(String [] args)
        {
            league = "Harvest";

            var result1 = new WebClient().DownloadString("https://poe.ninja/api/data/ItemOverview?league="+league+"&type=Fossil&language=en");
            var data1 = fossil.Fossil.FromJson(result1);

            var result2 = new WebClient().DownloadString("https://poe.ninja/api/data/CurrencyOverview?league="+league+"&type=Fragment&language=en");
            var data2 = fragment.Fragment.FromJson(result2);

            var fracfossil = 0.0;
            var simu = 0.0;

            data1.Lines.ForEach(x =>
            {
                if (x.Name == "Fractured Fossil")
                    fracfossil = x.ChaosValue;
            });

            data2.Lines.ForEach(x =>
            {
                if (x.CurrencyTypeName == "Simulacrum")
                    simu = x.ChaosEquivalent;
            });

            double timeless = Math.Round(timelesscalc.calc() + simu * 7.5 / 20 - fracfossil, 2);
            double skittering = Math.Round(skitteringcalc.calc() + simu * 7.5 / 20 - fracfossil, 2);
            double obscured = Math.Round(obscuredcalc.calc() + simu * 7.5 / 20 - fracfossil, 2);
            double blighted = Math.Round(blightedcalc.calc() + simu * 7.5 / 20 - fracfossil, 2);
            double fragmented = Math.Round(fragmentedcalc.calc() + simu * 7.5 / 20 - fracfossil, 2);
            double fossilised = Math.Round(fossilisedcalc.calc() + simu * 7.5 / 20 - fracfossil, 2);
            double foreboding = Math.Round(forebodingcalc.calc() + simu * 7.5 / 20 - fracfossil, 2);
            double amorphous = Math.Round(amorphouscalc.calc() + simu * 7.5 / 20 - fracfossil, 2);
            double whispering = Math.Round(whisperingcalc.calc() + simu * 7.5 / 20 - fracfossil, 2);

            SortedDictionary<double, string> results =new SortedDictionary<double, string>(Comparer<double>.Create((x, y) => y.CompareTo(x)));
            results.Add(timeless, "Timeless");
            results.Add(skittering, "Skittering");
            results.Add(obscured, "Obscured");
            results.Add(blighted, "Blighted");
            results.Add(fragmented, "Fragmented");
            results.Add(fossilised, "Fossilised");
            results.Add(foreboding, "Foreboding");
            results.Add(amorphous, "Amorphous");
            results.Add(whispering, "Whispering");

            int i = 1;

            foreach (KeyValuePair<double, string> pair in results)
            {
                if(i == 1)
                {
                    Console.WriteLine("------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("{1} Delirium Orb: {0}c", pair.Key, pair.Value);
                    Console.ResetColor();
                    Console.WriteLine("------------------------------------------------");
                } else if(i == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{1} Delirium Orb: {0}c", pair.Key, pair.Value);
                    Console.ResetColor();
                    Console.WriteLine("------------------------------------------------");
                } else if (i == 3 || (i > 3 && pair.Key > 20))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("{1} Delirium Orb: {0}c", pair.Key, pair.Value);
                    Console.ResetColor();
                    Console.WriteLine("------------------------------------------------");
                } else if(pair.Key < 20)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{1} Delirium Orb: {0}c", pair.Key, pair.Value);
                    Console.ResetColor();
                    Console.WriteLine("------------------------------------------------");
                }

                i++;
            }

            Console.ReadLine();
        }

        
    }
}
