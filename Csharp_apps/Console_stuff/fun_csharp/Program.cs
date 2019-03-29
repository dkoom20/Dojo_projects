using System;

namespace fun_csharp
{
    class Program
    {
        public static void Main(string[] args)
        {
            //print 1 thru 255
            for (int num = 1; num < 256; num++)
            {
                Console.WriteLine(num);
            }

            //Print numbers divisable by 3 or 5,
            //unless if divisible by both 3 and 5 which 15 represents
            Console.WriteLine("=========================================");

            for (int num = 1; num <= 100; num++)
            {
         //       if(!(num % 15 == 0))
                if(!(num % 3 == 0 && num % 5 == 0))
                {
                    if(num % 3 == 0 || num % 5 == 0)
                    {
                        Console.WriteLine(num);
                    }
                }
                
            }

            //FizzBuzz 
            Console.WriteLine("=========================================");

            for (int num = 1; num <= 100; num++)
            {
                if(num % 3 == 0 && num % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (num % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (num % 5 == 0)
                {
                   Console.WriteLine("Buzz");
                }
            }

            // FizzBuzz without Modulus
            Console.WriteLine("=========================================");

            int multothree = 3;
            int multofive = 5;
            for (int num = 1; num < 101; num++)
            {
                multothree--;
                multofive--;
                if (multothree == 0 && multofive == 0)
                {
                    Console.WriteLine("FizzBuzz");
                    multothree = 3;
                    multofive = 5;
                }
                else if (multothree == 0)
                {
                    Console.WriteLine("Fizz");
                    multothree = 3;
                }
                else if (multofive == 0)
                {
                    Console.WriteLine("Buzz");
                    multofive = 5;
                }
                else
                {
                    Console.WriteLine("nada");
                }
            }

            // Generate 10 random values 1-100 and output Fizz or Buzz
            Console.WriteLine("=========================================");

            Random rand = new Random();
            for (int num = 0; num <= 10; num++){
                int val = rand.Next(1, 100);

                string output = "For attempt " + num + " the value is " + val + " and the word is ";

                if(val % 3 == 0 && val % 5 == 0)
                {
                    output += "FizzBuzz";
                }
                else if (val % 3 == 0)
                {
                    output += "Fizz";
                }
                else if (val % 5 == 0)
                {
                   output += "Buzz";
                } else {
                    output += "Neither";
                }

                Console.WriteLine(output);
            }
        }
    }
}
