using System;
using System.Collections.Generic;
using System.Linq;

namespace AltexTravel.API.Mappers
{
    public static class TextManager
    {
        public static IEnumerable<char> CharArrayToTitleCase(this string s)
        {
            bool newWord = true;
            foreach (char c in s)
            {
                if (newWord) { yield return Char.ToUpper(c); newWord = false; }
                else yield return Char.ToLower(c);
                if (c == ' ') newWord = true;
            }
        }

        public static string StringToTitleCase(this string c)
        {
            return new string(c.CharArrayToTitleCase().ToArray());
        }
    }
}
