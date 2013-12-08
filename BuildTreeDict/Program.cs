using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;

namespace BuildTreeDict
{
    class Program
    {
        static void Main(string[] args)
        {
            var treedict = ConfigurationManager.AppSettings["treedict"];
            var appends = ConfigurationManager.AppSettings["appends"];
            var filters = ConfigurationManager.AppSettings["filters"];


            var appendWords = File.ReadAllLines(appends, Encoding.UTF8);
            var list = new List<string>();
            foreach (var item in appendWords)
            {
                list.AddRange(item.Split(new char[] { '/', '）', '（', '(', ')', '|' }, StringSplitOptions.RemoveEmptyEntries));
            }
            
            var lines = File.ReadAllLines(treedict).Where(s => s.Length <= 1).ToArray();

            Loogn.TreeSpliter.Splitter.BuildTextDicts(treedict, list, File.ReadAllLines(filters, Encoding.UTF8));
            Console.WriteLine("请任意键结束！");
            Console.Read();
        }
    }
}
