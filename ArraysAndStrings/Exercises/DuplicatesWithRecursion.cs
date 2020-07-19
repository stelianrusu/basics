using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings.Exercises
{

    // https://practice.geeksforgeeks.org/problems/recursively-remove-all-adjacent-duplicates/0/
    public class DuplicatesWithRecursion
    {
        private readonly Stack<CharTracker> stack = new Stack<CharTracker>();
        public string Dedup(string input)
        {
            string iterationResult = RemoveDupsIteration(input);
            if (iterationResult.Length < input.Length)
                return Dedup(iterationResult);
            else
                return iterationResult;
        }

        private string RemoveDupsIteration(string input)
        {
            stack.Clear();
            AnalyzeChar(input, input.Length - 1);
            return BuildStringFromStack();
        }


        private string BuildStringFromStack()
        {
            StringBuilder sb = new StringBuilder();
            while (stack.Count > 0)
            {
                sb.Append(stack.Pop().Char);
            }

            return sb.ToString();
        }

        private void AnalyzeChar(string input, int i)
        {
            var top = PeekOrNull();
            if (i == -1)
            {
                if (top != null && top.IsDup)
                    RemoveDuplicatesFromTop();
                return;
            }

            char curChar = input[i];
            if (top == null)
            {
                stack.Push(new CharTracker() { IsDup = false, Char = curChar });
                AnalyzeChar(input, i - 1);
                return;
            }

            if (top.Char == curChar)
            {
                top.IsDup = true;
                stack.Push(new CharTracker { Char = curChar, IsDup = true });
            }
            else
            {
                if (top.IsDup)
                    RemoveDuplicatesFromTop();
                stack.Push(new CharTracker() { IsDup = false, Char = curChar });
            }
            AnalyzeChar(input, i - 1);
        }

        private void RemoveDuplicatesFromTop()
        {
            if (stack.Count == 0)
                return;

            var top = stack.Peek();
            var cur = stack.Peek();
            while (stack.Count > 0 && cur.Char == top.Char)
            {
                stack.Pop();
                if (stack.Count > 0)
                    cur = stack.Peek();
            }
        }

        private string RemoveDuplicatesIfNeeded(string str, int dupCount)
        {
            if (dupCount == 1)
                return str;

            return str.Substring(dupCount);
        }

        private CharTracker PeekOrNull()
        {
            if (stack.Count == 0)
                return null;

            return stack.Peek();
        }
    }

    public class CharTracker
    {
        public char Char { get; set; }
        public bool IsDup { get; set; }
    }
}
