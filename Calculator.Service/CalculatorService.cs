using Calculator.Service.Models;
using Calculator.Service.Helpers;
using System;

namespace Calculator.Service
{
    public class CalculatorService : ICalculatorService
    {
        public MathExpression EvaluateExpression(MathExpression mathExpression)
        {
            try
            {
                return MathHelper.EvaluateExpression(mathExpression);
            }
            catch (Exception ex)
            {

                return null;
            }
            
        }

        public char[][] GetCalculatorLayoutKeys()
        {
           return MathHelper.GetCalculatorKeys();
        }
    }
}
