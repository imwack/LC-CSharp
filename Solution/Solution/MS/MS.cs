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


    }
}
