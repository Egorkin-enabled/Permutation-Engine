using System;
using System.Text;
using System.Linq;
using static Engine.Utils;

namespace Engine
{

    public struct Perestanovka : ICloneable
    {



        public int[,] vars;

        public Perestanovka(int[,] v)
            => vars = v;

        public int CalcPoradok()
        {
            int pow = 1;
            var p = (Perestanovka)this.Clone();

            Repeat:
            p.Muilt(this);
            pow++;

            for (int x = 0; x < p.vars.GetLength(0); x++)
                if (p.vars[x, 0] != p.vars[x, 1])
                    goto Repeat;

            return pow;
        }

        public static Perestanovka MakeZero(int length)
        {
            int[,] v = new int[length, 2];

            for (int x = 0; x < length; x++)
                v[x, 0] = v[x, 1] = x + 1;

            return new Perestanovka(v);
        }

        public void Pow(int x)
        {
            if (x < 0)
            {
                MakeNegative();
                x = -x;
            }
            else if (x == 0)
            {
                vars = MakeZero(vars.GetLength(0)).vars;
                return;
            }

            int[,] copy = (int[,])vars.Clone();

            for (int y = 1; y < x; y++)
            {
                for (int z = 0; z < vars.GetLength(0); z++)
                {
                    for (int s = 0; s < vars.GetLength(0); s++)
                    {
                        if (copy[z, 1] == vars[s, 0])
                        {
                            copy[z, 1] = vars[s, 1];
                            break;
                        }
                    }
                }
            }

            vars = copy;
        }

        public void Muilt(Perestanovka p)
        {
            int[,] result = (int[,])vars.Clone();

            for (int x = 0; x < vars.GetLength(0); x++)
            {
                for (int s = 0; s < p.vars.GetLength(0); s++)
                {
                    if (result[x, 1] == p.vars[s, 0])
                    {
                        result[x, 1] = p.vars[s, 1];
                        break;
                    }
                }
            }

            vars = result;
        }

        public void MakeNegative()
        {
            for (int x = 0; x < vars.GetLength(0); x++)
            {
                Swip(ref vars[x, 0], ref vars[x, 1]);
            }
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            for (int y = 0; y < vars.GetLength(1); y++)
            {
                for (int x = 0; x < vars.GetLength(0); x++)
                {
                    b.Append(vars[x, y] + ", ");
                }
                b.Append("\n");
            }

            return b.ToString();
        }

        public object Clone()
        {
            return new Perestanovka((int[,])vars.Clone());
        }
    }
}