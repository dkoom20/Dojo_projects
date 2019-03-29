using System;
using System.Collections.Generic;

namespace collections_csharp
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] intArray = new int[10] {0,1,2,3,4,5,6,7,8,9};
            string[] nameArray = new string[] {"Tim", "Martin", "Nikki", "Sara"};
            bool[] boolArray = new bool[10];
            for(int idx = 0; idx < 10; idx += 2)
            {
                boolArray[idx] = true;
            }
            for(int idx = 1; idx < 10; idx += 2)
            {
                boolArray[idx] = false;
            }

            //=============================================================================================

            // two dimensional Multiplication table
            int[,] mtable = new int[10,10];
            for(int xx = 0; xx < 10; xx++)
            {
                for(int yy = 0; yy < 10; yy++)
                {
                    mtable[xx, yy] = (xx + 1) * (yy + 1);
                }
            }

            // display the multiplication table
            for(int xx = 0; xx < 10; xx++)
            {
                string display1 = "[ ";
                for(int yy = 0; yy < 10; yy++)
                {
                    display1 += mtable[xx, yy] + ", ";
                }
                display1 += "]";
                Console.WriteLine(display1);
            }

            //=============================================================================================


            //List icecreams
            List<string> icecreams = new List<string>();
            icecreams.Add("Chocolate");
            icecreams.Add("Vanilla");
            icecreams.Add("Mint Chip");
            icecreams.Add("Cookie Dough");
            icecreams.Add("Cookies n Creme");
            icecreams.Add("Black Cherry");
            icecreams.Add("Tootie Frootie");
            icecreams.Add("Strawberry");


            //How many listed ice cream flavors
            string display2 = "How many icecreams: ";
            display2 += icecreams.Count;
            Console.WriteLine(display2);


            //display the 3rd flavor, then remove it
            Console.WriteLine("Third flavor is: " + icecreams[2]);
            icecreams.RemoveAt(2);

            //How many listed ice cream flavors now
            string display3 = "How many icecreams: ";
            display3 += icecreams.Count;
            Console.WriteLine(display3);
            
            //=============================================================================================

            // build dict with name and favorite ice cream (randomly selected)
            Dictionary<string, string> userInfo = new Dictionary<string,string>();
            Random rand = new Random();
            foreach(string name in nameArray)
            {
                userInfo[name] = icecreams[rand.Next(icecreams.Count)];
            }

            // display the Dictionary
            Console.WriteLine("Users and their favor ice cream:");
            foreach(KeyValuePair<string, string> info in userInfo)
            {
                Console.WriteLine(info.Key + " - " + info.Value);
            }
        }
    }
}
