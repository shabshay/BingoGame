using System;

namespace Bingo52on25.Model
{
    public class BingoBoard
    {
        private int _range;
        private int _size;

        private BingoCell[,] _cells;
        private BingoCell[] _cellsByValueIndex;

        private int _maxCounterValue;
        private int[] _columnsCounters;
        private int[] _rowsCounters;
        private int _diagCounter1;
        private int _diagCounter2;

        private static Random rand = new Random();

        public bool IsBingo => _maxCounterValue == _size;

        public BingoBoard(int range, int size)
        {
            this._range = range;
            this._size = size;
            this._diagCounter1 = 0;
            this._diagCounter2 = 0;
            this._maxCounterValue = 0;
            this._columnsCounters = new int[size];
            this._rowsCounters = new int[size];

            CreateCells();
        }

        public BingoCell this[int row, int column]
        {
            get
            {
                return _cells[row, column];
            }
        }

        private void CreateCells()
        {
            this._cellsByValueIndex = new BingoCell[_range];
            this._cells = new BingoCell[_size, _size];
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    int randNum = GetNextCellNumber();
                    var cell = new BingoCell(randNum, i, j);

                    this._cells[i, j] = cell;
                    this._cellsByValueIndex[randNum] = cell;
                }
            }
        }

        private int GetNextCellNumber()
        {
            int num;

            do
            {
                num = rand.Next(_range);
            } while (WasDrawn(num));
            
            return num;
        }

        private bool WasDrawn(int num)
        {
            return _cellsByValueIndex[num] != null;
        }

        internal void Mark(int num)
        {
            var cell = _cellsByValueIndex[num];
            if (cell != null)
            {
                cell.Mark();
                UpdateCounters(cell.Row, cell.Column);
            }
        }

        private void UpdateCounters(int row, int column)
        {
            this._rowsCounters[row]++;
            this._columnsCounters[column]++;
            if (IsDiag1(row, column))
            {
                this._diagCounter1++;
            }

            if (IsDiag2(row, column))
            {
                this._diagCounter2++;
            }

            UpdateMaxCounter(row, column);
        }

        private void UpdateMaxCounter(int row, int column)
        {
            this._maxCounterValue =
                            Math.Max(_maxCounterValue, Math.Max(
                            Math.Max(_diagCounter1, _diagCounter2),
                            Math.Max(_rowsCounters[row], _columnsCounters[column])));
        }

        private bool IsDiag2(int row, int column)
        {
            return (row + column == _size - 1);
        }

        private bool IsDiag1(int row, int column)
        {
            return row == column;
        }
    }
}