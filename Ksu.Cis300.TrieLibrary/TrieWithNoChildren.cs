using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    /// <summary>
    /// Implements a Trie with no children
    /// </summary>
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// Whether the Trie also contains the empty string
        /// </summary>
        private bool _hasEmptyString = false;

        /// <summary>
        /// Adds a given string to the Trie
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
                return new TrieWithOneChild(s, _hasEmptyString);
            }
        }

        /// <summary>
        /// Checks if the Trie contains a given string
        /// </summary>
        /// <param name="s">string to be checked for</param>
        /// <returns></returns>
        public bool Contains(string s)
        {
            if (s == "" && _hasEmptyString)
                return true;
            return false;
        }
    }
}
