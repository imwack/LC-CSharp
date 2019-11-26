using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Solution
{
    public class TrieNode
    {
        public char c;
        public TrieNode[] next;
        public bool isWord; //是否是个单词
        public int count;

        public TrieNode(char ch)
        {
            c = ch;
            next = new TrieNode[26];
        }
    }
    public class Trie
    {
        public TrieNode root;
        /** Initialize your data structure here. */
        public Trie()
        {
            root = new TrieNode(' ');
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            TrieNode cur = root;
            foreach (char c in word)
            {
                int index = c - 'a';
                if (cur.next[index] == null)
                    cur.next[index] = new TrieNode(c);
                cur = cur.next[index];
            }
            if (cur.isWord)
                cur.count++;
            else
            {
                cur.isWord = true;
                cur.count = 1;
            }
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            TrieNode cur = root;
            foreach (char w in word)
            {
                int index = w - 'a';
                if (cur.next[index] == null) return false;
                cur = cur.next[index];
            }
            return cur.isWord;
        }

        public List<string> SearchWithPrefix(string word)
        {
            List<string> result = new List<string>();
            TrieNode cur = root;
            foreach (char w in word)
            {
                int index = w - 'a';
                if (cur.next[index] == null) return result;
                cur = cur.next[index];
            }
            StringBuilder sb = new StringBuilder(word);
            DFSTrie(cur, sb.ToString(), result);
            return result;
        }

        public void DFSTrie(TrieNode t, string str, List<string> result)
        {
            if(result.Count>=3) return;
            if (t.isWord)
            {
                for(int i = 0;i<t.count;i++)
                    result.Add(str);
            }

            for (int i = 0; i < 26; i++)
            {
                if(t.next[i]==null) continue;
                string b = str;
                int c= 'a' + i;
                b += (char) c;


                DFSTrie(t.next[i], b, result);
            }
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            TrieNode cur = root;
            foreach (char w in prefix)
            {
                int index = w - 'a';
                if (cur.next[index] == null) return false;
                cur = cur.next[index];
            }
            return true;
        }

    }
}
