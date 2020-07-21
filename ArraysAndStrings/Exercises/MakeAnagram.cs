using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings.Exercises
{
    public class MakeAnagram
    {
        public static int makeAnagram(string a, string b)
        {
            int[] charCount = new int[255];
            foreach (char c in a)
            {
                charCount[(int)c]++;
            }

            foreach (char c in b)
            {
                charCount[(int)c]--;
            }

            int result = 0;
            foreach (int cnt in charCount)
            {
                result += Math.Abs(cnt);
            }

            return result;
        }

        public static int alternatingCharacters(string s)
        {
            char prevChar = 'Z';
            int deletionsNeeded = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (prevChar != s[i])
                    prevChar = s[i];
                else
                {
                    deletionsNeeded++;
                }
            }

            return deletionsNeeded;
        }

        // Complete the isValid function below.
        public static string isValid(string s)
        {

            int[] charCount = new int[255];
            foreach (char c in s)
            {
                charCount[(int)c]++;
            }

            var distinctCounts = charCount.Where(cnt => cnt > 0).Distinct().ToList();
            bool allEqual = distinctCounts.Count() == 1;
            if (allEqual)
                return "YES";

            if (distinctCounts.Count() > 2)
                return "NO";

            var set1 = charCount.Where(cnt => cnt == distinctCounts[0]).ToList();
            var set2 = charCount.Where(cnt => cnt == distinctCounts[1]).ToList();

            if ((set1.Count != 1) && (set2.Count != 1))
                return "NO";

            if (set1.Count == 1)
            {
                if (set1[0] - 1 == 0 || set1[0] - 1 == set2[0])
                    return "YES";
            }

            if (set2.Count == 1)
            {
                if (set2[0] - 1 == 0 || set2[0] - 1 == set1[0])
                    return "YES";
            }

            return "NO";
        }

        public static long substrCount(int n, string s)
        {
            int palyndromeCount = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char expectedChar = s[i];
                int k = 0;

                while ((i + k < s.Length) && (s[i + k] == expectedChar))
                {
                    palyndromeCount++;
                    k++;
                }

                bool endReached = i + k >= s.Length - 1;
                if (endReached)
                    continue;

                int endOfPotentialPalyndromeWithMiddle = i + (k) + 1 + (k);
                if (endOfPotentialPalyndromeWithMiddle > s.Length)
                    continue;

                if (s.Substring(i + k + 1, k) == s.Substring(i, k))
                    palyndromeCount++;
            }

            return palyndromeCount;
        }

    }
}
