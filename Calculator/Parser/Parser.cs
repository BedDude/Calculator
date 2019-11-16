using System.Collections.Generic;
using Calculator.Lexing;

namespace Calculator.Parsing
{
    static class Parser
    {
        public static List<LexerToken> GetSortedList(List<LexerToken> listOfLexerTokens)
        {
            List<LexerToken> testOutput = new List<LexerToken>();

            byte[] listOfPriorities = GetListOfPriorities(listOfLexerTokens);
            Stack<(LexerToken, byte)> someStack = new Stack<(LexerToken, byte)>();

            for(int i = 0;i < listOfLexerTokens.Count;i++)
            {
                if(listOfLexerTokens[i].type == TokenType.NUMBER)
                {
                    testOutput.Add(listOfLexerTokens[i]);
                }
                else
                {
                    while(someStack.Count > 0 && someStack.Peek().Item2 <= listOfPriorities[i])
                    {
                        testOutput.Add(someStack.Pop().Item1);
                    }
                    someStack.Push((listOfLexerTokens[i], listOfPriorities[i]));
                }
            }
            while(someStack.Count > 0)
            {
                testOutput.Add(someStack.Pop().Item1);
            }

            return testOutput;
        }

        private static byte[] GetListOfPriorities(List<LexerToken> listOfLexerTokens)
        {
            int size = listOfLexerTokens.Count;
            byte[] listOfPriorities = new byte[size];

            object something;
            for(int i = 0;i < size;i++)
            {
                something = listOfLexerTokens[i].something;
                if(listOfLexerTokens[i].type == TokenType.NUMBER)
                {
                    listOfPriorities[i] = byte.MaxValue;
                }
                else
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
            }

            return listOfPriorities;
        }
    }
}
