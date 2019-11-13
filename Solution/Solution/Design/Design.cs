using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Design
{
    public class MyLinkedList
    {
        DoubleListNode head = new DoubleListNode(0);
        DoubleListNode tail = new DoubleListNode(-1);

        /** Initialize your data structure here. */
        public MyLinkedList()
        {
            head.next = tail;
            tail.prev = head;
        }

        private DoubleListNode GetIndex(int index)
        {
            DoubleListNode cur = head.next;
            for (int i = 0; i < index; i++)
            {
                if (cur != tail)
                {
                    cur = cur.next;
                }
            }
            return cur;
        }
        
        /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
        public int Get(int index)
        {
            DoubleListNode cur = GetIndex(index);
            return cur.val;
        }

        /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
        public void AddAtHead(int val)
        {
            DoubleListNode temp = new DoubleListNode(val);
            DoubleListNode next = head.next;
            head.next = temp;
            temp.next = next;
            temp.prev = head;
            next.prev = temp;
        }

        /** Append a node of value val to the last element of the linked list. */
        public void AddAtTail(int val)
        {
            DoubleListNode last = tail.prev;
            DoubleListNode temp = new DoubleListNode(val);
            last.next = temp;
            temp.prev = last;
            temp.next = tail;
            tail.prev = temp;
        }

        /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
        public void AddAtIndex(int index, int val)
        {
            if (index == 0)
            {
                AddAtHead(val);
                return;
            }
            DoubleListNode node = GetIndex(index-1);
            if (node.val != -1)
            {
                DoubleListNode next = node.next;
                DoubleListNode temp = new DoubleListNode(val);
                node.next = temp;
                temp.next = next;
                temp.prev = node;
                next.prev = temp;
            }

        }

        /** Delete the index-th node in the linked list, if the index is valid. */
        public void DeleteAtIndex(int index)
        {
            DoubleListNode node = GetIndex(index);
            if (node.val != -1)
            {
                DoubleListNode pre = node.prev;
                pre.next = node.next;
                node.next.prev = pre;
            }

        }
    }

    public class Player : IComparable
    {
        public int id;
        public int score;

        public Player(int i, int s)
        {
            id = i;
            score = s;
        }

        public int CompareTo(object obj)
        {
            return ((Player) obj).score > score ? -1 : 1;
        }
    }
    public class Leaderboard
    {
        SortedList<Player,int>  list = new SortedList<Player, int>();
        public Leaderboard()
        {

        }

        public void AddScore(int playerId, int score)
        {
            Player p = new Player(playerId, score);
            list.Add(p,score);
        }

        public int Top(int K)
        {
            int cnt = 0, i = 0;
            foreach (var l in list)
            {
                i++;
                cnt += l.Value;
                if(i == K) break;
            }
            return cnt;
        }

        public void Reset(int playerId)
        {

        }
    }

    public partial class MySolution
    {
        public class Codce
        {
            Dictionary<string, string> CodeDic = new Dictionary<string, string>();
            // Encodes a URL to a shortened URL
            public string encode(string longUrl)
            {
                string str = longUrl.GetHashCode().ToString();
                CodeDic[str] = longUrl;
                return str;
            }

            // Decodes a shortened URL to its original URL.
            public string decode(string shortUrl)
            {
                return CodeDic[shortUrl];
            }
        }
    }
}
