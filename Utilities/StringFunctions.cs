using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
    public static class StringFunctions
    {
        static readonly char[] superthinChars = new char[] { 'f', 'i', 'j', 'l', 'r', 't', '!', '(', ')', '-', '*', '^', '/', '\\', '|', '{', '}', '[', ']', ';', ':', '\'', '"', ',', '.', '/', '?', '`', '~', ' ', '\n' };
        static readonly char[] thinChars = new char[] { 'a', 'c', 'd', 'e', 'n', 'o', 's', 'u', 'v', 'x', 'y', 'z', 'b', 'g', 'h', 'k', 'p', 'q', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        static readonly char[] medChars = new char[] {
                'm','w',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'N', 'O', 'P', 'R', 'S', 'T', 'U', 'V', 'Y',
                '$', '%', '&', '=', '_', '+', '<', '>'};
        static readonly char[] largeChars = new char[] { 'M', '@', '#', 'Q', 'W', 'X', 'Z' };

        public static string ScrambleString(string text, int length)
        {
            var numIndicesSuperThin = superthinChars.Length - 1;
            var numIndicesThin = thinChars.Length - 1;
            var numIndicesMed = medChars.Length - 1;
            var numIndicesLarge = largeChars.Length - 1;

            var scrambledString = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                if (superthinChars.Contains(text[i]))
                {
                    scrambledString.Append(superthinChars[random.Next(0, numIndicesSuperThin)]);
                }
                else if (thinChars.Contains(text[i]))
                {
                    scrambledString.Append(thinChars[random.Next(0, numIndicesThin)]);
                }
                else if (medChars.Contains(text[i]))
                {
                    scrambledString.Append(medChars[random.Next(0, numIndicesMed)]);
                }
                else if (largeChars.Contains(text[i]))
                {
                    scrambledString.Append(largeChars[random.Next(0, numIndicesLarge)]);
                }
                else
                {
                    Console.WriteLine($"I missed a character {text[i]}");
                }
            }

            return scrambledString.ToString();
        }

        public static string RemoveFromString(string input, string remove)
        {
            return input.Replace(remove, string.Empty);
        }

    }
}
