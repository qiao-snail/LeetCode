using System;
using LeetCode.QuestionDatabase;

namespace ConsoleApp {
    class Program {
        static void Main (string[] args) {
            string str="abcadbf";
            var l = new Solution ().LengthOfLongestSubstring (str);
            Console.WriteLine(str);
            Console.WriteLine (l);
            Console.WriteLine ("Hello World!");
        }

    }
}