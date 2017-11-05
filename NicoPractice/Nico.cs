using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoPractice
{
    public class Nico
    {
        public string NicoVariation(string key, string message)
        {
            var encrypts = GetEncodeString(key.ToCharArray(), message.ToCharArray());

            return string.Join("", encrypts.Select(x => x.Value).ToArray()); 
        }

        private IOrderedEnumerable<KeyValuePair<char, char>> GetEncodeString(char[] letters, char[] plaintext)
        {
            var container = new Dictionary<char, char>();
            for (var indexOfLetters = 0; indexOfLetters < letters.Length; indexOfLetters++)
            {
                container.Add(letters[indexOfLetters], plaintext[indexOfLetters]);
            }

            return container.OrderBy(x => x.Key);
        }
    }
}
