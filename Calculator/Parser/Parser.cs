using System.Collections.Generic;
using Calculator.Lexing;

namespace Calculator.Parsing
{
    static class Parser
    {
        public static List<Token> GetSortedList(List<Token> listOfLexerTokens)
        {
            List<Token> testOutput = new List<Token>();

            byte[] listOfPriorities = GetListOfPriorities(listOfLexerTokens);
            Stack<(Token, byte)> someStack = new Stack<(Token, byte)>();

            for(int i = 0;i < listOfLexerTokens.Count;i++)
            {
                if(listOfLexerTokens[i].type == TokenType.OPERATOR_BINARY)
                {
                    while(someStack.Count > 0 && someStack.Peek().Item2 <= listOfPriorities[i])
                    {
                        testOutput.Add(someStack.Pop().Item1);
                    }
                    someStack.Push((listOfLexerTokens[i], listOfPriorities[i]));
                }
                else
                {
                    testOutput.Add(listOfLexerTokens[i]);
                }
            }
            while(someStack.Count > 0)
            {
                testOutput.Add(someStack.Pop().Item1);
            }

            return testOutput;
        }

        private static byte[] GetListOfPriorities(List<Token> listOfLexerTokens)
        {
            int size = listOfLexerTokens.Count;
            byte[] listOfPriorities = new byte[size];

            object something;
            for(int i = 0;i < size;i++)
            {
                something = listOfLexerTokens[i].something;
                if(listOfLexerTokens[i].type == TokenType.OPERATOR_BINARY)
                {
                    switch(listOfLexerTokens[i].something)
                    {
                        case '^':
                        case '%':
                            listOfPriorities[i] = 0;
                            break;
                        case '*':
                        case '/':
                            listOfPriorities[i] = 1;
                            break;
                        default:
                            listOfPriorities[i] = 2;
                            break;
                    }
                }
                else
                {
                    listOfPriorities[i] = byte.MaxValue;
                }
            }

            return listOfPriorities;
        }
    }
}
