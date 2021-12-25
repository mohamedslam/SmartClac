using System;
using System.Collections.Generic;
using System.Text;

namespace SmartClac.Class
{
    public class Claculation
    {

        private static string[] _operatorsOfOperation = { "-", "+", "/", "*", "^" };

        private static Func<double, double, double>[] MyAllowanceOperation =
        {
            (a1, a2) => a1 - a2,
            (a1, a2) => a1 + a2,
            (a1, a2) => a1 / a2,
            (a1, a2) => a1 * a2,
            (a1, a2) => Math.Pow(a1, a2)
        };

        public static double Claculate(string expression)
        {
            List<string> tokens = getTokens(expression);
            Stack<double> operandStack = new Stack<double>();
            Stack<string> operatorStack = new Stack<string>();
            int tokenIndex = 0;

            while (tokenIndex < tokens.Count)
            {
                string token = tokens[tokenIndex];
                if (token == "(")
                {
                    string subExpr = GetSeperatedSubExpression(tokens, ref tokenIndex);
                    operandStack.Push(Claculate(subExpr));
                    continue;
                }
                if (token == ")")
                {
                    throw new ArgumentException("Mis-matched parentheses in expression");
                }
                //check is that  operator  or not ?
                if (Array.IndexOf(_operatorsOfOperation, token) >= 0)
                {
                    while (operatorStack.Count > 0 && Array.IndexOf(_operatorsOfOperation, token) < Array.IndexOf(_operatorsOfOperation, operatorStack.Peek()))
                    {
                        string op = operatorStack.Pop();
                        double arg2 = operandStack.Pop();
                        double arg1 = operandStack.Pop();
                        operandStack.Push(MyAllowanceOperation[Array.IndexOf(_operatorsOfOperation, op)](arg1, arg2));
                    }
                    operatorStack.Push(token);
                }
                else
                {
                    operandStack.Push(double.Parse(token));
                }
                tokenIndex += 1;
            }

            while (operatorStack.Count > 0)
            {
                string op = operatorStack.Pop();
                double arg2 = operandStack.Pop();
                double arg1 = operandStack.Pop();
                operandStack.Push(MyAllowanceOperation[Array.IndexOf(_operatorsOfOperation, op)](arg1, arg2));
            }
            return operandStack.Pop();
        }

        private static string GetSeperatedSubExpression(List<string> tokens, ref int index)
        {
            StringBuilder subFormula = new StringBuilder();
            int parenlevels = 1;
            index += 1;
            while (index < tokens.Count && parenlevels > 0)
            {
                string token = tokens[index];
                if (tokens[index] == "(")
                {
                    parenlevels += 1;
                }

                if (tokens[index] == ")")
                {
                    parenlevels -= 1;
                }

                if (parenlevels > 0)
                {
                    subFormula.Append(token);
                }

                index += 1;
            }

            if ((parenlevels > 0))
            {
                throw new ArgumentException("Brackets do not match");
            }
            return subFormula.ToString();
        }

        private static List<string> getTokens(string expression)
        {
            string operators = "()^*/+-";
            List<string> tokens = new List<string>();
            StringBuilder sb = new StringBuilder();

            foreach (char c in expression.Replace(" ", string.Empty))
            {
                if (operators.IndexOf(c) >= 0)
                {
                    if ((sb.Length > 0))
                    {
                        tokens.Add(sb.ToString());
                        sb.Length = 0;
                    }
                    tokens.Add(c.ToString());
                }
                else
                {
                    sb.Append(c);
                }
            }

            if ((sb.Length > 0))
            {
                tokens.Add(sb.ToString());
            }
            return tokens;
        }

    }
}
