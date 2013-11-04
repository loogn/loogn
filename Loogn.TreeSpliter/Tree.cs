﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.Compression;
using System.Text;

namespace Loogn.TreeSpliter
{
    public class Tree : IDisposable
    {
        class CacheInfo : IDisposable
        {
            public string FilePath { get; set; }
            public HashSet<string> Words { get; set; }
            public Dictionary<char, bool> LoadFlag { get; set; }
            public Dictionary<char, Node> Roots { get; set; }
            private FileSystemWatcher fw;
            public CacheInfo(string filePath)
            {
                FilePath = filePath;
                Words = new HashSet<string>();
                Roots = new Dictionary<char, Node>();
                LoadFlag = new Dictionary<char, bool>();

                fw = new FileSystemWatcher(Path.GetDirectoryName(Path.GetFullPath(filePath)), Path.GetFileName(filePath));
                fw.NotifyFilter = NotifyFilters.LastWrite;
                fw.Changed += new FileSystemEventHandler(fw_Changed);
                fw.EnableRaisingEvents = true;

                fw_Changed(this, null);
            }
            void fw_Changed(object sender, FileSystemEventArgs e)
            {
                Words.Clear();
                using (var fs = File.Open(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string word = null;
                        while ((word = sr.ReadLine()) != null)
                        {
                            Words.Add(word);
                        }
                    }
                }
                LoadFlag.Clear();
                Roots.Clear();
                var capitals = Words.Select((line) => { return line[0]; }).Distinct();
                foreach (var cap in capitals)
                {
                    LoadFlag.Add(cap, false);
                }
            }

            #region dispose
            bool isDisposed = false;
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            protected virtual void Dispose(bool disposeing)
            {
                if (isDisposed) return;
                if (disposeing)
                {
                    if (fw != null)
                        fw.Dispose();
                }
                isDisposed = true;
            }
            ~CacheInfo()
            {
                Dispose(false);
            }
            #endregion
        }
        static Dictionary<string, CacheInfo> cacheDict = new Dictionary<string, CacheInfo>();

        public static readonly string TreeDict = System.Configuration.ConfigurationManager.AppSettings["TreeDict"];
        string DictFile;
        public Tree(string dictFile)
        {
            DictFile = dictFile;
            if (!cacheDict.Keys.Contains(dictFile))
            {
                cacheDict.Add(dictFile, new CacheInfo(dictFile));
            }
        }

        public Node GetChildNode(char capital, Node parent)
        {
            Node node = null;
            if (parent.Parent == null)
            {
                return GetRootNode(DictFile, capital);
            }
            else
            {
                parent.Children.TryGetValue(capital, out node);
            }
            return node;
        }

        static Node LoadRootNode(CacheInfo cacheInfo, char capital)
        {
            var rootNode = new Node(capital, Node.Empty);
            cacheInfo.Roots.Add(capital, rootNode);
            cacheInfo.LoadFlag[capital] = true;
            var terms = cacheInfo.Words.Where((word) => { return word[0] == capital; });
            foreach (var term in terms)
            {
                int length = term.Length;
                if (length == 1) //首字也为一个词的情况
                    rootNode.End = true;
                var parentNode = rootNode;
                unsafe
                {
                    fixed (char* cs = term)
                    {
                        int i = 1;
                        char curChar;
                        while ((curChar = *(cs + i)) != char.MinValue)
                        {
                            Node curDictNode = null;
                            if (parentNode.Children.Keys.Contains(curChar))
                            {
                                curDictNode = parentNode.Children[curChar];
                            }
                            else
                            {
                                curDictNode = new Node(curChar, parentNode);
                                parentNode.Children.Add(curChar, curDictNode);
                            }
                            if (i == length - 1) curDictNode.End = true;
                            parentNode = curDictNode;
                            i++;
                        }
                    }
                }
            }
            return rootNode;
        }
        static Node GetRootNode(string dictFile, char capital)
        {
            CacheInfo cacheInfo;
            Node root = null;
            if (cacheDict.TryGetValue(dictFile, out cacheInfo))
            {
                bool flag;
                if (cacheInfo.LoadFlag.TryGetValue(capital, out flag))
                {
                    if (!flag)
                    {
                        root = LoadRootNode(cacheInfo, capital);
                    }
                    else
                    {
                        cacheInfo.Roots.TryGetValue(capital, out root);
                    }
                }
            }
            return root;
        }

        public static void BuildTextDicts(string dictFile, IEnumerable<string> appendWords, IEnumerable<string> removeWords, bool sort = false)
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
            if (removeWords != null)
            {
                int removeCount = 0;
                foreach (var removeWord in removeWords)
                {
                    if (dicts.Remove(removeWord.ToUpperInvariant()))
                        removeCount++;
                }
                Console.WriteLine("从词库移除：{0}", removeCount);
            }
            if (appendWords != null)
            {
                int appendCount = 0;
                foreach (var appendWord in appendWords)
                {
                    if (!string.IsNullOrWhiteSpace(appendWord) && dicts.Add(appendWord.ToUpperInvariant()))
                        appendCount++;
                }
                Console.WriteLine("向词库追加加：{0}", appendCount);
            }

            if (sort)
            {
                List<string> newList = new List<string>(dicts.Count);
                foreach (var item in dicts)
                {
                    newList.Add(item.ToUpperInvariant());
                }
                newList.Sort();
                File.WriteAllLines(dictFile, newList, Encoding.UTF8);
            }
            else
            {
                File.WriteAllLines(dictFile, dicts, Encoding.UTF8);
            }
        }

        #region dispose
        bool isDisposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposeing)
        {
            if (isDisposed) return;
            if (disposeing)
            {
                if (cacheDict != null)
                {
                    foreach (var cacheItem in cacheDict.Values)
                    {
                        cacheItem.Dispose();
                    }
                }
            }
            isDisposed = true;
        }
        ~Tree()
        {
            Dispose(false);
        }
        #endregion
    }
}
