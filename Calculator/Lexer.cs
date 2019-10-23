using System.Collections.Generic;

namespace Calculator
{
    public static class Lexer
    {
        public static List<Token> GetListOfTokens(string inputString)
        {
            List<Token> listOfTokens = new List<Token>();
            int nextNumber = 0;

            foreach(var symbol in inputString)
            {
                switch(symbol)
                {
                    case '+':
                        AddNumberInList(ref nextNumber, ref listOfTokens);
                        listOfTokens.Add(new Token(symbol, TokenType.OPERATION_ADD));
                        break;
                    case '-':
                        AddNumberInList(ref nextNumber, ref listOfTokens);
                        listOfTokens.Add(new Token(symbol, TokenType.OPERATION_SUBTRACT));
                        break;
                    case '*':
                        AddNumberInList(ref nextNumber, ref listOfTokens);
                        listOfTokens.Add(new Token(symbol, TokenType.OPERATION_MULTIPLY));
                        break;
                    case '/':
                        AddNumberInList(ref nextNumber, ref listOfTokens);
                        listOfTokens.Add(new Token(symbol, TokenType.OPERATION_DIVISION));
                        break;
                    case '^':
                        AddNumberInList(ref nextNumber, ref listOfTokens);
                        listOfTokens.Add(new Token(symbol, TokenType.OPERATION_POW));
                        break;
                    default:
                        nextNumber = (nextNumber * 10) + (symbol - 48);
                        break;
                }
            }
            AddNumberInList(ref nextNumber, ref listOfTokens);

            return listOfTokens;
        }

        private static void AddNumberInList(ref int number, ref List<Token> list)
        {
            list.Add(new Token(number, TokenType.NUMBER));
            number = 0;
        }
    }
}
