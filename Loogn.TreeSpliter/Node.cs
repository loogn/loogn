using System;
using System.Collections.Generic;

namespace Loogn.TreeSpliter
{
    [Serializable]
    public class Node
    {
        public char Value { get; set; }
        public Node Parent { get; set; }
        public bool End { get; set; }
        public Dictionary<char, Node> Children { get; set; }
        public static Node Empty = new Node(' ', null);
        public Node(char value, Node parent)
        {
            this.Value = value;
            this.Parent = parent;
            Children = new Dictionary<char, Node>();
        }
        public string GetTermValue()
        {
            List<char> chars = new List<char>(10);
            Node node = this;
            while (node.Parent != null)
            {
                chars.Insert(0, node.Value);
                node = node.Parent;
            }
            return new string(chars.ToArray());
        }
    }
}
