using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kek
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Расширенный алгоритм Евклида\n");

            while (true)
            {
                int a, b;

                Console.WriteLine("Введите целое большее число\n");
                string inputA = Console.ReadLine();

                Console.WriteLine("Введите второе целое число\n");
                string inputB = Console.ReadLine();

                if (Int32.TryParse(inputA, out a) && (Int32.TryParse(inputB, out b)) && (a > b))
                {
                    EOA(a, b);
                }
                else
                {
                    Console.WriteLine("Ошибка: неверно заданы данные");
                }
            }
        }

        static void EOA(int aA, int bB)
        {
            List<int> A = new List<int>() { aA };
            List<int> B = new List<int>() { bB };
            List<int> mod = new List<int>();
            List<int> div = new List<int>();

            while (aA % bB != 0)
            {
                int C = aA % bB;
                mod.Add(C);

                div.Add(aA / bB);

                aA = bB;
                A.Add(aA);

                bB = C;
                B.Add(bB);

            }
            mod.Add(aA % bB);
            div.Add(aA / bB);

            List<int> x = new List<int>();
            List<int> y = new List<int>();

            for (int i = 0; i < B.Count - 1; i++)
            {
                x.Add(0);
                y.Add(0);
            }

            x.Insert(B.Count - 1, 0);
            y.Insert(B.Count - 1, 1);

            for (int i = B.Count - 2; i >= 0; i--)
            {
                x[i] = y[i + 1];
                y[i] = x[i + 1] - y[i + 1] * div[i];
            }


            Console.WriteLine("A\t B\t A mod B\t A div B\t x\t y\t");
            for (int i = 0; i < B.Count(); i++)
            {
                Console.WriteLine("{0}\t {1}\t {2}\t\t {3}\t\t {4}\t {5}\t", A[i], B[i], mod[i], div[i], x[i], y[i]);
            }

            Console.WriteLine("{0}*{1} + {2}*{3} = {4}", A[0], x[0], B[0], y[0], B[B.Count - 1]);

            Console.ReadKey();
            System.Environment.Exit(0);
        }
    }
}
