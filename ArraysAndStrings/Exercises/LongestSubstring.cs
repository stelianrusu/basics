using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings.Exercises
{
    // https://practice.geeksforgeeks.org/problems/longest-common-substring/0/
    public class LongestSubstring
    {
        public string Find(string s1, string s2)
        {
            string longest = "";
            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 0; j < s2.Length; j++)
                {
                    if (s1[i] == s2[j])
                    {
                        string longestCandidate = s1[i].ToString();
                        int k = 1;
                        while (i + k < s1.Length && j + k < s2.Length && s1[i + k] == s2[j + k])
                        {
                            longestCandidate += s1[i + k];
                            k++;
                        }
                        if (longestCandidate.Length > longest.Length)
                            longest = longestCandidate;
                    }
                }
            }

            return longest;
        }
    }
}
