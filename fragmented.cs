using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;

namespace Delirium
{
    public class fragmentedcalc
    {

        public static double calc()
        {
            var result = new WebClient().DownloadString("https://poe.ninja/api/data/CurrencyOverview?league=" + Program.League + "&type=Fragment&language=en");
            var data = fragment.Fragment.FromJson(result);

            double frag1 = 0.0, frag2 = 0.0, frag3 = 0.0, frag4 = 0.0, frag5 = 0.0, frag6 = 0.0, frag7 = 0.0, frag8 = 0.0, frag9 = 0.0, frag10 = 0.0, frag11 = 0.0, frag12 = 0.0, frag13 = 0.0
                , frag14 = 0.0, frag15 = 0.0, frag16 = 0.0;

            data.Lines.ForEach(x =>
            {
                if (x.CurrencyTypeName == "Sacrifice at Dusk")
                    frag1 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Sacrifice at Dawn")
                    frag2 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Sacrifice at Noon")
                    frag3 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Sacrifice at Midnight")
                    frag4 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Fragment of Purification")
                    frag5 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Fragment of Eradication")
                    frag6 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Fragment of Enslavement")
                    frag7 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Fragment of Constriction")
                    frag8 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Fragment of the Minotaur")
                    frag9 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Fragment of the Phoenix")
                    frag10 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Fragment of the Chimera")
                    frag11 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Fragment of the Hydra")
                    frag12 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Mortal Ignorance")
                    frag13 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Mortal Rage")
                    frag14 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Mortal Grief")
                    frag15 = x.ChaosEquivalent;

                else if (x.CurrencyTypeName == "Mortal Hope")
                    frag16 = x.ChaosEquivalent;
            });

            var frags = frag1 * 257 / 5 + frag2 * 169 / 5 + frag3 * 138 / 5 + frag4 * 63 / 5 + frag5 * 2 / 5 + frag6 * 1 / 5 + frag7 * 1 / 5 + frag8 * 1 / 5 + frag9 * 1 / 5 + frag10 * 1 / 5 
                + frag11 * 0 / 5 + frag12 * 2 / 5 + frag13 * 4 / 5 + frag14 * 5 / 5 + frag15 * 2 / 5 + frag16 * 1 / 5;

            return frags;
        }

    }

}