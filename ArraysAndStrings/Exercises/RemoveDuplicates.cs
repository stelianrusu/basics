using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings.Exercises
{
    public class DupCleaner
    {
        public string RemoveDups(string input)
        {
            string output = "";
            bool[] charFound = new bool[256];
            foreach (char c in input)
            {
                int asciiCode = (int) c;
                if (charFound[asciiCode] == false)
                {
                    output += c;
                    charFound[asciiCode] = true;
                }
            }
            return output;
        }
    }
}
