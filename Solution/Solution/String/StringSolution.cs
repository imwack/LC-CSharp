using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public partial class MySolution
    {


        public string ReverseWords(string s)
        {
            StringBuilder sb = new StringBuilder();
            int start = 0;
            while (start<s.Length)
            {
                while (start < s.Length && s[start] == ' ')
                    start++;
                int end = start + 1;
                while (end<s.Length && s[end]!=' ')
                {
                    end++;
                }
                if(end>s.Length)
                    break;
                
                sb.Append(ReverseStr(s, start, end));
                sb.Append(" ");
                start = end + 1;
            }
            return ReverseStr(sb.ToString(), 0, sb.Length-1);
        }

        public string ReverseStr(string str, int start, int end)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = end-1; i >= start; i--)
                sb.Append(str[i]);
            return sb.ToString();
        }

        public int DeleteTreeNodes(int nodes, int[] parent, int[] value)
        {
            Dictionary<int, int> keyToParent = new Dictionary<int, int>();
            Dictionary<int,List<int>> dic =new Dictionary<int, List<int>>();
            HashSet<int> node = new HashSet<int>();
            for (int i = 0; i < nodes; i++)
                node.Add(i);
            for (int i = 0; i < parent.Length; i++)
            {
                keyToParent[i] = parent[i];
                if(!dic.ContainsKey(parent[i]))
                    dic[parent[i]] = new List<int>();
                dic[parent[i]].Add(i);
            }
            HashSet<int> all = new HashSet<int>();
            int[] dp = new int[nodes];
            for (int i = 0; i < nodes; i++)
            {
                dp[i] = value[i];
                all.Add(i);
            }
            for (int i = parent.Length - 1; i > 0; i--)
            {
                dp[parent[i]] += dp[i];
            }
            for (int i = 0; i < nodes; i++)
            {
                if (dp[i] == 0)
                {
                    if (dic.ContainsKey(i))
                    foreach (var son in dic[i])
                    {
                        all.Remove(son);
                    }
                    all.Remove(i);
                }
            }
            return all.Count;
        }

        public string ToHexspeak(string num)
        {
            long result = long.Parse(num);
            string str = "";
            while (result>0)
            {
                long s = result%16;
                if (s == 10) str += 'A';
                else if (s == 11) str += 'B';
                else if (s == 12) str += 'C';
                else if (s == 13) str += 'D';
                else if (s == 14) str += 'E';
                else if (s == 15) str += 'F';
                else str += s;
                result = result/16;
            }
            string hex = "";
            foreach (var s in str.Reverse())
            {
                hex += s;
            }
            Console.WriteLine(hex);
            StringBuilder sb = new StringBuilder();
            foreach (char c in hex)
            {
                if (c == '1') sb.Append('I');
                else if (c == '0') sb.Append('O');
                else if (c == 'A') sb.Append('A');
                else if (c == 'B') sb.Append('B');
                else if (c == 'C') sb.Append('C');
                else if (c == 'D') sb.Append('D');
                else if (c == 'E') sb.Append('E');
                else if (c == 'F') sb.Append('F');
                else return "ERROR";

            }
            return sb.ToString();
        }
        public int Compress(char[] chars)
        {
            int read = 1, write = 0;
            int count = 1;
            char first = chars[0];
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == chars[i - 1])
                {
                    count++;
                }
                if(chars[i] != chars[i - 1] || i == chars.Length-1)
                {
                    chars[write++] =first;

                    if (count > 1)
                    {
                        List<int> num  = new List<int>();
                        while (count>0)
                        {
                            num.Add(count % 10);
                            count /= 10;
                        }
                        for(int j = num.Count-1;j>=0;j--)
                        {
                            chars[write++] = (char) (num[j] + '0');
                        }
                    }
                    first = chars[i];
                    count = 1;
                }
            }
            return write;
        }
        public int BalancedStringSplit(string s)
        {
            int l = 0, r = 0, cnt=0;
            foreach(char c in s)
            {
                if (c == 'L')
                {
                    l++;
                }
                else
                {
                    r++;
                }
                if (l == r)
                {
                    l = 0;
                    r = 0;
                    cnt++;
                }
            }
            return cnt + 1;
        }
        public string MostCommonWord(string paragraph, string[] banned)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < paragraph.Length; ++i)
            {
                if (IsAlpha(paragraph[i]))
                {
                    if (paragraph[i] >= 'A' && paragraph[i] <= 'Z')
                        sb.Append((char)(paragraph[i] - 'A' + 'a'));
                    else
                        sb.Append(paragraph[i]);
                }
                else
                {
                    if (sb.Length > 0 && !banned.Contains(sb.ToString()))
                    {
                        if (!dic.ContainsKey(sb.ToString()))
                            dic[sb.ToString()] = 0;
                        dic[sb.ToString()]++;
                    }
                    sb.Clear();
                }
            }
            if (sb.Length > 0 && !banned.Contains(sb.ToString()))
            {
                if (!dic.ContainsKey(sb.ToString()))
                    dic[sb.ToString()] = 0;
                dic[sb.ToString()]++;
            }
            int maxCnt = 0;
            string ret = "";
            foreach (var pair in dic)
            {
                if (pair.Value > maxCnt)
                {
                    ret = pair.Key;
                    maxCnt = pair.Value;
                }
            }
            return ret;
        }

        public bool IsAlpha(char c)
        {
            return ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'));
        }

        public IList<string> RemoveComments(string[] source)
        {
            IList<string> code = new List<string>();
            bool inCommnet = false;
            StringBuilder sb = new StringBuilder();
            foreach (string s in source)
            {
                int i = 0;
                while (i < s.Length)
                {
                    if (inCommnet)
                    {
                        if (s[i] == '*' && i < s.Length - 1 && s[i + 1] == '/')
                        {
                            inCommnet = false;
                            ++i;
                        }
                        ++i;
                    }
                    else
                    {
                        if (s[i] == '/' && i < s.Length - 1 && s[i + 1] == '/')
                        {
                            //注释这行就没了
                            i = s.Length;
                        }
                        else if (s[i] == '/' && i < s.Length - 1 && s[i + 1] == '*')
                        {
                            inCommnet = true;
                            i += 2;
                        }
                        else
                        {
                            sb.Append(s[i]);
                            ++i;
                        }
                    }
                }
                if (!inCommnet && sb.Length > 0)
                {
                    code.Add(sb.ToString());
                    sb.Clear();
                }
            }

            return code;
        }
        public string LongestWord(string[] words)
        {
            System.Array.Sort(words);
            HashSet<string> set = new HashSet<string>();
            string longest = "";
            foreach (var word in words)
            {
                if (word.Length == 1 || set.Contains(word.Substring(0, word.Length - 1)))
                {
                    if(!set.Contains(word))
                        set.Add(word);
                    if (word.Length > longest.Length)
                        longest = word;
                }

            }
            return longest;
        }

        public string ToGoatLatin(string S)
        {
            StringBuilder sb = new StringBuilder();
            string[] str = S.Split(' ');
            for (int i = 0; i < str.Length; i++)
            {
                if (i != 0)
                    sb.Append(" ");
                if (str[i][0] == 'a' || str[i][0] == 'e' || str[i][0] == 'i' || str[i][0] == 'o' || str[i][0] == 'u' ||
                   str[i][0] == 'A' || str[i][0] == 'E' || str[i][0] == 'I' || str[i][0] == 'O' || str[i][0] == 'U')
                {
                    sb.Append(str[i]);
                }
                else
                {
                    sb.Append(str[i], 1, str[i].Length - 1);
                    sb.Append(str[i][0]);
                }
                sb.Append("ma");
                sb.Append('a', i + 1);
            }
            return sb.ToString();
        }
        public int NumSpecialEquivGroups(string[] A)
        {
            HashSet<string> s = new HashSet<string>();
            foreach (string str in A)
            {
                char[] odd = new char[26];
                char[] even = new char[26];
                for(int i = 0; i<str.Length; i++)
                {
                    if (i%2 == 0)
                    {
                        odd[str[i] - 'a']++;
                    }
                    else
                    {
                        even[str[i] - 'a']++;
                    }
                }
                string code = new string(odd) + new string(even);
                if (!s.Contains(code))
                {
                    s.Add(code);
                }
            }
            return s.Count;
        }

        public string[] UncommonFromSentences(string A, string B)
        {
            string AB = A + " " + B;
            Dictionary<string, int> dic = new Dictionary<string, int>();
            List<string> result = new List<string>();
            var strs = AB.Split(' ');
            foreach (var s in strs)
            {
                if (!dic.ContainsKey(s))
                {
                    dic[s] = 0;
                }
                else
                {
                    dic[s]++;
                }
            }
            foreach (var s in dic)
            {
                if (s.Value == 1)
                {
                    result.Add(s.Key);
                }
            }
            return result.ToArray();
        }

        public string LargestTimeFromDigits(int[] A)
        {
            string ret = "";
            int sum = -1;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j == i) continue;
                    for (int k = 0; k < 4; k++)
                    {
                        if (k == i || k == j) continue;
                        for (int l = 0; l < 4; l++)
                        {
                            if (l == k || l == i || l == j) continue;
                            if (CheckTimeValid(A, i, j, k, l))
                            {
                                int s = (A[i] * 10 + A[j]) * 3600 + A[k] * 10 + A[l];
                                if (s > sum)
                                {
                                    sum = s;
                                    ret = A[i].ToString() + A[j].ToString() + ":" + A[k].ToString() + A[l].ToString();
                                }
                            }
                        }
                    }
                }
            }
            return ret;
        }

        private bool CheckTimeValid(int[] A, int i0, int i1, int i2, int i3)
        {
            return A[i0] * 10 + A[i1] < 24 && A[i2] * 10 + A[i3] < 60;
        }
        public int CountBinarySubstrings(string s)
        {
            if (s.Length == 0) return 0;
            List<int> cnt = new List<int>();
            char cur = s[0];
            int count = 1, total = 0;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == cur)
                {
                    count++;
                }
                else
                {
                    cur = s[i];
                    cnt.Add(count);
                    count = 1;
                }
            }
            cnt.Add(count);
            for (int i = 1; i < cnt.Count; i++)
            {
                total += Math.Min(cnt[i], cnt[i - 1]);
            }
            return total;
        }
 
        public string ShortestCompletingWord(string licensePlate, string[] words)
        {
            Dictionary<char,uint> dic = new Dictionary<char, uint>();
            foreach (char c in licensePlate)
            {
                char cc = c;
                if (cc >= 'A' && cc <= 'Z')
                {
                    cc = (char)(cc - 'A' + 'a');
                }
                if (cc >= 'a' && cc <= 'z')
                {
                    if (!dic.ContainsKey(cc))
                    {
                        dic[cc] = 0;
                    }
                    dic[cc]++;
                }
            }

            return "";
        }

        public string[] FindOcurrences(string text, string first, string second)
        {
            List<string> result = new List<string>();
            string[] arr = text.Split(' ');
            for (int i = 0; i < arr.Length - 1;i++)
            {
                if (arr[i] == first && arr[i + 1] == second)
                {
                    if(i+2< arr.Length)
                        result.Add(arr[i+2]);
                }
            }
            return result.ToArray();
        }
        public string GcdOfStrings(string str1, string str2)
        {
            if (str1.Length < str2.Length)
                return GcdOfStrings(str2, str1);
            if (str2 == "")
                return str1;
            if (!str1.StartsWith(str2))
                return "";
            return str1.Substring(str1.IndexOf(str2) + str2.Length);

        }
        public string SmallestSubsequence(string text)
        {
            List<char> seq = new List<char>();
            int[] cnt = new int[256];
            int[] use = new int[256];
            foreach (char c in text)
            {
                cnt[c - 'a']++;
            }
            foreach (char c in text)
            {
                if (use[c - 'a'] > 0)
                {
                    cnt[c - 'a']--;
                    continue;
                }
                while (seq.Count > 0 && c < seq.Last() && cnt[seq.Last() - 'a'] > 0)
                {
                    use[seq.Last() - 'a'] = 0;
                    seq.RemoveAt(seq.Count - 1);
                }
                seq.Add(c);
                use[c - 'a']++;
                cnt[c - 'a']--;
            }
            StringBuilder sb = new StringBuilder();
            foreach (var c in seq)
            {
                sb.Append(c);
            }
            return sb.ToString();
        }
        public bool CheckInclusion(string s1, string s2)
        {
            return true;
        }
        //003 
        public int LengthOfLongestSubstring(string s)
        {
            int maxLen = 0, start = 0;
            int[] first = new int[1024];
            for (int i = 0; i < 1024; ++i)
            {
                first[i] = -1;
            }
            for (int i = 0; i < s.Length; ++i)
            {
                if (first[(int)s[i]] >= start)
                {
                    start = first[(int)s[i]] + 1;
                }

                maxLen = Math.Max(maxLen, i - start + 1);
                first[(int)s[i]] = i;
            }

            return maxLen;
        }
        public int UniqueMorseRepresentations(string[] words)
        {
            string[] code =
            {
                ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---",
                ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.."
            };
            HashSet<string> s = new HashSet<string>();
            foreach (string w in words)
            {
                StringBuilder sb = new StringBuilder();
                foreach (char c in w)
                {
                    sb.Append(code[c - 'a']);
                }
                if (!s.Contains(sb.ToString()))
                    s.Add(sb.ToString());
            }
            return s.Count;
        }

        public string ToLowerCase(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var c in str)
            {
                if (c >= 'A')
                    sb.Append((char)(c - 'A' + 'a'));
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
                return "";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strs[0].Length; i++)
            {
                bool same = true;
                for (int j = 1; j < strs.Length; j++)
                {
                    if (strs[j].Length < i || strs[j][i] != strs[0][i])
                    {
                        same = false;
                        break;
                    }
                }
                if (!same) break;
                sb.Append(strs[0][i]);
            }
            return sb.ToString();
        }
        public int OrdinalOfDate(string date)
        {
            DateTime dt = DateTime.Parse(date);
            return dt.DayOfYear;
        }

        public int CountCharacters(string[] words, string chars)
        {
            int len = 0;
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (var c in chars)
            {
                if (!dic.ContainsKey(c)) dic[c] = 0;
                dic[c]++;
            }
            foreach (var word in words)
            {
                if (CanSpell(dic, word))
                    len += word.Length;
            }
            return len;
        }

        public bool CanSpell(Dictionary<char, int> dic, string word)
        {
            Dictionary<char, int> newDic = new Dictionary<char, int>();
            foreach (var c in word)
            {
                if (!newDic.ContainsKey(c)) newDic[c] = 0;
                newDic[c]++;
            } 
            foreach (var pair in newDic)
            {
                if(!dic.ContainsKey(pair.Key)) return false;
                if (dic[pair.Key] < pair.Value) return false;
            }
            return true;
        }
        public int[] NumSmallerByFrequency(string[] queries, string[] words)
        {
            List<int> result = new List<int>();
            List<int> f1 = new List<int>();
            List<int> f2 = new List<int>();
            foreach (var q in queries)
            {
                int[] cnt = new int[26];
                foreach (char c in q)
                {
                    cnt[c - 'a'] ++;
                }
                for (int i = 0; i < 26; i++)
                {
                    if (cnt[i] != 0)
                    {
                        f1.Add(cnt[i]);
                        break;
                    }
                }
            }
            foreach (var q in words)
            {
                int[] cnt = new int[26];
                foreach (char c in q)
                {
                    cnt[c - 'a']++;
                }
                for (int i = 0; i < 26; i++)
                {
                    if (cnt[i] != 0)
                    {
                        f2.Add(cnt[i]);
                        break;
                    }
                }
            }
            f2.Sort();
            foreach (var cnt in f1)
            {
                int i = 0;
                for (; i < f2.Count; i++)
                {
                    if (f2[i] > cnt)
                    {
                        break;
                    }
                }
                result.Add( f2.Count - i);
            }
            return result.ToArray();
        }

    }
}
