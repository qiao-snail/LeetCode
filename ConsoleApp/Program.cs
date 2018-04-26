using LeetCode.QuestionDatabase;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var re1s = new ListNode(1);
            ListNode L1 = re1s;
            ListNode L2 = new ListNode(3);
            ListNode L3 = new ListNode(5);
            ListNode L4 = new ListNode(8);
            //L1.next = L2;
            //L2.next = L3;
            //L3.next = L4;

            for (int i = 0; i < 3; i++)
            {
                L1.next = new ListNode(i + 5);
                L1 = L1.next;
            }
            AddTwoNumbers(L1, null);
            var res = new Solution().ReverseListNode(L1);
            Console.WriteLine("Hello World!");
        }



        static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode one = l1, two = l2;
            ListNode res = new ListNode(0);
            ListNode three = res;
            int sum = 0;
            while (one != null && two != null)
            {
                three.next = new ListNode((one.val + two.val + sum) % 10);
                sum = (one.val + two.val + sum) / 10;
                one = one.next;
                two = two.next;
                three = three.next;
            }
            while (one != null)
            {
                three.next = new ListNode((one.val + sum) % 10);
                sum = (one.val + sum) / 10;
                one = one.next;
                three = three.next;
            }
            while (two != null)
            {
                three.next = new ListNode((two.val + sum) % 10);
                sum = (two.val + sum) / 10;
                two = two.next; three = three.next;
            }
            if (sum != 0) three.next = new ListNode(1);
            return res.next;
        }
    }
}
