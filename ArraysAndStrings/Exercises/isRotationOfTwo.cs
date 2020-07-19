using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings.Exercises
{
    public class IsRotationOfTwo
    {
        public bool isRotation(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;
            if (s1.Length < 3)
                return s1 == s2;

            return CheckRotation(s1, s2) || CheckRotation(s2, s1);
        }

        private bool CheckRotation(string s1, string s2)
        {
            bool bothHaveSameRoot = s1.Substring(0, s1.Length - 2) == s2.Substring(2);
            if (!bothHaveSameRoot)
                return false;

            return s1.Substring(s1.Length - 2) == s2.Substring(0, 2);
        }

    }
}
