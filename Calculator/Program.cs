using System;
using System.Collections.Generic;
using Calculator.Lexing;
using Calculator.Parsing;
using Calculator.Calculation;

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
                    answer = ArithmeticUnit.GetAnswer(postfixNotationListOfTokens);

                    Console.WriteLine($"  {answer}");
                }
            }
        }
    }
}
