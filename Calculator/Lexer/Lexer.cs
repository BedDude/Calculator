using System.Collections.Generic;

namespace Calculator.Lexer
{
    static class Lexer
    {
        public static List<Token> GetListOfTokens(string inputString)
        {
            List<Token> listOfTokens = new List<Token>();
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
                        listOfTokens.Add(new Token(symbol, TokenType.OPERATOR));
                    }
                    else
                    {
                        isNegativeNumber = true;
                    }
                }
                else
                {
                    AddNumberInList(ref nextNumber, ref listOfTokens, isNegativeNumber);
                    listOfTokens.Add(new Token(symbol, TokenType.OPERATOR));
                    isNegativeNumber = false;
                }

                previousSymbol = symbol;
            }
            AddNumberInList(ref nextNumber, ref listOfTokens, isNegativeNumber);

            return listOfTokens;
        }

        private static void AddNumberInList(ref int number, ref List<Token> list, bool isNegativeNumber)
        {
            if(isNegativeNumber)
            {
                number *= -1;
            }

            list.Add(new Token(number, TokenType.NUMBER));
            number = 0;
        }
    }
}