using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{

    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();


            List<string> l = new List<string>
            {
                "9001 discuss.leetcode.com", "50 yahoo.com", "1 intel.mail.com", "5 wiki.org"
            };
            int[][] A = new int[][] {new int[] {0, 0, 1, 1}, new int[] { 1, 0, 1, 0}, new int[] { 1, 1, 0, 0}};
            MySolution s = new MySolution();
            int[] num = new[] {-1, 0, 1, 2, -1, -4};
            ListNode n1 = new ListNode(1);
            ListNode n2 = new ListNode(2);
            ListNode n3 = new ListNode(3);
            ListNode n4 = new ListNode(4);
            n1.next = n2;
            n2.next = n3;
            n3.next = n4;
            ListNode[] xx = new ListNode[] {n1, n3};
            s.ReverseKGroup(n1, 3);
        }
    }
}
