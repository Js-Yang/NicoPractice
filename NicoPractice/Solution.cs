﻿using System.Collections.Generic;
using System.Linq;

namespace NicoPractice
{
    public class Solution
    {
        public static string Nico(string keys, string plainText)
        {
            var plainTextGroup = SplitTextByLength(plainText, keys.Length);

            return plainTextGroup.Aggregate(string.Empty, (current, text) => current + Encrypts(keys, text));
        }

        private static string Encrypts(string keys, string plainText)
        {
            var encrypts = new Dictionary<char, char>();

            for (var index = 0; index < keys.Length; index++)
            {
                encrypts.Add(keys[index], plainText[index]);
            }

            return string.Join("", encrypts.OrderBy(x => x.Key).Select(x => x.Value).ToArray());
        }

        private static IEnumerable<string> SplitTextByLength(string text, int chunkSize)
        {
            text = PadRightByBlank(text, chunkSize, text.Length / chunkSize);

            return Enumerable.Range(0, text.Length / chunkSize).Select(i => text.Substring(i * chunkSize, chunkSize));
        }

        private static string PadRightByBlank(string text, int chunkSize, int rows)
        {
            if (text.Length % chunkSize == 0)
            {
                return text;
            }

            var lengthNeeded = (rows + 1) * chunkSize;
            return text.PadRight(lengthNeeded, ' ');
        }
    }
}
