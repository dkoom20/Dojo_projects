using System;
using System.Collections.Generic;
using System.Linq;

namespace puzzles_csharp
{
    class Program
    {
        public static int[] RandomArray()
        {
            Random rand = new Random();
            int[] nbrArray = new int[10];
            int sum = 0;
            for(int idx = 0; idx < nbrArray.Length; idx++) {
                int val = rand.Next(5,26);
                nbrArray[idx] = val;
                sum += val;
            }
            Console.WriteLine("Maximum value: {0}", nbrArray.Max());
            Console.WriteLine("Minimum value: {0}", nbrArray.Min());
            Console.WriteLine("Sum of all values: {0}", sum);
            return nbrArray;
        }

        public static string TossCoin()
        {
            Random rand = new Random();
            Console.WriteLine("Tossing a Coin!");
            string tossResult = "Tails";
            if(rand.NextDouble() >= .5) {
                tossResult = "Heads";
            }
            Console.WriteLine(tossResult);
            return tossResult;
        }

        public static Double TossMultipleCoins(int num)
        {
            int nbrHeads = 0;
            for(int reps = 0; reps < num; reps++){
                if(TossCoin() == "Heads"){
                    nbrHeads++;
                }
            }
            return (double)nbrHeads/(double)num;
        }

        public static string[] Names()
        {
            string[] names = new string[5] {"Todd","Tiffany","Charlie","Geneva","Sydney"};
            List<string> n5List = new List<string>();

            Random rand = new Random();
            for(var idx = 0; idx < names.Length - 1; idx++){
                int randIdx = rand.Next(idx + 1, names.Length - 1);
                string temp = names[idx];

                names[idx] = names[randIdx];
                names[randIdx] = temp;
                Console.WriteLine(names[idx]);


                if (names[idx].Length > 4) {    
                    n5List.Add(names[idx]);
                    Console.WriteLine("greater than 5 names: {0}", names[idx]);
                }

            }
            Console.WriteLine(names[names.Length - 1]);

            if (names[names.Length - 1].Length > 4) {
                    Console.WriteLine("greater than 5 names: {0}", names[names.Length - 1]);
            }

            return n5List.ToArray();
        }

        static void Main(string[] args)
        {
            TossCoin();
        	RandomArray();
            TossMultipleCoins(8);
            Names();
        }
    }
}
