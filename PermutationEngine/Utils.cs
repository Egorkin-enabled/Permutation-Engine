using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PermutationEngine
{
    /// <summary>
    /// Содержит методы утилиты.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Меняет местами два объекта.
        /// </summary>
        public static void Swip<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

        /// <summary>
        /// Читает с консоли перестановку.
        /// </summary>
        /// <returns></returns>
        public static Permutation ReadPermutationFromConsole()
        {
            string[] a  = Console.ReadLine().Split(new []{ ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] b = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); ;

            int[,] inp = new int[a.Length, 2];

            for (int x = 0; x < a.Length; x++)
            {
                inp[x, 0] = int.Parse(a[x]);
                inp[x, 1] = int.Parse(b[x]);
            }

            return new Permutation(inp);
        }
    }
}
