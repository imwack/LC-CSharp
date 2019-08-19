using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public partial class MySolution
    {
        //965. Univalued Binary Tree
        public bool IsUnivalTree(TreeNode root, int val)
        {
            if (root == null)
                return true;
            if (root.val != val)
                return false;
            return IsUnivalTree(root.left, val) && IsUnivalTree(root.right, val);

        }
        public bool IsUnivalTree(TreeNode root)
        {
            if (root == null)
                return true;
            return IsUnivalTree(root, root.val);
        }


        //559. Maximum Depth of N-ary Tree
        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node()
            {
            }

            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }

            public int GetDepth(Node root, int h)
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

            public int MaxDepth(Node root)
            {
                if (root == null)
                    return 0;
                return GetDepth(root, 1);
            }
        }

        public IList<IList<int>> LevelOrder(Node root)
        {
            IList<IList<int>> list = new List<IList<int>>();
            Queue<Node> q = new Queue<Node>();
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

        public int SumRootToLeaf(TreeNode root)
        {
            return SumRootToLeaf(root, 0);
        }
        public int SumRootToLeaf(TreeNode root, int sum)
        {
            if (root == null)
            {
                return 0;
            }
            sum = sum * 2 + root.val;
            if (root.left == null && root.right == null) //leaf
            {
                return sum;
            }
            else
            {
                return SumRootToLeaf(root.left, sum) + SumRootToLeaf(root.right, sum);
            }
        }

        //993. Cousins in Binary Tree
        public bool IsCousins(TreeNode root, int x, int y)
        {
            int l = GetHeight(root, x, y, 0);
            if (l == -2)
                return false;
            int r = GetHeight(root, y, x, 0);
            return l == r && l != -1;
        }
        //-1 means not fount -2 means invalid cousin
        public int GetHeight(TreeNode root, int x, int y, int h)
        {
            if (root == null)
            {
                return -1;
            }
            if (root.left != null && root.left.val == x)
            {
                if (root.right != null && root.right.val == y)
                    return -2;
                return h + 1;
            }
            if (root.right != null && root.right.val == x)
            {
                if (root.left != null && root.left.val == y)
                    return -2;
                return h + 1;
            }
            int height = GetHeight(root.left, x, y, h + 1);
            if (height != -1)
                return height;
            return GetHeight(root.right, x, y, h + 1);
        }

        private int minDiff = int.MaxValue;
        private int lastVal = int.MinValue;
        public int MinDiffInBST(TreeNode root)
        {
            BSTDfs(root);
            return minDiff;
        }
        //PreOrder and record last value;
        public void BSTDfs(TreeNode root)
        {
            if (root != null)
            {
                BSTDfs(root.left);
                if (lastVal < root.val)
                {
                    minDiff = Math.Min(minDiff, root.val - lastVal);
                }
                lastVal = root.val;
                //Console.WriteLine(lastVal);
                BSTDfs(root.right);

            }
        }

        public QuadNode Intersect(QuadNode n1, QuadNode n2)
        {
            QuadNode n = new QuadNode();
            if (n1.isLeaf && n2.isLeaf)
            {
                n.isLeaf = true;
                n.val = n1.val || n2.val;
            }
            else if (n1.isLeaf)
            {
                return n1.val ? n1 : n2;
            }
            else if (n2.isLeaf)
            {
                return n2.val ? n2 : n1;
            }
            else
            {
                n.topLeft = Intersect(n1.topLeft, n2.topLeft);
                n.topRight = Intersect(n1.topRight, n2.topRight);
                n.bottomLeft = Intersect(n1.bottomLeft, n2.bottomLeft);
                n.bottomRight = Intersect(n1.bottomRight, n2.bottomRight);
                if (n.topLeft.isLeaf && n.topRight.isLeaf && n.bottomLeft.isLeaf && n.bottomRight.isLeaf &&
                    n.topLeft.val == n.topRight.val && n.topLeft.val == n.bottomLeft.val && n.topLeft.val == n.bottomRight.val)
                {
                    n.isLeaf = true;
                    n.val = n.topLeft.val;
                }

            }
            return n;
        }

        public TreeNode SufficientSubset(TreeNode root, int limit)
        {
            if (root == null)
            {
                return null;
            }
            if (root.left == root.right)
            {
                return root.val >= limit ? root : null;
            }
            if (root.left != null)
            {
                root.left = SufficientSubset(root.left, limit - root.val);
            }
            if (root.right != null)
            {
                root.right = SufficientSubset(root.right, limit - root.val);
            }
            if (root.left == root.right)
            {
                return null;
            }
            return root;
        }
        public bool BtreeGameWinningMove(TreeNode root, int n, int x)
        {
            return true;
        }

        public int lastValue = 0;
        public TreeNode BstToGst(TreeNode root)
        {
            //这道题从最又往左遍历就行了吧，右根左的顺序来遍历 每次加上前一个数就ok了吧
            BstToGstDfs(root);
            return root;
        }

        public void BstToGstDfs(TreeNode root)
        {
            if(root == null)return;
            BstToGstDfs(root.right);
            lastValue += root.val;
            root.val = lastValue;
            BstToGstDfs(root.left);
        }
        public TreeNode BstFromPreorder(int[] preorder)
        {
            return BstFromPreorder(preorder, 0, preorder.Length - 1);
        }

        public TreeNode BstFromPreorder(int[] preorder, int l, int r)
        {
            if (l > r) return null;
            if (l == r) return new TreeNode(preorder[l]);
            TreeNode root = new TreeNode(preorder[l]);
            int rootVal = root.val;
            int i = l;
            for (i = l + 1; i <= r; i++)
            {
                if (preorder[i] > rootVal)
                {
                    break;
                }
            }
            if (i != l + 1) //有左子树
            {
                root.left = BstFromPreorder(preorder, l + 1, i - 1);
            }
            if (i != r || preorder[r] > rootVal)     //有右子树
            {
                root.right = BstFromPreorder(preorder, i, r);
            }
            return root;
        }

        public int MaxLevelSum(TreeNode root)
        {
            if (root == null) return 0;
            int maxVal = root.val, maxLevel = 1;
            int curLevel = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count>0)
            {
                curLevel++;
                int n = queue.Count;
                int sum = 0;
                for (int i = 0; i < n; i++)
                {
                    var front = queue.Dequeue();
                    sum += front.val;
                    if(front.left!=null) queue.Enqueue(front.left);
                    if(front.right!=null) queue.Enqueue(front.right);
                }
                if (sum > maxVal)
                {
                    Console.WriteLine(sum);
                    Console.WriteLine(maxVal);
                    maxVal = sum;
                    maxLevel = curLevel;
                }
            }

            return maxLevel;
        }

        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            return ConstructMaximumBinaryTree(nums, 0, nums.Length - 1);
        }

        private TreeNode ConstructMaximumBinaryTree(int[] nums, int l, int r)
        {
            if (l > r) return null;
            if(l == r) return new TreeNode(nums[l]);
            int max = nums[l];
            int maxIndex = l;
            for (int i = l + 1; i <= r; i++)
            {
                if (nums[i] > max)
                {
                    max = nums[i];
                    maxIndex = i;
                }
            }
            
            TreeNode root = new TreeNode(max);
            root.left = ConstructMaximumBinaryTree(nums, l, maxIndex - 1);
            root.right = ConstructMaximumBinaryTree(nums, maxIndex+1, r);
            return root;
        }
    }
}
