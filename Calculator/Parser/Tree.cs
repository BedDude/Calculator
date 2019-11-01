using Calculator.Lexing;
using System.Collections.Generic;

namespace Calculator.Parsing
{
    class Tree
    {
        private TreeElement[] _treeElements;

        public TreeElement Root { get; set; }

        public Tree(int size)
        {
            _treeElements = new TreeElement[size];
        }

        public void Create(List<LexerToken> listOfLexerTokens)
        {
            for(int i = 0;i < listOfLexerTokens.Count;i++)
            {
                _treeElements[i] = new TreeElement(listOfLexerTokens[i], i, _treeElements);
            }
            Root = _treeElements[0];
        }
    }
}
