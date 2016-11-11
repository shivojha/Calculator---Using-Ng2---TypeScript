using Calculator.Service.Models;

namespace Calculator.Service
{
    public interface ICalculatorService
    {
        MathExpression EvaluateExpression(MathExpression mathExpression);
        char[][] GetCalculatorLayoutKeys();
    }
}