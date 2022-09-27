using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAlgorithms
{
    public static class Greedy
    {
        public static void Egyption()
        {
            Console.WriteLine("Iput decimal in format [a/b]");
            string input = Console.ReadLine();//     5/8
            decimal[] numbers = input.Split('/')
                .Select(num => decimal.Parse(num))
                .ToArray();

            List<int> resultDelimiters = new List<int>();

            decimal value = numbers[0] / numbers[1];
            int delimiter = 1;

            while (value > 0)
            {
                delimiter++;
                if (value >= 1m / delimiter)
                {
                    resultDelimiters.Add(delimiter);
                    value -= 1m / delimiter;
                }
            }

            Console.WriteLine("1/"+String.Join("+1/", resultDelimiters));
        }

    }
}
