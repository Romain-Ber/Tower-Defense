using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defense
{
    public static class Lexicon
    {
        public static Dictionary<string, List<string>> lexiconContent;
        static Lexicon()
        {
            lexiconContent = new Dictionary<string, List<string>>();
            lexiconContent.Add("index", new List<string> {
                "                                                LEXICON",
                "",
                "" });

        }
    }
}
