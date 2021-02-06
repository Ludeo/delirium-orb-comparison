using System;
using System.Collections.Generic;
using System.Net;
using Delirium.fossil;
using Delirium.fragment;

namespace Delirium
{
    public static class Program
    {
        public static string League { get; private set; }

        public static void Main()
        {
            League = "Ritual";

            string result1 = new WebClient().DownloadString("https://poe.ninja/api/data/ItemOverview?league=" + League + "&type=Fossil&language=en");
            Fossil data1 = Fossil.FromJson(result1);

            string result2 = new WebClient().DownloadString("https://poe.ninja/api/data/CurrencyOverview?league=" + League + "&type=Fragment&language=en");
            Fragment data2 = Fragment.FromJson(result2);

            double fracturefossil = 0.0;
            double simulacrum = 0.0;

            data1.Lines.ForEach(x =>
            {
                if (x.Name == "Fractured Fossil")
                {
                    fracturefossil = x.ChaosValue;
                }
            });

            data2.Lines.ForEach(x =>
            {
                if (x.CurrencyTypeName == "Simulacrum")
                {
                    simulacrum = x.ChaosEquivalent;
                }
            });

            double timeless = Math.Round(timelesscalc.calc() + (simulacrum * 7.5 / 20) - fracturefossil, 2);
            double skittering = Math.Round(skitteringcalc.calc() + (simulacrum * 7.5 / 20) - fracturefossil, 2);
            double obscured = Math.Round(obscuredcalc.calc() + (simulacrum * 7.5 / 20) - fracturefossil, 2);
            double blighted = Math.Round(blightedcalc.calc() + (simulacrum * 7.5 / 20) - fracturefossil, 2);
            double fragmented = Math.Round(fragmentedcalc.calc() + (simulacrum * 7.5 / 20) - fracturefossil, 2);
            double fossilised = Math.Round(fossilisedcalc.calc() + (simulacrum * 7.5 / 20) - fracturefossil, 2);
            double foreboding = Math.Round(forebodingcalc.calc() + (simulacrum * 7.5 / 20) - fracturefossil, 2);
            double amorphous = Math.Round(amorphouscalc.calc() + (simulacrum * 7.5 / 20) - fracturefossil, 2);
            double whispering = Math.Round(whisperingcalc.calc() + (simulacrum * 7.5 / 20) - fracturefossil, 2);

            SortedDictionary<double, string> results = new SortedDictionary<double, string>(Comparer<double>.Create((x, y) => y.CompareTo(x)))
            {
                { timeless, "Timeless" },
                { skittering, "Skittering" },
                { obscured, "Obscured" },
                { blighted, "Blighted" },
                { fragmented, "Fragmented" },
                { fossilised, "Fossilised" },
                { foreboding, "Foreboding" },
                { amorphous, "Amorphous" },
                { whispering, "Whispering" },
            };

            int i = 1;

            foreach ((double key, string value) in results)
            {
                switch (i)
                {
                    case 1:
                        Console.WriteLine("------------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("{1} Delirium Orb: {0}c", key, value);
                        Console.ResetColor();
                        Console.WriteLine("------------------------------------------------");

                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("{1} Delirium Orb: {0}c", key, value);
                        Console.ResetColor();
                        Console.WriteLine("------------------------------------------------");

                        break;
                    default:
                    {
                        if (i == 3 || (i > 3 && key > 20))
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("{1} Delirium Orb: {0}c", key, value);
                            Console.ResetColor();
                            Console.WriteLine("------------------------------------------------");
                        }
                        else if (key < 20)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("{1} Delirium Orb: {0}c", key, value);
                            Console.ResetColor();
                            Console.WriteLine("------------------------------------------------");
                        }

                        break;
                    }
                }

                i++;
            }

            Console.ReadLine();
        }
    }
}
