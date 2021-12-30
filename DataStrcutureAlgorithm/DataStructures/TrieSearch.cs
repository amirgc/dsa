using System;
using System.Collections.Generic;
using System.Text;

namespace DataStrcutureAlgorithm.DataStructures
{
   

    public class TrieSearch
    {
        public class Trie
        {

            // Node definition of a trie
            public class Node
            {
                public bool isWord { get; set; }
                public List<Node> children { get; set; } = new List<Node>(new Node[26]);
            };

            Node Root, curr;
            List<string> resultBuffer;

            // Runs a DFS on trie starting with given prefix and adds all the words in the resultBuffer, limiting result size to 3
            void dfsWithPrefix(Node curr, String word)
            {
                if (resultBuffer.Count == 3)
                    return;
                if (curr.isWord)
                    resultBuffer.Add(word);

                // Run DFS on all possible paths.
                for (char c = 'a'; 
                    c <= 'z'; c++)
                    if (curr.children[c - 'a'] != null)
                        dfsWithPrefix(curr.children[c - 'a'], word + c);
            }

            public Trie()
            {
                Root = new Node();
            }

            // Inserts the string in trie.
            public void insert(string s)
            {
                // Points curr to the root of trie.
                curr = Root;
                foreach (char c in s)
                {
                    if (curr.children[c - 'a'] == null)
                        curr.children[c - 'a'] = new Node();

                    curr = curr.children[c - 'a'];
                }

                // Mark this node as a completed word.
                curr.isWord = true;
            }
            public List<String> getWordsStartingWith(String prefix)
            {
                curr = Root;
                resultBuffer = new List<String>();
                // Move curr to the end of prefix in its trie representation.
                foreach (char c in prefix)
                {
                    if (curr.children[c - 'a'] == null)
                        return resultBuffer;
                    curr = curr.children[c - 'a'];
                }
                dfsWithPrefix(curr, prefix);
                return resultBuffer;
            }
        };
        public IList<IList<String>> suggestedProducts(String[] products, String searchWord)
        {
            Trie trie = new Trie();
            List<IList<String>> result = new List<IList<String>>();
            // Add all words to trie.
            foreach (var word in products)
                trie.insert(word);
           
            string prefix = "";
            
            foreach (char c in searchWord)
            {
                prefix += c;
                result.Add(trie.getWordsStartingWith(prefix));
            }

            return result;
        }
    };
}
