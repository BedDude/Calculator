namespace Calculator.Lexing
{
    /// <summary>
    /// Token class
    /// Contains a symbol and symbols type
    /// </summary>
    class Token
    {
        public readonly object something;
        public readonly TokenType type;

        public Token(object something, TokenType type)
        {
            this.something = something;
            this.type = type;
        }
    }
}
