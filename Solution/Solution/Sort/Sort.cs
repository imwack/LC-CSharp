using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class Interval
    {
      public int start;
      public int end;
      public Interval() { start = 0; end = 0; }
      public Interval(int s, int e) { start = s; end = e; }
    }

    public partial class MySolution
    {
        //56. Merge Intervals 
        //First sort array : 1.start increase 2.end increase
        //Second Merge two interval and get new range[start,end]
        public IList<Interval> Merge(IList<Interval> intervals)
        {

            IList<Interval> ret = new List<Interval>();
            var arr = intervals.ToArray();
            
            Array.Sort(arr, (a, b) =>
            {
                if (a.start == b.start)
                {
                    return a.end >= b.end ? 1 : -1;
                }
                return a.start >= b.start ? 1 : -1;
            });
            int i = 0;
            while (i < arr.Length)
            {
                int start = arr[i].start;
                int end = arr[i].end;
                while (i + 1 < arr.Length && end >= arr[i + 1].start)
                {
                    if (arr[i + 1].end > end)
                        end = arr[i + 1].end;
                    ++i;
                }

                ret.Add(new Interval(start, end));
                i++;
            }
            return ret;
        }

        public class MHeap
        {
            private int[] heap;
            public int Peek => heap[0];
            private int count = 0;
            private bool CanAdd => count < heap.Length;
            public MHeap(int k, int[] nums)
            {
                heap = new int[k];
                for (int i = 0; i < k; i++)
                    heap[i] = int.MaxValue;

                for (int i = 0; i < k && i < nums.Length; i++)
                {
                    heap[i] = nums[i];
                    count++;
                }
                for (int i = count/2 ; i >= 0; i--)
                    AdjustDown(i);
            }

            public void Push(int n)
            {
                if (CanAdd)
                {
                    heap[count] = n;
                    count++;
                    for (int i = count/2; i >= 0; i--)
                        AdjustDown(i);

                }
                else if (heap[0] < n)
                {
                    heap[0] = n;
                    AdjustDown(0);
                }
            }
            public void AdjustDown(int index)
            {
                int left = index * 2 + 1;
                while (left < count)
                {
                    if (left + 1 < count && heap[left + 1] < heap[left])
                    {
                        left++;
                    }
                    if (heap[left] < heap[index])
                    {
                        int temp = heap[index];
                        heap[index] = heap[left];
                        heap[left] = temp;
                        index = left;
                        left = left * 2 + 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        public class KthLargest
        {

            private MHeap hp;
            public KthLargest(int k, int[] nums)
            {
                hp = new MHeap(k, nums);
                for (int i = k; i < nums.Length; i++)
                {
                    hp.Push(nums[i]);
                }
            }

            public int Add(int val)
            {
                hp.Push(val);
                return hp.Peek;
            }
        }

        public class Item
        {
            public int v;
            public int l;
        }
        public int LargestValsFromLabels(int[] values, int[] labels, int num_wanted, int use_limit)
        {
            if (use_limit == 0)
                return 0;
            int sum = 0;
            List< Item > items = new List<Item>();
            for (int i = 0; i < values.Length; i++)
            {
                items.Add(new Item() {v=values[i], l=labels[i]});
            }
            items.Sort((a,b)=> { return a.v >= b.v ? -1 : 1; });
            Dictionary<int,int> labelCountDic = new Dictionary<int, int>();
            int cur = 0; //物品index
            for (int i = 0; i < num_wanted; i++)
            {
                for (int j = cur; j < items.Count; j++)
                {
                    if (!labelCountDic.ContainsKey(items[j].l) || labelCountDic[items[j].l] < use_limit)
                    {
                        if (!labelCountDic.ContainsKey(items[j].l))
                            labelCountDic[items[j].l] = 0;
                        labelCountDic[items[j].l]++;
                        sum += items[j].v;
                        cur++;
                        break;
                    }
                    else
                    {
                        cur++;
                    }
                }
            }
            return sum;
        }

        public int LastStoneWeight(int[] stones)
        {
            int result = 0;
            MaxHeap<int> heap = new MaxHeap<int>(stones);
            while (heap.Count > 0)
            {
                if (heap.Count == 1)
                {
                    result = heap.Peek;
                    break;
                }
                int peek1 = heap.Pop();
                int peek2 = heap.Pop();
                int remain = Math.Abs(peek2 - peek1);
                if (remain != 0)
                {
                    heap.Push(remain);
                }
            }
            return result;
        }

        public IList<int> PancakeSort(int[] A)
        {
            IList<int> result = new List<int>();
            for (int n = A.Length; n > 0; --n)
            {
                //每次把最大的换到最后去
                for (int i = 0; i < n; i++)
                {
                    if (A[i] == n)
                    {
                        result.Add(i+1);
                        Array.Reverse(A,0,i+1);
                        result.Add(n);
                        Array.Reverse(A, 0, n);
                        break;
                    }
                }
            }
            return result;
        }
    }
}
