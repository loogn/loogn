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
        public static HashSet<string> Split(string text, Tree dictTree)
        {
            var terms = new HashSet<string>();
            if (string.IsNullOrEmpty(text)) return terms;
            text = text.ToUpperInvariant();
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

        public static void BuildTextDicts(string dictFile, IEnumerable<string> appendWords, IEnumerable<string> removeWords)
        {
            HashSet<string> dicts;
            if (File.Exists(dictFile))
            {
                dicts = new HashSet<string>(File.ReadAllLines(dictFile,Encoding.UTF8));
            }
            else
            {
                dicts = new HashSet<string>();
            }
            if (appendWords != null)
            {
                int appendCount = 0;
                foreach (var appendWord in appendWords)
                {
                    if (dicts.Add(appendWord.ToUpperInvariant()))
                        appendCount++;
                }
                Console.WriteLine("向词库追加加：{0}", appendCount);
            }
            if (removeWords != null)
            {
                int removeCount = 0;
                foreach (var removeWord in removeWords)
                {
                    if (dicts.Remove(removeWord))
                        removeCount++;
                }
                Console.WriteLine("从词库移除：{0}", removeCount);
            }
            File.WriteAllLines(dictFile, dicts.ToArray(), Encoding.UTF8);
        }
        public static void FilterTextDicts(string dictFile, IEnumerable<string> includes)
        {
            HashSet<string> dicts;
            if (File.Exists(dictFile))
            {
                dicts = new HashSet<string>(File.ReadAllLines(dictFile, Encoding.UTF8));
            }
            else
            {
                dicts = new HashSet<string>();
            }

            if (includes != null)
            {

                int removeCount = 0;
                foreach (var include in includes)
                {
                    removeCount += dicts.RemoveWhere((s) =>
                    {
                        return s.IndexOf(include) >= 0;
                    });
                }
                Console.WriteLine("从词库移除：{0}", removeCount);
            }
            File.WriteAllLines(dictFile, dicts.ToArray(), Encoding.UTF8);
        }
    }

}
