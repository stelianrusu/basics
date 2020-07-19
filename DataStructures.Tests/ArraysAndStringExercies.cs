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

        [Fact]
        public void RomanNumberConvertor()
        {
            RomanNumberConvertor conv = new RomanNumberConvertor();
            Assert.Equal(1, conv.ConvertToInt("I"));
            Assert.Equal(2, conv.ConvertToInt("II"));
            Assert.Equal(3, conv.ConvertToInt("III"));
            Assert.Equal(4, conv.ConvertToInt("IV"));
            Assert.Equal(5, conv.ConvertToInt("V"));
            Assert.Equal(6, conv.ConvertToInt("VI"));
            Assert.Equal(7, conv.ConvertToInt("VII"));
            Assert.Equal(8, conv.ConvertToInt("VIII"));
            Assert.Equal(9, conv.ConvertToInt("IX"));
            Assert.Equal(10, conv.ConvertToInt("X"));
            Assert.Equal(11, conv.ConvertToInt("XI"));
            Assert.Equal(11, conv.ConvertToInt("XI"));
            Assert.Equal(14, conv.ConvertToInt("XIV"));
            Assert.Equal(16, conv.ConvertToInt("XVI"));
            Assert.Equal(19, conv.ConvertToInt("XIX"));
            Assert.Equal(21, conv.ConvertToInt("XXI"));
        }

        [Fact]
        public void IsAnagram()
        {
            IsAnagram angrm = new IsAnagram();

            Assert.True(angrm.Check("geeksforgeeks", "forgeeksgeeks"));
            Assert.False(angrm.Check("allergy", "allergic"));
        }

        [Fact]
        public void LongestSubstring()
        {
            LongestSubstring ls = new LongestSubstring();
            Assert.Equal("CDGH", ls.Find("ABCDGH", "ACDGHR"));
            Assert.Equal("CDGH", ls.Find("ABCDGH", "ABRCDGH"));
            Assert.Equal("A", ls.Find("ABC", "AC"));
            Assert.Equal("", ls.Find("A", "B"));
        }

        [Fact]
        public void DupCleaner()
        {
            DupCleaner dc = new DupCleaner();
            Assert.Equal("geksfor",dc.RemoveDups("geeksforgeeks"));
            Assert.Equal("geks for", dc.RemoveDups("geeks for geeks"));
        }
        public void ReadInput()
        {
            int phraseCnt = int.Parse(Console.ReadLine());
            for (int i = 0; i < phraseCnt; i++)
            {
                var line = Console.ReadLine();
                
            }

        }
    }
}
