using System;

namespace Warmups.BLL
{
    public class Arrays
    {
        public bool FirstLast6(int[] numbers)
        {
            //Given an array of ints, 
            //return true if 6 appears as either the first or last element in the array. 
            //The array will be length 1 or more. 

            string str = "";
            bool firstLast = false;

            for (int i = 0; i < numbers.Length; ++i)
            {
                str += numbers[i];
            }
            if (str.StartsWith("6") || str.EndsWith("6"))
            {
                firstLast = true;
            }

            return firstLast;
        }

        public bool SameFirstLast(int[] numbers)
        {
            //Given an array of ints, return true if the array is length 1 or more, 
            //and the first element and the last element are equal. 

            return (numbers.Length > 0 && numbers[0] == numbers[numbers.Length - 1]);




        }
        public int[] MakePi(int n)
        {
            //Return an int array length n containing the first n digits of pi.

            int[] numb = new int[6];
            int[] toReturn = new int[n];

            numb[0] = 3;
            numb[1] = 1;
            numb[2] = 4;
            numb[3] = 1;
            numb[4] = 5;
            numb[5] = 9;
            for (int i = 0; i < n; ++i)
            {
                toReturn[i] = numb[i];
            }

            return toReturn;
        }

        public bool CommonEnd(int[] a, int[] b)
        {
            //Given 2 arrays of ints, a and b, 
            //return true if they have the same first element 
            //or they have the same last element. Both arrays will be length 1 or more. 

            return (a[0] == b[0] || a[a.Length - 1] == b[b.Length - 1]);


        }

        public int Sum(int[] numbers)
        {
            //Given an array of ints, return the sum of all the elements.

            int sum = 0;

            for (int i = 0; i < numbers.Length; ++i)
            {
                sum += numbers[i];
            }

            return sum;
        }


        public int[] RotateLeft(int[] numbers)
        {
            //Given an array of ints, 
            //return an array with the elements "rotated left" 
            //so {1, 2, 3} yields {2, 3, 1}.

            int[] rotateLeft = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; ++i)
            {
                rotateLeft[i] = numbers[i];
            }
            for (int i = 1; i < numbers.Length; ++i)
            {
                rotateLeft[i - 1] = numbers[i];
            }
            rotateLeft[rotateLeft.Length - 1] = numbers[0];

            return rotateLeft;
        }

        //Given an array of ints length 3, return a new array with the elements in reverse order, 
        //so for example {1, 2, 3} becomes {3, 2, 1}. 

        public int[] Reverse(int[] numbers)
        {
            int[] reverse = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; ++i)
            {
                reverse[i] = numbers[numbers.Length - 1 - i];
            }

            return reverse;
        }

        public int[] HigherWins(int[] numbers)
        {
            //Given an array of ints, 
            //figure out which is larger between the first and last elements in the array, 
            //and set all the other elements to be that value.Return the changed array. 

            int[] higherWins = new int[numbers.Length];

            if (numbers[0] > numbers[numbers.Length - 1])
            {
                for (int i = 0; i < numbers.Length; ++i)
                {
                    higherWins[i] = numbers[0];
                }
            }

            else
            {
                for (int i = 0; i < numbers.Length; ++i)
                {
                    higherWins[i] = numbers[numbers.Length - 1];
                }
            }

            return higherWins;
        }

        public int[] GetMiddle(int[] a, int[] b)
        {
            //Given 2 int arrays, a and b, each length 3, 
            //return a new array length 2 containing their middle elements. 

            int[] sum = new int[2];

            sum[0] = a[1];
            sum[1] = b[1];

            return sum;
        }

        public bool HasEven(int[] numbers)
        {
            //Given an int array, 
            //return true if it contains an even number(HINT: Use Mod(%)). 

            bool hasEven = false;

            for (int i = 0; i < numbers.Length; ++i)
            {
                if (numbers[i] % 2 == 0)
                {
                    hasEven = true;
                }
            }

            return hasEven;
        }

        public int[] KeepLast(int[] numbers)
        {
            //Given an int array, 
            //return a new array 
            //with double the length where its last element is the same as the original array, 
            //and all the other elements are 0. The original array will be length 1 or more. 
            //Note: by default, a new int array contains all 0's. 

            int[] keepLast = new int[numbers.Length * 2];

            if (numbers.Length > 1)
            {
                keepLast[keepLast.Length - 1] = numbers[(numbers.Length - 1)];
            }

            else keepLast[1] = numbers[0];

            return keepLast;
        }

        public bool Double23(int[] numbers)
        {
            //Given an int array, return true if the array contains 2 twice, or 3 twice. 

            int threeCount = 0;
            int twoCount = 0;

            for (int i = 0; i < numbers.Length; ++i)
            {
                if (numbers[i] == 2)
                {
                    ++twoCount;
                }
                if (numbers[i] == 3)
                {
                    ++threeCount;
                }

            }

            return (threeCount == 2) || (twoCount == 2);
        }

        public int[] Fix23(int[] numbers)
        {
            //Given an int array length 3, 
            //if there is a 2 in the array immediately followed by a 3, 
            //set the 3 element to 0. Return the changed array. 

            for (int i = 1; i < numbers.Length; ++i)
            {
                if (numbers[i - 1] == 2)
                {
                    if (numbers[i] == 3)
                    {
                        numbers[i] = 0;
                    }
                }
            }

            return numbers;          
        }

        public bool Unlucky1(int[] numbers)
        {
            //We'll say that a 1 immediately followed by a 3 in an array is an "unlucky" 1. 
            //Return true if the given array contains an unlucky 1 in the first 2 or last 2 positions in the array. 

            return
                (((numbers[0] == 1) || numbers[1] == 1) && ((numbers[1] == 3) || numbers[2] == 3))

                ||

                ((numbers[numbers.Length - 2] == 1) && (numbers[numbers.Length - 1] == 3));
        }

        public int[] Make2(int[] a, int[] b)
        {
            //Given 2 int arrays, a and b, 
            //return a new array length 2 containing, 
            //as much as will fit, the elements from a followed by the elements from b. 
            //The arrays may be any length, including 0, 
            //but there will be 2 or more elements available between the 2 arrays. 

            int[] make2 = new int[2];
            int[] aAndB = new int[a.Length + b.Length];

            for (int i = 0; i < a.Length; ++i)
            {
                aAndB[i] = a[i];
            }
            for (int i = 0; i < b.Length; ++i)
            {
                aAndB[a.Length + i] = b[i];
            }

            make2[0] = aAndB[0];
            make2[1] = aAndB[1];

            return make2;
        }
    }
}
