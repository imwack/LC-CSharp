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

        //933. Number of Recent Calls
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

        #endregion
    }
}
