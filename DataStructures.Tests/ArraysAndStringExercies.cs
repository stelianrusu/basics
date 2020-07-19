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
            List<string> permutations = permutator.GeneratePermutations("ABC");
            String.Join(" ", permutations);
        }

        [Fact]
        public void Palyndrome()
        {
            LongestPalindrome longestPalindrome = new LongestPalindrome();
            string result = longestPalindrome.Find("qrrc");
        }

        [Fact]
        public void DuplicatesWithRecursion_OnlyDups()
        {
            DuplicatesWithRecursion recursion = new DuplicatesWithRecursion();
            string res = recursion.Dedup("ississippi");
            Assert.Equal("",res);
        }

        [Fact]
        public void DuplicatesWithRecursion_ThreeCharDups()
        {
            DuplicatesWithRecursion recursion = new DuplicatesWithRecursion();
            string res = recursion.Dedup("mxxxy");
            Assert.Equal("my", res);
        }

        [Fact]
        public void DuplicatesWithRecursion_OneChar()
        {
            DuplicatesWithRecursion recursion = new DuplicatesWithRecursion();
            string res = recursion.Dedup("m");
            Assert.Equal("m", res);
        }

        [Fact]
        public void DuplicatesWithRecursion_ThreeSetsChar()
        {
            DuplicatesWithRecursion recursion = new DuplicatesWithRecursion();
            string res = recursion.Dedup("mississipie");
            Assert.Equal("mpie", res);
        }

        [Fact]
        public void IsRotationOfTwo()
        {
            IsRotationOfTwo isRotation = new IsRotationOfTwo();
            bool result = isRotation.isRotation("amazon", "azonam");
            Assert.True(result);
        }

        [Fact]
        public void IsRotationOfTwo_ThreeLetters()
        {
            IsRotationOfTwo isRotation = new IsRotationOfTwo();
            bool result = isRotation.isRotation("abc", "cab");
            Assert.True(result);
            result = isRotation.isRotation("abc", "bca");
            Assert.True(result);
        }


        [Fact]
        public void IsRotationOfTwo_Not()
        {
            IsRotationOfTwo isRotation = new IsRotationOfTwo();
            bool result = isRotation.isRotation("geeksforgeeks", "geeksgeeksfor");
            Assert.False(result);
        }

        public List<string> ReadInput()
        {
            int phraseCnt = int.Parse(Console.ReadLine());
            List<string> inputList = new List<string>();
            for (int i = 0; i < phraseCnt; i++)
            {
                inputList.Add(Console.ReadLine());
            }

            return inputList;
        }
    }
}
