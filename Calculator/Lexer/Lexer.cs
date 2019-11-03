using System.Collections.Generic;

namespace Calculator.Lexing
{
    static class Lexer
    {
        public static List<LexerToken> GetListOfTokens(string inputString)
        {
            List<LexerToken> listOfTokens = new List<LexerToken>();
            int nextNumber = 0;

            bool isNegativeNumber = false;
            char previousSymbol = char.MinValue;
            foreach(var symbol in inputString)
            {
                if(char.IsDigit(symbol))
                {
                    nextNumber = (nextNumber * 10) + (symbol - 48);
                }
                else if(symbol == '-')
                {
                    if(char.IsDigit(previousSymbol))
                    {
                        AddNumberInList(ref nextNumber, ref listOfTokens, isNegativeNumber);
                        listOfTokens.Add(new LexerToken(symbol, TokenType.OPERATOR));
                    }
                    else
                    {
                        isNegativeNumber = true;
                    }
                }
                else
                {
                    AddNumberInList(ref nextNumber, ref listOfTokens, isNegativeNumber);
                    listOfTokens.Add(new LexerToken(symbol, TokenType.OPERATOR));
                    isNegativeNumber = false;
                }

                previousSymbol = symbol;
            }
            AddNumberInList(ref nextNumber, ref listOfTokens, isNegativeNumber);

            return listOfTokens;
        }

        private static void AddNumberInList(ref int number, ref List<LexerToken> list, bool isNegativeNumber)
        {
            if(isNegativeNumber)
            {
                number *= -1;
            }

            list.Add(new LexerToken(number, TokenType.NUMBER));
            number = 0;
        }
    }
}