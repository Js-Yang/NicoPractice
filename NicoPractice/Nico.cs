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
            char[] letters = key.ToCharArray();
            var container = new Dictionary<char, char>();
            for (var indexOfLetters = 0; indexOfLetters < letters.Length; indexOfLetters++)
            {
                container.Add(letters[indexOfLetters], message.ToCharArray()[indexOfLetters]);
            }

            var encryptsContainer = container.OrderBy(x => x.Key);
            return string.Join("", encryptsContainer.Select(x => x.Value).ToArray());
        }
    }
}
