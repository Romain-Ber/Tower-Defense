using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defense
{
    public static class Lexicon
    {
        public static Dictionary<string, Dictionary<int, string>> lexiconContent;

        static Lexicon()
        {

            lexiconContent = new Dictionary<string, Dictionary<int, string>>
            {
                { "Void", new Dictionary<int, string>
                    {
                        { 0, "" },
                        { 1, "" },
                        { 2, "" },
                        { 3, "" },
                        { 4, "" },
                        { 5, "" },
                        { 6, "" },
                        { 7, "" },
                        { 8, "" },
                        { 9, "" },
                        { 10, "" },
                        { 11, "" },
                        { 12, "" },
                        { 13, "" },
                        { 14, "" },
                        { 15, "" },
                        { 16, "" },
                        { 17, "" },
                        { 18, "" },
                        { 19, "" },
                        { 20, "" },
                        { 21, "" },
                        { 22, "" },
                        { 23, "" },
                        { 24, "" },
                        { 25, "" },
                        { 26, "" },
                        { 27, "" },
                        { 28, "" },
                        { 29, "" }
                    }
                },
                { "Summary", new Dictionary<int, string> 
                    {
                        { 0, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 1, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 2, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 3, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 4, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 5, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 6, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 7, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 8, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 9, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 10, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 11, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 12, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 13, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 14, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 15, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 16, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 17, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 18, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 19, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 20, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 21, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 22, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 23, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 24, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 25, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 26, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 27, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 28, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" },
                        { 29, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" }
                    }
                },
                //Towers
                { "Arrow", new Dictionary<int, string>
                    {
                        { 0, "The Arrow Tower constitute the first line of defense against"},
                        { 1, "airborne targets. " },
                        { 2, "single" }
                    }
                },
                { "Ballista", new Dictionary<int, string>
                    {
                        { 1, "air" },
                        { 2, "anti armor" }
                    }
                },
                { "Blade", new Dictionary<int, string>
                    {
                        { 1, "ground" },
                        { 2, "aoe antiarmor" }
                    }
                },
                { "Canon", new Dictionary<int, string>
                    {
                        { 1, "ground" },
                        { 2, "aoe dps" }
                    }
                },
                { "Catapult", new Dictionary<int, string>
                    {
                        { 1, "ground" },
                        { 2, "debuf" }
                    }
                },
                { "Nova", new Dictionary<int, string>
                    {
                        { 1, "target all" },
                        { 2, "ultimate" }
                    }
                },
                { "Slingshot", new Dictionary<int, string>
                    {
                        { 1, "air" },
                        { 2, "debuf" }
                    }
                },
                { "Zap", new Dictionary<int, string>
                    {
                        { 1, "air" },
                        { 2, "aoe dps" }
                    }
                },
                ///Monsters
                { "Leafbug", new Dictionary<int, string>
                    {
                        { 1, "ground, slow" },
                        { 2, "weak" }
                    }
                },
                { "Firebug", new Dictionary<int, string>
                    {
                        { 1, "ground, fast" },
                        { 2, "weak" }
                    }
                },
                { "FlyingLocust", new Dictionary<int, string>
                    {
                        { 1, "air, slow" },
                        { 2, "weak" }
                    }
                },
                { "Firewasp", new Dictionary<int, string>
                    {
                        { 1, "air, fast" },
                        { 2, "weak" }
                    }
                },
                { "MagmaCrab", new Dictionary<int, string>
                    {
                        { 1, "ground" },
                        { 2, "armored" }
                    }
                },
                { "Clampbeetle", new Dictionary<int, string>
                    {
                        { 1, "air" },
                        { 2, "armored" }
                    }
                },
                { "Scorpion", new Dictionary<int, string>
                    {
                        { 1, "ground" },
                        { 2, "superarmored" }
                    }
                },
                { "Voidbutterfly", new Dictionary<int, string>
                    {
                        { 1, "air" },
                        { 2, "superfast" }
                    }
                },
            };
        }
    }
}
