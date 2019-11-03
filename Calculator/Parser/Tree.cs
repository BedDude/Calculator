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
            Queue<int> queueOfNumbersPositions = new Queue<int>();
            (int, int, int) coordinate;

            int centralPosition;
            for(int i = 0;i < listOfLexerTokens.Count;i++)
            {
                coordinate.Item1 = i;
                if(listOfLexerTokens[i].type == TokenType.NUMBER)
                {
                    coordinate.Item2 = int.MinValue;
                    coordinate.Item3 = int.MinValue;
                    queueOfNumbersPositions.Enqueue(i);
                }
                else
                {
                    if(queueOfNumbersPositions.Count == 0)
                    {
                        centralPosition = i;
                    }
                    else
                    {
                        centralPosition = queueOfNumbersPositions.Dequeue();
                    }
                    coordinate.Item2 = centralPosition * 2 + 1;
                    coordinate.Item3 = centralPosition * 2 + 2;
                }

                _treeElements[i] = new TreeElement(listOfLexerTokens[i], _treeElements, coordinate);
            }

            queueOfNumbersPositions.Clear();
            Root = _treeElements[0];
        }
    }
}
