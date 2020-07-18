using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings.Exercises
{
	public class StringPermutator
    {
        public List<string> GeneratePermutations(string word)
        {
            List<string> permutations = new List<string>();
            Permutate(word, "", permutations);
            return permutations;

        }

        private void Permutate(string remainder, string fixedPart, List<string> permutations)
        {
            if (remainder == "")
            {
                permutations.Add(fixedPart);
                return;
            }
            for (int i = 0; i < remainder.Length; i++)
            {
                string newFixedPart = fixedPart + remainder[i];
                string newRemainder = remainder.Substring(0, i) + remainder.Substring(i + 1);
                Permutate(newRemainder, newFixedPart, permutations);
            }
        }
    }
}
