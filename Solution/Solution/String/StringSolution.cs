﻿using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}