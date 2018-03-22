using System;
using static System.Math;

namespace Warmups.BLL
{
    public class Loops
    {
        //Given a string and a non-negative int n, return a larger string that is n copies of the original string. 

        //StringTimes("Hi", 2) -> "HiHi"
        //StringTimes("Hi", 3) -> "HiHiHi"
        //StringTimes("Hi", 1) -> "Hi"

        public string StringTimes(string str, int n)
        {
            string stringTimes = "";

            for (int i = 0; i < n; i++)
            {
                stringTimes += str;
            }

            return stringTimes;       
        }

        //Given a string and a non-negative int n, we'll say that the front of the string is the first 3 chars, 
        //or whatever is there if the string is less than length 3. Return n copies of the front; 

        //FrontTimes("Chocolate", 2) -> "ChoCho"
        //FrontTimes("Chocolate", 3) -> "ChoChoCho"
        //FrontTimes("Abc", 3) -> "AbcAbcAbc"

        public string FrontTimes(string str, int n)
        {
            string frontTimes = "";
            string frontPart = "";

            if (str.Length >= 3)
            {
                frontPart = str.Substring(0, 3);
                for (int i = 0; i < n; i++)
                {

                    frontTimes += frontPart;

                }

            }
            else for (int i = 0; i < n; i++)
                {

                    frontTimes += str;

                }

            return frontTimes;          
        }

        //Count the number of "xx" in the given string. We'll say that overlapping is allowed, so "xxx" contains 2 "xx". 

        //CountXX("abcxx") -> 1
        //CountXX("xxx") -> 2
        //CountXX("xxxx") -> 3


        public int CountXX(string str)
        {

            int countXX = 0;
            int startLength = str.Length;

            for (int i = 0; i < startLength - 1; i++)
            {
                if (str.Substring(0, 2) == "xx")
                {
                    countXX++;
                    str = str.Remove(0, 1);
                }
                else str = str.Remove(0, 1);
            }

            return countXX;   
        }

        //Given a string, return true if the first instance of "x" in the string is immediately followed by another "x". 

        //DoubleX("axxbb") -> true
        //DoubleX("axaxxax") -> false
        //DoubleX("xxxxx") -> true


        public bool DoubleX(string str)
        {
            return (str.Contains("x") && (str.IndexOf("x") == str.IndexOf("xx")));            
        }

        //Given a string, return a new string made of every other char starting with the first, so "Hello" yields "Hlo". 

        //EveryOther("Hello") -> "Hlo"
        //EveryOther("Hi") -> "H"
        ////EveryOther("Heeololeo") -> "Hello"

        public string EveryOther(string str)
        {
            string everyOther = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (i % 2 == 0)
                {
                    everyOther += str.Substring(i, 1);
                }
            }

            return everyOther;             
        }

        //Given a non-empty string like "Code" return a string like "CCoCodCode".  (first char, first two, first 3, etc)

        //StringSplosion("Code") -> "CCoCodCode"
        //StringSplosion("abc") -> "aababc"
        //StringSplosion("ab") -> "aab"

        public string StringSplosion(string str)
        {
            string stringSplosion = "";
            for (int i = 0; i < str.Length; i++)
            {
                stringSplosion += str.Substring(0, i + 1);
            }
            return stringSplosion;       
        }

        //Given a string, 
        //return the count of the number of times that a substring length 2 appears in the string and also as the last 2 chars of the string, 
        //so "hixxxhi" yields 1 (we won't count the end substring). 

        //CountLast2("hixxhi") -> 1
        //CountLast2("xaxxaxaxx") -> 1
        //CountLast2("axxxaaxx") -> 2

        public int CountLast2(string str)
        {
            int count = 0;

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str.EndsWith(str.Substring(i, 2)))
                {
                    count++;
                }
            }

            return count - 1;
        }


        //Given an array of ints, return the number of 9's in the array. 

        //Count9({ 1, 2, 9}) -> 1
        //Count9({ 1, 9, 9}) -> 2
        //Count9({ 1, 9, 9, 3, 9}) -> 3

        public int Count9(int[] numbers)
        {
            int count9 = 0;

            for (int i = 0; i < numbers.Length; ++i)
            {
                if (numbers[i] == 9)
                {
                    count9++;
                }
            }

            return count9;          
        }

        //Given an array of ints, return true if one of the first 4 elements in the array is a 9. 
        //The array length may be less than 4. 

        //ArrayFront9({ 1, 2, 9, 3, 4}) -> true
        //ArrayFront9({ 1, 2, 3, 4, 9}) -> false
        //ArrayFront9({ 1, 2, 3, 4, 5}) -> false

        public bool ArrayFront9(int[] numbers)
        {
            bool arrayFront9 = false;

            if (numbers.Length > 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (numbers[i] == 9)
                    {
                        arrayFront9 = true;
                    }

                }
            }
            else
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] == 9)
                    {
                        arrayFront9 = true;
                    }

                }
            }

            return arrayFront9;           
        }

        //Given an array of ints, return true if .. 1, 2, 3, .. appears in the array somewhere.

        //Array123({1, 1, 2, 3, 1}) -> true
        //Array123({ 1, 1, 2, 4, 1}) -> false
        //Array123({ 1, 1, 2, 1, 2, 3}) -> true

        public bool Array123(int[] numbers)
        {
            string strNumbers = "";

            for (int i = 0; i < numbers.Length; i++)
            {
                strNumbers += numbers[i];
            }

            return strNumbers.Contains("123");             
        }

        //Given 2 strings, a and b, return the number of the positions where they contain the same length 2 substring.
        //So "xxcaazz" and "xxbaaz" yields 3, since the "xx", "aa", and "az" substrings appear in the same place in both strings.

        //SubStringMatch("xxcaazz", "xxbaaz") -> 3
        //SubStringMatch("abc", "abc") -> 2
        //SubStringMatch("abc", "axc") -> 0

        public int SubStringMatch(string a, string b)
        {
            int subStringMatch = 0;
            string useStr = "";

            if (a.Length < b.Length)
            {
                useStr = a;
            }
            else useStr = b;


            for (int i = 0; i < useStr.Length - 1; i++)
            {
                if (a.Substring(i, 2) == b.Substring(i, 2))
                {
                    subStringMatch++;
                }
            }

            return subStringMatch;           
        }

        //Given a string, return a version where all the "x" have been removed.
        //Except an "x" at the very start or end should not be removed.

        //StringX("xxHxix") -> "xHix"
        //StringX("abxxxcd") -> "abcd"
        //StringX("xabxxxcdx") -> "xabcdx"


        public string StringX(string str)
        {
            string stringX = str;

            if (str.EndsWith("x"))
            {
                stringX = str.Replace("x", "") + "x";
            }
            if (str.StartsWith("x"))
            {
                stringX = "x" + str.Replace("x", "");
            }
            if (str.StartsWith("x") && str.EndsWith("x"))
            {
                stringX = "x" + str.Replace("x", "") + "x";
            }
            else stringX = str.Replace("x", "");

            return stringX;       
        }

        //Given a string, return a string made of the chars at indexes 0,1, 4,5, 8,9 ... so "kittens" yields "kien". 

        //AltPairs("kitten") -> "kien"
        //AltPairs("Chocolate") -> "Chole"
        //AltPairs("CodingHorror") -> "Congrr"

        public string AltPairs(string str)
        {
            string altPairs = "";
            for (int i = 0; i < str.Length - 1; ++i)
            {
                if (i % 4 == 0)
                    altPairs += str.Substring(i, 2);
            }
     
            if (str.Length % 2 != 0)
            {
                altPairs += str.Substring(str.Length - 1);

            }

            return altPairs;          
        }

        //Suppose the string "yak" is unlucky. Given a string, return a version where all the "yak" are removed, 
        //but the "a" can be any char. The "yak" strings will not overlap.

        //DoNotYak("yakpak") -> "pak"
        //DoNotYak("pakyak") -> "pak"
        //DoNotYak("yak123ya") -> "123ya"

        public string DoNotYak(string str)
        {
            string doNotYak = str;

            for (int i = 2; i < str.Length; i++)
            {
                if (str.Substring(i, 1) == "k")
                {
                    if (str.Substring(i - 2, 1) == "y")
                    {
                        doNotYak = str.Remove(i - 2, 3);
                    }
                }
            }

            return doNotYak;      
        }

        //Given an array of ints, return the number of times that two 6's are next to each other in the array. 
        //Also count instances where the second "6" is actually a 7. 

        //Array667({ 6, 6, 2}) -> 1
        //Array667({ 6, 6, 2, 6}) -> 1
        //Array667({ 6, 7, 2, 6}) -> 1

        public int Array667(int[] numbers)
        {
            int array667 = 0;
            string str = "";

            for (int i = 0; i < numbers.Length; i++)
            {
                str += numbers[i];
            }

            for (int i = numbers.Length; i > 0; i--)
            {
                if (str.EndsWith("66") || str.EndsWith("67"))
                {
                    array667++;
                    str = str.Remove(str.Length - 1);
                }
                else str = str.Remove(str.Length - 1);
            }

            return array667;             
        }

        public bool NoTriples(int[] numbers)
        {
            bool noTripples = true;
            

            for (int i =0; i < numbers.Length-2; i++)
            {
                if (numbers[i]==numbers[i+1]&& numbers[i + 1] == numbers[i + 2])
                {
                    noTripples = false;
                }
            }

            return noTripples;       
        }

        public bool Pattern51(int[] numbers)
        {
            bool noTripples = false;

            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i] == (numbers[i + 1]-5) && numbers[i + 1]-6 == numbers[i + 2])
                {
                    noTripples = true;
                }
            }

            return noTripples;       
        }
    }
}
