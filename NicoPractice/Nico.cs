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
            var letters = key.ToCharArray();
            var plaintext = message.ToCharArray();
            var container = new Dictionary<char, char>();
            for (var indexOfLetters = 0; indexOfLetters < letters.Length; indexOfLetters++)
            {
                container.Add(letters[indexOfLetters], plaintext[indexOfLetters]);
            }

            var encrypts = container.OrderBy(x => x.Key);
            
            return string.Join("", encrypts.Select(x => x.Value).ToArray()); 
        }
    }
}
