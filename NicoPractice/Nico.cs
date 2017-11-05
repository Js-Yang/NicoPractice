using System.Collections.Generic;
using System.Linq;

namespace NicoPractice
{
    public class Nico
    {
        public string NicoVariation(string letters, string message)
        {
            var keys = letters.ToCharArray();
            var content = message.ToCharArray();
            var container = GetContainer(keys, content);

            return GetCyphertext(keys, content, container.OrderBy(x => x.Key));
        }

        private static string GetCyphertext(char[] keys, char[] content, IOrderedEnumerable<KeyValuePair<char, List<char>>> encryptsContainer)
        {
            var result = string.Empty;
            var columnCount = keys.Length;
            var rowCount = (content.Length / keys.Length);
            for (var indexOfRow = 0; indexOfRow < rowCount; indexOfRow++)
            {
                for (var indexOfColumn = 0; indexOfColumn < columnCount; indexOfColumn++)
                {
                    result = string.Concat(result, encryptsContainer.ElementAt(indexOfColumn).Value[indexOfRow]);
                }
            }
            return result;
        }

        private static Dictionary<char, List<char>> GetContainer(char[] keys, char[] content)
        {
            var container = new Dictionary<char, List<char>>();
            var indexOfLetters = 0;
            foreach (var value in content)
            {
                var key = keys[indexOfLetters++];
                if (container.ContainsKey(key))
                {
                    container[key].Add(value);
                }
                else
                {
                    container.Add(key, new List<char>() { value });
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
