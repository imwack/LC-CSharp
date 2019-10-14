using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Design
{
    

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
