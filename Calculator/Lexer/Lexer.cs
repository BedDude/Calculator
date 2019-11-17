using System.Collections.Generic;

namespace Calculator.Lexing
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
                else if(listOfTokens.Count > 0 && listOfTokens[listOfTokens.Count - 1].type == TokenType.OPERATOR_POSTFIX)
                {
                    listOfTokens.Add(new Token(symbol, TokenType.OPERATOR_BINARY));
                }
                else
                {
                    AddNumberInList(ref nextNumber, ref listOfTokens, isNegativeNumber);
                    if(symbol == '-')
                    {
                        if(char.IsDigit(previousSymbol))
                        {
                            listOfTokens.Add(new Token(symbol, TokenType.OPERATOR_BINARY));
                        }
                        else
                        {
                            isNegativeNumber = true;
                        }
                    }
                    else if(symbol == '!')
                    {
                        listOfTokens.Add(new Token(symbol, TokenType.OPERATOR_POSTFIX));
                    }
                    else
                    {
                        listOfTokens.Add(new Token(symbol, TokenType.OPERATOR_BINARY));
                        isNegativeNumber = false;
                    }
                }

                previousSymbol = symbol;
            }
            if(listOfTokens[listOfTokens.Count - 1].type == TokenType.OPERATOR_BINARY)
            {
                AddNumberInList(ref nextNumber, ref listOfTokens, isNegativeNumber);
            }

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