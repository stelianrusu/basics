using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings.Exercises
{
    public class PhraseReverser
    {
        public string[] ReversePhrases(string[] phrases)
        {
            string[] result = new string[phrases.Length];
            for (var i = 0; i < phrases.Length; i++)
            {
                result[i] = ReversePhrase(phrases[i]);
            }

            return result;

        }

        private string ReversePhrase(string phrase)
        {
            var words = phrase.Split('.');
            string[] reversedWords = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                reversedWords[words.Length - i - 1] = words[i];
            }

            return string.Join(".", reversedWords);
        }
    }
}
