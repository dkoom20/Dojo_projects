using System;
using System.Collections.Generic;

namespace boxunbox_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create list - oneList
            List<object> oneList = new List<object>();

            oneList.Add(7);
            oneList.Add(28);
            oneList.Add(-1);
            oneList.Add(true);
            oneList.Add("chair");

            //display all values / add all those that are type interface int
            int sum = 0;
            foreach(var obj in oneList) {
                Console.WriteLine(obj);
                if(obj is int) {
                    sum += (int)obj;
                }
            }
            Console.WriteLine("Sum of all the integers: {0}", sum);
        }
    }
}
