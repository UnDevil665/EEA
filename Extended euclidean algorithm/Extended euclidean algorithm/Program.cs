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
                string flag = "";

                while (!Equals(flag, "1") && !Equals(flag, "2"))
                {
                    Console.Write("Для выбора 1 примера введите 1.\nДля выбора 2 примера, введите 2.\n\nВвод: ");
                    flag = Console.ReadLine();

                    if ((Equals(flag, "1") || Equals(flag, "2")))
                    {
                        Console.WriteLine("\nВыбран пример {0}\n", flag);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\nОшибка: неверно заданы данные\n");
                    }

                }

                int a, b;

                Console.Write("Введите первое число: ");
                string inputA = Console.ReadLine();

                Console.Write("\nВведите второе число: ");
                string inputB = Console.ReadLine();

                if (Int32.TryParse(inputA, out a) && (Int32.TryParse(inputB, out b)) && (a != b))
                {
                    if (a < b)
                    {
                        int c = a;
                        a = b;
                        b = c;
                    }

                    EOA(a, b, flag);
                }
                else
                {
                    Console.WriteLine("\nОшибка: неверно заданы данные\n");
                }
            }
        }

        static void EOA(int aA, int bB, string flag)
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


            Console.WriteLine("\nA\t B\t A mod B\t A div B\t x\t y\t\n-----------------------------------------------------------");
            for (int i = 0; i < B.Count(); i++)
            {
                Console.WriteLine("{0}\t {1}\t {2}\t\t {3}\t\t {4}\t {5}\t", A[i], B[i], mod[i], div[i], x[i], y[i]);
            }

            if (Equals(flag, "1"))
                Console.WriteLine("{0}*{1} + {2}*{3} = {4}", A[0], x[0], B[0], y[0], B[B.Count - 1]);
            else
                Console.WriteLine("d = y mod phi(n) = {0} mod {1} = {2}", y[0], A[0], (y[0] % A[0]));
            Console.WriteLine("\nДля завершения работы программы нажмите любую клавишу");
            Console.ReadKey();
            System.Environment.Exit(0);
        }
    }
}
