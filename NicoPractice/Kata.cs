using System;
using System.Collections.Generic;
using System.Linq;

public class Kata
{
    public static string Nico(string keys, string message)
    {
        var paragraphs = GetParagraphsBy(message, keys.Length);

        return paragraphs.Aggregate(string.Empty, (cipherText, paragraph) => cipherText + Encrypts(keys, paragraph));
    }

    private static string Encrypts(string keys, string message)
    {
        var index = 0;
        return GetCipherText(keys.ToDictionary(key => key, key => message[index++]));
    }

    private static IEnumerable<string> GetParagraphsBy(string text, int chunkSize)
    {
        var textLengthNeeded = (int)(Math.Ceiling((double)text.Length / chunkSize) * chunkSize);

        text = text.PadRight(textLengthNeeded, ' ');

        return Enumerable.Range(0, text.Length / chunkSize).Select(i => text.Substring(i * chunkSize, chunkSize));
    }

    private static string GetCipherText(Dictionary<char, char> keysMessage)
    {
        return string.Concat(keysMessage.OrderBy(x => x.Key).Select(x => x.Value).ToArray());
    }
}
