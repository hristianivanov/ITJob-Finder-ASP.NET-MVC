namespace DevHunter.Web.Infrastructure.Extensions
{
	using System.Text;

	public static class StringExtensions
	{
		public static string InsertSpacesBeforeUppercase(this string input)
		{
			var sb = new StringBuilder();
			foreach (var ch in input)
			{
				if (char.IsUpper(ch) && sb.Length > 0)
				{
					sb.Append(' ');
				}
				sb.Append(ch);
			}
			return sb.ToString();
		}
	}
}
