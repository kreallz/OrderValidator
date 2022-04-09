using System.Text;
using OrderValidator.Helpers;

namespace OrderValidator
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var silent = ParamsHelper.GetBoolParamValue(args, "silent");
            try
            {
                var folder = ConsoleEx.GetFolderPath("Input folder", ParamsHelper.TryExtractParamValue(args, "i", out string? p) ? p : null, silent);
                var mask = ConsoleEx.GetParamValue("Search pattern", ParamsHelper.TryExtractParamValue(args, "m", out string? m) ? m : null, silent);
                var pg = ParamsHelper.GetBoolParamValue(args, "pg");

                var groups = Directory.GetFiles(folder, mask)
                    .Select(x => Path.GetFileName(x))
                    .GroupBy(x => GroupsHelper.GetMask(x))
                    .Where(x => x.Count() > 1);

                var groupsCount = groups.Count();
                var printGroupName = groupsCount > 1 || pg;

                foreach (var gr in groups)
                {
                    var files = gr.OrderBy(x => x).ToList();
                    var curr = files.First();
                    var last = files.Last();
                    if (printGroupName)
                        Console.WriteLine($"[{curr} .. {last}]:");
                    var success = true;
                    while (curr != last)
                    {
                        curr = GroupsHelper.GetNext(curr, last);
                        if (!files.Contains(curr))
                        {
                            ConsoleEx.WriteLine($"Not found: {curr}", ConsoleColor.DarkRed);
                            success = false;
                        }
                    }
                    if (success)
                        ConsoleEx.WriteLine("All files exist!", ConsoleColor.Green);
                    if (groupsCount > 1)
                        Console.WriteLine();
                }

                if (groupsCount == 0)
                    ConsoleEx.WriteLine("No file groups to validate!", ConsoleColor.DarkRed);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
