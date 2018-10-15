using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TestTask.My;

namespace ConsoleApp3
{
    class Sudoku
    {
        #region Private Field

        private (int, int) _point;
        private ApplicationViewModel _applicationViewModel;
        private CancellationToken _cancellationToken;
        private int[][] _sudokuFiled;
        private bool _isUpdate;
        
        #endregion

        #region Ctor

        public Sudoku()
        {
            Clean();
        }

        #endregion

        #region Indexer

        public int this[int col, int row]
        {
            get
            {
                return _sudokuFiled[col][row];
            }

            set
            {
                _sudokuFiled[col][row] = value;
            }
        }

        #endregion

        #region Public Method

        public void Clean()
        {
            _sudokuFiled = new int[9][];
            for (int i = 0; i < _sudokuFiled.Length; i++)
            {
                _sudokuFiled[i] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            }
        }

        public int Start(ApplicationViewModel application, bool IsStep, CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;
            _applicationViewModel = application;
            _isUpdate = IsStep;
            if (!IsValid(_sudokuFiled))
                return 0;
            if (!Solve(_sudokuFiled) && !_cancellationToken.IsCancellationRequested)
                return 0;
            if (_cancellationToken.IsCancellationRequested)
                return 1;
            _applicationViewModel.OnPropertyChanged();
            return 2;
        }

        #endregion

        #region Private Method

        private bool Solve(int[][] arr)
        {
            if (_cancellationToken.IsCancellationRequested)
                return false;

            if (IsWin(arr) && IsValid(arr))
                return true;

            _point = GetZeroPoint(arr);
            int row = _point.Item1;
            int col = _point.Item2;

            for (int num = 1; num <= 9; num++)
            {
                if (IsValid(arr))
                {
                    arr[row][col] = num;

                    if (_isUpdate)
                        _applicationViewModel.OnPropertyChanged();

                    if (Solve(arr))
                    {
                        return true;
                    }
                    arr[row][col] = 0;

                    if (_isUpdate)
                        _applicationViewModel.OnPropertyChanged();
                }

                if (_isUpdate)
                    Thread.Sleep(2);
            }
            return false;
        }

        private bool IsWin(int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] == 0)
                        return false;
                }
            }

            return true;
        }

        private bool IsValid(int[][] arr)
        {
            return IsValidByHorizontal(arr) && IsValidByVertical(arr) && IsValidBox(arr);
        }

        private (int, int) GetZeroPoint(int[][] arr)
        {
            for (int row = 0; row < arr.Length; row++)
                for (int col = 0; col < arr[row].Length; col++)
                    if (arr[row][col] == 0)
                    {
                        return (row, col);
                    }
            return (9, 9);
        }

        private bool IsValidByHorizontal(int[][] arr)
        {
            var res = arr.All(a => IsValidList(a.ToList()));
            return res;
        }

        private bool IsValidByVertical(int[][] arr)
        {
            var list = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    list.Add(arr[j][i]);
                }

                if (!IsValidList(list))
                    return false;
                list = new List<int>();
            }
            return true;
        }

        private bool IsValidBox(int[][] arr)
        {
            var list = new List<int>();
            var res = new List<int>();
            var box_start_rpw = 0;
            int box_start_col = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        list.Add(arr[row + box_start_rpw][col + box_start_col]);
                    }
                }
                box_start_col += 3;
                if (box_start_col == 9)
                    box_start_col = 0;
                if (i % 3 != 0)
                    box_start_rpw += 3;
                if (box_start_rpw == 9)
                    box_start_rpw = 0;
                if (!IsValidList(list))
                    return false;
                res = list;
                list = new List<int>();
            }
            return true;
        }

        private bool IsValidList(List<int> list)
        {
            var listWithoutZero = list.Where(i => i != 0).ToList();
            return listWithoutZero.Count == listWithoutZero.Distinct().Count();
        }

        #endregion
    }
}