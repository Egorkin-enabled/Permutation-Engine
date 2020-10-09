using System;
using System.Text;
using System.Linq;
using static Engine.Utils;

namespace Engine
{

    /// <summary>
    /// Представляет собой порядок.
    /// </summary>
    public struct Permutation : ICloneable
    {
        private int[,] vars;

        public Permutation(int[,] v)
        {
            if (v == null)
                throw new ArgumentNullException();
            else if (v.GetLength(1) != 2)
                throw new ArgumentException("Height must be equals 2.");

            vars = v;
        }

        /// <summary>
        /// Вычисляет порядок.
        /// </summary>
        /// <returns>Порядок перестановки.</returns>
        public int CalcOrder()
        {
            int pow = 1;
            var p = (Permutation)this.Clone();

            Repeat:
            p = p.Muilt(this);
            pow++;

            for (int x = 0; x < p.vars.GetLength(0); x++)
                if (p.vars[x, 0] != p.vars[x, 1])
                    goto Repeat;

            return pow;
        }

        /// <summary>
        /// Создает еденичную перестановку.
        /// </summary>
        /// <param name="length">длинна еденичной перестановки.</param>
        /// <returns></returns>
        public static Permutation MakeSingularPermutation(int length)
        {
            int[,] v = new int[length, 2];

            for (int x = 0; x < length; x++)
                v[x, 0] = v[x, 1] = x + 1;

            return new Permutation(v);
        }

        /// <summary>
        /// Возводит перестановку в степень.
        /// </summary>
        /// <param name="x">степень перестановки.</param>
        /// <returns></returns>
        public Permutation Pow(int x)
        {
            Permutation result = this;

            if (x < 0)
            {
                result = result.MakeNegative();
                x = -x;
            }
            else if (x == 0)
                return MakeSingularPermutation(vars.GetLength(0));

            int[,] copy = (int[,])vars.Clone();

            for (int y = 1; y < x; y++)
                    result = result.Muilt(this);

            return result;
        }

        /// <summary>
        /// Умножает подстановки.
        /// </summary>
        /// <param name="p">Та на которую умнажаем.</param>
        /// <returns></returns>
        public Permutation Muilt(Permutation p)
        {
            int[,] result = (int[,])p.vars.Clone();

            for (int s = 0; s < p.vars.GetLength(0); s++)
            {
                for (int x = 0; x < vars.GetLength(0); x++)
                {
                    if (p.vars[x, 1] == vars[s, 0])
                    {
                        result[x, 1] = vars[s, 1];
                        break;
                    }
                }
            }

            return new Permutation(result);
        }

        /// <summary>
        /// Переворачивает подстановку.
        /// </summary>
        /// <returns></returns>
        public Permutation MakeNegative()
        {
            Permutation result = (Permutation)this.Clone();

            for (int x = 0; x < result.vars.GetLength(0); x++)
            {
                Swip(ref result.vars[x, 0], ref result.vars[x, 1]);
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();

            int numLength = 0;

            for (int y = 0; y < vars.GetLength(1); y++)
                for (int x = 0; x < vars.GetLength(0); x++)
                    numLength = Math.Max(vars[x, y].ToString().Length, numLength);

            for (int y = 0; y < vars.GetLength(1); y++)
            {
                b.Append('|');

                for (int x = 0; x < vars.GetLength(0); x++)
                {
                    string val = vars[x, y].ToString();

                    for (int z = val.Length; z < numLength; z++)
                        b.Append(" ");

                    b.Append(val);
                    b.Append(", ");
                }

                b.Length -= 2;
                b.Append("|\n");
            }

            return b.ToString();
        }

        public object Clone()
            => new Permutation((int[,])vars.Clone());

        public int this[int x, int y] => vars[x, y];

        public int Length => vars.GetLength(0);

        public static Permutation operator *(Permutation a, Permutation b)
            => a.Muilt(b);

        public static Permutation operator ^(Permutation a, int pow)
            => a.Pow(pow);

        public static Permutation operator ~(Permutation a)
            => a.MakeNegative();
    }
}