using System;

namespace Bingo52on25.Model
{
    internal class BingoGame
    {
        private int _range;
        private int _size;
        private bool[] _drawnNumbers;
        private static Random _rand = new Random();

        public BingoBoard Board { get; internal set; }
        public bool IsOver => Board.IsBingo;

        public BingoGame(int range, int size)
        {
            this._range = range;
            this._size = size;
        }

        internal void StartNewGame()
        {
            Board = new BingoBoard(_range, _size);
            this._drawnNumbers = new bool[_range];
        }

        internal int DrawNextNumber()
        {
            int num;
            do
            {
                num = _rand.Next(_range);
            } while (_drawnNumbers[num]);

            _drawnNumbers[num] = true;
            Board.Mark(num);
            return num; 
        }

    }
}