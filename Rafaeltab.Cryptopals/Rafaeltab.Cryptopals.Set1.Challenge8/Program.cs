using Rafaeltab.Cryptopals.Set1.Common;
using Rafaeltab.Cryptopals.Set1.Common.Scoring;
using System.Collections;
using System.Text;

var fileContent = File.ReadAllLines("8.txt");

var bestScore = int.MaxValue;
var bestString = "";

foreach (var line in fileContent)
{
    var lineBytes = Convert.FromHexString(line.Trim());

    var blockSize = 16;

    var distanceTotal = 0;
    var distanceCount = 0;

    for (int x = 0; x < lineBytes.Length/blockSize; x++)
    {
        for (int y = 0; y < lineBytes.Length / blockSize; y++)
        {
            if (x != y) {
            }

            distanceTotal += EditDistance(
                lineBytes.Skip(x * blockSize).Take(blockSize).ToArray(),
                lineBytes.Skip(y * blockSize).Take(blockSize).ToArray());

            distanceCount++;
        }
    }

    var avDistance = distanceTotal / distanceCount;
    if (avDistance < bestScore) {
        bestScore = avDistance;
        bestString = line;
    }

}

Console.WriteLine(bestString);
Console.WriteLine(bestScore);

int EditDistance(byte[] textA, byte[] textB)
{
    if (textA.Length != textB.Length) throw new ArgumentException("textA and textB have to be the same length");

    var textABits = new BitArray(textA);
    var textBBits = new BitArray(textB);

    int distance = 0;
    for (int c = 0; c < textABits.Length; c++)
    {
        if (textABits[c] != textBBits[c])
        {
            distance++;
        }
    }
    return distance;
}