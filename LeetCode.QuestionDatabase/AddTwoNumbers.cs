using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LeetCode.QuestionDatabase
{
    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode(-1);
            
            while (l1.next != null || l2.next != null)
            {
                if ((l1.val + l2.val) < 10)
                {
                    result.next = new ListNode(l1.val + l2.val);

                }
            }
            return result;

        }

        /*反序操作如下所示
         *  A b c d e f
            B a c d e f
            C b a d e f
            D c b a e f
            E d c b a f
            F e d c b a

         */
        public ListNode ReverseListNode(ListNode l)
        {
            //先在整个链表中取第一项，并分割剩下节点
            //从剩下节点中重复操作1，并把取得的第一个节点拼接。
            ListNode p = l, n = null;
            while (p != null)
            {
                ListNode tmp = p.next;
                p.next = n;
                n = p;
                p = tmp;
            }
            return n;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

}
