using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Queue
{
    public partial class MySolution
    {
        #region queue

        // 933. Number of Recent Calls
        //Just like message queue , each time enque need check out of date item 
        public class RecentCounter
        {
            public Queue<int> queue;

            public RecentCounter()
            {
                queue = new Queue<int>();
            }

            public int Ping(int t)
            {
                while (queue.Count > 0 && t - queue.Peek() > 3000)
                {
                    queue.Dequeue();
                }
                queue.Enqueue(t);
                return queue.Count;
            }
        }


        // 346	Moving Average from Data Stream
        // Like slide window , with max window size, when window is full dequeue
        public class MovingAverage
        {
            Queue<int> q = new Queue<int>();
            public int Count;
            public int Sum = 0;
            MovingAverage(int size)
            {
                Count = size;
            }

            double Next(int val)
            {
                if (q.Count >= Count)
                {
                    Sum -= q.Dequeue();
                }
                q.Enqueue(val);
                Sum += val;
                return Sum*1.0/q.Count;
            }
        }

        #endregion
    }
}
