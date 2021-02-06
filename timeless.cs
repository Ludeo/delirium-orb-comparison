using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;

namespace Delirium
{
    public class timelesscalc
    {

        public static double calc()
        {
            var result1 = new WebClient().DownloadString("https://poe.ninja/api/data/CurrencyOverview?league="+Program.League+"&type=Fragment&language=en");
            var data1 = fragment.Fragment.FromJson(result1);

            var result2 = new WebClient().DownloadString("https://poe.ninja/api/data/ItemOverview?league="+Program.League+"&type=Incubator&language=en");
            var data2 = incubator.Incubator.FromJson(result2);

            double emblem1 = 0.0, emblem2 = 0.0, emblem3 = 0.0, emblem4 = 0.0, emblem5 = 0.0;
            double incubator1 = 0.0, incubator2 = 0.0, incubator3 = 0.0, incubator4 = 0.0, incubator5 = 0.0, incubator6 = 0.0, incubator7 = 0.0, incubator8 = 0.0, incubator9 = 0.0, incubator10 = 0.0
                , incubator11 = 0.0, incubator12 = 0.0, incubator13 = 0.0, incubator14 = 0.0,incubator15 = 0.0, incubator16 = 0.0, incubator17 = 0.0, incubator18 = 0.0, incubator19 = 0.0
                , incubator20 = 0.0, incubator21 = 0.0, incubator22 = 0.0, incubator23 = 0.0;

            data1.Lines.ForEach(x =>
            {
                if (x.CurrencyTypeName == "Timeless Maraketh Emblem")
                    emblem1 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Timeless Templar Emblem")
                    emblem2 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Timeless Vaal Emblem")
                    emblem3 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Timeless Eternal Emblem")
                    emblem4 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Timeless Karui Emblem")
                    emblem5 = x.ChaosEquivalent;
            });

            data2.Lines.ForEach(x =>
            {
                if (x.Name == "Thaumaturge's Incubator")
                    incubator1 = x.ChaosValue;

                else if (x.Name == "Geomancer's Incubator")
                    incubator2 = x.ChaosValue;

                else if (x.Name == "Time-Lost Incubator")
                    incubator3 = x.ChaosValue;

                else if (x.Name == "Foreboding Incubator")
                    incubator4 = x.ChaosValue;

                else if (x.Name == "Diviner's Incubator")
                    incubator5 = x.ChaosValue;

                else if (x.Name == "Whispering Incubator")
                    incubator6 = x.ChaosValue;

                else if (x.Name == "Enchanted Incubator")
                    incubator7 = x.ChaosValue;

                else if (x.Name == "Ornate Incubator")
                    incubator8 = x.ChaosValue;

                else if (x.Name == "Skittering Incubator")
                    incubator9 = x.ChaosValue;

                else if (x.Name == "Fragmented Incubator")
                    incubator10 = x.ChaosValue;

                else if (x.Name == "Celestial Jeweller's Incubator")
                    incubator11 = x.ChaosValue;

                else if (x.Name == "Fossilised Incubator")
                    incubator12 = x.ChaosValue;

                else if (x.Name == "Obscured Incubator")
                    incubator13 = x.ChaosValue;

                else if (x.Name == "Infused Incubator")
                    incubator14 = x.ChaosValue;

                else if (x.Name == "Abyssal Incubator")
                    incubator15 = x.ChaosValue;

                else if (x.Name == "Cartographer's Incubator")
                    incubator16 = x.ChaosValue;

                else if (x.Name == "Celestial Armoursmith's Incubator")
                    incubator17 = x.ChaosValue;

                else if (x.Name == "Celestial Blacksmith's Incubator")
                    incubator18 = x.ChaosValue;

                else if (x.Name == "Decadent Incubator")
                    incubator19 = x.ChaosValue;

                else if (x.Name == "Mysterious Incubator")
                    incubator20 = x.ChaosValue;

                else if (x.Name == "Otherworldly Incubator")
                    incubator21 = x.ChaosValue;

                else if (x.Name == "Primal Incubator")
                    incubator22 = x.ChaosValue;

                else if (x.Name == "Singular Incubator")
                    incubator23 = x.ChaosValue;
            });

            double emblems = emblem1/5 + 0.99*emblem2/5 + 2.51*emblem3/5 + 3.34*emblem4/5 + 3.75*emblem5/5;
            double incubators = incubator1 * 9 / 5 + incubator2 * 4 / 5 + incubator3 * 13 / 5 + incubator4 * 24 / 5 + incubator5 * 44 / 5 + incubator6 * 0 / 5 + incubator7 * 57 / 5 
                + incubator8 * 56 / 5 + incubator9 * 39 / 5 + incubator10 * 55 / 5 + incubator11 * 25 / 5 + incubator12 * 45 / 5 + incubator13 * 31 / 5 + incubator14 * 22 / 5 
                + incubator15 * 50 / 5 + incubator16 * 44 / 5 + incubator17 * 16 / 5 + incubator18 * 18 / 5+ incubator19 * 11 / 5 + incubator20 * 46 / 5 + incubator21 * 16 / 5 
                + incubator22 * 31 / 5 + incubator23 * 34 / 5;

            return emblems+incubators;
        }
        

    }
}
