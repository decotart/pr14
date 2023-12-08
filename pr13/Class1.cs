using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr13
{
    public class Soluiton
    {
        /// <summary>
        /// находит номер последнего столбца, содержащего равное количество положительных и отрицательных элементов
        /// </summary>
        /// <param name="matrix">матрица</param>
        /// <returns>номер последнего столбца, содержащего равное количество положительных и отрицательных элементов</returns>
        public static int GetResult(int[,] matrix)
        {
            int count1, count2, result = 0;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                count1 = 0; count2 = 0;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] < 0) count1++;
                    else count2++;
                }

                if (count1 == count2) result = j + 1;
            }

            return result;
        }
    }

    public class ArrayMod
    {
        public static void FillRandon(ref int[,] matrix)
        {
            Random rnd = new();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(-10, 10);
                }
            }
        }

        public static void Save(int[,] mas)
        {
            SaveFileDialog save = new();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";

            if (save.ShowDialog() == true)
            {
                StreamWriter file = new(save.FileName);
                file.WriteLine(mas.GetLength(0));
                file.WriteLine(mas.GetLength(1));

                foreach (int i in mas)
                {
                    file.WriteLine(i);
                }
                file.Close();
            }
        }

        public static int[,]? Open()
        {
            OpenFileDialog open = new();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";

            if (open.ShowDialog() == true)
            {
                StreamReader file = new(open.FileName);

                int length1 = Convert.ToInt32(file.ReadLine());
                int length2 = Convert.ToInt32(file.ReadLine());

                int[,] mas = new int[length1, length2];

                for (int i = 0; i < length1; i++)
                {
                    for (int j = 0; j < length2; j++)
                    {
                        mas[i, j] = Convert.ToInt32(file.ReadLine());
                    }
                }
                file.Close();
                return mas;
            }
            return null;

        }

    }

    public static class VisualArray
    {
        public static DataTable ToDataTable<T>(this T[] arr)
        {
            var res = new DataTable();
            for (int i = 0; i < arr.Length; i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }
            var row = res.NewRow();
            for (int i = 0; i < arr.Length; i++)
            {
                row[i] = arr[i];
            }
            res.Rows.Add(row);
            return res;
        }
        public static DataTable ToDataTable<T>(this T[,] matrix)
        {
            var res = new DataTable();
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row[j] = matrix[i, j];
                }

                res.Rows.Add(row);
            }

            return res;
        }
    }
}