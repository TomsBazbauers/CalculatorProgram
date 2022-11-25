namespace CalculatorProgram.Calculations.Interfaces
{
    public interface ICalculator
    {
        string Calculate(int hours, int minutes);

        string FormatResult(decimal result);
    }
}
