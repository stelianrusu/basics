using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings.Exercises
{
    public class LongestPalindrome
    {
        public string Find(string s)
        {
            if (string.IsNullOrEmpty(s))
                return "";

            string longestPolindrome = s[0].ToString();

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = s.Length- 1;j > i; j--)
                {
                    if (s[i] == s[j])
                    {
                        int left = i;
                        int right = j;
                        bool middleReached = false;
                        while (s[left] == s[right] && !middleReached)
                        {
                            left++;
                            right--;
                            middleReached = left >= right;
                        }

                        if(middleReached)
                            if (longestPolindrome.Length < j - i + 1)
                                longestPolindrome = s.Substring(i, j - i + 1);
                    }
                }
            }

            return longestPolindrome;
        }   
    }
}
