using System.Collections.Generic;
using Calculator.Lexing;

namespace Calculator.Parsing
{
    static class Parser
    {
        public static List<Token> GetListInPostfixNotation(List<Token> listOfLexerTokens)
        {
            List<Token> listInPOstfixNotation = new List<Token>();

            byte[] listOfPriorities = GetListOfPriorities(listOfLexerTokens);
            Stack<(Token, byte)> stackOfOperators = new Stack<(Token, byte)>();

            for(int i = 0;i < listOfLexerTokens.Count;i++)
            {
                switch(listOfLexerTokens[i].type)
                {
                    case TokenType.OPERATOR_BINARY:
                        while(stackOfOperators.Count > 0 && stackOfOperators.Peek().Item2 <= listOfPriorities[i])
                        {
                            listInPOstfixNotation.Add(stackOfOperators.Pop().Item1);
                        }
                        stackOfOperators.Push((listOfLexerTokens[i], listOfPriorities[i]));
                        break;
                    case TokenType.OPERATOR_POSTFIX:
                    case TokenType.NUMBER:
                        listInPOstfixNotation.Add(listOfLexerTokens[i]);
                        break;
                    case TokenType.BRACKET_OPEN:
                        stackOfOperators.Push((listOfLexerTokens[i], listOfPriorities[i]));
                        break;
                    case TokenType.BRACKET_CLOSE:
                        while(stackOfOperators.Peek().Item1.type != TokenType.BRACKET_OPEN)
                        {
                            listInPOstfixNotation.Add(stackOfOperators.Pop().Item1);
                        }
                        stackOfOperators.Pop();
                        break;
                }
            }
            while(stackOfOperators.Count > 0)
            {
                listInPOstfixNotation.Add(stackOfOperators.Pop().Item1);
            }

            return listInPOstfixNotation;
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
