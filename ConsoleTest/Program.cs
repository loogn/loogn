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

using System.Xml;
namespace ConsoleTest
{
    public class Edge
    {
        public int ID { get; set; }
        public int Length { get; set; }
    }

    public class P
    { 
    
    }
    public class SP : P
    { }

    public class Program
    {
        static string mgConn = "server=192.168.18.187:27017;database=papillon;username=pp;password=pp;connect=direct;maxPoolSize=200;connectTimeout=1m;";
        //jjoobb2008

        public static Dictionary<string, string> GetDictFromXml(string xml)
        {
            
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                dict.Add(node.Name, node.InnerText.Trim());
            }
            return dict;
        }


        static void Main(string[] args)
        {

            var xml = @"<xml><ToUserName><![CDATA[gh_a97acd3e54eb]]></ToUserName>
<FromUserName><![CDATA[o5nvljqxq-J513ZK2ajDW12wIrGA]]></FromUserName>
<CreateTime>1390271120</CreateTime>
<MsgType><![CDATA[event]]></MsgType>
<Event><![CDATA[subscribe]]></Event>
<EventKey><![CDATA[]]></EventKey>
</xml>";

            var dict = GetDictFromXml(xml);

            Console.WriteLine(dict.Count);

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


        }
    }
}