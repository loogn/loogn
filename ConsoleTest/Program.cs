using System.Collections.Generic;

using System.Xml;
using Loogn.DB;
using System;
using Loogn.Common;
namespace ConsoleTest
{
  
    public class Program
    {
        static string mgConn = "server=192.168.18.187:27017;database=papillon;username=pp;password=pp;connect=direct;maxPoolSize=200;connectTimeout=1m;";
        //jjoobb2008


        static void test(string plain)
        {
            var key = "whosydd!";

            Console.WriteLine(plain);
            var str = StringHelper.DESEncrypt(plain, key);
            Console.WriteLine(str);
            Console.WriteLine(StringHelper.DESDecrypt(str, key));

        }
        static void Main(string[] args)
        {
            test("23");
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