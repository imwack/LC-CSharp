using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public partial class MySolution
    {
        //[8] String to Integer (atoi)
        public int MyAtoi(string str)
        {
            long value = 0;
            bool positive = true;
            str = str.Trim();
            if (str.Length == 0)
            {
                return 0;
            }
            int i = 0;
            if (str[i] == '-' || str[i] == '+')
            {
                positive = str[i] == '+';
                ++i;
            }
            for (; i < str.Length; i++)
            {
                if (str[i] >= '0' && str[i] <= '9')
                {
                    int digit = str[i] - '0';
                    value = value * 10 + digit;
                    if (value > int.MaxValue)
                    {
                        return positive ? int.MaxValue : int.MinValue;
                    }
                }
                else
                {
                    break;
                }
            }
            if (i == 0)
                return 0;
            if (!positive) value = -value;
            return (int)value;
        }

        //[13] Roman to Integer
        /*    I             1
            * V             5
            * X             10
            * L             50
            * C             100
            * D             500
            * M             1000
        */
        public int RomanToInt(string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>
            {
                ['I'] = 1,
                ['V'] = 5,
                ['X'] = 10,
                ['L'] = 50,
                ['C'] = 100,
                ['D'] = 500,
                ['M'] = 1000
            };
            int n = 0;
            for (int i = 0;i<s.Length;i++)
            {
                if (i == s.Length - 1 || dic[s[i]] >= dic[s[i + 1]])
                {
                    n += dic[s[i]];
                }
                else
                {
                    n -= dic[s[i]];
                }
            }
            return n;
        }
    }
}
