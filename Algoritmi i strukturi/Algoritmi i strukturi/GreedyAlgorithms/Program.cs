using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedyAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Greedy.Egyption();
            
            /*Искаме една колекция от числа да я подредим 
              по възходящ ред от най-голямо към най малко число.
           С всяка стъпка ще се доближавам до решението. 
             */

            int[] nums = { 1, 5, 2, 76, 43, 21, 9, 3 };
            //искам 76,43,21,9,5,3,2,1
            int[] result = new int[nums.Length]; //[0 0 0 0 0 0 0 0]

            List<int> numsCopy = nums.ToList();

            int localMax = int.MinValue;
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < numsCopy.Count(); j++)
                {
                    if (localMax >= numsCopy[j])
                    {
                        continue;
                    }
                    localMax = numsCopy[j];
                }

                result[i] = localMax;
                numsCopy.Remove(localMax);
                localMax = int.MinValue;
            }
            Console.WriteLine(String.Join(" ; ",result));

        }
    }
}
