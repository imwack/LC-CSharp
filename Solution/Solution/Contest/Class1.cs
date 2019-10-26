using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Contest
{
    public class Contest
    {
        public bool CheckStraightLine(int[][] coordinates)
        {
            int x1 = coordinates[0][0], y1 = coordinates[0][1];
            int x2 = coordinates[1][0], y2 = coordinates[1][1];

            for (int i = 3; i < coordinates.Length; i++)
            {
                int x3 = coordinates[i][0], y3 = coordinates[i][1];
                if ((y3 - y2)*(x2 - x1) != (y2 - y1)*(x3 - x2))
                    return false;
            }
            return true;
        }

        public class TrieT
        {
            public Dictionary<string,TrieT> Child = new Dictionary<string, TrieT>();
            public bool IsRoot;
        }

        public IList<string> RemoveSubfolders(string[] folder)
        {
            IList<string> result = new List<string>();
            TrieT root = new TrieT();
            foreach (var fo in folder)
            {
                string[] path = fo.Split('/');
                TrieT cur = root;
                foreach (var p in path)
                {
                    if(p=="") continue;
                    if (!cur.Child.ContainsKey(p))
                    {
                        cur.Child.Add(p, new TrieT());
                    }
                    cur = cur.Child[p];
                }
                cur.IsRoot = true;
            }
            GetFolder(root, result, "");
            return result;
        }

        public void GetFolder(TrieT root, IList<string> result, string cur)
        {
            if (root.IsRoot)
            {
                result.Add(cur);
                return;
            }
            foreach (var pair in root.Child)
            {
                GetFolder(pair.Value, result, cur + "/" + pair.Key);
            }
        }

        public int BalancedString(string s)
        {
            int n = 0;
            int q=0, w=0, e=0, r=0;
            foreach (char c in s)
            {
                if (c == 'Q') q++;
                if (c == 'W') w++;
                if (c == 'E') e++;
                if (c == 'R') r++;
            }
            int average = s.Length/4;
            Dictionary<char ,int> dic = new Dictionary<char, int>();
            if (q > average)
            {
                dic['Q'] = q - average;
                n += q - average;
            }
            if (w > average)
            {
                dic['W'] = (w - average);
                n += w - average;
            }
            if (e > average)
            {
                dic['E'] = (e - average);
                n += e - average;
            }
            if (r > average)
            {
                dic['R'] = (r - average);
                n += r - average;
            }
            for (int len = n; len < s.Length; len++)
            {
                //滑动窗口
                for (int j = 0; j < s.Length; j++)
                {
                    Dictionary<char ,int> cur = new Dictionary<char, int>();
                    for (int k = j; k < len + j; k++)
                    {
                        if (!cur.ContainsKey(s[k])) cur[s[k]] = 0;
                        cur[s[k]]++;
                    }
                    bool success = true;
                    foreach (var pair in dic)
                    {
                        if (!cur.ContainsKey(pair.Key) || cur[pair.Key] < pair.Value)
                        {
                            success = false;
                            break;
                        }
                    }
                    if (success) return len;
                }
            }
            return s.Length;
        }

    }
}
