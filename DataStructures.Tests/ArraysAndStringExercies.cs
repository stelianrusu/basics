using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArraysAndStrings.Exercises;
using Xunit;

namespace Basics.AlgoTests
{
    public class ArraysAndStringExercises
    {
        [Fact]
        public void PhraseReverser()
        {
            PhraseReverser reverser = new PhraseReverser();
            var args = new string[] {"i"};

            var result = reverser.ReversePhrases(args.Skip(1).Take(args.Length - 1).ToArray());
            foreach (var output in result)
            {
                Console.WriteLine(output);
            }
        }

        [Fact]
        public void PermutateWord()
        {
            StringPermutator permutator = new StringPermutator();
            string word;
            word = String.Concat(word.OrderBy(c => c));
            List<string> permutations = permutator.GeneratePermutations("ABC");
            String.Join(" ", permutations);
        }
    }
}
