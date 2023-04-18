using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defense
{
    public static class Levels
    {
        public static Dictionary<int, List<string>> levelContent;
        static Levels()
        {
            levelContent = new Dictionary<int, List<string>>();

            levelContent.Add(0, new List<string> {  "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug", });

            levelContent.Add(1, new List<string> {  "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug" });

            levelContent.Add(2, new List<string> {  "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug" });

            levelContent.Add(3, new List<string> {  "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug" });

            levelContent.Add(4, new List<string> {  "Firebug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Firebug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Firebug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Firebug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug",
                                                    "Leafbug" });
        }
    }
}