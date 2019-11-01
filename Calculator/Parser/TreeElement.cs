using Calculator.Lexing;

namespace Calculator.Parsing
{
    class TreeElement
    {
        private readonly TreeElement[] _treeElements;
        private int _position;
        
        public LexerToken Token { get; }
        public TreeElement Left => _treeElements[2 * _position + 1];
        public TreeElement Right => _treeElements[2 * _position + 2];

        public TreeElement(LexerToken token, int position, TreeElement[] elements)
        {
            Token = token;
            _position = position;
            _treeElements = elements;
        }
    }
}
