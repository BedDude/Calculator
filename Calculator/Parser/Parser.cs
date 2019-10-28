using System.Collections.Generic;
using Calculator.Lexer;

namespace Calculator.Parser
{
    static class Parser
    {
        public static Tree GetTree(List<LexerToken> listOfLexerTokens)
        {
            ParserToken[] parserTokens = GetListOf(listOfLexerTokens);

            return new Tree();
        }

        private static ParserToken[] GetListOf(List<LexerToken> listOfLexerTokens)
        {
            int size = listOfLexerTokens.Count;
            ParserToken[] parserTokens = new ParserToken[size];

            object something;
            for(int i = 0;i < size;i++)
            {
                something = listOfLexerTokens[i].something;
                if(listOfLexerTokens[i].type == TokenType.NUMBER)
                {
                    parserTokens[i] = new ParserToken(something, byte.MaxValue);
                }
                else
                {
                    switch(listOfLexerTokens[i].something)
                    {
                        case '^':
                            parserTokens[i] = new ParserToken(something, 0);
                            break;
                        case '*':
                        case '/':
                            parserTokens[i] = new ParserToken(something, 1);
                            break;
                        default:
                            parserTokens[i] = new ParserToken(something, 2);
                            break;
                    }
                }
            }

            return parserTokens;
        }
    }
}
