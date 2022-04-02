﻿using System.Text;
using OrderValidator.Helpers;

namespace OrderValidator
{
    public static class Program
    {
        private static char[] _digits = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        private static string GetMask(string value)
        {
            for (int i = 1; i <= 9; i++)
                value = value.Replace(i.ToString(), "0");
            return value;
        }

        private static bool LessThan(string val1, string val2)
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

        private static string GetNext(string curr, string last)
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

        public static void Main(string[] args)
        {
            var folder = ConsoleEx.GetFolderPath("Input folder", ParamsHelper.TryExtractParamValue(args, "i", out string? p) ? p : null);
            Console.WriteLine(folder);
            var mask = ConsoleEx.GetParamValue("Search pattern", ParamsHelper.TryExtractParamValue(args, "m", out string? m) ? m : "*");

            foreach (var gr in Directory.GetFiles(folder, mask).Select(x => Path.GetFileName(x)).GroupBy(x => GetMask(x)))
            {
                if (gr.Count() == 1)
                    continue;
                foreach (var symbol in $"Group: {gr.Key}")
                    ConsoleEx.Write(symbol, symbol == '0' ? ConsoleColor.DarkGreen : Console.ForegroundColor);

                var files = gr.OrderBy(x => x).ToList();
                var curr = files.First();
                var last = files.Last();
                Console.WriteLine($" [{curr} .. {last}]");
                var success = true;
                while (curr != last)
                {
                    curr = GetNext(curr, last);
                    if (!files.Contains(curr))
                    {
                        ConsoleEx.WriteLine($"Not found: {curr}", ConsoleColor.DarkRed);
                        success = false;
                    }
                }
                if (success)
                    ConsoleEx.WriteLine("All files exist!", ConsoleColor.Green);

                Console.WriteLine();
            }
        }
    }
}
