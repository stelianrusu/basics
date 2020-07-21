using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings.Exercises
{
    public class LongestDistinctSubstring
    {
        public string Find(string input)
        {
            string longest = "";
            bool[] foundChars = new bool[255];
            for (int i = 0; i < input.Length; i++)
            {
                Array.Clear(foundChars, 0, foundChars.Length);
                string longestCandidate = input[i].ToString();
                foundChars[(int)input[i]] = true;
                for (int k = 1; k < input.Length - i; k++)
                {
                    char nextChar = input[i + k];
                    if (foundChars[(int) nextChar] == true)
                        break;
                    else
                    {
                        foundChars[(int)nextChar] = true;
                        longestCandidate += nextChar;
                    }
                }

                if (longestCandidate.Length > longest.Length)
                    longest = longestCandidate;
            }

            return longest;
        }
    }
}
