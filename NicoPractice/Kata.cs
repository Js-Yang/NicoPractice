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
            var encrypts = new Dictionary<char, char>();
            for (var indexOfKeys = 0; indexOfKeys < keys.Length; indexOfKeys++)
            {
                encrypts.Add(keys[indexOfKeys], plainText[indexOfKeys]);
            }

            return string.Join("", encrypts.OrderBy(x => x.Key).Select(x => x.Value).ToArray());
        }
    }
}
