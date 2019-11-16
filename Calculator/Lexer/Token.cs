namespace Calculator.Lexing
{
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
