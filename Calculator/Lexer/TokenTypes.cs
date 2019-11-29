namespace Calculator.Lexing
{
    /// <summary>
    /// Enumeration of sumbols types
    /// </summary>
    enum TokenType
    {
        NUMBER,
        OPERATOR_BINARY,
        OPERATOR_POSTFIX,
        BRACKET_OPEN,
        BRACKET_CLOSE
    }
}