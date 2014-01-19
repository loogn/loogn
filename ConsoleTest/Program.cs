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
using Loogn.Common.Aspect;
using System.ComponentModel;
using System.Net.Sockets;
using Loogn.WeiXinSDK;
namespace ConsoleTest
{
    public class Edge
    {
        public int ID { get; set; }
        public int Length { get; set; }
    }

    public class Program
    {
        static string mgConn = "server=192.168.18.187:27017;database=papillon;username=pp;password=pp;connect=direct;maxPoolSize=200;connectTimeout=1m;";
        //jjoobb2008

        static void Main(string[] args)
        {
            WeiXin.ConfigGlobalCredential("wx344ac22d559aec2b", "08e16d4561df55dd770f0a56d0f08a60");

            var qrcode = WeiXin.CreateQRCode(true, 23);
            if (qrcode.error == null)
            {
                //返回错误，可以用qrcode.error查看错误消息
            }
            else
            { 
                //返回正确，可以操作qrcode.ticket
            }
            /*{
    "group": {
        "id": 107, 
        "name": "test"
    }
}*/



            return;

            #region Mongo ReplicaSet
            //MongoClientSettings set = new MongoClientSettings();
            //List<MongoServerAddress> servers = new List<MongoServerAddress>();
            //servers.Add(new MongoServerAddress("127.0.0.1", 27016));
            //servers.Add(new MongoServerAddress("127.0.0.1", 27017));
            //servers.Add(new MongoServerAddress("127.0.0.1", 27018));
            //servers.Add(new MongoServerAddress("127.0.0.1", 27019));
            //set.Servers = servers;
            //List<MongoCredential> creds = new List<MongoCredential>();
            //creds.Add(MongoCredential.CreateMongoCRCredential("admin", "sa", "sa"));
            //set.Credentials = creds;

            //set.ReplicaSetName = "jobset";
            //set.ReadPreference = new ReadPreference(ReadPreferenceMode.PrimaryPreferred);
            //set.ConnectTimeout = TimeSpan.FromSeconds(30);

            //MongoClient client = new MongoClient(set);
            //MongoServer server = client.GetServer();
            //MongoDatabase db = server.GetDatabase("test");
            //MongoCollection coll = db.GetCollection("t2");

            //BsonDocument bdoc = new BsonDocument();
            //bdoc.Add("name", "ping");
            //bdoc.Add("age", 23);
            //bdoc.Add("sex", "女");

            //coll.Insert(bdoc);
            ////读取
            //QueryDocument qd = new QueryDocument();
            //qd.Add("name", "ping");
            //BsonDocument rd = coll.FindOneAs<BsonDocument>(qd);
            //Console.WriteLine(rd.ToString());
            #endregion

            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("1", 1);
            dict.Add("2", 2);
            List<string> keys = new List<string>();
            foreach (var kv in dict)
            {
                if (kv.Value == 1)
                {
                    keys.Add(kv.Key);
                }
            }
            foreach (var key in keys)
            {
                dict.Remove(key);
            }
            Console.WriteLine(dict.Count);

        }
    }
}