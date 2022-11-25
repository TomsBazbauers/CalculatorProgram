using CalculatorProgram.ClockCalculations.Calculator;
using CalculatorProgram.ClockCalculations.Interfaces;
using NUnit.Framework;

namespace CalculatorProgram.Tests.AngleCalculatorTests
{
    public class AngleCalculatorTests
    {
        private readonly ICalculator _sut;

        public AngleCalculatorTests()
        {
            _sut = new AngleCalculator();
        }

        [Test]
        [TestCase(1, 30)]
        [TestCase(5, 45)]
        [TestCase(11, 0)]
        public void Calculate_InputValid_ReturnsCorrectResultCorrectFormat(int hours, int minutes)
        {
            // Arrange
            var hourAngle = 30 * hours + 0.5m * minutes;
            var minuteAngle = 6 * minutes;
            var result = hourAngle - minuteAngle;

            decimal expectedResult = 360 - result > result ? result : 360 - result;
            var expectedFormat = string.Join("", expectedResult, "°");

            // Act
            var actual = _sut.Calculate(hours, minutes);

            // Assert
            Assert.IsInstanceOf<string>(actual);
            Assert.That(decimal.Parse(actual.Remove(actual.Length - 1)), Is.EqualTo(expectedResult));
            Assert.That(actual, Is.EqualTo(expectedFormat));
        }

        [Test]
        [Repeat(20)]
        public void FormatResult_InputValid_ReturnsCorrectResultCorrectFormat()
        {
            // Arrange
            var testDecimal = (decimal)new Random().NextDouble();
            var expected = string.Join("", testDecimal, "°");

            // Act
            var actual = _sut.FormatResult(testDecimal);

            // Assert
            Assert.IsInstanceOf<string>(actual);
            Assert.That(decimal.Parse(actual.Remove(actual.Length - 1)), Is.EqualTo(testDecimal));
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}