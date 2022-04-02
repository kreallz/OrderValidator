namespace OrderValidator.Helpers
{
    public static class ConsoleEx
	{
		public static string GetFolderPath(string paramName, string? value = null)
		{
			paramName = $"{paramName}: ";
			Console.Write(paramName);
			if (!string.IsNullOrWhiteSpace(value))
				Console.WriteLine(value);
			else
				value = Console.ReadLine();
			while (!Directory.Exists(value))
			{
				Console.WriteLine("Wrong path!");
				Console.Write(paramName);
				value = Console.ReadLine();
			}
			return value;
		}

		public static string GetParamValue(string paramName, string? value = null)
		{
			paramName = $"{paramName}: ";
			Console.Write(paramName);
			if (!string.IsNullOrWhiteSpace(value))
				Console.WriteLine(value);
			else
				value = Console.ReadLine();
			while (string.IsNullOrWhiteSpace(value))
			{
				Console.WriteLine("Enter value!");
				Console.Write(paramName);
				value = Console.ReadLine();
			}
			return value;
		}

		public static void WriteLine(string value, ConsoleColor? color = null)
		{
			var tmp = Console.ForegroundColor;
			if (color != null)
				Console.ForegroundColor = color.Value;
			Console.WriteLine(value);
			Console.ForegroundColor = tmp;
		}

		public static void Write(char value, ConsoleColor? color = null)
		{
			var tmp = Console.ForegroundColor;
			if (color != null)
				Console.ForegroundColor = color.Value;
			Console.Write(value);
			Console.ForegroundColor = tmp;
		}
	}
}

