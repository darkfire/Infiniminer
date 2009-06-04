using Microsoft.Xna.Framework.Graphics;

namespace Infiniminer
{
    public class Defines
    {
        public const string INFINIMINER_VERSION = "v1.5";
        public const int GROUND_LEVEL = 8;

        /*public const string deathByLava = "HAD AN UNFORTUNATE SMELTING ACCIDENT!";
        public const string deathByElec = "WAS LIT UP!";//"GOT TOO CLOSE TO THE POWER LINES!";
        public const string deathByExpl = "WAS KILLED BY AN EXPLOSION!";//SAW A BRIGHT FLASH";
        public const string deathByFall = "HAD A QUICK MEET WITH GRAVITY!";//SOLID GROUND!";
        public const string deathByMiss = "WAS KILLED BY MISADVENTURE!";
        public const string deathBySuic = "HAS COMMITED PIXELCIDE!";*/

        public const string deathByLava = "WAS INCINERATED BY LAVA!";
        public const string deathByElec = "WAS ELECTROCUTED!";
        public const string deathByExpl = "WAS KILLED IN AN EXPLOSION!";
        public const string deathByFall = "WAS KILLED BY GRAVITY!";
        public const string deathByMiss = "WAS KILLED BY MISADVENTURE!";
        public const string deathBySuic = "HAS COMMITED PIXELCIDE!";
        public static Color IM_BLUE = new Color(80, 150, 255);
        public static Color IM_RED = new Color(222, 24, 24);

        public static string Sanitize(string input)
        {
            string output = "";
            for (int i = 0; i < input.Length; i++)
            {
                char c = (char)input[i];
                if (c >= 32 && c <= 126)
                    output += c;
            }
            return output;
        }
    }
}