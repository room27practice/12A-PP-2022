using System;
using System.Linq;

namespace Matrix
{
    internal class Program
    {
        static void Main()
        {
            ZadachaMatrix1();
            // ZadachaJagged1();
            // Zadacha2();
        }

        private static void ZadachaMatrix1()
        {
            int n = int.Parse(Console.ReadLine());//3

            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine(); //11 2 4
                int[] data = input.Split(" ")
                                .Select(x => int.Parse(x))
                                .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            int diag1Sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                diag1Sum += matrix[i, i];
            }
            int diag2Sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                diag2Sum += matrix[row, (matrix.GetLength(1) - 1) - row];
            }
            Console.WriteLine($"Diagonal 1 Sum= {diag1Sum}");
            Console.WriteLine($"Diagonal 2 Sum= {diag2Sum}");
            Console.WriteLine("Difference = " + GetModulValue(diag1Sum, diag2Sum));
            Console.WriteLine(new String('=', 20));
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }

        }

        private static void ZadachaJagged1()
        {
            int n = int.Parse(Console.ReadLine());//3
            int[][] jaggedArray = new int[n][];
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = Console.ReadLine().Split(" ")
                .Select(x => int.Parse(x))
                .ToArray();
            }
            int diag1Sum = 0;
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                diag1Sum += jaggedArray[i][i];
            }
            int diag2Sum = 0;
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                diag2Sum += jaggedArray[row][(jaggedArray.Length - 1) - row];
            }
            Console.WriteLine($"Diagonal 1 Sum= {diag1Sum}");
            Console.WriteLine($"Diagonal 2 Sum= {diag2Sum}");
            Console.WriteLine("Difference = " + GetModulValue(diag1Sum, diag2Sum));

            Console.WriteLine(new String('=', 20));

            foreach (var row in jaggedArray)
            {
                Console.WriteLine(String.Join(" ", row));
            }

        }


        private static int GetModulValue(int a, int b)
        {
            int result = a - b;
            if (result > 0)
            {
                return result;
            }
            return -result;
        }
        private static void Zadacha2()
        {
            throw new NotImplementedException();
        }

    }
}
