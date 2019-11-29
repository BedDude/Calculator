using System.Collections.Generic;

namespace Calculator.Lexing
{
    /// <summary>
    /// Lexer class
    /// Used to create a list of tokens
    /// </summary>
    static class Lexer
    {
        /// <summary>
        /// Splits the input string into tokens
        /// </summary>
        /// <param name="inputString">Input character sequence</param>
        /// <returns>List of tokens</returns>
        public static List<Token> GetListOfTokens(string inputString)
        {
            List<Token> listOfTokens = new List<Token>();
            int nextNumber = 0;

            bool isNegativeNumber = false;
            char previousSymbol = char.MinValue;
            Token lastElementInList = new Token(0, TokenType.NUMBER);
            bool veryImportantBool = true;
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
                        veryImportantBool = lastElementInList.type != TokenType.OPERATOR_POSTFIX && lastElementInList.type != TokenType.BRACKET_CLOSE;
                    }

                    switch(symbol)
                    {
                        case '(':
                            listOfTokens.Add(new Token(symbol, TokenType.BRACKET_OPEN));
                            break;
                        case ')':
                            if(veryImportantBool)
                            {
                                AddNumberInList(ref nextNumber, ref listOfTokens, isNegativeNumber);
                            }
                            listOfTokens.Add(new Token(symbol, TokenType.BRACKET_CLOSE));
                            break;
                        case '!':
                            if(veryImportantBool)
                            {
                                AddNumberInList(ref nextNumber, ref listOfTokens, isNegativeNumber);
                            }
                            listOfTokens.Add(new Token(symbol, TokenType.OPERATOR_POSTFIX));
                            break;
                        case '-':
                            if(!char.IsDigit(previousSymbol) && previousSymbol != '!' && previousSymbol != ')')
                            {
                                isNegativeNumber = true;
                            }
                            else
                            {
                                if(veryImportantBool)
                                {
                                    AddNumberInList(ref nextNumber, ref listOfTokens, isNegativeNumber);
                                }
                                listOfTokens.Add(new Token(symbol, TokenType.OPERATOR_BINARY));
                            }
                            break;
                        default:
                            if(veryImportantBool)
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

        /// <summary>
        /// Adds a number to list
        /// </summary>
        /// <param name="number">Number to insert into list</param>
        /// <param name="list">List of tokens</param>
        /// <param name="isNegativeNumber">Flag for number negativity</param>
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