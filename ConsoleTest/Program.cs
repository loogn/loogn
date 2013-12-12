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
using Loogn.Common;
using System.ComponentModel;
using System.Net.Sockets;
namespace ConsoleTest
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
 
    public class Program
    {
        static string mgConn = "server=192.168.18.187:27017;database=papillon;username=pp;password=pp;connect=direct;maxPoolSize=200;connectTimeout=1m;";

        static void Main(string[] args)
        {
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

            List<Person> list=new List<Person> ();
            list.Add(new Person { ID=1, Name="user1", Age=23 });
            list.Add(new Person { ID = 2, Name = "user2", Age = 24 });
            list.Add(new Person { ID = 3, Name = "user3", Age = 23 });
            list.Add(new Person { ID = 4, Name = "user4", Age = 25 });
            list.Add(new Person { ID = 5, Name = "user5", Age = 20 });

            var result = list.MapReduce<Person, int, string, string>(Map, 
                (key, values) => string.Join(",", values));
            
            foreach (var d in result)
            {
                Console.WriteLine(d.Key + ":" + d.Value);
            }
        }

        public static IEnumerable<KeyValuePair<int, string>> Map(Person p)
        {
            if (p.Age > 22)
                yield return new KeyValuePair<int, string>(p.Age, p.Name);
        }
    }
}