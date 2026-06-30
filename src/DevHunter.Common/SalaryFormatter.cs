namespace DevHunter.Common
{
    using System.Globalization;

    public static class SalaryFormatter
    {
        public static string Format(decimal? minSalary, decimal? maxSalary)
        {
            if (minSalary == null && maxSalary == null)
            {
                return string.Empty;
            }

            string? formattedMax = maxSalary?
                .ToString("#,0", CultureInfo.InvariantCulture)
                .Replace(",", " ");

            string? formattedMin = minSalary?
                .ToString("#,0", CultureInfo.InvariantCulture)
                .Replace(",", " ");

            return !string.IsNullOrWhiteSpace(formattedMin)
                ? $"{formattedMin} - {formattedMax} lv."
                : $"{formattedMax} lv.";
        }
    }
}
