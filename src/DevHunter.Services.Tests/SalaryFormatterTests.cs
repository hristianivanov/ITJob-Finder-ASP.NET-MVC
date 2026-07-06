namespace DevHunter.Services.Tests
{
    using FluentAssertions;

    using DevHunter.Common;

    [TestFixture]
    public class SalaryFormatterTests
    {

        [Test]
        public void Format_ShouldReturnEmptyStringWhenBothNull()
        {
            SalaryFormatter.Format(null, null).Should().BeEmpty();
        }


        [TestCase(null, 2500, "2 500 lv.")]
        [TestCase(null, 1000, "1 000 lv.")]
        [TestCase(null, 500, "500 lv.")]
        [TestCase(null, 10000, "10 000 lv.")]
        public void Format_ShouldReturnMaxOnlyWhenMinIsNull(
            decimal? min, decimal max, string expected)
        {
            SalaryFormatter.Format(min, max).Should().Be(expected);
        }


        [TestCase(2000, 3500, "2 000 - 3 500 lv.")]
        [TestCase(1000, 5000, "1 000 - 5 000 lv.")]
        [TestCase(500, 1500, "500 - 1 500 lv.")]
        public void Format_ShouldReturnRangeWhenBothProvided(
            decimal min, decimal max, string expected)
        {
            SalaryFormatter.Format(min, max).Should().Be(expected);
        }


        [Test]
        public void Format_ShouldUseSpaceAsThousandSeparator()
        {
            var result = SalaryFormatter.Format(null, 100000);

            result.Should().Be("100 000 lv.");
        }


        [Test]
        public void Format_ShouldAlwaysEndWithLvSuffix()
        {
            SalaryFormatter.Format(null, 1000).Should().EndWith("lv.");
            SalaryFormatter.Format(500, 1000).Should().EndWith("lv.");
        }


        [Test]
        public void Format_ShouldHandleZeroValues()
        {
            SalaryFormatter.Format(0, 0).Should().Be("0 - 0 lv.");
        }

        [Test]
        public void Format_ShouldHandleMaxOnlyZero()
        {
            SalaryFormatter.Format(null, 0).Should().Be("0 lv.");
        }

        [Test]
        public void Format_ShouldHandleDecimalValues()
        {
            SalaryFormatter.Format(null, 1500.99m).Should().Be("1 501 lv.");
        }
    }
}
