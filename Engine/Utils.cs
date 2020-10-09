using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Engine
{
    public static class Utils
    {
        public static void Swip(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        public static Perestanovka ReadPerestanovka()
        {
            string[] a  = Console.ReadLine().Split(new []{ ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] b = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); ;

            int[,] inp = new int[a.Length, 2];

            for (int x = 0; x < a.Length; x++)
            {
                inp[x, 0] = int.Parse(a[x]);
                inp[x, 1] = int.Parse(b[x]);
            }

            return new Perestanovka(inp);
        }
    }
}
