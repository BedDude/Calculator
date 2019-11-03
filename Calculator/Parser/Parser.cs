using System.Collections.Generic;
using Calculator.Lexing;

namespace Calculator.Parsing
{
    static class Parser
    {
        public static Tree GetTree(List<LexerToken> listOfLexerTokens)
        {
            Tree tree = new Tree(listOfLexerTokens.Count);

            byte[] parserTokens = GetListOf(listOfLexerTokens);


            return tree;
        }

        private static byte[] GetListOf(List<LexerToken> listOfLexerTokens)
        {
            int size = listOfLexerTokens.Count;
            byte[] listOf = new byte[size];

            object something;
            for(int i = 0;i < size;i++)
            {
                something = listOfLexerTokens[i].something;
                if(listOfLexerTokens[i].type == TokenType.NUMBER)
                {
                    listOf[i] = byte.MaxValue;
                }
                else
                {
                    switch(listOfLexerTokens[i].something)
                    {
                        case '^':
                            listOf[i] = 0;
                            break;
                        case '*':
                        case '/':
                            listOf[i] = 1;
                            break;
                        default:
                            listOf[i] = 2;
                            break;
                    }
                }
            }

            return listOf;
        }
    }
}
