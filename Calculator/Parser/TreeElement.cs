using Calculator.Lexing;

namespace Calculator.Parsing
{
    class TreeElement
    {
        private readonly TreeElement[] _treeElements;
        private readonly int _position;
        private readonly int _left;
        private readonly int _right;

        public LexerToken Token { get; }
        public TreeElement Left => _treeElements[_left];
        public TreeElement Right => _treeElements[_right];

        public TreeElement(LexerToken token, TreeElement[] elements, (int, int, int) coordinate)
        {
            Token = token;
            _treeElements = elements;
            _position = coordinate.Item1;
            _left = coordinate.Item2;
            _right = coordinate.Item3;
        }
    }
}
