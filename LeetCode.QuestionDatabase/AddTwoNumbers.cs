using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LeetCode.QuestionDatabase {
    public class Solution {
        public ListNode AddTwoNumbers (ListNode l1, ListNode l2) {
            ListNode result = new ListNode (-1);

            while (l1.next != null || l2.next != null) {
                if ((l1.val + l2.val) < 10) {
                    result.next = new ListNode (l1.val + l2.val);

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
        public ListNode ReverseListNode (ListNode l) {
            //先在整个链表中取第一项，并分割剩下节点
            //从剩下节点中重复操作1，并把取得的第一个节点拼接。
            ListNode p = l, n = null;
            while (p != null) {
                ListNode tmp = p.next;
                p.next = n;
                n = p;
                p = tmp;
            }
            return n;
        }

        static ListNode AddTwoNumbers1 (ListNode l1, ListNode l2) {
            ListNode listNodeRoot = new ListNode (0);
            ListNode listNodeCurr = listNodeRoot;
            int carry = 0;

            while (l1 != null || l2 != null || carry != 0) {
                //需要考虑l1和l2有一个为空的情况
                int sum = (l1 != null ? l1.val : 0) + (l2 != null ? l2.val : 0) + carry;

                //计算当前位和进位
                listNodeCurr.next = new ListNode (sum % 10);
                carry = sum / 10;

                //向后遍历
                listNodeCurr = listNodeCurr.next;
                l1 = (l1 != null ? l1.next : null);
                l2 = (l2 != null ? l2.next : null);
            }

            return listNodeRoot.next;

            int temp = l1.val + l2.val;
            int flag = temp / 10;
            var root = new ListNode (temp % 10);
            var tempNode = root;
            l1 = l1.next;
            l2 = l2.next;
            while (l1 != null || l2 != null) {
                var sum = flag;
                if (l1 != null) {
                    sum += l1.val;
                    l1 = l1.next;
                }
                if (l2 != null) {
                    sum += l2.val;
                    l2 = l2.next;
                }
                flag = sum / 10;
                var node = new ListNode (sum % 10);
                tempNode.next = node;
                tempNode = node;
            }
            if (flag != 0) {
                tempNode.next = new ListNode (1);
            }
            return root;
        }

        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode (int x) { val = x; }
        }

    }
}