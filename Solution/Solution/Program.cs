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
        static void Main(string[] args)
        {
            //Test();
            
            Stopwatch stopwatch = new Stopwatch();
            string[] strs = new[] {"aa", "bb", "ab", "ba"};
            int[][] A = new int[][] {new int[] {0, 0, 1, 1}, new int[] { 1, 0, 1, 0}, new int[] { 1, 1, 0, 0}};
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


        }
    }
}
