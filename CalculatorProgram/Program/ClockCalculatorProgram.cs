using CalculatorProgram.ClockCalculations.Calculator;
using CalculatorProgram.ClockCalculations.Interfaces;
using CalculatorProgram.Interfaces;

namespace CalculatorProgram.ClockCalculations
{
    public class ClockCalculatorProgram : ICalculatorProgram
    {
        private readonly ICalculator _calculator = new AngleCalculator();

        public void Run()
        {
            var hours = 0;
            var minutes = 0;

            var isValidHours = false;
            var isValidMinutes = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Please enter current clock arrow hours:");
                isValidHours = int.TryParse(Console.ReadLine(), out hours) && hours > 0 && hours <= 12;

                if (isValidHours)
                {
                    Console.WriteLine("Please enter current clock arrow minutes:");
                    isValidMinutes = int.TryParse(Console.ReadLine(), out minutes) && minutes > 0 && minutes <= 60;
                }

            } while (!isValidHours || !isValidMinutes);

            Console.WriteLine($"Time: {FormatTime(hours, minutes)}\n" +
                $"Result: {_calculator.Calculate(hours, minutes)}");
        }

        public string FormatTime(int hours, int minutes)
        {
            return new TimeOnly(hours, minutes).ToString("hh:mm");
        }
    }
}
