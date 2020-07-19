using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings.Exercises
{
    //https://practice.geeksforgeeks.org/problems/roman-number-to-integer/0
    public class RomanNumberConvertor
    {
        private Dictionary<char, int> romanValues = new Dictionary<char, int>()
        {
            {'I', 1},
            {'X', 10},
            {'V', 5},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };
        public int ConvertToInt(string romanString)
        {
            Stack<char> charStack = new Stack<char>();
            foreach (char romanChar in romanString)
                charStack.Push(romanChar);

            int result = 0;
            int previousValue = 0;
            while (charStack.Count > 0)
            {
                int value = romanValues[charStack.Pop()];
                if (value < previousValue)
                    result -= value;
                else
                    result += value;
                previousValue = value;
            }

            return result;
        }
    }
}
