using System;
using System.Text;

namespace OrderValidator.Helpers
{
	public static class GroupsHelper
	{
        private static char[] _digits = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public static string GetMask(string value)
        {
            for (int i = 1; i <= 9; i++)
                value = value.Replace(i.ToString(), "0");
            return value;
        }

        public static bool LessThan(string val1, string val2)
        {
            for (int i = 0; i < val1.Length; i++)
            {
                var i1 = Array.IndexOf(_digits, val1[i]);
                if (i1 == -1)
                    continue;
                var i2 = Array.IndexOf(_digits, val2[i]);
                if (i2 == -1)
                    return false;
                if (i1 < i2)
                    return true;
            }
            return false;
        }

        public static string GetNext(string curr, string last)
        {
            var sb = new StringBuilder(curr);
            for (int i = curr.Length - 1; i >= 0; i--)
            {
                var index = Array.IndexOf(_digits, curr[i]);
                if (index == -1)
                    continue;
                if (index != 9)
                {
                    sb[i] = _digits[index + 1];
                    break;
                }
                else if (index == 9)
                    sb[i] = '0';
            }
            curr = sb.ToString();
            return LessThan(curr, last) ? curr : last;
        }
    }
}

