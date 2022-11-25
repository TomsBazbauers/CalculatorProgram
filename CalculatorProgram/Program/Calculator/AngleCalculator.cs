using CalculatorProgram.Calculations.Interfaces;

namespace CalculatorProgram.Calculations.Calculator
{
    public class AngleCalculator : ICalculator
    {
        private const int _DegreesPerHour = 30;
        private const int _DegreesPerMinute = 6;
        private const decimal _HourArrowDegreesPerMinute = 0.5m;

        public string Calculate(int hours, int minutes)
        {
            var angleHours = _DegreesPerHour * hours + _HourArrowDegreesPerMinute * minutes;
            var angleMinutes = _DegreesPerMinute * minutes;

            decimal result = Math.Abs(angleHours - angleMinutes);

            return 360 - result > result ? FormatResult(result) : FormatResult(360 - result);
        }

        public string FormatResult(decimal result)
        {
            return string.Join("", result, "°");
        }
    }
}
