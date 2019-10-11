using System;

namespace Bingo52on25.Model
{
    public class BingoCell
    {
        public bool IsMarked { get; private set; }
        public int Value { get; private set; }
        public int Row { get; private set; }
        public int Column { get; private set; }

        public BingoCell(int randNum, int row, int column)
        {
            this.Value = randNum;
            this.IsMarked = false;
            this.Row = row;
            this.Column = column;
        }

        internal void Mark()
        {
            IsMarked = true;
        }
    }
}