using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defense
{
    public class Levels
    {
        public static Dictionary<int, List<string>> level;
        public Levels()
        {
            level = new Dictionary<int, List<string>>();
            level.Add(0, new List<string> { "Leafbug",
                                            "Leafbug",
                                            "Leafbug",
                                            "Leafbug",
                                            "Leafbug",
                                            "Leafbug",
                                            "Leafbug",
                                            "Leafbug",
                                            "Leafbug",
                                            "Leafbug" });
            level.Add(1, new List<string> { "Leafbug",
                                            "Leafbug",
                                            "Leafbug",
                                            "Leafbug",
                                            "Leafbug",
                                            "Leafbug",
                                            "Leafbug",
                                            "Leafbug",
                                            "Leafbug",
                                            "Leafbug" });
        }
    }
}