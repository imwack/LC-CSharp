using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public partial class MySolution
    {
        //559. Maximum Depth of N-ary Tree
        public class NodeN
        {
            public int val;
            public IList<NodeN> children;

            public NodeN()
            {
            }

            public NodeN(int _val, IList<NodeN> _children)
            {
                val = _val;
                children = _children;
            }

            public int GetDepth(NodeN root, int h)
            {
                if (root == null)
                {
                    return h;
                }
                int maxh = h;
                foreach (var r in root.children)
                {
                    maxh = Math.Max(maxh, GetDepth(r, h + 1));
                }
                return maxh;
            }

            public int MaxDepth(NodeN root)
            {
                if (root == null)
                    return 0;
                return GetDepth(root, 1);
            }
        }
    }
}
