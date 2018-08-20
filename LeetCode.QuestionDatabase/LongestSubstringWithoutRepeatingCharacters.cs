using System;
using System.Collections.Generic;

namespace LeetCode.QuestionDatabase
{
    public partial class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            char[] charArray = s.ToCharArray();
            if (s == null || s.Length < 1)
                return 0;
            HashSet<char> set = new HashSet<char>();
            int pre = 0; // 窗口的左边界
            int max_str = int.MinValue; // 最长字串长度
            int i = 0; // 窗口的右边界
            int len = s.Length;
            //csabadb
            while (i < len)
            {
                if (set.Contains(charArray[i])) // 找到与i位置相等的那个字符，pre指向该字符的下一个位置，重新开始窗口
                {
                    if (i - pre > max_str)
                        max_str = i - pre;
                    while (charArray[pre] != charArray[i]) //直到找到与当前字符相等的那个字符，然后才可以重新开始新一轮的窗口计数
                    {
                        set.Remove(charArray[pre]);
                        pre++;
                    }
                    pre++;
                }
                else
                {
                    set.Add(charArray[i]);
                }
                i++;
            }
            max_str = Math.Max(max_str, i - pre); // i一直向后，直到超出s的长度，此时也要计算窗口的大小
            return max_str;
        }
    }
}