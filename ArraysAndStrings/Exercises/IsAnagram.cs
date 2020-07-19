using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings.Exercises
{
    public class IsAnagram
    {
        public bool Check(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;

            Dictionary<char, int> charCounter = new Dictionary<char, int>();
            foreach (char c in s1)
            {
                int count = 0;
                if (charCounter.ContainsKey(c))
                    count = charCounter[c];
                charCounter[c] = ++count;
            }

            foreach (char c in s2)
            {
                if (!charCounter.ContainsKey(c))
                    return false;

                charCounter[c] = charCounter[c] - 1;
            }

            foreach (var charCount in charCounter)
            {
                if (charCount.Value != 0)
                    return false;
            }

            return true;
        }
    }
}
