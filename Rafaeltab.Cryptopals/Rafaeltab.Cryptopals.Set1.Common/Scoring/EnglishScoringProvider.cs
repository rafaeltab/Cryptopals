namespace Rafaeltab.Cryptopals.Set1.Common.Scoring
{
    public class EnglishScoringProvider : IScoringProvider
    {
        /// <summary>
        /// Scores a string from best to worst based on how clsoe to english it seems to be. 
        /// </summary>
        /// <param name="toScore">The string to score</param>
        /// <returns>Score, the higher the result the worse the string is.</returns>
        public float score(string toScore)
        {
            //make the string lowercase so it can be compared to the scoring table
            toScore = toScore.ToLower();
            //create a dictionary with the average frequency of each character in english (gotton from https://www3.nd.edu/~busiforc/handouts/cryptography/letterfrequencies.html)
            Dictionary<char, float> scoringtable = new Dictionary<char, float>(){
                {' ', 20f},
                {'e', 11.1607f},
                {'a', 8.4966f},
                {'r', 7.5809f},
                {'i', 7.5448f},
                {'o', 7.1635f},
                {'t', 6.9509f},
                {'n', 6.6544f},
                {'s', 5.7351f},
                {'l', 5.4893f},
                {'c', 4.5388f},
                {'u', 3.6308f},
                {'d', 3.3844f},
                {'p', 3.1671f},
                {'m', 3.0129f},
                {'h', 3.0034f},
                {'g', 2.4705f},
                {'b', 2.0720f},
                {'f', 1.8121f},
                {'y', 1.7779f},
                {'w', 1.2899f},
                {'k', 1.1016f},
                {'v', 1.0074f},
                {'x', 0.2902f},
                {'z', 0.2722f},
                {'j', 0.1965f},
                {'q', 0.1962f}
            };

            //create a dictionary that will contain the count of each character in the toScore string
            Dictionary<char, int> countChars = new Dictionary<char, int>();
            //set the score to 0
            float score = 0.0f;
            //loop over each character in the toScore string
            foreach (var c in toScore)
            {
                //if the character is not in the scoring table add 10 as a default. This was arbitrarily chosen
                if (scoringtable.ContainsKey(c))
                {
                    //increase the char count
                    if (!countChars.ContainsKey(c))
                    {
                        countChars[c] = 0;
                    }

                    countChars[c]++;
                }
                else
                {
                    score += 30;
                }
            }

            //compare the 2 dictionaries
            foreach (var c in scoringtable)
            {
                if (countChars.ContainsKey(c.Key))
                {
                    score += Math.Abs(c.Value - (countChars[c.Key] / toScore.Length));
                }
                else
                {
                    score += c.Value;
                }
            }

            return score/toScore.Length;
        }
    }
}
