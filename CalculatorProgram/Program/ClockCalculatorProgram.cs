using CalculatorProgram.Calculations.Interfaces;
using CalculatorProgram.Interfaces;

namespace CalculatorProgram.Calculations
{
    public class ClockCalculatorProgram : ICalculatorProgram
    {
        private readonly ICalculator _calculator;

        public ClockCalculatorProgram(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public void Run()
        {
            var hours = 0;
            var minutes = 0;

            var isValidHours = false;
            var isValidMinutes = false;
            var isQuitHit = false;

            do
            {
                Console.WriteLine("Please enter current clock arrow hours:");
                isValidHours = int.TryParse(Console.ReadLine(), out hours) && hours > 0 && hours <= 12;

                if (isValidHours)
                {
                    while (!isValidMinutes)
                    {
                        Console.WriteLine("Please enter current clock arrow minutes:");
                        isValidMinutes = int.TryParse(Console.ReadLine(), out minutes) && minutes >= 0 && minutes <= 60;
                    }

                    Console.Clear();
                    Console.WriteLine($"Time: {FormatTime(hours, minutes)}\n" +
                        $"Result: {_calculator.Calculate(hours, minutes)}\nQuit? [y/n]");

                    isQuitHit = Console.ReadLine().Equals("y");
                    isValidMinutes = false;
                }

            } while (!isQuitHit);

            Console.WriteLine("See ya!");
        }

        public string FormatTime(int hours, int minutes)
        {
            return new TimeOnly(hours, minutes).ToString("hh:mm");
        }
    }
}