using System;
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
    }
}
