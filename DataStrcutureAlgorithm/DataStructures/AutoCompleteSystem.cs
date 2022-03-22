using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStrcutureAlgorithm.DataStructures
{
    public class AutocompleteSystem
    {
        private AutocompleteNode _trie;
        private IDictionary<string, int> _history;

        private string _sentence;
        private AutocompleteNode _node;

        public AutocompleteSystem(string[] sentences, int[] times)
        {
            _trie = new AutocompleteNode();

            _history = new Dictionary<string, int>();

            _node = _trie;

            _sentence = string.Empty;

            for (int index = 0; index < sentences.Length; index++)
            {
                var sentence = sentences[index];

                var time = times[index];

                _history.Add(sentence, time);

                Insert(_trie, sentence, sentence);
            }
        }

        private void Reset()
        {
            if (_history.ContainsKey(_sentence))
            {
                _history[_sentence]++;
            }
            else
            {
                _history.Add(_sentence, 1);

                Insert(_trie, _sentence, _sentence);
            }

            _sentence = string.Empty;

            _node = _trie;
        }

        public IList<string> Input(char c)
        {
            var list = new List<string>();

            if (c == '#')
            {
                Reset();

                return list;
            }

            _sentence += c;

            if (_node == null)
            {
                return list;
            }

            if (!_node.Children.TryGetValue(c, out _node)) return list;

            return _node.Matches
                .OrderByDescending(match => _history[match])
                .ThenBy(match => match, StringComparer.Ordinal)
                .Take(3)
                .ToList();
        }

        private static void Insert(AutocompleteNode node, string word, string match)
        {
            if (string.IsNullOrEmpty(word)) return;

            if (!node.Children.TryGetValue(word[0], out var child))
            {
                child = new AutocompleteNode(match);

                node.Children.Add(word[0], child);
            }
            else
            {
                child.Matches.Add(match);
            }

            Insert(child, word.Substring(1), match);
        }
    }

    public class AutocompleteNode
    {
        public IDictionary<char, AutocompleteNode> Children;
        public IList<string> Matches;

        public AutocompleteNode() : this(new List<string>()) { }

        public AutocompleteNode(string match) : this(new List<string> { match }) { }

        public AutocompleteNode(IList<string> matches)
        {
            Children = new Dictionary<char, AutocompleteNode>();
            Matches = matches;
        }
    }
}
