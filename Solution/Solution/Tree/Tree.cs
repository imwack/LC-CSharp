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

        public IList<IList<int>> LevelOrder(NodeN root)
        {
            IList<IList<int>> list = new List<IList<int>>();
            Queue<NodeN> q = new Queue<NodeN>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                int n = q.Count;
                IList<int> l = new List<int>();
                for (int i = 0; i < n; i++)
                {
                    var node = q.Dequeue();
                    l.Add(node.val);
                    foreach (var child in node.children)
                    {
                        q.Enqueue(child);
                    }
                }
                list.Add(l);
            }
            return list;
        }

        //993. Cousins in Binary Tree
        public bool IsCousins(TreeNode root, int x, int y)
        {
            int l = Dfs(root, x, 0);
            int r = Dfs(root, y, 0);
            if (l == r && l!=-1)
            {
                return true;
            }
            return false;
        }

        public int Dfs(TreeNode root, int x, int d)
        {
            if (root == null)
                return -1;
            if (root.val == x)
                return d;
            int n = Dfs(root.left, x, d + 1);
            if (n != -1)
                return n;
            return Dfs(root.right, x, d + 1);
        }

        public TreeNode IncreasingBST(TreeNode root)
        {
            TreeNode t = new TreeNode(0);
            TreeNode newRoot = t;
            PreOrder(root,ref newRoot);
            return t.right;
        }

        public void PreOrder(TreeNode root,ref TreeNode newRoot)
        {
            if (root != null)
            {
                PreOrder(root.left,ref newRoot);
                newRoot.right = root;
                newRoot.left = null;
                newRoot = newRoot.right;
                PreOrder(root.right,ref newRoot);
            }
        }

        public QuadNode Construct(int[][] grid)
        {
            return ConstructQuad(grid, 0, 0, grid.Length - 1, grid[0].Length);
        }

        private QuadNode ConstructQuad(int[][] grid, int x1, int y1, int x2, int y2)
        {
            //Console.WriteLine($"({x1}, {y1}) ({x2}, {y2})");
            QuadNode root = new QuadNode();
            root.isLeaf = true;
            if (x2 == x1)
            {
                return new QuadNode(grid[x1][y1] == 1, true, null, null, null, null);

            }
            else
            {
                int len = (x2 - x1 + 1) / 2;
                root.topLeft = ConstructQuad(grid, x1, y1, x1 + len - 1, y1 + len - 1);
                root.topRight = ConstructQuad(grid, x1, y1 + len, x1 + len - 1, y2);
                root.bottomLeft = ConstructQuad(grid, x1 + len, y1, x2, y1 + len - 1);
                root.bottomRight = ConstructQuad(grid, x1 + len, y1 + len, x2, y2);
            }
            root.val = (root.topLeft.val && root.topRight.val && root.bottomLeft.val && root.bottomRight.val);
            root.isLeaf = ((root.topLeft.val && root.topRight.val && root.bottomLeft.val && root.bottomRight.val) || (!root.topLeft.val && !root.topRight.val && !root.bottomLeft.val && !root.bottomRight.val)) &&
                   (root.topLeft.isLeaf && root.topRight.isLeaf && root.bottomLeft.isLeaf && root.bottomRight.isLeaf);
            if (root.isLeaf)
            {
                root.topLeft = null;
                root.topRight = null;
                root.bottomLeft = null;
                root.bottomRight = null;
            }

            return root;
        }
    }
}
