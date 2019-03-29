using System;
using System.Collections.Generic;

namespace basic13_csharp
{
    class Program
    {
         // display 1 to 255 
        public static void Disp255() {
            for(int idx = 1; idx <= 255; idx++) {
                Console.WriteLine(idx);
            }
        }

        // display odd numbers from 1 to 255
        public static void DispOdds() {
            for(int idx = 1; idx < 256; idx++) {
                if(idx % 2 == 1) {
                    Console.WriteLine(idx);
                }
            }
        }

        //Print Sum all number between 0 and 255
        //New number: $ Sum: #
        public static void DispSum() {
            int sum = 0;
            for(int num = 0; num <= 255; num++) {
                sum += num; 
                Console.WriteLine($"New Number: {num} Sum: {sum}");
            }
        }

        //Iterate through a passed array
        public static void ArrayIterate(int[] arr) {
            string output = "[";
            for(int idx = 0; idx < arr.Length; idx++) {
                output += arr[idx] + ", ";
            }
            output += "]";
            Console.WriteLine(output);
        }

        //Find max value in an array
        public static void MaxInArray(int[] arr) {
            int max = arr[0];
            foreach(int val in arr){
                if(val > max) {
                    max = val;
                }
            }
            Console.WriteLine("The max value is {0}", max);
        }

        //Get average value of an array
        public static void AvgOfArray(int[] arr) {
            int sum = GetSum(arr);
            Console.WriteLine("This average is " + (double)sum/(double)arr.Length);
        }
        public static int GetSum(int[] arr) {
            int sum = 0;
            for(int num = 0; num < arr.Length; num++) {
                sum += arr[num]; //sum = sum + num
            }
            return sum;
        }

        //Create arr of odd numbers between 1 and 255
        public static int[] CreateOddArray() {
            List<int> oddList = new List<int>();
            for(int val = 1; val <= 255; val++) {
                if(val % 2 == 1) {
                    oddList.Add(val);
                }
            }
            return oddList.ToArray();
        }

        //Count all values greater than theArray
        public static void GreaterThanY(int[] arr, int y) {
            int count = 0;
            foreach(int val in arr){
                if(val > y) {
                    count++;
                }
            }
            Console.WriteLine($"There are {count} values greater than {y}");
        }

        //Square values
        public static void SquareVals(int[] arr) {
            for(int idx = 0; idx < arr.Length; idx++) {
                int orig = arr[idx];
                arr[idx] *= arr[idx];

                Console.WriteLine($"Original value {orig} is now squared to {arr[idx]}");
            }
        }

        //Elimate Negatives
        public static void ReplaceNegatives(int[] arr) {
            for(int idx = 0; idx < arr.Length; idx++) {
                if(arr[idx] < 0) {
                    arr[idx] = 0;
                }
            }
        }

        // find minimum, maximum, and calculate the average
        public static void MinMaxAvg(int[] arr) {
            int sum = 0;
            int min = arr[0];
            int max = arr[0];
            foreach(int val in arr) {
                sum += val;
                if(val < min) {
                    min = val;
                }
                if(val > max) {
                    max = val;
                }
            }
            Console.WriteLine("The max of the array is {0}, the min is {1}, and the average is {2}", max, min, (double)sum/(double)arr.Length);
        }

        //Shift an array to left and add 0 to the end
        public static void ShiftLeft(int[] arr) {
            for(int idx = 0; idx < arr.Length - 1; idx++){
                arr[idx] = arr[idx + 1];
            }
            arr[arr.Length - 1] = 0;
        }

        //replace negatives with "dojo"
        public static object[] NumberToString(object[] arr)
        {
            for(int idx = 0; idx < arr.Length; idx++)
            {
                if((int)arr[idx] < 0)
                {
                    arr[idx] = "Dojo";
                    Console.WriteLine($"value is now {arr[idx]}");
                }
            }
            return arr;
        }
        static void Main(string[] args)
        {
            Disp255();
            DispOdds();
            DispSum();
            int[] theArray = new int[8] {1,3,5,8,9,10,13,22};
            ArrayIterate(theArray);
            MaxInArray(theArray);
            AvgOfArray(theArray);
            CreateOddArray();
            GreaterThanY(theArray, 4);
            SquareVals(theArray);
            ReplaceNegatives(theArray); 
            ShiftLeft(theArray);
            MinMaxAvg(theArray);
            ShiftLeft(theArray);
            object[] ntsArray = new object[] {-1, 3, 2, 4, -16};
            NumberToString(ntsArray);
        }
    }
}
