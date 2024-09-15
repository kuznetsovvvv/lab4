using System;
using System.Numerics;

namespace CsharpProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите число 1:");
            string input = Console.ReadLine(); // Читаем строку с клавиатуры

            int l;
            if (!int.TryParse(input, out l))
            {
                Console.WriteLine("Неверный ввод. Введите целое число.");
                return;
            }

            Console.WriteLine("Введите число 2:");
            string input2 = Console.ReadLine(); // Читаем строку с клавиатуры

            int k;
            if (!int.TryParse(input2, out k))
            {
                Console.WriteLine("Неверный ввод. Введите целое число.");
                return;
            }

            if (l >= k)
            {
                Console.WriteLine("Минимальное число должно быть меньше максимального.");
                return;
            }

            MyMatrix obj = new(3, 2, l, k);

            obj.Print();
            MyMatrix obj1 = new(3, 2, l, k);
            obj1.Print();
            MyMatrix obj2 = obj + obj1;
            obj2.Print();
            MyMatrix obj3 = obj * obj1;
            obj3.Print();
            Console.WriteLine(obj.matrix[1, 1]);
            int value = obj[1, 1]; // индексирование
        }
    }

    public class MyMatrix
    {
        public int[,] matrix;
        public int m;
        public int n;

        public MyMatrix(int m, int n)
        {
            this.m = m;
            this.n = n;
            this.matrix = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }

        public MyMatrix(int m, int n, int l, int k)
        {
            this.m = m;
            this.n = n;
            this.matrix = new int[m, n];

            Random random = new Random();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int r = random.Next(l, k);
                    matrix[i, j] = r;
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < m; i++)
            {
                Console.Write("(");
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " "); 
                }
                Console.Write(")");
                Console.WriteLine(); 
            }
            Console.WriteLine();
        }


        public static MyMatrix operator +(MyMatrix a, MyMatrix b)
        {
            MyMatrix obj = new MyMatrix(3,2);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    obj.matrix[i, j] = a.matrix[i, j] + b.matrix[i, j];
                }
            }


            return obj;
        }

        public static MyMatrix operator -(MyMatrix a, MyMatrix b)
        {
            MyMatrix obj = new MyMatrix(3, 2);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    obj.matrix[i, j] = a.matrix[i, j] - b.matrix[i, j];
                }
            }


            return obj;
        }


        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            MyMatrix obj = new MyMatrix(3, 2);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {

                    obj.matrix[i, j] = a.matrix[i, j] * b.matrix[i, j];
                }
            }
            return obj;
        }

        public static MyMatrix operator *(MyMatrix a,int r)
        {
            MyMatrix obj = new MyMatrix(3, 2);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {

                    obj.matrix[i, j] = a.matrix[i, j] * r;
                }
            }
            return obj;
        }

        public static MyMatrix operator /(MyMatrix a, int r)
        {
            MyMatrix obj = new MyMatrix(3, 2);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {

                    obj.matrix[i, j] = a.matrix[i, j] / r;
                }
            }
            return obj;
        }




        public int this[int m, int n]
        {
            get
            {
                return this.matrix[m, n];
            }
        }

    }





}
