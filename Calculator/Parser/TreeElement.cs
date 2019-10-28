using Calculator.Lexer;

namespace Calculator.Parser
{
    class TreeElement
    {
        public TreeElement Left { get; set; }
        public TreeElement Right { get; set; }
        public LexerToken Token { get; }

        public TreeElement(LexerToken token)
        {
            Token = token;
            Left = null;
            Right = null;
        }
    }
}
