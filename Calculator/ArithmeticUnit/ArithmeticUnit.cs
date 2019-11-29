using System;
using System.Collections.Generic;
using Calculator.Lexing;

namespace Calculator.Calculation
{
    /// <summary>
    /// Class of arithmetic unit
    /// Used for calculation
    /// </summary>
    static class ArithmeticUnit
    {
        /// <summary>
        /// Calculation function
        /// Use stack calculation
        /// </summary>
        /// <param name="listOfTokens">List of tokens in postfix notation</param>
        /// <returns>Result of calculation</returns>
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
                    secondOperand = stackOfNumbers.Pop();
                    switch(token.something)
                    {
                        case '!':
                            stackOfNumbers.Push(GetFactorial((int)secondOperand));
                            break;
                        case '+':
                            firstOperand = stackOfNumbers.Pop();
                            stackOfNumbers.Push(firstOperand + secondOperand);
                            break;
                        case '-':
                            firstOperand = stackOfNumbers.Pop();
                            stackOfNumbers.Push(firstOperand - secondOperand);
                            break;
                        case '*':
                            firstOperand = stackOfNumbers.Pop();
                            stackOfNumbers.Push(firstOperand * secondOperand);
                            break;
                        case '/':
                            firstOperand = stackOfNumbers.Pop();
                            stackOfNumbers.Push(firstOperand / secondOperand);
                            break;
                        case '^':
                            firstOperand = stackOfNumbers.Pop();
                            stackOfNumbers.Push(Math.Pow(firstOperand, secondOperand));
                            break;
                        case '%':
                            firstOperand = stackOfNumbers.Pop();
                            stackOfNumbers.Push(firstOperand / 100 * secondOperand);
                            break;
                    }
                }
            }

            return stackOfNumbers.Pop();
        }

        /// <summary>
        /// Recursive function of calculation the factorial of integer
        /// </summary>
        /// <param name="number">Just integer</param>
        /// <returns>Factorial of number</returns>
        private static int GetFactorial(int number)
        {
            if(number == 1 || number == 0)
            {
                return 1;
            }
            else
            {
                return number * GetFactorial(number - 1);
            }
        }
    }
}
