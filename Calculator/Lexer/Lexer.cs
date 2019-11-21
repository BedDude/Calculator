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
            Token lastElementInList = new Token(0, TokenType.NUMBER);
            bool YWSMTh = true;
            foreach(var symbol in inputString)
            {
                if(char.IsDigit(symbol))
                {
                    nextNumber = (nextNumber * 10) + (symbol - 48);
                }
                else
                {
                    if(listOfTokens.Count > 0)
                    {
                        lastElementInList = listOfTokens[listOfTokens.Count - 1];
                        YWSMTh = lastElementInList.type != TokenType.OPERATOR_POSTFIX;
                    }

                    switch(symbol)
                    {
                        case '!':
                            if(YWSMTh)
                            {
                                AddNumberInList(ref nextNumber, ref listOfTokens, isNegativeNumber);
                            }
                            listOfTokens.Add(new Token(symbol, TokenType.OPERATOR_POSTFIX));
                            break;
                        case '-':
                            if(!char.IsDigit(previousSymbol))
                            {
                                isNegativeNumber = true;
                            }
                            else
                            {
                                if(YWSMTh)
                                {
                                    AddNumberInList(ref nextNumber, ref listOfTokens, isNegativeNumber);
                                }
                                listOfTokens.Add(new Token(symbol, TokenType.OPERATOR_BINARY));
                            }
                            break;
                        default:
                            if(YWSMTh)
                            {
                                AddNumberInList(ref nextNumber, ref listOfTokens, isNegativeNumber);
                            }
                            listOfTokens.Add(new Token(symbol, TokenType.OPERATOR_BINARY));
                            isNegativeNumber = false;
                            break;
                    }
                }

                previousSymbol = symbol;
            }
            if(listOfTokens.Count == 0 || listOfTokens[listOfTokens.Count - 1].type == TokenType.OPERATOR_BINARY)
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