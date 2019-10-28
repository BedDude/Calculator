namespace Calculator.Parser
{
    class ParserToken
    {
        public readonly object something;
        public readonly byte priority;

        public ParserToken(object something, byte priority)
        {
            this.something = something;
            this.priority = priority;
        }
    }
}
