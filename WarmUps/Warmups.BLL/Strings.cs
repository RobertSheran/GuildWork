using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            return "Hello " + name + "!";
        }

        //Given two strings, a and b, return the result of putting them together in the order abba, e.g. 
        //"Hi" and "Bye" returns "HiByeByeHi". 

        //Abba("Hi", "Bye") -> "HiByeByeHi"
        //Abba("Yo", "Alice") -> "YoAliceAliceYo"
        //Abba("What", "Up") -> "WhatUpUpWhat"


        public string Abba(string a, string b)
        {
            return (a + b + b + a);            
        }
        //The web is built with HTML strings like "<i>Yay</i>" which draws Yay as italic text.In this example, 
        //the "i" tag makes <i> and</i> which surround the word "Yay". Given tag and word strings, 
        //create the HTML string with tags around the word, e.g. "<i>Yay</i>". 

        //MakeTags("i", "Yay") -> "<i>Yay</i>"
        //MakeTags("i", "Hello") -> "<i>Hello</i>"
        //MakeTags("cite", "Yay") -> "<cite>Yay</cite>"

        public string MakeTags(string tag, string content)
        {
            string makeTags = "<" + tag + ">" + content + "</" + tag + ">";

            return makeTags;     
        }

        //Given an "out" string length 4, such as "<<>>", and a word, 
        //return a new string where the word is in the middle of the out string, e.g. "<<word>>".

        //Hint: Substrings are your friend here

        //InsertWord("<<>>", "Yay") -> "<<Yay>>"
        //InsertWord("<<>>", "WooHoo") -> "<<WooHoo>>"
        //InsertWord("[[]]", "word") -> "[[word]]"

        public string InsertWord(string container, string word)
        {
            string insertWord = (container.Insert((container.Length / 2), word));

            return insertWord;          
        }

        //Given a string, return a new string made of 3 copies of the last 2 chars of the original string. 
        //The string length will be at least 2. 

        //MultipleEndings("Hello") -> "lololo"
        //MultipleEndings("ab") -> "ababab"
        //MultipleEndings("Hi") -> "HiHiHi"



        public string MultipleEndings(string str)
        {
            string multipleEndings = "";
            string last2 = str.Substring(str.Length - 2);

            multipleEndings = last2 + last2 + last2;

            return multipleEndings;       
        }
        //Given a string of even length, return the first half. So the string "WooHoo" yields "Woo". 

        //FirstHalf("WooHoo") -> "Woo"
        //FirstHalf("HelloThere") -> "Hello"
        //FirstHalf("abcdef") -> "abc"
        public string FirstHalf(string str)
        {
            return str.Remove((str.Length / 2));             
        }
        //Given a string, return a version without the first and last char, so "Hello" yields "ell". 
        //The string length will be at least 2. 

        //TrimOne("Hello") -> "ell"
        //TrimOne("java") -> "av"
        //TrimOne("coding") -> "odin"

        public string TrimOne(string str)
        {
            string trimOne = "";

            trimOne = str.Substring(1, str.Length - 2);

            return trimOne;
        }

        //Given 2 strings, a and b, return a string of the form short+long+short, 
        //with the shorter string on the outside and the longer string on the inside.
        //The strings will not be the same length, but they may be empty (length 0). 

        //LongInMiddle("Hello", "hi") -> "hiHellohi"
        //LongInMiddle("hi", "Hello") -> "hiHellohi"
        //LongInMiddle("aaa", "b") -> "baaab"

        public string LongInMiddle(string a, string b)
        {
            string longInMiddle = "";
            string longer = "";
            string shorter = "";

            if (a.Length > b.Length)
            {
                longer = a;
                shorter = b;
            }
            else
            {
                longer = b;
                shorter = a;
            }
            longInMiddle = shorter + longer + shorter;

            return longInMiddle;
        }

        //Given a string, return a "rotated left 2" version where the first 2 chars are moved to the end.
        //The string length will be at least 2. 

        //Rotateleft2("Hello") -> "lloHe"
        //Rotateleft2("java") -> "vaja"
        //Rotateleft2("Hi") -> "Hi"

        public string RotateLeft2(string str)
        {
            string rotateLeft2 = "";

            if (str.Length <= 2)
            {
                rotateLeft2 = str;
            }

            else
            {
                string lastSection = str.Substring(2);
                string first2 = str.Remove(2);
                rotateLeft2 = lastSection + first2;

            }

            return rotateLeft2;
        }

        //Given a string, return a "rotated right 2" version where the last 2 chars are moved to the start.
        //The string length will be at least 2. 

        //RotateRight2("Hello") -> "loHel"
        //RotateRight2("java") -> "vaja"
        //RotateRight2("Hi") -> "Hi"

        public string RotateRight2(string str)
        {
            string last2 = "";
            string fistSection = "";
            string rotateRight2 = "";

            if (str.Length <= 2)
            {
                rotateRight2 = str;
            }
            else
            {
                last2 = str.Substring(str.Length - 2);
                fistSection = str.Remove(str.Length - 2);
                rotateRight2 = last2 + fistSection;
            }

            return rotateRight2;           
        }

        //Given a string, return a string length 1 from its front, unless front is false, 
        //in which case return a string length 1 from its back.The string will be non-empty.

        //TakeOne("Hello", true) -> "H"
        //TakeOne("Hello", false) -> "o"
        //TakeOne("oh", true) -> "o"


        public string TakeOne(string str, bool fromFront)
        {
            string takeOne;

            if (fromFront)
            {
                takeOne = str.Remove(1);
            }
            else
            {
                takeOne = str.Remove(0, str.Length - 1);
            }

            return takeOne;
        }

        //Given a string of even length, return a string made of the middle two chars, 
        //so the string "string" yields "ri". The string length will be at least 2. 

        //MiddleTwo("string") -> "ri"
        //MiddleTwo("code") -> "od"
        //MiddleTwo("Practice") -> "ct"

        public string MiddleTwo(string str)
        {
            string middleTwo = str.Substring((str.Length / 2) - 1, 2);

            return middleTwo;         
        }

        //Given a string, return true if it ends in "ly". 

        //EndsWithLy("oddly") -> true
        //EndsWithLy("y") -> false
        //EndsWithLy("oddy") -> false

        public bool EndsWithLy(string str)
        {
            bool endsWthLy = false;

            if (str.Length >= 2)
            {
                if (str.Substring(str.Length - 2) == "ly")
                {
                    endsWthLy = true;
                }
            }
            return endsWthLy;           
        }

        //Given a string and an int n, return a string made of the first and last n chars from the string. 
        //The string length will be at least n.

        //FrontAndBack("Hello", 2) -> "Helo"
        //FrontAndBack("Chocolate", 3) -> "Choate"
        //FrontAndBack("Chocolate", 1) -> "Ce"


        public string FrontAndBack(string str, int n)
        {
            string frontAndBack;

            string frontN = str.Remove(n);
            string backN = str.Substring(str.Length - n);

            frontAndBack = frontN + backN;
            return frontAndBack;             
        }

        //Given a string and an index, return a string length 2 starting at the given index.
        //If the index is too big or too small to define a string length 2, use the first 2 chars.
        //The string length will be at least 2.

        //TakeTwoFromPosition("java", 0)-> "ja"
        //TakeTwoFromPosition("java", 2)-> "va"
        //TakeTwoFromPosition("java", 3)-> "ja"

        public string TakeTwoFromPosition(string str, int n)
        {
            string takeTwoFromPosition;

            if (n + 1 >= str.Length)
            {
                takeTwoFromPosition = str.Remove(2);
            }
            else
            {
                takeTwoFromPosition = str.Substring(n, 2);

            }

            return takeTwoFromPosition;           
        }

        //Given a string, 
        //return true if "bad" appears starting at index 0 or 1 in the string, such as with "badxxx" or "xbadxx" but not "xxbadxx". 
        //The string may be any length, including 0.

        //HasBad("badxx") -> true
        //HasBad("xbadxx") -> true
        //HasBad("xxbadxx") -> false


        public bool HasBad(string str)
        {
            bool hasBad = false;

            if (str.Length >= 3)
            {
                if (str.IndexOf("bad") == 0 || str.IndexOf("bad") == 1)
                {
                    hasBad = true;
                }
            }

            return hasBad;    
        }

        //Given a string, return a string length 2 made of its first 2 chars.If the string length is less than 2, 
        //use '@' for the missing chars.

        //AtFirst("hello") -> "he"
        //AtFirst("hi") -> "hi"
        //AtFirst("h") -> "h@"


        public string AtFirst(string str)
        {
            string atFirst;

            str = str + "@@";
            atFirst = str.Substring(0, 2);

            return atFirst; 
        }

        //Given 2 strings, a and b, return a new string made of the first char of a and the last char of b, 
        //so "yo" and "java" yields "ya". If either string is length 0, use '@' for its missing char. 

        //LastChars("last", "chars") -> "ls"
        //LastChars("yo", "mama") -> "ya"
        //LastChars("hi", "") -> "h@"

        public string LastChars(string a, string b)
        {
            string lastChars;

            a = a + "@";
            b = "@" + b;
            string aFirst = a.Substring(0, 1);
            string bLast = b.Substring(b.Length - 1, 1);
            lastChars = aFirst + bLast;
            return lastChars;  
        }

        //Given two strings, append them together(known as "concatenation") and return the result.However, 
        //if the concatenation creates a double-char, then omit one of the chars, so "abc" and "cat" yields "abcat". 

        //ConCat("abc", "cat") -> "abcat"
        //ConCat("dog", "cat") -> "dogcat"
        //ConCat("abc", "") -> "abc"

        public string ConCat(string a, string b)
        {
            string conCat;

            if (a.Length > 0 && b.Length > 0)
            {
                if (a.EndsWith(b.Substring(0, 1)))
                {
                    a = a.Remove(a.Length - 1);
                }
            }
            conCat = a + b;

            return conCat;           
        }

        //Given a string of any length, return a new string where the last 2 chars,
        //if present, are swapped, so "coding" yields "codign". 

        //SwapLast("coding") -> "codign"
        //SwapLast("cat") -> "cta"
        //SwapLast("ab") -> "ba"

        public string SwapLast(string str)
        {
            string swapLast = str;
            string last2 = str;
            string firstPart = str;

            if (str.Length >= 2)
            {
                firstPart = str.Remove(str.Length - 2);
                last2 = str.Substring(str.Length - 2, 2);
                last2 = last2.Substring(1, 1) + last2.Substring(0, 1);
                swapLast = firstPart + last2;
            }

            return swapLast;   
        }

        //Given a string, return true if the first 2 chars in the string also appear at the end of the string, such as with "edited". 

        //FrontAgain("edited") -> true
        //FrontAgain("edit") -> false
        //FrontAgain("ed") -> true

        public bool FrontAgain(string str)
        {
            return str.EndsWith(str.Substring(0, 2));       
        }

        //Given two strings, append them together(known as "concatenation") and return the result.
        //However, if the strings are different lengths, 
        //omit chars from the longer string so it is the same length as the shorter string. So "Hello" and "Hi" yield "loHi". 
        //The strings may be any length. 

        //MinCat("Hello", "Hi") -> "loHi"
        //MinCat("Hello", "java") -> "ellojava"
        //MinCat("java", "Hello") -> "javaello"


        public string MinCat(string a, string b)
        {
            string minCat;

            if (a.Length != b.Length)
            {
                if (a.Length > b.Length)
                {
                    a = a.Substring((a.Length - b.Length), b.Length);
                }
                else
                {
                    b = b.Substring((b.Length - a.Length), a.Length);
                }
            }
            minCat = a + b;

            return minCat;  
        }


        //Given a string, return a version without the first 2 chars.
        //Except keep the first char if it is 'a' and keep the second char if it is 'b'. The string may be any length.

        //TweakFront("Hello") -> "llo"
        //TweakFront("away") -> "aay"
        //TweakFront("abed") -> "abed"

        public string TweakFront(string str)
        {
            string tweakFromt;

            if (str.Length > 0)
            {
                if (str.IndexOf("ab") == 0)
                {
                    tweakFromt = str;
                }
                else if (str.IndexOf("a") == 0)
                {
                    tweakFromt = str.Remove(1, 1);
                }
                else if (str.IndexOf("b") == 1)
                {
                    tweakFromt = str.Remove(0, 1);
                }
                else
                {
                    tweakFromt = str.Substring(2, str.Length - 2);
                }
            }
            else tweakFromt = str;

            return tweakFromt;           
        }

        //Given a string, if the first or last chars are 'x', return the string without those 'x' chars, 
        //and otherwise return the string unchanged.
        
        //StripX("xHix") -> "Hi"
        //StripX("xHi") -> "Hi"
        //StripX("Hxix") -> "Hxi"

        public string StripX(string str)
        {
            string stripx = str;            

            if (str.StartsWith("x"))
            {
                stripx = str.Remove(0, 1);
            }

            if (stripx.EndsWith("x"))
            {
                stripx = stripx.Remove(stripx.Length - 1, 1);
            }            

            return stripx;          
        }
    }
}
