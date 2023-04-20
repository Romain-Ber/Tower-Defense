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
                { "Summary", new Dictionary<int, string> 
                    { 
                        { 1, "cc" },
                        { 2, "cc" }
                    }
                },
                //Towers
                { "Arrow", new Dictionary<int, string>
                    {
                        { 1, "cc" },
                        { 2, "cc" }
                    }
                },
                { "Ballista", new Dictionary<int, string>
                    {
                        { 1, "cc" },
                        { 2, "cc" }
                    }
                },
                { "Blade", new Dictionary<int, string>
                    {
                        { 1, "cc" },
                        { 2, "cc" }
                    }
                },
                { "Canon", new Dictionary<int, string>
                    {
                        { 1, "cc" },
                        { 2, "cc" }
                    }
                },
                { "Catapult", new Dictionary<int, string>
                    {
                        { 1, "cc" },
                        { 2, "cc" }
                    }
                },
                { "Nova", new Dictionary<int, string>
                    {
                        { 1, "cc" },
                        { 2, "cc" }
                    }
                },
                { "Poison", new Dictionary<int, string>
                    {
                        { 1, "cc" },
                        { 2, "cc" }
                    }
                },
                { "Zap", new Dictionary<int, string>
                    {
                        { 1, "cc" },
                        { 2, "cc" }
                    }
                },
                ///Monsters
                { "Clampbeetle", new Dictionary<int, string>
                    {
                        { 1, "cc" },
                        { 2, "cc" }
                    }
                },
                { "Firebug", new Dictionary<int, string>
                    {
                        { 1, "cc" },
                        { 2, "cc" }
                    }
                },
                { "Firewasp", new Dictionary<int, string>
                    {
                        { 1, "cc" },
                        { 2, "cc" }
                    }
                },
                { "FlyingLocust", new Dictionary<int, string>
                    {
                        { 1, "cc" },
                        { 2, "cc" }
                    }
                },
                { "Leafbug", new Dictionary<int, string>
                    {
                        { 1, "cc" },
                        { 2, "cc" }
                    }
                },
                { "MagmaCrab", new Dictionary<int, string>
                    {
                        { 1, "cc" },
                        { 2, "cc" }
                    }
                },
                { "Scorpion", new Dictionary<int, string>
                    {
                        { 1, "cc" },
                        { 2, "cc" }
                    }
                },
                { "Voidbutterfly", new Dictionary<int, string>
                    {
                        { 1, "cc" },
                        { 2, "cc" }
                    }
                },
            };
        }
    }
}
