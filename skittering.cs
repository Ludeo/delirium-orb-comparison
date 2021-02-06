using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;

namespace Delirium
{
    public class skitteringcalc
    {

        public static double calc()
        {
            var result = new WebClient().DownloadString("https://poe.ninja/api/data/ItemOverview?league="+Program.League+"&type=Scarab&language=en");
            var data = scarab.Scarab.FromJson(result);

            double rscarab1 = 0.0, rscarab2 = 0.0, rscarab3 = 0.0, rscarab4 = 0.0, rscarab5 = 0.0, rscarab6 = 0.0, rscarab7 = 0.0, rscarab8 = 0.0, rscarab9 = 0.0, rscarab10 = 0.0, rscarab11 = 0.0
                ,rscarab12 = 0.0, rscarab13 = 0.0, rscarab14 = 0.0;
            double pscarab1 = 0.0, pscarab2 = 0.0, pscarab3 = 0.0, pscarab4 = 0.0, pscarab5 = 0.0, pscarab6 = 0.0, pscarab7 = 0.0, pscarab8 = 0.0, pscarab9 = 0.0, pscarab10 = 0.0, pscarab11 = 0.0
                , pscarab12 = 0.0, pscarab13 = 0.0, pscarab14 = 0.0;
            double gscarab1 = 0.0, gscarab2 = 0.0, gscarab3 = 0.0, gscarab4 = 0.0, gscarab5 = 0.0, gscarab6 = 0.0, gscarab7 = 0.0, gscarab8 = 0.0, gscarab9 = 0.0, gscarab10 = 0.0, gscarab11 = 0.0
                , gscarab12 = 0.0, gscarab13 = 0.0, gscarab14 = 0.0;

            data.Lines.ForEach(x =>
            {
                if(x.Name == "Rusted Sulphite Scarab")
                    rscarab1 = x.ChaosValue;

                else if (x.Name == "Rusted Legion Scarab")
                    rscarab2 = x.ChaosValue;

                else if (x.Name == "Rusted Harbinger Scarab")
                    rscarab3 = x.ChaosValue;

                else if (x.Name == "Rusted Metamorph Scarab")
                    rscarab4 = x.ChaosValue;

                else if (x.Name == "Rusted Ambush Scarab")
                    rscarab5 = x.ChaosValue;

                else if (x.Name == "Rusted Bestiary Scarab")
                    rscarab6 = x.ChaosValue;

                else if (x.Name == "Rusted Breach Scarab")
                    rscarab7 = x.ChaosValue;

                else if (x.Name == "Rusted Cartography Scarab")
                    rscarab8 = x.ChaosValue;

                else if (x.Name == "Rusted Divination Scarab")
                    rscarab9 = x.ChaosValue;

                else if (x.Name == "Rusted Elder Scarab")
                    rscarab10 = x.ChaosValue;

                else if (x.Name == "Rusted Perandus Scarab")
                    rscarab11 = x.ChaosValue;

                else if (x.Name == "Rusted Reliquary Scarab")
                    rscarab12 = x.ChaosValue;

                else if (x.Name == "Rusted Shaper Scarab")
                    rscarab13 = x.ChaosValue;

                else if (x.Name == "Rusted Torment Scarab")
                    rscarab14 = x.ChaosValue;


                if (x.Name == "Polished Sulphite Scarab")
                    pscarab1 = x.ChaosValue;

                else if (x.Name == "Polished Legion Scarab")
                    pscarab2 = x.ChaosValue;

                else if (x.Name == "Polished Harbinger Scarab")
                    pscarab3 = x.ChaosValue;

                else if (x.Name == "Polished Metamorph Scarab")
                    pscarab4 = x.ChaosValue;

                else if (x.Name == "Polished Ambush Scarab")
                    pscarab5 = x.ChaosValue;

                else if (x.Name == "Polished Bestiary Scarab")
                    pscarab6 = x.ChaosValue;

                else if (x.Name == "Polished Breach Scarab")
                    pscarab7 = x.ChaosValue;

                else if (x.Name == "Polished Cartography Scarab")
                    pscarab8 = x.ChaosValue;

                else if (x.Name == "Polished Divination Scarab")
                    pscarab9 = x.ChaosValue;

                else if (x.Name == "Polished Elder Scarab")
                    pscarab10 = x.ChaosValue;

                else if (x.Name == "Polished Perandus Scarab")
                    pscarab11 = x.ChaosValue;

                else if (x.Name == "Polished Reliquary Scarab")
                    pscarab12 = x.ChaosValue;

                else if (x.Name == "Polished Shaper Scarab")
                    pscarab13 = x.ChaosValue;

                else if (x.Name == "Polished Torment Scarab")
                    pscarab14 = x.ChaosValue;


                if (x.Name == "Gilded Sulphite Scarab")
                    gscarab1 = x.ChaosValue;

                else if (x.Name == "Gilded Legion Scarab")
                    gscarab2 = x.ChaosValue;

                else if (x.Name == "Gilded Harbinger Scarab")
                    gscarab3 = x.ChaosValue;

                else if (x.Name == "Gilded Metamorph Scarab")
                    gscarab4 = x.ChaosValue;

                else if (x.Name == "Gilded Ambush Scarab")
                    gscarab5 = x.ChaosValue;

                else if (x.Name == "Gilded Bestiary Scarab")
                    gscarab6 = x.ChaosValue;

                else if (x.Name == "Gilded Breach Scarab")
                    gscarab7 = x.ChaosValue;

                else if (x.Name == "Gilded Cartography Scarab")
                    gscarab8 = x.ChaosValue;

                else if (x.Name == "Gilded Divination Scarab")
                    gscarab9 = x.ChaosValue;

                else if (x.Name == "Gilded Elder Scarab")
                    gscarab10 = x.ChaosValue;

                else if (x.Name == "Gilded Perandus Scarab")
                    gscarab11 = x.ChaosValue;

                else if (x.Name == "Gilded Reliquary Scarab")
                    gscarab12 = x.ChaosValue;

                else if (x.Name == "Gilded Shaper Scarab")
                    gscarab13 = x.ChaosValue;

                else if (x.Name == "Gilded Torment Scarab")
                    gscarab14 = x.ChaosValue;

            });

            var rscarabs = rscarab1 * 121 / 20 + rscarab2 * 131 / 20 + rscarab3 * 117 / 20 + rscarab4 * 112 / 20 + rscarab5 * 119 / 20 + rscarab6 * 125 / 20 + rscarab7 * 124 / 20 
                + rscarab8 * 118 / 20 + rscarab9 * 114 / 20 + rscarab10 * 115 / 20 + rscarab11 * 121 / 20 + rscarab12 * 111 / 20 + rscarab13 * 117 / 20 + rscarab14 * 112 / 20;

            var pscarabs = pscarab1 * 60 / 20 + pscarab2 * 68 / 20 + pscarab3 * 44 / 20 + pscarab4 * 69 / 20 + pscarab5 * 70 / 20 + pscarab6 * 64 / 20 + pscarab7 * 57 / 20 + pscarab8 * 51 / 20 
                + pscarab9 * 66 / 20 + pscarab10 * 70 / 20 + pscarab11 * 55 / 20 + pscarab12 * 69 / 20 + pscarab13 * 62 / 20 + pscarab14 * 54 / 20;

            var gscarabs = gscarab1 * 30 / 20 + gscarab2 * 26 / 20 + gscarab3 * 16 / 20 + gscarab4 * 14 / 20 + gscarab5 * 19 / 20 + gscarab6 * 23 / 20 + gscarab7 * 24 / 20 + gscarab8 * 20 / 20 
                + gscarab9 * 20 / 20 + gscarab10 * 20 / 20 + gscarab11 * 27 / 20 + gscarab12 * 27 / 20 + gscarab13 * 19 / 20 + gscarab14 * 22 / 20;

            return rscarabs + pscarabs + gscarabs;
        }
    }
}
