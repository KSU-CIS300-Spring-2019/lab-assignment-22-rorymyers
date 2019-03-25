/*File:TriesWithOneChild.cs
 * Author: ROry Myers
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithOneChild : ITrie
    {

        private bool _Contains;
        private ITrie _Child;
        private char _Label;
        /// <summary>
        /// Constructs new Trie
        /// </summary>
        /// <param name="s"></param>
        /// <param name="hasEmpty"></param>
        public TrieWithOneChild(string s, bool hasEmpty)
        {
            if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            _Contains = hasEmpty;
            _Label = s[0];
            _Child = new TrieWithNoChildren().Add(s.Substring(1));


        }
        /// <summary>
        /// Adds the given string to the trie rooted at this node.
        /// </summary>
        /// <param name="s">The string to add.</param>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _Contains = true;
            }
            else if (s[0] == _Label)
            {
                _Child = _Child.Add(s.Substring(1));
                return this;
            }
            else
            {
                return new TrieWithManyChildren(s, _Contains, _Label, _Child);
            }
            return this;
        }
        /// <summary>
        /// Gets whether the trie rooted at this node contains the given string.
        /// </summary>
        /// <param name="s">The string to look up.</param>
        /// <returns>Whether the trie rooted at this node contains s.</returns>
        public bool Contains(string s)
        {
            if(s == "")
            {
                return _Contains;
            }
            if (s[0] == _Label)
            {
                return _Child.Contains(s.Substring(1));
            }
            else
            {
                return false;
            }
        }
    }
}
