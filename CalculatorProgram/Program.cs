using CalculatorProgram.ClockCalculations;
using CalculatorProgram.ClockCalculations.Calculator;
using CalculatorProgram.Interfaces;

namespace CalculatorProgram
{
    public class Program
    {
        static void Main(string[] args)
        {
            RunProgram().Run();
        }

        public static ICalculatorProgram RunProgram()
        {
            return new ClockCalculatorProgram(new AngleCalculator());
        }
    }
}