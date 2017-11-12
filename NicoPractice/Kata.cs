using System.Collections.Generic;
using System.Linq;

namespace NicoPractice
{
    public class Kata
    {
        private const char DefaultAlphabet = ' ';

        public static string Nico(string keys, string plainText)
        {
            var cyphertextArray = GetCyphertext(keys, plainText);
            return GetCyphertext(cyphertextArray);
        }

        private static IOrderedEnumerable<KeyValuePair<char, List<char>>> GetCyphertext(string keys, string plainText)
        {
            var container = new Dictionary<char, List<char>>();
            var indexOfKeys = 0;
            foreach (var alphabet in plainText.ToCharArray())
            {
                UpdateContainer(container, keys[indexOfKeys++], alphabet);
                
                indexOfKeys = ResetIndexIfOverLength(keys.Length, indexOfKeys);
            }
            return container.OrderBy(x => x.Key);
        }

        private static int ResetIndexIfOverLength(int keysLength, int index)
        {
            if (index == keysLength)
            {
                index = 0;
            }
            return index;
        }

        private static void UpdateContainer(Dictionary<char, List<char>> container, char key, char alphabet)
        {
            if (container.ContainsKey(key))
            {
                container[key].Add(alphabet);
            }
            else
            {
                container.Add(key, new List<char>() {alphabet});
            }
        }

        private static string GetCyphertext(IOrderedEnumerable<KeyValuePair<char, List<char>>> cyphertextArray)
        {
            var cyphertext = string.Empty;
            var colCount = cyphertextArray.Count();
            var rowsCount = cyphertextArray.Sum(keyValuePair => keyValuePair.Value.Count);
            var dataRow = GetDataRows(colCount, rowsCount);

            for (var indexOfRow = 0; indexOfRow < dataRow; indexOfRow++)
            {
                for (var indexOfCol = 0; indexOfCol < colCount; indexOfCol++)
                {
                    cyphertext = string.Concat(cyphertext, GetAlphabetBy(cyphertextArray, indexOfCol, indexOfRow));
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

        private static int GetDataRows(int colCount, int rowsCount)
        {
            return (rowsCount % colCount) == 0
                ? (rowsCount / colCount)
                : (rowsCount / colCount) + 1;
        }
    }
}
