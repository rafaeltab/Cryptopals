
namespace Rafaeltab.Cryptopals.Set1.Common.Scoring
{
    public interface IScoringProvider
    {
        /// <summary>
        /// Scores a string from best to worst. 
        /// </summary>
        /// <param name="toScore">The string to score</param>
        /// <returns>Score, the higher the result the worse the string is.</returns>
        float score(string toScore);
    }
}
