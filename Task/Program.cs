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
            Perestanovka a = ReadPerestanovka();

            WriteLine("Enter b:");
            Perestanovka b = ReadPerestanovka();

            WriteLine();

            // a^(-1)
            WriteLine("a^(-1)");
            var aCopy = (Perestanovka)a.Clone();
            aCopy.Pow(-1);
            WriteLine(aCopy);

            //b^(-2)
            WriteLine("b^(-2)");
            var bCopy = (Perestanovka)b.Clone();
            bCopy.Pow(-2);
            WriteLine(bCopy);

            //a * b
            WriteLine("a*b");
            aCopy = (Perestanovka)a.Clone();
            bCopy = (Perestanovka)b.Clone();

            aCopy.Muilt(bCopy);
            WriteLine(aCopy);

            //b * a
            WriteLine("b*a");
            aCopy = (Perestanovka)a.Clone();
            bCopy = (Perestanovka)b.Clone();

            bCopy.Muilt(aCopy);
            WriteLine(bCopy);

            //a^3
            WriteLine("a^3");
            aCopy = (Perestanovka)a.Clone();
            aCopy.Pow(3);
            WriteLine(aCopy);

            //b^4
            WriteLine("b^4");
            bCopy = (Perestanovka)b.Clone();
            bCopy.Pow(4);
            WriteLine(bCopy);

            //a^55
            WriteLine("a^55");
            aCopy = (Perestanovka)a.Clone();
            aCopy.Pow(55);
            WriteLine(aCopy);

            //b^-99
            WriteLine("b^(-99)");
            bCopy = (Perestanovka)b.Clone();
            bCopy.Pow(-99);
            WriteLine(bCopy);

            //Calc poradok
            Write("порядок a равен ");
            WriteLine(a.CalcPoradok());


            Write("порядок b равен ");
            //b.MakeNegative();
            WriteLine(b.CalcPoradok());

            WriteLine();
            WriteLine("All fine. Repeat? (y/n)");
            if (ReadLine().Trim() == "y")
                goto Repeat;

            
        }
    }
}
