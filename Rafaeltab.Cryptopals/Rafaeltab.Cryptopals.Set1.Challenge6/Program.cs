using Rafaeltab.Cryptopals.Set1.Common;
using System.Collections;

byte[] text = Convert.FromBase64String(File.ReadAllText("6.txt"));

var keysizes = FindKeySize(text);
var bestResKey = Crack(text, keysizes);

var bestRes = Xor.RepeatingXor(bestResKey, text);

Console.WriteLine(bestRes);
//Console.WriteLine($"{secondBestResKey}: {secondBestRes}");
//Console.WriteLine($"{thirdBestResKey}: {thirdBestRes}");

Console.WriteLine($"{bestResKey}");

// 2.
/// <summary>
/// Calculate the bit hamming distance. Meaning the amount of BITS that differ.
/// </summary>
int EditDistance(byte[] textA, byte[] textB) {
    if (textA.Length != textB.Length) throw new ArgumentException("textA and textB have to be the same length");

    var textABits = new BitArray(textA);
    var textBBits = new BitArray(textB);

    int distance = 0;
    for (int c = 0; c < textABits.Length; c++)
    {
        if (textABits[c] != textBBits[c]) {
            distance++;
        }
    }
    return distance;
}

// 4.
int FindKeySize(byte[] text) {
    int bestKeySize = -1;

    float bestKeyDistance = float.MaxValue;

    // 1.
    for (int keysize = 2; keysize < 40; keysize++)
    {
        var parts = new List<byte[]>();

        // I tried it with just 4 keysize blocks and also with the top 3 sizes, these are not adequate and give 5, 3 and 2 as sizes which are all incorrect.
        // I found the minimum amount of blocks to use is 9, in other texts this will probably differ, for this text it also works with a 1000 in a reasonable timeframe in the order of mere seconds
        for (int i = 0; i < Math.Min(text.Length / keysize, 9); i++)
        {
            parts.Add(text.Skip(i*keysize).Take(keysize).ToArray());
        }

        var distances = new List<int>();

        for (int i = 0; i < parts.Count; i++) {
            for (int j = 0; j < parts.Count; j++)
            {
                if (i == j) continue;

                distances.Add(EditDistance(parts[i], parts[j]));
            }
        }

        var average = 0;
        for (int d = 0; d < distances.Count; d++)
        {
            average += distances[d];
        }
        average /= distances.Count;
        

        // 3.
        var distance = average/keysize;

        if (bestKeyDistance > distance)
        {
            bestKeyDistance = distance;

            bestKeySize = keysize;
        }
    }

    return bestKeySize;
}

// 5 and 6
/// <summary>
/// Find the key for a text with a specific keysize
/// </summary>
string Crack(byte[] text, int keysize) {
    byte[][] blocks = new byte[keysize][];
    for (int i = 0; i < keysize; i++)
    {
        var chars = new List<byte>();
        for (int j = i; j < text.Length; j += keysize) {
            chars.Add(text[j]);
        }
        blocks[i] = chars.ToArray();
    }

    var key = new char[keysize];
    for (int i = 0; i < keysize; i++)
    {
        //convert to hex
        var toScore = Convert.ToHexString(blocks[i]);
        // Here a full range parameter can be used, this will loop over all utf8 characters instead of just the characters between ' ' and 'z'
        var bestScore = Xor.FindBestScore(toScore);

        key[i] = bestScore.Item1;
    }

    return new string(key);
}