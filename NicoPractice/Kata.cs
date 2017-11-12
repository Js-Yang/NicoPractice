using System;
using System.Linq;

public class Kata
{
    public static string Nico(string keys, string message)
    {
        var sizeOfParagraph = (int)Math.Ceiling((double)message.Length / keys.Length);
        var plainText = message.PadRight((sizeOfParagraph * keys.Length), ' ');
        return Enumerable.Range(0, sizeOfParagraph).Select(size => plainText.Substring(size * keys.Length, keys.Length)).Aggregate(string.Empty, (cipherText, paragraph) =>
        {
            var index = 0;
            return cipherText + string.Concat(keys.ToDictionary(key => key, key => paragraph[index++]).OrderBy(x => x.Key).Select(x => x.Value).ToArray());
        });
    }
}