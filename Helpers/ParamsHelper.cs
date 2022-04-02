namespace OrderValidator.Helpers
{
    public static class ParamsHelper
	{
		private static string GetParamName(string param)
		{
			if (param.First() != '-')
				param = '-' + param;

			if (param.Last() != ':')
				param += ':';

			return param;
		}

		private static string ExtractValue(string paramString, string paramName)
			=> paramString.Substring(GetParamName(paramName).Length);

		public static bool TryExtractParamValue(string[] args, string param, out string? value)
		{
			param = GetParamName(param);
			var paramString = GetParamValue(args, param);
			if (paramString == null)
			{
				value = null;
				return false;
			}
			value = ExtractValue(paramString, param);
			return true;
		}

		public static IEnumerable<string> GetParamValues(string[] args, string param)
		{
			param = GetParamName(param);
			return args.Where(x => x.StartsWith(param));
		}

		public static string? GetParamValue(string[] args, string param)
			=> GetParamValues(args, param).FirstOrDefault();
	}
}

