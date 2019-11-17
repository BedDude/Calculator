using System;
using System.Collections.Generic;
using Calculator.Lexing;

namespace Calculator.Calculation
{
    static class ArithmeticUnit
    {
        public static double GetAnswer(List<Token> listOfTokens)
        {
            Stack<double> stackOfNumbers = new Stack<double>();

            double firstOperand, secondOperand;
            foreach(var token in listOfTokens)
            {
                if(token.type == TokenType.NUMBER)
                {
                    stackOfNumbers.Push(Convert.ToDouble(token.something));
                }
                else
                {
                    firstOperand = stackOfNumbers.Pop();
                    switch(token.something)
                    {
                        case '+':
                            secondOperand = stackOfNumbers.Pop();
                            stackOfNumbers.Push(firstOperand + secondOperand);
                            break;
                        case '-':
                            secondOperand = stackOfNumbers.Pop();
                            stackOfNumbers.Push(secondOperand - firstOperand);
                            break;
                        case '*':
                            secondOperand = stackOfNumbers.Pop();
                            stackOfNumbers.Push(firstOperand * secondOperand);
                            break;
                        case '/':
                            secondOperand = stackOfNumbers.Pop();
                            stackOfNumbers.Push(secondOperand / firstOperand);
                            break;
                        case '^':
                            secondOperand = stackOfNumbers.Pop();
                            stackOfNumbers.Push(Math.Pow(secondOperand, firstOperand));
                            break;
                        case '%':
                            secondOperand = stackOfNumbers.Pop();
                            stackOfNumbers.Push(secondOperand / 100 * firstOperand);
                            break;
                    }
                }
            }

            return stackOfNumbers.Pop();
        }
    }
}
