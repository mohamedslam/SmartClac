using SmartClac.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartClac.Class
{
    public class ClsClaculation: CalculationMainOperation,ICalculation
    {  
        public  double Claculate(string expression)
        {
            if (expression.Trim().Length < 3)
                throw new ArgumentException("Correct Your calculation");

            List<string> tokens = GetTokens(expression);
            Stack<double> operand_Stack = new Stack<double>();
            Stack<string> operator_Stack = new Stack<string>();

            int tokenIndex = 0;

            // for Sepertated Digital and operator 
            while (tokenIndex < tokens.Count)
            {
                string token = tokens[tokenIndex];

                if (token == "(")
                {
                    string subExpr = GetSeperatedSubExpression(tokens, ref tokenIndex);
                    operand_Stack.Push(Claculate(subExpr));
                    continue;
                }

                if (token == ")")
                    throw new ArgumentException("Correct the position of the brackets with the equation");

                //check is that  operator  or not ?
                if (GetIndex(_MathOperators, token) >= 0)
                {
                    while (operator_Stack.Count > 0 && GetIndex(_MathOperators, token) < GetIndex(_MathOperators, operator_Stack.Peek()))
                    {
                        string math_operator = operator_Stack.Pop();
                        
                        double arg1 = operand_Stack.Pop();
                        double arg2 = operand_Stack.Pop();

                        operand_Stack.Push(MyAllowanceOperation[GetIndex(_MathOperators, math_operator)](arg1, arg2));
                    }
                    operator_Stack.Push(token);
                }
                else
                    operand_Stack.Push(double.Parse(token));

                tokenIndex ++;
            }
           
            return CalcTriminal(operand_Stack, operator_Stack);
        }
        private double CalcTriminal(Stack<double> operand_Stack, Stack<string> operator_Stack)
        {             
            //calc every two value between oprator
            while (operator_Stack.Count > 0)
            {
                string Operator = operator_Stack.Pop();
                double arg2 = operand_Stack.Pop();
                double arg1 = operand_Stack.Pop();
                operand_Stack.Push(MyAllowanceOperation[Array.IndexOf(_MathOperators, Operator)](arg1, arg2));
            }
            return operand_Stack.Pop();
        }
        public List<string> GetTokens(string expression)
        {

            List<string> tokens = new List<string>();
            StringBuilder sb = new StringBuilder();

            foreach (char c in expression.Trim())
            {
                if (CheckOperator(c))
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
