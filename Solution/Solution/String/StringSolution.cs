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

        public string RemoveOuterParentheses(string S)
        {
            StringBuilder sb = new StringBuilder();
            int left = 0;
            bool push = false;
            foreach (char c in S)
            {
                if (push)
                    sb.Append(c);

                if (c == '(')
                {
                    if (left == 0)
                    {
                        push = true;
                    }
                    left++;
                }
                else
                {
                    left--;
                    if (left == 0)
                    {
                        push = false;
                    }
                }
            }
            return sb.ToString();
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
        public char NextGreatestLetter(char[] letters, char target)
        {
            char ret = letters[0]>target? letters[0]: (char)(letters[0]+26);
            for (int i = 1; i < letters.Length; i++)
            {
                if (letters[i] <= target)
                {
                    letters[i] = (char)((int)letters[i] + 26);
                }
                if (letters[i] > target && letters[i] < ret)
                {
                    ret = letters[i];
                }
            }
 
            if (ret > 'z')
            {
                ret = (char) ((int) ret - 26);
            }
            return ret;
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
        public TreeNode SufficientSubset(TreeNode root, int limit)
        {
            if (root == null) return root;
            TreeNode sumTree = new TreeNode(root.val);
            SufficientSubsetDfs(root, sumTree);

            SufficientSubsetDelet(root, root.left, sumTree.left, limit, true);
            SufficientSubsetDelet(root, root.right, sumTree.right, limit, false);
            return root;
        }

        public void SufficientSubsetDelet(TreeNode parent, TreeNode current, TreeNode sumTree, int limit, bool left)
        {
            if (current != null && sumTree.val < limit)
            {
                if (left) parent.left = null;
                else parent.right = null;
            }
        }
        public void SufficientSubsetDfs(TreeNode root, TreeNode sumTree)
        {
            if(root == null)
                return;
            if(root.left!=null)
                sumTree.left =  new TreeNode(root.left.val + root.val);
            if (root.right != null)
                sumTree.right = new TreeNode(root.right.val + root.val);
            SufficientSubsetDfs(root.left, sumTree.left);
            SufficientSubsetDfs(root.right, sumTree.right);
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


    }
}
