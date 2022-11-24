namespace CalculatorProgram.ClockCalculations.Interfaces
{
    public interface ICalculator
    {
        string Calculate(int hours, int minutes);

        string FormatResult(decimal result);
    }
}
