using System;
using System.Collections.Generic;
using System.Text;

namespace SmartClac.Class
{
    public abstract class CalculationMainOperation
    {
        protected readonly string[] _MathOperators = { "-", "+", "/","%","*", "^", "(",")" };

        protected Func<double, double, double>[]
            MyAllowanceOperation =
        {
            (a1, a2) => a1 - a2,
            (a1, a2) => a1 + a2,
            (a1, a2) => a1 / a2,
            (a1, a2) => a1 % a2,
            (a1, a2) => a1 * a2,
            (a1, a2) => Math.Pow(a1, a2),
            
        };
        protected int GetIndex(string[] arr, string elemnt)
        {
            return Array.IndexOf(arr, elemnt);
        }
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
        protected bool CheckOperator(char opr)
        {
            foreach(var item in _MathOperators)
                if (item == opr.ToString())
                    return true;
            return false;
        }

    }
}
