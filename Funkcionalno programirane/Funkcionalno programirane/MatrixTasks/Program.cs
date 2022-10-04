using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixTasks
{
    internal class Program
    {
        static int subMatrixSizeRows = 2;
        static int subMatrixSizeCols = 2;
        static void Main()
        {
            Task3();
        }

        public static void Task3()
        {
            int rows = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .First();                  //44 5

            int[][] jagged = new int[rows][];

            ReadInput(jagged);

            int[][] result = GetSubMatrixes(jagged, subMatrixSizeRows, subMatrixSizeCols)
                .OrderByDescending(m => GetJaggedSum(m)).First();


            PrintResults(result);
        }

        private static void PrintResults(int[][] result)
        {
            Console.WriteLine("Sum = " + GetJaggedSum(result));
            foreach (var row in result)
            {
                Console.WriteLine(String.Join(" ", row));
            }
        }

        private static void ReadInput(int[][] jag)
        {
            for (int i = 0; i < jag.Length; i++)
            {
                jag[i] = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            }
        }

        private static List<int[][]> GetSubMatrixes(int[][] jagged, int miniRow, int miniCol)
        {
            var result = new List<int[][]>();
            for (int rows = 0; rows <= jagged.Length - miniRow; rows++)
            {
                for (int cols = 0; cols <= jagged[0].Length - miniCol; cols++)
                {
                    int[][] current = new int[miniRow][];
                    for (int r = 0; r < miniRow; r++)
                    {
                        current[r] = jagged[rows + r].Skip(cols).Take(miniCol).ToArray();
                    }
                    result.Add(current);
                }
            }
            return result;
        }

        private static int GetJaggedSum(int[][] jag)
        {
            return jag.Select(row => row.Sum()).Sum();
        }

    }
}