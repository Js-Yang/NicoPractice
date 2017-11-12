using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoPractice
{
    public class Kata
    {
        public static string Nico(string keys, string plainText)
        {
            var plainTexts = SplitByLength(plainText, keys.Length);

            return plainTexts.Aggregate(string.Empty, (current, text) => current + Encrypts(keys, text));
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

        private static IEnumerable<string> SplitByLength(string plainText, int chunkSize, char padChar = ' ')
        {
            if (plainText.Length % chunkSize != 0)
            {
                var length = (plainText.Length % chunkSize + 1) * plainText.Length;
                plainText = plainText.PadRight(length, padChar);
            }
            return Enumerable.Range(0, plainText.Length / chunkSize).Select(i => plainText.Substring(i * chunkSize, chunkSize));
        }
    }
}
