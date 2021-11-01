using Rafaeltab.Cryptopals.Set1.Common;

const string toScore = "1b37373331363f78151b7f2b783431333d78397828372d363c78373e783a393b3736";

var bestScore = Xor.FindBestScore(toScore);

Console.WriteLine($"{bestScore} {Xor.XorSingleChar(bestScore.Item1, toScore)}");