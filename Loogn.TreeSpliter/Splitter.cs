using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace Loogn.TreeSpliter
{
    public static class Splitter
    {
        /// <summary>
        /// 请在Appsetting里配置TreeDict
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static HashSet<string> Split(string text)
        {
            return Split(text, Tree.TreeDict);
        }
        public static HashSet<string> Split(string text, string dictPath)
        {
            var dictTree = new Tree(dictPath);
            return Split(text, dictTree);
        }
        public static HashSet<string> Split(string input, Tree dictTree)
        {
            var terms = new HashSet<string>();
            if (string.IsNullOrEmpty(input)) return terms;
            var text = input.ToUpperInvariant();
            var length = text.Length;
            unsafe
            {
                fixed (char* cs = text)
                {
                    int i = 0;
                    char fc;
                    while ((fc = *(cs + i++)) != char.MinValue)
                    {
                        var rootNode = dictTree.GetChildNode(fc, Node.Empty);
                        if (rootNode == null) continue;
                        if (rootNode.End)
                        {
                            var termValue = rootNode.GetTermValue();
                            if (!terms.Contains(termValue))
                            {
                                terms.Add(termValue);
                            }
                        }
                        var parentNode = rootNode;
                        char tc;
                        int j = i;
                        while ((tc = *(cs + j++)) != char.MinValue)
                        {
                            var subNode = dictTree.GetChildNode(tc, parentNode);
                            if (subNode == null) break;
                            if (subNode.End)
                            {
                                var termValue = subNode.GetTermValue();
                                if (!terms.Contains(termValue))
                                {
                                    terms.Add(termValue);
                                }
                            }
                            parentNode = subNode;
                        }
                    }
                }
            }
            return terms;
        }

        
    }
}
