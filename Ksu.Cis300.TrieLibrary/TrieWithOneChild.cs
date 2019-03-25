using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    /// <summary>
    /// Implements a Trie with one child
    /// </summary>
    public class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// Whether the Trie also holds the empty string
        /// </summary>
        private bool _hasEmptyString;

        /// <summary>
        /// Child of the Trie
        /// </summary>
        private ITrie _child;

        /// <summary>
        /// Label of the Trie's child
        /// </summary>
        private char _childLabel;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Label of the new Trie</param>
        /// <param name="emptyString">Whether the Trie will hold the empty string</param>
        public TrieWithOneChild(string label, bool emptyString)
        {
            if (label == "" || label[0] < 'a' || label[0] > 'z')
            {
                throw new ArgumentException();
            }

            _hasEmptyString = emptyString;
            _childLabel = label[0];
            _child = new TrieWithNoChildren().Add(label.Substring(1));
        }

        /// <summary>
        /// Adds a new string to the Trie
        /// </summary>
        /// <param name="s">string to be added</param>
        /// <returns></returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _hasEmptyString = true;
                return this;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            else
            {
                if (s[0] == _childLabel)
                {
                    _child = _child.Add(s.Substring(1));
                    return this;
                }
                else
                {
                    return new TrieWithManyChildren(s, _hasEmptyString, _childLabel, _child);
                }
            }
        }

        /// <summary>
        /// Checks if the Trie contains a given string
        /// </summary>
        /// <param name="s">string to be checked for</param>
        /// <returns></returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _hasEmptyString;
            }
            else if (s[0] == _childLabel)
            {
                return _child.Contains(s.Substring(1));
            }
            else
            {
                return false;
            }
        }
    }
}
