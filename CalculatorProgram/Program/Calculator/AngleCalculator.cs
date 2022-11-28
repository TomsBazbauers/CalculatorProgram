using CalculatorProgram.Calculations.Interfaces;

namespace CalculatorProgram.Calculations.Calculator
{
    public class AngleCalculator : ICalculator
    {
        private const int _DegreesFullCircle = 360;
        private const int _DegreesPerHour = 30;
        private const int _DegreesPerMinute = 6;
        private const decimal _DegreesHourArrowPerMinute = 0.5m;

        public string Calculate(int hours, int minutes)
        {
            var angleHours = _DegreesPerHour * hours + _DegreesHourArrowPerMinute * minutes;
            var angleMinutes = _DegreesPerMinute * minutes;

            decimal result = Math.Abs(angleHours - angleMinutes);

            return _DegreesFullCircle - result > result ? FormatResult(result) : FormatResult(_DegreesFullCircle - result);
        }

        public string FormatResult(decimal result)
        {
            return string.Join("", result, "°");
        }
    }
}
