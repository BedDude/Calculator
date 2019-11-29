using System;
using System.Collections.Generic;
using Calculator.Lexing;
using Calculator.Parsing;
using Calculator.Calculation;

namespace Calculator
{
    /// <summary>
    /// Main class in program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main function in program
        /// Used for work coordination and creation UI
        /// </summary>
        static void Main()
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
                    List<Token> postfixNotationListOfTokens = Parser.GetListInPostfixNotation(listOfTokens);
                    answer = ArithmeticUnit.GetAnswer(postfixNotationListOfTokens);

                    Console.WriteLine($"  {answer}");
                }
            }
        }
    }
}
