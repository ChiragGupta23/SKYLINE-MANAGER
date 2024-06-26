using System.Text;
using System;

namespace Skyline_Manager.Util
{
    public static class Utilities
    {

        public static string RandomString(int size, bool lowerCase = true)
        {
            Random rnd = new Random();
            var builder = new StringBuilder(size);
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26

            for (var i = 0; i < size; i++)
            {
                var @char = (char)rnd.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
    }
}