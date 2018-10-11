using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using TestTask.My;


namespace ConsoleApp3
{
    class Sudoku
    {

        private (int, int) _point;

        public event PropertyChangedEventHandler PropertyChanged;

        private int[][] _sudokuFiled { get; set; }

        public int this[int col, int row]
        {
            get
            {
                return  _sudokuFiled[col][row];
            }

            set
            {
                _sudokuFiled[col][row] = value;
            }
        }

        public  Sudoku()
        {
            _sudokuFiled = new int[9][];
            for (int i = 0; i < _sudokuFiled.Length; i++)
            {
                _sudokuFiled[i] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            }
        }

        public void Start(ApplicationViewModel application)
        {
            if (!IsValid(_sudokuFiled))
                return;
            Solve(_sudokuFiled, application);
        }

        private bool Solve(int[][] arr,ApplicationViewModel application)
        {

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
                    application.OnPropertyChanged("");
                    if (Solve(arr,application))
                    {
                        return true;
                    }
                    arr[row][col] = 0;
                }
            }
            return false;
        }

        private void ShowSuduko(int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }

                Console.WriteLine(Environment.NewLine);
            }
        }

        private static bool IsWin(int[][] arr)
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

    }
}