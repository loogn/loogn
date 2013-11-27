using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using System.Text;
using Loogn.Common;
using MongoDB.Bson;
namespace ConsoleTest
{
    class Program
    {
        static string mgConn = "server=192.168.18.187:27017;database=papillon;username=pp;password=pp;connect=direct;maxPoolSize=200;connectTimeout=1m;";
        static void Main(string[] args)
        {
            var dt = DateTime.Parse("2013-11-26 03:00:00");

            Console.WriteLine(dt.ToUniversalTime().ToString("yyyyMMdd"));

            Console.WriteLine(dt.ToString("yyyyMMdd"));

            
            List<BsonDocument> list = new List<BsonDocument>(280000);
            foreach (var line in File.ReadAllLines(@"e:\treedict.txt"))
            {
                list.Add(new BsonDocument { { "_id", line } });
            }


            MongoClient mc = new MongoClient(mgConn);

            var db = mc.GetServer().GetDatabase("papillon");
            var coll = db.GetCollection("dict");
            coll.InsertBatch(list);
        }
    }
}
