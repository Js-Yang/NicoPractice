using System.Collections.Generic;
using System.Linq;

namespace NicoPractice
{
    public class Nico
    {
        private const char DefaultAlphabet = ' ';

        public string NicoVariation(string letters, string message)
        {
            var keys = letters.ToCharArray();
            var alphabets = message.ToCharArray();
            var container = GetRelationShip(keys, alphabets);
            return GetCyphertext(keys, alphabets, container.OrderBy(x => x.Key));
        }

        private static string GetCyphertext(char[] keys, char[] content, IOrderedEnumerable<KeyValuePair<char, List<char>>> encryptsContainer)
        {
            var cyphertext = string.Empty;
            var columnCount = keys.Length;
            var rowCount = GetRowsCount(keys, content);

            for (var indexOfRow = 0; indexOfRow < rowCount; indexOfRow++)
            {
                for (var indexOfColumn = 0; indexOfColumn < columnCount; indexOfColumn++)
                {
                    cyphertext = string.Concat(cyphertext, GetAlphabet(encryptsContainer, indexOfColumn, indexOfRow));
                }
            }
            return cyphertext;
        }

        private static char GetAlphabet(IOrderedEnumerable<KeyValuePair<char, List<char>>> encryptsContainer, int indexOfColumn, int indexOfRow)
        {
            var alphabet = DefaultAlphabet;
            if (encryptsContainer.ElementAt(indexOfColumn).Value.Count > indexOfRow)
            {
                alphabet = encryptsContainer.ElementAt(indexOfColumn).Value[indexOfRow];
            }
            return alphabet;
        }

        private static int GetRowsCount(char[] keys, char[] content)
        {
            return (content.Length % keys.Length) == 0
                ? (content.Length / keys.Length)
                : (content.Length / keys.Length) + 1;
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
