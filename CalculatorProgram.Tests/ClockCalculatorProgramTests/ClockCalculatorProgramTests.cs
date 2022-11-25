using CalculatorProgram.ClockCalculations;
using CalculatorProgram.ClockCalculations.Calculator;
using NUnit.Framework;

namespace CalculatorProgram.Tests.ClockCalculatorProgramTests
{
    public class ClockCalculatorProgramTests
    {
        private readonly ClockCalculatorProgram _sut;

        public ClockCalculatorProgramTests()
        {
            _sut = new ClockCalculatorProgram(new AngleCalculator());
        }

        [Test]
        [TestCase(1, 30)]
        [TestCase(7, 30)]
        [TestCase(12, 30)]
        public void FormatTime_InputValid_ReturnsCorrectFormat(int hours, int minutes)
        {
            // Arrange
            var expected = new TimeOnly(hours, minutes).ToString("hh:mm");

            // Act
            var actual = _sut.FormatTime(hours, minutes);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}