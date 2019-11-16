using System;
using System.Collections.Generic;
using Calculator.Lexing;
using Calculator.Parsing;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            double answer;
            while(true)
            {
                Console.Write("> ");
                input = Console.ReadLine().Replace(" ", "");

                if(input == "exit")
                {
                    break;
                }

                if(input != "")
                {
                    List<Token> listOfTokens = Lexer.GetListOfTokens(input);
                    List<Token> postfixNotationListOfTokens = Parser.GetSortedList(listOfTokens);
                    answer = GetAnswer(postfixNotationListOfTokens);

                    Console.WriteLine($"  {answer}");
                }
            }
        }

        static double GetAnswer(List<Token> listOfTokens)
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
                    secondOperand = stackOfNumbers.Pop();
                    switch(token.something)
                    {
                        case '+':
                            stackOfNumbers.Push(firstOperand + secondOperand);
                            break;
                        case '-':
                            stackOfNumbers.Push(secondOperand - firstOperand);
                            break;
                        case '*':
                            stackOfNumbers.Push(firstOperand * secondOperand);
                            break;
                        case '/':
                            stackOfNumbers.Push(secondOperand / firstOperand);
                            break;
                        case '^':
                            stackOfNumbers.Push(Math.Pow(secondOperand, firstOperand));
                            break;
                        case '%':
                            stackOfNumbers.Push(secondOperand / 100 * firstOperand);
                            break;
                    }
                }
            }

            return stackOfNumbers.Pop();
        }
    }
}
