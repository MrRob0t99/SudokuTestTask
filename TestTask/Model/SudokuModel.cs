using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleApp3
{
    class Sudoku
    {
        public static (int, int) point;

        static int[][] S(int[][] arr)
        {
            //int[][] sudokuFiled = new int[9][];
            //sudokuFiled[0] = new int[] { 0, 0, 0, 6, 2, 0, 9, 1, 0 };
            //sudokuFiled[1] = new int[] { 1, 4, 0, 0, 0, 0, 6, 0, 0 };
            //sudokuFiled[2] = new int[] { 2, 0, 6, 8, 0, 0, 0, 0, 0 };
            //sudokuFiled[3] = new int[] { 4, 0, 8, 0, 0, 9, 0, 6, 0 };
            //sudokuFiled[4] = new int[] { 0, 0, 0, 0, 0, 0, 0, 4, 9 };
            //sudokuFiled[5] = new int[] { 0, 6, 0, 4, 0, 0, 0, 0, 1 };
            //sudokuFiled[6] = new int[] { 0, 0, 4, 0, 0, 0, 0, 0, 8 };
            //sudokuFiled[7] = new int[] { 0, 0, 0, 1, 0, 5, 4, 0, 6 };
            //sudokuFiled[8] = new int[] { 0, 2, 1, 0, 8, 0, 5, 0, 0 };
            if (!IsValid(arr))
                return null;
            if (Solve(arr))
                return null;
            return arr;
        }

        static bool Solve(int[][] arr)
        {
            if (IsWin(arr) && IsValid(arr))
                return true;

            point = GetZeroPoint(arr);
            int row = point.Item1;
            int col = point.Item2;

            for (int num = 1; num <= 9; num++)
            {
                if (IsValid(arr))
                {
                    arr[row][col] = num;

                    if (Solve(arr))
                    {
                        return true;
                    }
                    arr[row][col] = 0;
                }
            }
            return false;
        }

        static void ShowSuduko(int[][] arr)
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

        static bool IsWin(int[][] arr)
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

        static bool IsValid(int[][] arr)
        {
            return IsValidByHorizontal(arr) && IsValidByVertical(arr) && IsValidBox(arr);
        }

        static (int, int) GetZeroPoint(int[][] arr)
        {
            for (int row = 0; row < arr.Length; row++)
                for (int col = 0; col < arr[row].Length; col++)
                    if (arr[row][col] == 0)
                    {
                        return (row, col);
                    }
            return (9, 9);
        }

        static bool IsValidByHorizontal(int[][] arr)
        {
            var res = arr.All(a => IsValidList(a.ToList()));
            return res;
        }

        static bool IsValidByVertical(int[][] arr)
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

        static bool IsValidBox(int[][] arr)
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

        static bool IsValidList(List<int> list)
        {
            var listWithoutZero = list.Where(i => i != 0).ToList();
            return listWithoutZero.Count == listWithoutZero.Distinct().Count();
        }
    }
}