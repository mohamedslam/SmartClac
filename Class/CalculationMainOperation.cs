using System;
using System.Collections.Generic;
using System.Text;

namespace SmartClac.Class
{
   public abstract class CalculationMainOperation
    {
        protected  string[] _MathOperators = { "-", "+", "/", "*", "^","%" };

        protected  Func<double, double, double>[]
            MyAllowanceOperation =
        {
            (a1, a2) => a1 - a2,
            (a1, a2) => a1 + a2,
            (a1, a2) => a1 / a2,
            (a1, a2) => a1 * a2,            
            (a1, a2) => Math.Pow(a1, a2),
            (a1, a2) => a1 % a2,
        };
            string operators = "()^*/+-%";
        List<string> tokens;
        StringBuilder sb;
        protected string GetSeperatedSubExpression(List<string> tokens, ref int index)
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

        protected List<string> getTokens(string expression)
        {
             tokens = new List<string>();
             sb = new StringBuilder();

            foreach (char c in expression.Trim())
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
                    sb.Append(c);
            }

            if ((sb.Length > 0))
                tokens.Add(sb.ToString());

            return tokens;
        }
    }
}
