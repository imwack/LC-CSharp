using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Design
{
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
