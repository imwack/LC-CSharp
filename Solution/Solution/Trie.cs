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
            cur.isWord = true;
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
