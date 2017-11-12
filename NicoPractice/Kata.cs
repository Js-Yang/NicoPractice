﻿using System.Collections.Generic;
using System.Linq;

namespace Solution
{
    public class Kata
    {
        public static string Nico(string keys, string plainText)
        {
            var chunkOfPlainText = SplitTextByChunkSize(plainText, keys.Length);

            return chunkOfPlainText.Aggregate(string.Empty, (current, text) => current + Encrypts(keys, text));
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

        private static IEnumerable<string> SplitTextByChunkSize(string text, int chunkSize)
        {
            text = PadRightByBlank(text, chunkSize);

            return Enumerable.Range(0, text.Length / chunkSize).Select(i => text.Substring(i * chunkSize, chunkSize));
        }

        private static string PadRightByBlank(string text, int chunkSize)
        {
            return text.Length % chunkSize == 0 ? text : text.PadRight((text.Length / chunkSize + 1) * chunkSize, ' ');
        }
    }
}
