using Calculator.Service.Models;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System;

namespace Calculator.Service.Helpers
{
    public static class MathHelper
    {
        public static MathExpression EvaluateExpression(MathExpression mathExpression)
        {

            try
            {
                var expression = mathExpression;

                //
                switch (expression.Key)
                {
                    case "=":
                        expression.Expression = ComputeExpression(expression.Expression); break;
                    case "C":
                        expression.Expression = ClearExpression(); break;
                    case "+":
                    case "-":
                    case "/":
                    case "*":
                        expression.Expression = AppendOrReplaceArithmaticOperator(mathExpression); break;
                    case ".":
                        expression.Expression = AppendDecimal(expression.Expression); break;
                    case "0":
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                        expression.Expression = AppendNumber(expression); break;
                    default:
                        break;

                }


                return expression;
            }
            catch (Exception)
            {

                throw new InvalidOperationException();
            }

        }

        internal static char[][] GetCalculatorKeys()
        {
            char[][] keys =  {
                                new char[] {'+', '-', '*', '/'},
                                new char[] {'1', '2', '3'},
                                new char[] {'4', '5', '6'},
                                new char[] {'7', '8', '9'},
                                new char[] {'0', '.', 'C'},
                                new char[] {'='}
                                };
            return keys;
        }

        private static string AppendNumber(MathExpression expression)
        {
            return string.Format("{0}{1}", expression.Expression, expression.Key);
        }

        private static string ClearExpression()
        {
            return string.Empty;
        }

        private static string AppendOrReplaceArithmaticOperator(MathExpression expression)
        {
            return

                CanAddArithmaticOperator(expression) ?
                                    string.Format("{0}{1}", expression.Expression, expression.Key) : ReplaceOldOperatorWithNew(expression);
                
                
        }

        private static string ReplaceOldOperatorWithNew(MathExpression expression)
        {
            return string.Format("{0}{1}", expression.Expression.Substring(0, expression.Expression.Length - 1), expression.Key);
        }

        private static bool CanAddArithmaticOperator(MathExpression expression)
        {
            return !(expression.Expression.EndsWith("+")
                || expression.Expression.EndsWith("-")
                || expression.Expression.EndsWith("/")
                || expression.Expression.EndsWith("*"));
        }

        private static string AppendDecimal(string expression)
        {
            return (!expression.Contains(".")) ? string.Format("{0}.", expression) : expression;
        }

        private static string ComputeExpression(string expression)
        {
            try
            {
                DataTable dt = new DataTable();
                var result = dt.Compute(expression, "");
                return result.ToString();

            }
            catch (Exception)
            {
                throw new InvalidOperationException();
            }

        }

    }

    public enum KeyOperationValues
    {
        [Display(Name = "+")]
        Sum,
        [Display(Name = "-")]
        Minus,
        [Display(Name = "x")]
        Multiply,
        [Display(Name = "/")]
        Divide,
        [Display(Name = "c")]
        Clear,
        [Display(Name = "=")]
        Compute,
        [Display(Name = ".")]
        Decimal
    }

}
