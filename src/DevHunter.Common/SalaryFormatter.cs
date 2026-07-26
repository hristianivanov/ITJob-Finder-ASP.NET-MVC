namespace DevHunter.Common
{
    using System.Globalization;

    public static class SalaryFormatter
    {
        private const string CurrencySuffix = "lv.";

        private static readonly NumberFormatInfo SalaryFormat = new()
        {
            NumberGroupSeparator = " ",
            NumberDecimalDigits = 0
        };

        public static string Format(decimal? minSalary, decimal? maxSalary)
        {
            if (minSalary == null && maxSalary == null)
                return string.Empty;

            string? formattedMax = maxSalary?.ToString("N", SalaryFormat);
            string? formattedMin = minSalary?.ToString("N", SalaryFormat);

            return !string.IsNullOrWhiteSpace(formattedMin)
                ? $"{formattedMin} - {formattedMax} {CurrencySuffix}"
                : $"{formattedMax} {CurrencySuffix}";
        }
    }
}
