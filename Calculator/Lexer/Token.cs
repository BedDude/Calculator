namespace Calculator.Lexing
{
    class LexerToken
    {
        public readonly object something;
        public readonly TokenType type;

        public LexerToken(object something, TokenType type)
        {
            this.something = something;
            this.type = type;
        }
    }
}
