using Rafaeltab.Cryptopals.Set1.Common.Scoring;
using System.Text;

namespace Rafaeltab.Cryptopals.Set1.Common
{
    public class Xor
    {

        /// <summary>
        /// Xor a hex string to a single char and put the result in a string
        /// </summary>
        public static string XorSingleChar(char c, string xor)
        {
            var xorBytes = Convert.FromHexString(xor);

            var resBytes = new byte[xorBytes.Length];
            string res = "";


            for (int i = 0; i < xorBytes.Length; i++)
            {
                res += (char)(c ^ xorBytes[i]);
            }

            return res;
        }

        /// <summary>
        /// Use the scoring function and xor to find the character that is most english like
        /// <param name="fulLRange">If set to true it will use the full range of '/u0000' to '/uffff'. Otherwise it will go from ' '-'z'</param>
        /// <param name="scoring">The scoring provider to use, by default it uses EnglishScoringProvider</param>
        /// </summary>
        public static Tuple<char, float> FindBestScore(string toDecrypt, bool fullRange = false, IScoringProvider? scoring = null)
        {
            IScoringProvider scoringProvider;

            if (scoring == null)
            {
                scoringProvider = new EnglishScoringProvider();
            }
            else
            {
                scoringProvider = scoring;
            }

            char? minC = null;
            float minScore = float.MaxValue;

            var start = ' ';
            var end = 'z';

            if (fullRange)
            {
                start = '\u0000';
                end = '\uffff';
            }

            for (char c = start; c <= end; c++)
            {
                var xored = XorSingleChar(c, toDecrypt);
                var score = scoringProvider.score(xored);

                if (minScore > score)
                {
                    minC = c;
                    minScore = score;
                }
            }
            if (minC == null || minC.HasValue == false)
            {
                throw new Exception("String was empty");
            }

            return Tuple.Create(minC.Value, minScore);
        }

        /// <summary>
        /// Calculates the repeating XOR
        /// </summary>
        /// <param name="key">The key to use for the repeating XOR</param>
        /// <param name="data">The data to encrypt in utf8 format</param>
        /// <returns>Encrypted data</returns>
        public static string RepeatingXor(string key, string data) {
            var dataBytes = Encoding.UTF8.GetBytes(data);
            var res = new byte[dataBytes.Length];

            for (int b = 0; b < dataBytes.Length; b++)
            {
                char c = key[b % key.Length];
                res[b] = (byte)(c ^ dataBytes[b]);
            }

            return Convert.ToHexString(res);
        }

        /// <summary>
        /// Calculates the repeating XOR
        /// </summary>
        /// <param name="key">The key to use for the repeating XOR</param>
        /// <param name="data">The data to encrypt in byte format</param>
        /// <returns>Encrypted data</returns>
        public static string RepeatingXor(string key, byte[] data)
        {
            var res = new char[data.Length];

            for (int b = 0; b < data.Length; b++)
            {
                char c = key[b % key.Length];
                res[b] = (char)(c ^ data[b]);
            }

            return new string(res);
        }
    }
}
