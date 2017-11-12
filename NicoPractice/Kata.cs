using System.Collections.Generic;
using System.Linq;

namespace NicoPractice
{
    public class Kata
    {
        private const char DefaultAlphabet = ' ';

        public static string Nico(string letters, string message)
        {
            var keys = letters.ToCharArray();
            var alphabets = message.ToCharArray();
            var combination = GetRelationShip(keys, alphabets);
            return GetCyphertext(combination.OrderBy(x => x.Key));
        }

        private static string GetCyphertext(IOrderedEnumerable<KeyValuePair<char, List<char>>> encryptsContainer)
        {
            var cyphertext = string.Empty;
            var keysCount = encryptsContainer.Count();
            var alphabetCount = encryptsContainer.Sum(keyValuePair => keyValuePair.Value.Count);
            var dataHeight = GetDataHeight(keysCount, alphabetCount);

            for (var indexOfHeight = 0; indexOfHeight < dataHeight; indexOfHeight++)
            {
                for (var indexOfKey = 0; indexOfKey < keysCount; indexOfKey++)
                {
                    cyphertext = string.Concat(cyphertext, GetAlphabetBy(encryptsContainer, indexOfKey, indexOfHeight));
                }
            }
            return cyphertext;
        }

        private static char GetAlphabetBy(IOrderedEnumerable<KeyValuePair<char, List<char>>> encryptsContainer, int indexOfKey, int indexOfHeight)
        {
            var alphabet = DefaultAlphabet;
            if (encryptsContainer.ElementAt(indexOfKey).Value.Count > indexOfHeight)
            {
                alphabet = encryptsContainer.ElementAt(indexOfKey).Value[indexOfHeight];
            }
            return alphabet;
        }

        private static int GetDataHeight(int keysLength, int rowsCount)
        {
            return (rowsCount % keysLength) == 0
                ? (rowsCount / keysLength)
                : (rowsCount / keysLength) + 1;
        }

        private static Dictionary<char, List<char>> GetRelationShip(char[] keys, char[] content)
        {
            var container = new Dictionary<char, List<char>>();
            var indexOfLetters = 0;
            foreach (var alphabet in content)
            {
                var key = keys[indexOfLetters++];
                if (container.ContainsKey(key))
                {
                    container[key].Add(alphabet);
                }
                else
                {
                    container.Add(key, new List<char>() { alphabet });
                }
                
                if (indexOfLetters == keys.Length)
                {
                    indexOfLetters = 0;
                }
            }
            return container;
        }
    }
}
