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
            MongoClient mc = new MongoClient(mgConn);
            var db= mc.GetServer().GetDatabase("papillon");
            MongoDB.Driver.GridFS.MongoGridFS fs = new MongoDB.Driver.GridFS.MongoGridFS(db);

            fs.Delete("abc.txt");
            //var stream = fs.Create("abc.txt", new MongoDB.Driver.GridFS.MongoGridFSCreateOptions()
            //{
            //    Aliases = new string[] { "ab", "bc" },
            //    ChunkSize = 1,
            //    UploadDate = DateTime.Now,
            //    Metadata = new BsonDocument { { "m1", 23 }, { "m2", "ab" } },
            //    ContentType = "txt",
            //});
            //var data=Encoding.ASCII.GetBytes("23423423434");
            //stream.Write(data, 0, data.Length);
            //stream.Close();
        }
    }
}
