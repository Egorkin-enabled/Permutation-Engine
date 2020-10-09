using Engine;
using static Engine.Utils;
using static System.Console;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Repeat:
            //Enter data
            WriteLine("Enter a:");
            Permutation a = ReadPermutation();

            WriteLine("Enter b:");
            Permutation b = ReadPermutation();

            WriteLine();

            // a^(-1)
            WriteLine("a^(-1)");
            WriteLine(a ^ -1);

            //b^(-2)
            WriteLine("b^(-2)");
            WriteLine(b ^ -2);

            //a * b
            WriteLine("a*b");
            WriteLine(a * b);

            //b * a
            WriteLine("b*a");
            WriteLine(b * a);

            //a^3
            WriteLine("a^3");
            WriteLine(a ^ 3);

            //b^4
            WriteLine("b^4");
            WriteLine(b ^ 4);

            //a^55
            WriteLine("a^55");
            WriteLine(a ^ 55);

            //b^-99
            WriteLine("b^(-99)");
            WriteLine(b ^ -99);

            //Calc poradok
            Write("order of a is ");
            WriteLine(a.CalcOrder());


            Write("order of b is ");
            //b.MakeNegative();
            WriteLine(b.CalcOrder());

            WriteLine();
            WriteLine("All fine. Repeat? (y/n)");
            if (ReadLine().Trim() == "y")
                goto Repeat;


        }
    }
}
