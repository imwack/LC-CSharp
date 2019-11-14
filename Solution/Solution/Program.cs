using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Solution.Design;

namespace Solution
{

    class Program
    {
        public class Camp
        {
            public int Rank;
        }
        public static void Test()
        {
            Camp a = new Camp() {Rank = 1};
            Camp b = new Camp() {Rank = 3};
            Camp c = new Camp() {Rank = 2};
            List<Camp> l = new List<Camp>();
            l.Add(a);
            l.Add(b);
            l.Add(c);
            l.Sort((aa,bb)=>aa.Rank<bb.Rank?-1:1);
            foreach (var camp in l)
            {
                Console.WriteLine(camp.Rank);
            }

        }
        public enum CalMatchName
        {
            CalMatchName1 = 0,  //普通局
            CalMatchName2 = 1,  //高端局
            CalMatchName3 = 2,  //大神局
        }
        public static CalMatchName GetCalMatchName(int MatchIndex, int realPlayerNum)
        {
            CalMatchName matchName = CalMatchName.CalMatchName1;
            if (MatchIndex >= 3 && MatchIndex <=5 && realPlayerNum > 13)
            {
                matchName = CalMatchName.CalMatchName2;
            }
            if (MatchIndex > 5)
            {
                matchName = CalMatchName.CalMatchName2;
                if (realPlayerNum > 20)
                {
                    matchName = CalMatchName.CalMatchName3;
                }
            }
            Console.WriteLine("GetCalMatchName matchName={0} matchIndex={1} realPlayerNum={2}", matchName, MatchIndex+1, realPlayerNum);
            return matchName;
        }

        static void Main(string[] args)
        {
            //Contest.Contest con  = new Contest.Contest();
            //con.ClosedIsland(new int[][] {
            //new int[] {1,1,0,1,1,1,1,1,1,1},
            //new int[] {0,0,1,0,0,1,0,1,1,1},
            //new int[] {1,0,1,0,0,0,1,0,1,0},
            //new int[] {1,1,1,1,1,0,0,1,0,0},
            //new int[] { 1, 0, 1, 0, 1, 1, 1, 1, 1, 0 },
            //new int[] { 0,0,0,0,1,1,0,0,0,0 },
            //new int[] { 1,0,1,0,0,0,0,1,1,0 },
            //new int[] { 1,1,0,0,1,1,0,0,0,0},
            //new int[] { 0,0,0,1,1,0,1,1,1,0 },
            //new int[] { 1,1,0,1,0,1,0,0,1,0},
            //});
            //Test();


            Stopwatch stopwatch = new Stopwatch();
            string[] strs = new[] {"aa", "bb", "ab", "ba"};
            int[][] A = new int[][] {new int[] {1,2}, new int[] { 3}, new int[] {3}, new int[0] };
            MySolution s = new MySolution();
            int[] num = new[] {-1, 0, 1, 2, -1, -4};
            int[] a = new[] {4, -1, 4, -2, 4};
            int[][] b = new[] {new int[] {2, 4}};
            TreeNode r1 = new TreeNode(2);
            TreeNode r2 = new TreeNode(1);
            TreeNode r3 = new TreeNode(3);
            r1.left = r2;
            r1.right = r3;
            s.CountBinarySubstrings("10101");

            int[][]arr = new int[3][]
            {new int[] {1,0, 1},new int[] {0,0,0},new int[] {1,0,1}
            };

            ListNode l1 = new ListNode(1);
            ListNode l2 = new ListNode(2);
            l1.next = l2;
            ListNode l3 = new ListNode(3);
            l2.next = l3;
            ListNode l4 = new ListNode(4);
            l3.next = l4;
            s.Find132pattern(new int[] { -2, 1, 2, -2, 1, 2 });
 
        }
    }
}
