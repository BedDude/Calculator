namespace Calculator.Lexer
{
    class Token
    {
        public object something;
        public TokenType type;

        public Token(object something, TokenType type)
        {
            this.something = something;
            this.type = type;
        }
    }
}
