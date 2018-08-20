using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.QuestionDatabase
{
    /// <summary>
    /// 最长回文子串
    /// </summary>
    public partial class Solution
    {
        //示例 1：

        //输入: "babad"
        //输出: "bab"
        //注意: "aba"也是一个有效答案。

        //示例 2：

        //输入: "cbbd"
        //输出: "bb"

        string preProcess(string s)
        {
            int n = s.Length;
            if (n == 0) return "^$";
            string ret = "^";
            for (int i = 0; i < n; i++)
                ret += "#" + s.Substring(i, 1);
            ret += "#$";
            return ret;
        }

        public string LongestPalindrome(string s)
        {
            string T = preProcess(s);
            int n = T.Length;
            int[] P = new int[n];
            int C = 0, R = 0;
            for (int i = 1; i < n - 1; i++)
            {
                int i_mirror = 2 * C - i; // equals to i' = C - (i-C)

                P[i] = (R > i) ? Math.Min(R - i, P[i_mirror]) : 0;

                // Attempt to expand palindrome centered at i
                while (T[i + 1 + P[i]] == T[i - 1 - P[i]])
                    P[i]++;
                // If palindrome centered at i expand past R,
                // adjust center based on expanded palindrome.
                if (i + P[i] > R)
                {
                    C = i;
                    R = i + P[i];
                }
            }

            // Find the maximum element in P.
            int maxLen = 0;
            int centerIndex = 0;
            for (int i = 1; i < n - 1; i++)
            {
                if (P[i] > maxLen)
                {
                    maxLen = P[i];
                    centerIndex = i;
                }
            }
            //delete[] P;

            return s.Substring((centerIndex - 1 - maxLen) / 2, maxLen);
        }


        public string LongestPalindrome1(string str)
        {
            ////////////////////////////////////////////////////////////////
            // 思路：中心扩展算法
            // 1，自我比较，然后再检查自己两边的元素，从而得到以i为中心点的回文
            // 2，比较i和i+1，然后再检查i和i+1两边的元素，从而得到以i和i+1为中心点的回文
            // 算法中记录回文的开始和最大长度，这样就不必存储回文信息
            // 扩展方法中返回回文的长度，然后比较1、2中最长的回文，最后主方法根据长度去计算回文的开始与结束点
            ////////////////////////////////////////////////////////////////

            int left = 0;
            int onemid = 0, twomid = 0;
            int max = 0, count = 0;

            var len = str.Length;

            for (int i = 0; i < len; i++)
            {
                //检查以i为中心点的回文长度
                onemid = GreatLongestPalindromicExtra(str, i, i);
                //检查以i和i+1为中心点的回文长度
                twomid = GreatLongestPalindromicExtra(str, i, i + 1);

                //比较上面两种方式最长回文长度
                count = Math.Max(onemid, twomid);

                //根据回文长度计算开始和结束点
                if (max < count)
                {
                    max = count;
                    left = i - (max - 1) / 2;
                }
            }

            return str.Substring(left, max);
        }

        private int GreatLongestPalindromicExtra(string s, int l, int r)
        {
            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                l--; r++;
            }

            return r - l - 1;
        }

    }

}
