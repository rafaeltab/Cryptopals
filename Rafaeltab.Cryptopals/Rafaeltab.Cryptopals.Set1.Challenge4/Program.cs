using Rafaeltab.Cryptopals.Set1.Common;
using Rafaeltab.Cryptopals.Set1.Common.Scoring;

FindBestLine("4.txt");

void FindBestLine(string filePath, IScoringProvider? scoring = null) {
    if (!File.Exists(filePath)) throw new ArgumentException("File does not exist");
    var file = File.ReadAllText(filePath);

    var lowestScore = float.MaxValue;
    var lowestChar = 'a';
    var lowestLine = -1;

    var split = file.Split('\n');
    for (int line = 0; line < split.Length; line++)
    {
        var lineText = split[line];
        var score = Xor.FindBestScore(lineText, false, scoring);
        if (score.Item2 < lowestScore)
        {
            lowestScore = score.Item2;
            lowestChar = score.Item1;
            lowestLine = line;
        }
    }

    if (lowestLine == -1) {
        throw new Exception("No lines in file");
    }

    Console.WriteLine($"{lowestLine} {lowestChar} {lowestScore} {Xor.XorSingleChar(lowestChar, split[lowestLine])}");
}
