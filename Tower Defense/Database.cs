using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defense
{
    public static class Database
    {
        public static Dictionary<string, Dictionary<int, string>> lexiconContent;

        public static Dictionary<string, Dictionary<string, int>> towerDictionary;
        public static Dictionary<string, Dictionary<string, float>> monsterDictionary;

        static Database()
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
                        { 0, ""},
                        { 1, "single" },
                        { 2, "physical" }
                    }
                },
                { "Ballista", new Dictionary<int, string>
                    {
                        { 0, "air" },
                        { 1, "single" },
                        { 2, "physical" }
                    }
                },
                { "Blade", new Dictionary<int, string>
                    {
                        { 0, "ground" },
                        { 1, "aoe" },
                        { 2, "physical/magical" }
                    }
                },
                { "Canon", new Dictionary<int, string>
                    {
                        { 0, "ground" },
                        { 1, "aoe" },
                        { 2, "physical" }
                    }
                },
                { "Catapult", new Dictionary<int, string>
                    {
                        { 0, "ground" },
                        { 1, "aoe" },
                        { 2, "magical" }
                    }
                },
                { "Nova", new Dictionary<int, string>
                    {
                        { 0, "all" },
                        { 1, "aoe" },
                        { 2, "magical" }
                    }
                },
                { "Slingshot", new Dictionary<int, string>
                    {
                        { 1, "all" },
                        { 2, "aoe" },
                        { 3, "magical" }
                    }
                },
                { "Zap", new Dictionary<int, string>
                    {
                        { 0, " " },
                        { 1, "single" },
                        { 2, "magical" }
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
            towerDictionary = new Dictionary<string, Dictionary<string, int>>
            {
                {"Arrow", new Dictionary<string, int>
                    {
                    {"ground", 0},
                    {"air", 1 },
                    {"aoe", 0 },
                    {"physical", 1 },
                    {"lightning", 0 },
                    {"slow", 0 },
                    {"range", 3 },
                    {"speed", 5 },
                    {"rotation", 1 }
                    }
                },
            };

            monsterDictionary = new Dictionary<string, Dictionary<string, float>>
            {
                {"Leafbug", new Dictionary<string, float>
                    {
                    {"monsterWidth", 64 },
                    {"monsterHeight", 64 },
                    {"frameMax", 8},
                    {"frameOffsetX", 0 },
                    {"frameOffsetY", 0 },
                    {"frameSpeed", 100 },
                    {"monsterSpeed", 0.40f },
                    {"maxHealth", 10 },
                    {"IsGround", 1 }
                    }
                },
                {"Firebug", new Dictionary<string, float>
                    {
                    {"monsterWidth", 64 },
                    {"monsterHeight", 64 },
                    {"frameMax", 8},
                    {"frameOffsetX", 32 },
                    {"frameOffsetY", 0 },
                    {"frameSpeed", 100 },
                    {"monsterSpeed", 1f },
                    {"maxHealth", 10 },
                    {"IsGround", 1 }
                    }
                },
                {"FlyingLocust", new Dictionary<string, float>
                    {
                    {"monsterWidth", 64 },
                    {"monsterHeight", 64 },
                    {"frameMax", 8},
                    {"frameOffsetX", 32 },
                    {"frameOffsetY", 0 },
                    {"frameSpeed", 80 },
                    {"monsterSpeed", 1f },
                    {"maxHealth", 10 },
                    {"IsGround", 0 }
                    }
                },
                {"Firewasp", new Dictionary<string, float>
                    {
                    {"monsterWidth", 64 },
                    {"monsterHeight", 64 },
                    {"frameMax", 8},
                    {"frameOffsetX", 16 },
                    {"frameOffsetY", 16 },
                    {"frameSpeed", 100 },
                    {"monsterSpeed", 2f },
                    {"maxHealth", 10 },
                    {"IsGround", 0 }
                    }
                },
                {"MagmaCrab", new Dictionary<string, float>
                    {
                    {"monsterWidth", 64 },
                    {"monsterHeight", 64 },
                    {"frameMax", 8},
                    {"frameOffsetX", 0 },
                    {"frameOffsetY", 0 },
                    {"frameSpeed", 100 },
                    {"monsterSpeed", 0.75f },
                    {"maxHealth", 10 },
                    {"IsGround", 1 }
                    }
                },
                {"Clampbeetle", new Dictionary<string, float>
                    {
                    {"monsterWidth", 64 },
                    {"monsterHeight", 64 },
                    {"frameMax", 8},
                    {"frameOffsetX", 0 },
                    {"frameOffsetY", 0 },
                    {"frameSpeed", 80 },
                    {"monsterSpeed", 0.75f },
                    {"maxHealth", 10 },
                    {"IsGround", 0 }
                    }
                },
                {"Scorpion", new Dictionary<string, float>
                    {
                    {"monsterWidth", 64 },
                    {"monsterHeight", 64 },
                    {"frameMax", 8},
                    {"frameOffsetX", 0 },
                    {"frameOffsetY", 0 },
                    {"frameSpeed", 100 },
                    {"monsterSpeed", 0.75f },
                    {"maxHealth", 10 },
                    {"IsGround", 1 }
                    }
                },
                {"Voidbutterfly", new Dictionary<string, float>
                    {
                    {"monsterWidth", 64 },
                    {"monsterHeight", 64 },
                    {"frameMax", 4},
                    {"frameOffsetX", 0 },
                    {"frameOffsetY", 0 },
                    {"frameSpeed", 100 },
                    {"monsterSpeed", 2f },
                    {"maxHealth", 10 },
                    {"IsGround", 0 }
                    }
                }
            };
        }
    }
}
